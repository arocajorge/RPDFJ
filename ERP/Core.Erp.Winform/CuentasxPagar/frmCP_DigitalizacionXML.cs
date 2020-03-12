using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Core.Erp.Business.General;
using Core.Erp.Info.General;
using System.IO;
using Core.Erp.Business.CuentasxPagar;
using System.Diagnostics;
using Core.Erp.Info.CuentasxPagar;
using System.Xml.Linq;
using System.Xml;
using Core.Erp.Business.Contabilidad;
using Core.Erp.Info.Contabilidad;
using Core.Erp.Business.Contabilidad_Fj;
using Core.Erp.Info.Contabilidad_Fj;
using Core.Erp.Business.Caja;
using Core.Erp.Business.Bancos;
using Core.Erp.Business.Facturacion;

namespace Core.Erp.Winform.CuentasxPagar
{
    public partial class frmCP_DigitalizacionXML : Form
    {
        #region Variables
        cl_parametrosGenerales_Bus param = cl_parametrosGenerales_Bus.Instance;
        cp_RutaPorEmpresaPorUsuario_Bus bus_ruta;
        BindingList<cp_XML_Documento_Info> blst;
        cp_XML_Documento_Bus bus_xml;
        tb_sis_impuesto_Bus bus_impuesto;
        cp_proveedor_codigo_SRI_Bus bus_codigoProveedor;
        List<cp_proveedor_codigo_SRI_Info> ListaCodigoProveedor;
        ct_punto_cargo_Bus busPuntoCargo;
        List<ct_punto_cargo_Info> lstPuntoCargo;
        ba_TipoFlujo_Bus busTipoFlujo;
        caj_Caja_Movimiento_Tipo_Bus busTipoMovimiento;
        fa_formaPago_Bus busFormaPago;
        #endregion

        public frmCP_DigitalizacionXML()
        {
            InitializeComponent();
            bus_ruta = new cp_RutaPorEmpresaPorUsuario_Bus();
            blst = new BindingList<cp_XML_Documento_Info>();
            bus_xml = new cp_XML_Documento_Bus();
            bus_impuesto = new tb_sis_impuesto_Bus();
            bus_codigoProveedor = new cp_proveedor_codigo_SRI_Bus();
            ListaCodigoProveedor = new List<cp_proveedor_codigo_SRI_Info>();
            busPuntoCargo = new ct_punto_cargo_Bus();
            lstPuntoCargo = new List<ct_punto_cargo_Info>();
            busTipoFlujo = new ba_TipoFlujo_Bus();
            busTipoMovimiento = new caj_Caja_Movimiento_Tipo_Bus();
            busFormaPago = new fa_formaPago_Bus();
        }

