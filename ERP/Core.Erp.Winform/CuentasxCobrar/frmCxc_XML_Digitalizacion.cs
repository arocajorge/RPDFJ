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
using Core.Erp.Business.CuentasxPagar;
using Core.Erp.Info.CuentasxPagar;
using System.Xml;
using Core.Erp.Info.CuentasxCobrar;
using System.IO;
using System.Xml.Linq;
using Core.Erp.Business.CuentasxCobrar;
using Core.Erp.Business.Facturacion;
using Core.Erp.Info.Facturacion;

namespace Core.Erp.Winform.CuentasxCobrar
{
    public partial class frmCxc_XML_Digitalizacion : Form
    {

        #region Variables
        cl_parametrosGenerales_Bus param = cl_parametrosGenerales_Bus.Instance;
        cp_RutaPorEmpresaPorUsuario_Bus bus_ruta;
        BindingList<cxc_XML_Documento_Info> blst;
        List<cxc_cobro_tipo_Info> ListaTipoCobro;
        cxc_cobro_tipo_Bus busTipoCobro;
        cxc_XML_DocumentoDet_Bus busDet;
        fa_Cliente_Bus busCliente;
        List<fa_Cliente_Info> ListaCliente;
        cxc_XML_Documento_Bus busXML;
        #endregion

        #region Delegados
        public delegate void delegate_frmCxc_XML_Digitalizacion_FormClosed(object sender, FormClosedEventArgs e);
        public event delegate_frmCxc_XML_Digitalizacion_FormClosed event_delegate_frmCxc_XML_Digitalizacion_FormClosed;
        void frmCxc_XML_Digitalizacion_event_delegate_frmCxc_XML_Digitalizacion_FormClosed(object sender, FormClosedEventArgs e)
        {

        }
        private void frmCxc_XML_Digitalizacion_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                event_delegate_frmCxc_XML_Digitalizacion_FormClosed(sender, e);
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region Constructor
        public frmCxc_XML_Digitalizacion()
        {
            InitializeComponent();
            event_delegate_frmCxc_XML_Digitalizacion_FormClosed += frmCxc_XML_Digitalizacion_event_delegate_frmCxc_XML_Digitalizacion_FormClosed;
            bus_ruta = new cp_RutaPorEmpresaPorUsuario_Bus();
            blst = new BindingList<cxc_XML_Documento_Info>();
            ListaTipoCobro = new List<cxc_cobro_tipo_Info>();
            busTipoCobro = new cxc_cobro_tipo_Bus();
            busDet = new cxc_XML_DocumentoDet_Bus();
            busCliente = new fa_Cliente_Bus();
            ListaCliente = new List<fa_Cliente_Info>();
            busXML = new cxc_XML_Documento_Bus();
        }
        #endregion

        #region Eventos
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void frmCxc_XML_Digitalizacion_Load(object sender, EventArgs e)
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

                blst = new BindingList<cxc_XML_Documento_Info>();
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
                    var infoFactura = rootElement.Element("infoCompRetencion");
                    var infoTributaria = rootElement.Element("infoTributaria");
                    var IdentificacionComprador = infoFactura.Element("identificacionSujetoRetenido").Value;

                    if (IdentificacionComprador == param.InfoEmpresa.em_ruc)
                    {
                        #region Cabecera
                        var Documento = new cxc_XML_Documento_Info();
                        Documento.IdEmpresa = param.IdEmpresa;
                        Documento.XML = sXml_a_descerializar;
                        Documento.Tipo = infoTributaria.Element("codDoc").Value == "07" ? "RETENCION" : "";
                        Documento.emi_Ruc = infoTributaria.Element("ruc").Value;
                        Documento.emi_RazonSocial = infoTributaria.Element("razonSocial").Value;
                        Documento.emi_NombreComercial = infoTributaria.Element("nombreComercial") == null ? infoTributaria.Element("razonSocial").Value : infoTributaria.Element("nombreComercial").Value;
                        Documento.ClaveAcceso = infoTributaria.Element("claveAcceso").Value;
                        Documento.emi_ContribuyenteEspecial = infoFactura.Element("contribuyenteEspecial") == null ? "NO" : infoFactura.Element("contribuyenteEspecial").Value;
                        Documento.CodDocumento = infoTributaria.Element("codDoc").Value;
                        Documento.Establecimiento = infoTributaria.Element("estab").Value;
                        Documento.PuntoEmision = infoTributaria.Element("ptoEmi").Value;
                        Documento.NumeroDocumento = infoTributaria.Element("secuencial").Value;
                        Documento.emi_DireccionMatriz = infoTributaria.Element("dirMatriz").Value;
                        Documento.FechaEmision = DateTime.ParseExact(infoFactura.Element("fechaEmision").Value, "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture);
                        Documento.rec_RazonSocial = infoFactura.Element("razonSocialSujetoRetenido").Value;
                        Documento.rec_Identificacion = infoFactura.Element("identificacionSujetoRetenido").Value;
                        Documento.Comprobante = Documento.CodDocumento + "-" + Documento.Establecimiento + "-" + Documento.PuntoEmision + "-" + Documento.NumeroDocumento;
                        Documento.IdUsuarioCreacion = param.IdUsuario;
                        #endregion

                        #region Cliente
                        var Cliente = ListaCliente.Where(q => q.Persona_Info.pe_cedulaRuc == Documento.emi_Ruc).FirstOrDefault();
                        if (Cliente == null)
                        {
                            Cliente = busCliente.GetCliente(param.IdEmpresa, Documento.emi_Ruc);
                            if (Cliente == null)
                            {
                                Documento.AplicaRetencion = 2;
                                Documento.Motivo = "El cliente no existe en el sistema";
                            }
                            else
                            {
                                ListaCliente.Add(Cliente);
                                Documento.IdCliente = Cliente.IdCliente;
                            }    
                        }else
                            Documento.IdCliente = Cliente.IdCliente;
                        #endregion

                        #region Detalle
                        var infoImpuestos = rootElement.Element("impuestos");

                        if (infoImpuestos != null)
                        {
                            var list = infoImpuestos.Elements("impuesto")
                           .Select(element => element)
                           .ToList();
                            Documento.ListaDet = new List<cxc_XML_DocumentoDet_Info>();
                            foreach (var Impuesto in list)
                            {
                                var det = new cxc_XML_DocumentoDet_Info
                                {
                                    TipoRetencion = Impuesto.Element("codigo").Value == "1" ? "FTE" : "IVA",
                                    CodigoRetencion = Impuesto.Element("codigoRetencion").Value.ToString(),
                                    BaseImponible = Convert.ToDecimal(Impuesto.Element("baseImponible").Value.ToString()),
                                    PorcentajeRetencion = Convert.ToDecimal(Impuesto.Element("porcentajeRetener").Value.ToString()),
                                    ValorRetenido = Convert.ToDecimal(Impuesto.Element("valorRetenido").Value.ToString()),
                                    CodDocSustento = Impuesto.Element("codDocSustento").Value.ToString(),
                                    NumDocSustento = Impuesto.Element("numDocSustento").Value.ToString(),
                                    FechaEmisionDocSustento = DateTime.ParseExact(Impuesto.Element("fechaEmisionDocSustento").Value, "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture),
                                };
                                if (det.TipoRetencion == "FTE")
                                {
                                    Documento.TotalRetencionFTE += Convert.ToDouble(det.ValorRetenido);
                                    double Porcentaje = Convert.ToDouble(det.PorcentajeRetencion);
                                    var TipoCobro = ListaTipoCobro.Where(q => q.ESRetenFTE == "S" && q.PorcentajeRet == Porcentaje).FirstOrDefault();
                                    if (TipoCobro == null)
                                    {
                                        MessageBox.Show("El porcentaje de retención de fuente " + Porcentaje.ToString() + " no se encuentra registrado", param.Nombre_sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        return;
                                    }
                                    det.IdCobro_tipo = TipoCobro.IdCobro_tipo;
                                }
                                else
                                {
                                    Documento.TotalRetencionIVA += Convert.ToDouble(det.ValorRetenido);
                                    double Porcentaje = Convert.ToDouble(det.PorcentajeRetencion);
                                    var TipoCobro = ListaTipoCobro.Where(q => q.ESRetenIVA == "S" && q.PorcentajeRet == Porcentaje).FirstOrDefault();
                                    if (TipoCobro == null)
                                    {
                                        MessageBox.Show("El porcentaje de retención de IVA " + Porcentaje.ToString() + " no se encuentra registrado", param.Nombre_sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        return;
                                    }
                                    det.IdCobro_tipo = TipoCobro.IdCobro_tipo;
                                }
                                det.dc_TipoDocumento = det.CodDocSustento == "01" ? "FACT" : "NTDB";
                                Documento.DocumentoSustento = det.NumDocSustento;
                                Documento.ListaDet.Add(det);
                            }

                            #region Validar saldo factura
                            if (Documento.AplicaRetencion == 0 && Documento.ListaDet.Count > 0)
                            {
                                var Det1 = Documento.ListaDet.First();
                                var Cab = busDet.GetInfoParaCruzar(param.IdEmpresa, Det1.dc_TipoDocumento, Det1.NumDocSustento, Convert.ToDouble(Documento.ListaDet.Sum(q => q.ValorRetenido)), Documento.IdCliente);
                                if (Cab.IdSucursal > 0)
                                {
                                    Documento.IdSucursal = Cab.IdSucursal;
                                    Documento.IdBodega_Cbte = Cab.IdBodega_Cbte;
                                    Documento.IdCbte_vta_nota = Cab.IdCbte_vta_nota;
                                }
                                Documento.AplicaRetencion = Cab.AplicaRetencion;
                                Documento.Motivo = Cab.Motivo;
                            }
                            #endregion

                        #endregion
                        }
                        else
                            MessageBox.Show("El archivo: " + item + "\nNo cumple las especificaciones técnicas", param.Nombre_sistema, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                        blst.Add(Documento);
                        gcDetalle.DataSource = null;
                        gcDetalle.DataSource = blst;
                    }
                    
                }
            }
            catch (Exception ex)
            {
                gcDetalle.DataSource = blst;
                lblContador.Text = blst.Count.ToString();
                MessageBox.Show(ex.Message, param.Nombre_sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDigitalizar_Click(object sender, EventArgs e)
        {
            var lst = blst.Where(q => q.AplicaRetencion == 1).ToList();
            //var lst = blst.ToList();
            foreach (var item in lst)
            {
                if (!busXML.GuardarDB(item))
                {
                    MessageBox.Show("No se ha podido guardar el cobro para la factura "+item.Observacion,param.Nombre_sistema,MessageBoxButtons.OK,MessageBoxIcon.Error);
                    return;
                }
            }
            MessageBox.Show("Registros guardados exitósamente" , param.Nombre_sistema, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            this.Close();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            gcDetalle.ShowPrintPreview();
        }
        #endregion

        #region Metodos
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
          private void CargarCombos()
          {
              try
              {
                  ListaTipoCobro = busTipoCobro.Get_List_Cobro_Tipo_x_RetFte();
                  ListaTipoCobro.AddRange(busTipoCobro.Get_List_Cobro_Tipo_RetIva());
              }
              catch (Exception)
              {
                  
                  throw;
              }
          }
        #endregion
    }
}