        private void txtRutaXml_Click(object sender, EventArgs e)
        {
            try
            {
                FolderBrowserDialog folder = new FolderBrowserDialog();
                folder.Reset();
                folder.Description = " Seleccionar una carpeta ";
                folder.SelectedPath = txtRutaXml.Text;

                folder.ShowNewFolderButton = false;
                DialogResult ret = new DialogResult();
                ret = folder.ShowDialog();
                txtRutaXml.Text = folder.SelectedPath + @"\";
                folder.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, param.Nombre_sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }

        private void btnVerificarCarpeta_Click(object sender, EventArgs e)
        {
            try
            {
                bus_ruta.GuardarDB(new cp_RutaPorEmpresaPorUsuario_Info
                {
                    IdEmpresa = param.IdEmpresa,
                    IdUsuario = param.IdUsuario,
                    RutaXML = txtRutaXml.Text
                });

                blst = new BindingList<cp_XML_Documento_Info>();
                string folder = txtRutaXml.Text;
                string filter = "*.XML*";
                string[] files = Directory.GetFiles(folder, filter);

                foreach (var item in files)
                {
                    string readText = File.ReadAllText(item);
                    XmlDocument xmlComprobanteOrigen = new XmlDocument();
                    xmlComprobanteOrigen.Load(new StringReader(readText));
                    string mensajeErrorOut = string.Empty;
                    string sXml_a_descerializar = Quitar_a_xml_CDATA_y_Signature(xmlComprobanteOrigen.GetElementsByTagName("comprobante")[0].InnerXml, ref mensajeErrorOut);

                    var rootElement = XElement.Parse(sXml_a_descerializar);
                    var infoFactura = rootElement.Element("infoFactura");
                    var infoTributaria = rootElement.Element("infoTributaria");
                    var IdentificacionComprador = infoFactura.Element("identificacionComprador").Value;

                    if (IdentificacionComprador == param.InfoEmpresa.em_ruc)
                    {
                        var Documento = new cp_XML_Documento_Info
                        {
                            XML = sXml_a_descerializar,
                            Tipo = infoTributaria.Element("codDoc").Value == "01" ? "FACTURA" : "NOTA DE CREDITO",
                            emi_Ruc = infoTributaria.Element("ruc").Value,
                            emi_RazonSocial = infoTributaria.Element("razonSocial").Value,
                            emi_NombreComercial = infoTributaria.Element("nombreComercial") == null ? infoTributaria.Element("razonSocial").Value : infoTributaria.Element("nombreComercial").Value,
                            ClaveAcceso = infoTributaria.Element("claveAcceso").Value,
                            emi_ContribuyenteEspecial = infoFactura.Element("contribuyenteEspecial") == null ?  "NO" : infoFactura.Element("contribuyenteEspecial").Value,
                            CodDocumento = infoTributaria.Element("codDoc").Value,
                            Establecimiento = infoTributaria.Element("estab").Value,
                            PuntoEmision = infoTributaria.Element("ptoEmi").Value,
                            NumeroDocumento = infoTributaria.Element("secuencial").Value,
                            emi_DireccionMatriz = infoTributaria.Element("dirMatriz").Value,


                            FechaEmision = DateTime.ParseExact(infoFactura.Element("fechaEmision").Value, "dd/MM/yyyy",System.Globalization.CultureInfo.CurrentCulture),
                            rec_RazonSocial = infoFactura.Element("razonSocialComprador").Value,
                            rec_Identificacion = infoFactura.Element("identificacionComprador").Value    
                        };
                        Documento.FormaPago = infoFactura.Element("pagos") == null ? null : infoFactura.Element("pagos").Element("pago") == null ? null : (infoFactura.Element("pagos").Element("pago").Element("formaPago") == null ? null : infoFactura.Element("pagos").Element("pago").Element("formaPago").Value);
                        Documento.Plazo = infoFactura.Element("pagos") == null ? 0 : infoFactura.Element("pagos").Element("pago") == null ? 0 : (infoFactura.Element("pagos").Element("pago").Element("plazo") == null ? 0 : Convert.ToInt32(Convert.ToDecimal(infoFactura.Element("pagos").Element("pago").Element("plazo").Value)));

                        var list = infoFactura.Element("totalConImpuestos").Elements("totalImpuesto")
                           .Select(element => element)
                           .ToList();
                        Documento.SubtotalIVA = 0;
                        Documento.Subtotal0 = 0;
                        Documento.ValorIVA = 0;

                        foreach (var Impuesto in list)
                        {
                            if (Impuesto.Element("codigo").Value.ToString() != "3")
                            {
                                Documento.Porcentaje = Convert.ToDouble(Impuesto.Element("valor").Value);

                                if (Documento.Porcentaje == 0)
                                {
                                    Documento.Descuento += Impuesto.Element("descuentoAdicional") == null ? 0 : Convert.ToDouble(Impuesto.Element("descuentoAdicional").Value);
                                    Documento.Subtotal0 += Convert.ToDouble(Impuesto.Element("baseImponible").Value) - Documento.Descuento;
                                }
                                else
                                {
                                    Documento.Descuento += Impuesto.Element("descuentoAdicional") == null ? 0 : Convert.ToDouble(Impuesto.Element("descuentoAdicional").Value);
                                    Documento.SubtotalIVA += Convert.ToDouble(Impuesto.Element("baseImponible").Value) - Documento.Descuento;
                                    Documento.ValorIVA += Convert.ToDouble(Impuesto.Element("valor").Value);
                                    Documento.Porcentaje = bus_impuesto.Get_Info_impuesto(param.Get_Parametro_Info(tb_parametro_enum.P_IVA).Valor).porcentaje;
                                }    
                            }
                        }
                        Documento.Total = Documento.Subtotal0 + Documento.SubtotalIVA + Documento.ValorIVA;
                        double ValorIva = Math.Round((double)Documento.SubtotalIVA * 0.12,2,MidpointRounding.AwayFromZero);
                        if (ValorIva != Documento.ValorIVA)
                        {
                            MessageBox.Show("Revisar: \n"+ item+"\nIVA no cuadra con el subtotal con IVA :\nIVA calculado: " + ValorIva.ToString("c2") + "\nIVA en factura: " + Convert.ToDouble(Documento.ValorIVA).ToString("c2"));
                        }
                        Documento.Comprobante = Documento.CodDocumento + '-' + Documento.Establecimiento + "-" + Documento.PuntoEmision + "-" + Documento.NumeroDocumento;

                        var listD = rootElement.Element("detalles").Elements("detalle")
                           .Select(element => element)
                           .ToList();

                        Documento.lstDetalle = new List<cp_XML_DocumentoDet_Info>();
                        foreach (var Detalle in listD)
                        {
                            var d = new cp_XML_DocumentoDet_Info
                            {
                                NombreProducto = Detalle.Element("descripcion").Value.ToString(),
                                Cantidad = Convert.ToDouble(Detalle.Element("cantidad").Value),
                                Precio = Convert.ToDouble(Detalle.Element("precioTotalSinImpuesto").Value)  
                            };

                            var ImpuestoD = Detalle.Element("impuestos").Elements("impuesto")
                           .Select(element => element)
                           .FirstOrDefault();

                            d.PorcentajeIVA = Convert.ToDouble(ImpuestoD.Element("tarifa").Value);
                            d.ValorIva = Convert.ToDouble(ImpuestoD.Element("valor").Value);
                            d.Total = d.Precio + d.ValorIva;
                            Documento.lstDetalle.Add(d);
                        }
                        /*
                        Documento.SubtotalIVA = Documento.lstDetalle.Where(q=> q.PorcentajeIVA > 0).Sum(q=> q.Precio);
                        Documento.Subtotal0 = Documento.lstDetalle.Where(q=> q.PorcentajeIVA == 0).Sum(q=> q.Precio);
                        Documento.ValorIVA = Documento.lstDetalle.Sum(q => q.ValorIva);
                        Documento.Total = Documento.lstDetalle.Sum(q => q.Total);
                        */

                        if (Documento.Total == 0)
                        {
                            Documento.Descuento = infoFactura.Element("totalDescuento") == null ? 0 : Convert.ToDouble(infoFactura.Element("totalDescuento").Value);
                            Documento.Subtotal0 = Convert.ToDouble(infoFactura.Element("totalSinImpuestos").Value) - Documento.Descuento;
                            Documento.Total = Documento.Subtotal0; 
                        }

                        var listAdicional = rootElement.Element("infoAdicional").Elements("campoAdicional")
                          .Select(element => element).ToList();
                        if (listAdicional.Count > 0)
                        {
                            var Kilometraje = listAdicional.Where(x => (string)x.Attribute("nombre") == "kilometraje").FirstOrDefault();
                            var Placa = listAdicional.Where(x => (string)x.Attribute("nombre") == "placa").FirstOrDefault();
                            var Disco = listAdicional.Where(x => (string)x.Attribute("nombre") == "disco").FirstOrDefault();

                            if (Kilometraje != null && Placa != null && Disco != null)
                            {
                                Documento.Observacion = (Documento.lstDetalle.Count > 0 ? Documento.lstDetalle.First().NombreProducto : "") +"-km" + Kilometraje.Value.ToString() + "-D" + Disco.Value.ToString() + "-" + Placa.Value.ToString() + "-";
                                int numValue = 0;
                                if (Int32.TryParse(Disco.Value.ToString(), out numValue))
                                {
                                    var PuntoCargo = lstPuntoCargo.Where(q => q.codPunto_cargo == "DISCO " + Convert.ToInt32(Disco.Value).ToString()).FirstOrDefault();
                                    if (PuntoCargo != null)
                                    {
                                        Documento.IdPunto_cargo = PuntoCargo.IdPunto_cargo;
                                        Documento.IdCentroCosto = PuntoCargo.IdCentroCosto_Scc;
                                        Documento.IdCentroCosto_sub_centro_costo = PuntoCargo.IdCentroCosto_sub_centro_costo_Scc;
                                    }
                                }
                            }    
                        }
                        
                        Documento.Imagen = bus_xml.Existe(param.IdEmpresa, Documento.emi_Ruc, Documento.CodDocumento, Documento.Establecimiento, Documento.PuntoEmision, Documento.NumeroDocumento);
                        Documento.lstRetencion = new List<cp_XML_Documento_Retencion_Info>();
                        if (ListaCodigoProveedor.Where(q => q.IdEmpresa == param.IdEmpresa && q.pe_cedulRuc == Documento.emi_Ruc).Count() == 0)
                        {
                            var ListaDet = bus_codigoProveedor.GetList(param.IdEmpresa, Documento.emi_Ruc);
                            if (ListaDet.Count > 0)
                            {
                                Documento.Automatico = true;
                                Documento.lstRetencion = new List<cp_XML_Documento_Retencion_Info>();
                                var lstDup = ListaDet.GroupBy(q => q.re_tipo).Select(q => new
                                {
                                    re_tipo = q.Key,
                                    Contador = q.Count()
                                }).ToList();
                                if (lstDup.Where(q => q.Contador > 1).Count() > 0 && Documento.Imagen == 1)
                                {
                                    foreach (var Detalle in ListaDet)
                                    {
                                        Documento.lstRetencion.Add(new cp_XML_Documento_Retencion_Info
                                        {
                                            re_tipoRet = Detalle.re_tipo,
                                            re_baseRetencion = Math.Round(Convert.ToDouble(Detalle.re_tipo == "IVA" ? Documento.ValorIVA : (Documento.Subtotal0 + Documento.SubtotalIVA)), 2, MidpointRounding.AwayFromZero),
                                            IdCodigo_SRI = Detalle.IdCodigo_SRI,
                                            re_Codigo_impuesto = Detalle.re_Codigo_impuesto,
                                            re_Porcen_retencion = Detalle.re_Porcen_retencion,
                                            re_valor_retencion = Math.Round(Math.Round(Convert.ToDouble(Detalle.re_tipo == "IVA" ? Documento.ValorIVA : (Documento.Subtotal0 + Documento.SubtotalIVA)), 2, MidpointRounding.AwayFromZero) * (Detalle.re_Porcen_retencion / 100), 2, MidpointRounding.AwayFromZero)
                                        });
                                    }

                                    frmCP_XML_RetencionSubida frmRet = new frmCP_XML_RetencionSubida();
                                    frmRet.info = Documento;
                                    frmRet.ShowDialog();
                                    Documento = frmRet.info;
                                }
                                ListaCodigoProveedor.AddRange(ListaDet);
                            }
                        }
                        else
                        {
                            var ListaDet = ListaCodigoProveedor.Where(q => q.IdEmpresa == param.IdEmpresa && q.pe_cedulRuc == Documento.emi_Ruc).ToList();
                            var lstDup = ListaDet.GroupBy(q => q.re_tipo).Select(q => new
                            {
                                re_tipo = q.Key,
                                Contador = q.Count()
                            }).ToList();
                            if (lstDup.Where(q => q.Contador > 1).Count() > 0 && Documento.Imagen == 1)
                            {
                                foreach (var Detalle in ListaDet)
                                {
                                    Documento.lstRetencion.Add(new cp_XML_Documento_Retencion_Info
                                    {
                                        re_tipoRet = Detalle.re_tipo,
                                        re_baseRetencion = Math.Round(Convert.ToDouble(Detalle.re_tipo == "IVA" ? Documento.ValorIVA : (Documento.Subtotal0 + Documento.SubtotalIVA)), 2, MidpointRounding.AwayFromZero),
                                        IdCodigo_SRI = Detalle.IdCodigo_SRI,
                                        re_Codigo_impuesto = Detalle.re_Codigo_impuesto,
                                        re_Porcen_retencion = Detalle.re_Porcen_retencion,
                                        re_valor_retencion = Math.Round(Math.Round(Convert.ToDouble(Detalle.re_tipo == "IVA" ? Documento.ValorIVA : (Documento.Subtotal0 + Documento.SubtotalIVA)), 2, MidpointRounding.AwayFromZero) * (Detalle.re_Porcen_retencion / 100), 2, MidpointRounding.AwayFromZero)
                                    });
                                }

                                frmCP_XML_RetencionSubida frmRet = new frmCP_XML_RetencionSubida();
                                frmRet.info = Documento;
                                frmRet.ShowDialog();
                                Documento = frmRet.info;
                            }
                            Documento.Automatico = true;
                        }
                        if(blst.Where(q=> q.Comprobante == Documento.Comprobante && q.emi_Ruc == Documento.emi_Ruc).Count() == 0)
                            blst.Add(Documento);
                        gcDetalle.DataSource = null;
                        gcDetalle.DataSource = blst;
                    }
                }
                lblContador.Text = blst.Count.ToString();
                gcDetalle.DataSource = blst;
            }
            catch (Exception ex)
            {
                gcDetalle.DataSource = blst;
                lblContador.Text = blst.Count.ToString();
                MessageBox.Show(ex.Message, param.Nombre_sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public string Quitar_a_xml_CDATA_y_Signature(string InnerXml_Cbte, ref string msgError)
        {
            try
            {

                string sXml_a_descerializar = InnerXml_Cbte;
                string sValor_a_Reemplezar_cdata = "<![CDATA[";

                sXml_a_descerializar = sXml_a_descerializar.Replace(sValor_a_Reemplezar_cdata, "");
                sValor_a_Reemplezar_cdata = "]]>";
                sXml_a_descerializar = sXml_a_descerializar.Replace(sValor_a_Reemplezar_cdata, "");

                XmlDocument xml_valido = new System.Xml.XmlDocument();
                xml_valido.LoadXml(sXml_a_descerializar);

                // removiendo los datos de la firma 
                XmlNodeList nodeFirma = xml_valido.GetElementsByTagName("ds:Signature");
                nodeFirma.Item(0).RemoveAll();

                string valorareem = "<ds:Signature xmlns:ds=\"http://www.w3.org/2000/09/xmldsig#\"></ds:Signature>";

                sXml_a_descerializar = xml_valido.InnerXml;
                sXml_a_descerializar = sXml_a_descerializar.Replace(valorareem, "");


                return sXml_a_descerializar;

            }
            catch (Exception ex)
            {
                msgError = ex.Message;
                return "";
            }
        }

        private void frmCP_DigitalizacionXML_Load(object sender, EventArgs e)
        {
            try
            {
                var Ruta = bus_ruta.GetInfo(param.IdEmpresa, param.IdUsuario);
                txtRutaXml.Text = Ruta == null ? Environment.GetFolderPath(Environment.SpecialFolder.Desktop) : Ruta.RutaXML;
                CargarCombos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, param.Nombre_sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            gcDetalle.ShowPrintPreview();
        }

        private void btnDigitalizar_Click(object sender, EventArgs e)
        {
            try
            {
                txtRutaXml.Focus();
                gvDetalle.MoveNext();

                tb_sis_Documento_Tipo_Talonario_Bus busTalonario = new tb_sis_Documento_Tipo_Talonario_Bus();
                var Talonario = busTalonario.GetInfoRetElectronico(param.IdEmpresa);
                if (Talonario == null)
                {
                    MessageBox.Show("Para crear retenciones automáticas el sistema necesita un talonario electrónico",param.Nombre_sistema,MessageBoxButtons.OK);
                    return;
                }
                bool GenerarXML = true;
                foreach (var item in blst)
                {
                    item.IdEmpresa = param.IdEmpresa;

                    if (item.Tipo == "FACTURA")
                    {
                        item.ret_Establecimiento = param.InfoSucursal.Su_CodigoEstablecimiento;
                        item.ret_PuntoEmision = Talonario.PuntoEmision;
                        if (item.lstRetencion == null || item.lstRetencion.Count == 0)
                        {
                            item.lstRetencion = new List<cp_XML_Documento_Retencion_Info>();
                            var lstDet = ListaCodigoProveedor.Where(q => q.pe_cedulRuc == item.emi_Ruc).ToList();
                            if (lstDet.Count > 0)
                            {
                                foreach (var Detalle in lstDet)
                                {
                                    item.lstRetencion.Add(new cp_XML_Documento_Retencion_Info
                                    {
                                        re_tipoRet = Detalle.re_tipo,
                                        re_baseRetencion = Math.Round(Convert.ToDouble(Detalle.re_tipo == "IVA" ? item.ValorIVA : (item.Subtotal0 + item.SubtotalIVA)), 2, MidpointRounding.AwayFromZero),
                                        IdCodigo_SRI = Detalle.IdCodigo_SRI,
                                        re_Codigo_impuesto = Detalle.re_Codigo_impuesto,
                                        re_Porcen_retencion = Detalle.re_Porcen_retencion,
                                        re_valor_retencion = Math.Round(Math.Round(Convert.ToDouble(Detalle.re_tipo == "IVA" ? item.ValorIVA : (item.Subtotal0 + item.SubtotalIVA)), 2, MidpointRounding.AwayFromZero) * (Detalle.re_Porcen_retencion / 100), 2, MidpointRounding.AwayFromZero)
                                    });
                                }
                            }
                            else
                            {

                                var ListaDet = bus_codigoProveedor.GetList(param.IdEmpresa, item.emi_Ruc);
                                if (ListaDet.Count > 0)
                                {
                                    ListaCodigoProveedor.AddRange(ListaDet);
                                    foreach (var Detalle in ListaDet)
                                    {
                                        item.lstRetencion.Add(new cp_XML_Documento_Retencion_Info
                                        {
                                            re_tipoRet = Detalle.re_tipo,
                                            re_baseRetencion = Math.Round(Convert.ToDouble(Detalle.re_tipo == "IVA" ? item.ValorIVA : (item.Subtotal0 + item.SubtotalIVA)), 2, MidpointRounding.AwayFromZero),
                                            IdCodigo_SRI = Detalle.IdCodigo_SRI,
                                            re_Codigo_impuesto = Detalle.re_Codigo_impuesto,
                                            re_Porcen_retencion = Detalle.re_Porcen_retencion,
                                            re_valor_retencion = Math.Round(Math.Round(Convert.ToDouble(Detalle.re_tipo == "IVA" ? item.ValorIVA : (item.Subtotal0 + item.SubtotalIVA)), 2, MidpointRounding.AwayFromZero) * (Detalle.re_Porcen_retencion / 100), 2, MidpointRounding.AwayFromZero)
                                        });
                                    }
                                }
                            }    
                        }
                    }
                    item.IdUsuario = param.IdUsuario;
                    if (bus_xml.GuardarDB(item, ref GenerarXML))
                    {
                        string MensajeError = string.Empty;
                        if (GenerarXML && !bus_xml.Generacion_xml_SRI(item.IdEmpresa, item.IdDocumento, ref MensajeError))
                        {
                            MessageBox.Show("No se ha podido generar el XML de la retención del documento "+ item.Comprobante+" de "+item.RazonSocial, param.Nombre_sistema, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);                
                        }
                    }
                    item.Imagen = 2;
                }
                gcDetalle.Refresh();
                gcDetalle.RefreshDataSource();
                gcDetalle.DataSource = blst;
                MessageBox.Show("Registros digitalizados exitósamente",param.Nombre_sistema,MessageBoxButtons.OK,MessageBoxIcon.Asterisk);                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, param.Nombre_sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);                
            }
        }

        private void CargarCombos()
        {
            try
            {
                string mensaje = "";
                lstPuntoCargo = busPuntoCargo.Get_List_punto_Cargo_con_subcentro(param.IdEmpresa);
                cmbPuntoCargo.DataSource = lstPuntoCargo;

                var lstTipoMovimiento = busTipoMovimiento.Get_list_Caja_Movimiento_Tipo(param.IdEmpresa,Cl_Enumeradores.eTipo_Ing_Egr.EGRESOS, ref mensaje);
                cmbTipoMovimiento.DataSource = lstTipoMovimiento;

                var lstTipoFlujo = busTipoFlujo.Get_List_TipoFlujo(param.IdEmpresa);
                cmbTipoFlujo.DataSource = lstTipoFlujo;

                var lstFormaPago = busFormaPago.Get_List_fa_formaPago();
                cmbFormaPago.DataSource = lstFormaPago;
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        private void gvDetalle_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                cp_XML_Documento_Info row = (cp_XML_Documento_Info)gvDetalle.GetRow(e.RowHandle);
                if (row == null)
                    return;

                if (e.Column == ColIdPuntoCargo)
                {
                    var PuntoCargo = lstPuntoCargo.Where(q => q.IdPunto_cargo == row.IdPunto_cargo).FirstOrDefault();
                    if (PuntoCargo != null)
                    {
                        row.IdCentroCosto = PuntoCargo.IdCentroCosto_Scc;
                        row.IdCentroCosto_sub_centro_costo = PuntoCargo.IdCentroCosto_sub_centro_costo_Scc;
                    }
                    else
                    {
                        row.IdCentroCosto = null;
                        row.IdCentroCosto_sub_centro_costo = null;
                    }
                }
            }
            catch (Exception)
            {
                
                throw;
            }
        }

    }
}
