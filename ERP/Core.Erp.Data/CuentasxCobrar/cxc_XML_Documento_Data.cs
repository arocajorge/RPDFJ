using Core.Erp.Data.General;
using Core.Erp.Info.CuentasxCobrar;
using Core.Erp.Info.General;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Erp.Data.CuentasxCobrar
{
    public class cxc_XML_Documento_Data
    {
        #region Variables
        cxc_cobro_Data odata = new cxc_cobro_Data();
        #endregion
        public List<cxc_XML_Documento_Info> GetList(int IdEmpresa, DateTime FechaIni, DateTime FechaFin)
        {
            try
            {
                List<cxc_XML_Documento_Info> Lista = new List<cxc_XML_Documento_Info>();
                FechaIni = FechaIni.Date;
                FechaFin = FechaFin.Date;

                using (EntitiesCuentas_x_Cobrar db = new EntitiesCuentas_x_Cobrar())
                {
                    var lst = db.cxc_XML_Documento.Where(q => q.IdEmpresa == IdEmpresa && FechaIni <= q.FechaEmision && q.FechaEmision <= FechaFin).ToList();
                    foreach (var item in lst)
                    {
                        Lista.Add(new cxc_XML_Documento_Info
                        {
                            IdEmpresa = item.IdEmpresa,
                            IdDocumento = item.IdDocumento,
                            Comprobante = item.Comprobante,
                            XML = item.XML,
                            Tipo = item.Tipo,
                            emi_RazonSocial = item.emi_RazonSocial,
                            emi_NombreComercial = item.emi_NombreComercial,
                            emi_Ruc = item.emi_Ruc,
                            emi_DireccionMatriz = item.emi_DireccionMatriz,
                            emi_ContribuyenteEspecial = item.emi_ContribuyenteEspecial,
                            ClaveAcceso = item.ClaveAcceso,
                            CodDocumento = item.CodDocumento,
                            Establecimiento = item.Establecimiento,
                            PuntoEmision = item.PuntoEmision,
                            NumeroDocumento = item.NumeroDocumento,
                            FechaEmision = item.FechaEmision,
                            rec_RazonSocial = item.rec_RazonSocial,
                            rec_Identificacion = item.rec_Identificacion,
                            Estado = item.Estado,
                            Observacion = item.Observacion,
                        });
                    }
                }

                return Lista;
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public cxc_XML_Documento_Info GetInfo(int IdEmpresa, decimal IdDocumento)
        {
            try
            {
                cxc_XML_Documento_Info info = new cxc_XML_Documento_Info();

                using (EntitiesCuentas_x_Cobrar db = new EntitiesCuentas_x_Cobrar())
                {
                    var Entity = db.cxc_XML_Documento.Where(q => q.IdEmpresa == IdEmpresa && q.IdDocumento == IdDocumento).FirstOrDefault();
                    if (Entity == null)
                        return null;

                    info = new cxc_XML_Documento_Info
                    {
                        IdEmpresa = Entity.IdEmpresa,
                        IdDocumento = Entity.IdDocumento,
                        Comprobante = Entity.Comprobante,
                        XML = Entity.XML,
                        Tipo = Entity.Tipo,
                        emi_RazonSocial = Entity.emi_RazonSocial,
                        emi_NombreComercial = Entity.emi_NombreComercial,
                        emi_Ruc = Entity.emi_Ruc,
                        emi_DireccionMatriz = Entity.emi_DireccionMatriz,
                        emi_ContribuyenteEspecial = Entity.emi_ContribuyenteEspecial,
                        ClaveAcceso = Entity.ClaveAcceso,
                        CodDocumento = Entity.CodDocumento,
                        Establecimiento = Entity.Establecimiento,
                        PuntoEmision = Entity.PuntoEmision,
                        NumeroDocumento = Entity.NumeroDocumento,
                        FechaEmision = Entity.FechaEmision,
                        rec_RazonSocial = Entity.rec_RazonSocial,
                        rec_Identificacion = Entity.rec_Identificacion,
                        Estado = Entity.Estado,
                        Observacion = Entity.Observacion,
                    };
                }

                return info;
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        private decimal GetID(int IdEmpresa)
        {
            try
            {
                decimal ID = 1;

                using (EntitiesCuentas_x_Cobrar db = new EntitiesCuentas_x_Cobrar())
                {
                    int Cont = db.cxc_XML_Documento.Where(q => q.IdEmpresa == IdEmpresa).Count();
                    if (Cont > 0)
                        ID = db.cxc_XML_Documento.Where(q => q.IdEmpresa == IdEmpresa).Max(q => q.IdDocumento) + 1;                    
                }

                return ID;
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public bool GuardarDB(cxc_XML_Documento_Info info)
        {
            try
            {
                try
                {
                    using (EntitiesCuentas_x_Cobrar db = new EntitiesCuentas_x_Cobrar())
                    {
                        if (!string.IsNullOrEmpty(info.Motivo))
                        {
                            return false;
                        }
                        var Entity = new cxc_XML_Documento
                        {
                            IdEmpresa = info.IdEmpresa,
                            IdDocumento = info.IdDocumento = GetID(info.IdEmpresa),
                            Comprobante = info.Comprobante,
                            XML = info.XML,
                            Tipo = info.Tipo,
                            emi_RazonSocial = info.emi_RazonSocial,
                            emi_NombreComercial = info.emi_NombreComercial,
                            emi_Ruc = info.emi_Ruc,
                            emi_DireccionMatriz = info.emi_DireccionMatriz,
                            emi_ContribuyenteEspecial = info.emi_ContribuyenteEspecial,
                            ClaveAcceso = info.ClaveAcceso,
                            CodDocumento = info.CodDocumento,
                            Establecimiento = info.Establecimiento,
                            PuntoEmision = info.PuntoEmision,
                            NumeroDocumento = info.NumeroDocumento,
                            FechaEmision = info.FechaEmision,
                            rec_RazonSocial = info.rec_RazonSocial,
                            rec_Identificacion = info.rec_Identificacion,
                            Estado = true,
                            IdUsuarioCreacion = info.IdUsuarioCreacion,
                            FechaCreacion = DateTime.Now,
                            Observacion = info.Observacion ?? "",
                            DocumentoSustento = info.DocumentoSustento,
                            TotalRetencionIVA = info.TotalRetencionIVA,
                            TotalRetencionFTE = info.TotalRetencionFTE
                        };
                        int Secuencia = 1;
                        foreach (var item in info.ListaDet)
                        {
                            item.IdEmpresa = info.IdEmpresa;
                            item.IdSucursal = info.IdSucursal;
                            item.IdBodega_Cbte = info.IdBodega_Cbte;
                            item.IdCbte_vta_nota = info.IdCbte_vta_nota;
                            
                            cxc_XML_DocumentoDet d = new cxc_XML_DocumentoDet
                            {
                                IdEmpresa = info.IdEmpresa,
                                IdDocumento = info.IdDocumento,
                                Secuencia = Secuencia++,
                                TipoRetencion = item.TipoRetencion,
                                CodigoRetencion = item.CodigoRetencion,
                                BaseImponible = item.BaseImponible,
                                PorcentajeRetencion = item.PorcentajeRetencion,
                                ValorRetenido = item.ValorRetenido,
                                CodDocSustento = item.CodDocSustento,
                                NumDocSustento = item.NumDocSustento,
                                FechaEmisionDocSustento = item.FechaEmisionDocSustento,
                                IdSucursal = info.IdSucursal,
                                IdCobro = item.IdCobro = ArmarCobro(info.IdEmpresa, info.IdSucursal, info.IdCliente, info.FechaEmision, info.Comprobante, info.IdUsuarioCreacion, item),
                                dc_TipoDocumento = item.dc_TipoDocumento,
                                IdBodega_Cbte = info.IdBodega_Cbte,
                                IdCbte_vta_nota = info.IdCbte_vta_nota,
                                IdCobro_tipo = item.IdCobro_tipo
                            };
                            odata.ContabilizarRetencion(d.IdEmpresa, d.IdSucursal ?? 0, d.IdCobro ?? 0);
                            db.cxc_XML_DocumentoDet.Add(d);
                        }
                    db.cxc_XML_Documento.Add(Entity);
                    db.SaveChanges();
                    }

                    return true;
                }
                catch (DbEntityValidationException ex)
                {
                    string mensaje = string.Empty;
                    string arreglo = ToString();
                    tb_sis_Log_Error_Vzen_Data oDataLog = new tb_sis_Log_Error_Vzen_Data();
                    tb_sis_Log_Error_Vzen_Info Log_Error_sis = new tb_sis_Log_Error_Vzen_Info(ex.ToString(), "", arreglo, "", "", "", "", "", DateTime.Now);
                    oDataLog.Guardar_Log_Error(Log_Error_sis, ref mensaje);
                    mensaje = ex.ToString() + " " + ex.Message;
                    mensaje = "Error al Grabar" + ex.Message;
                    throw new Exception(ex.ToString());
                }
            }
            catch (Exception ex)
            {
                string arreglo = ToString();
                string strMensaje = "";
                tb_sis_Log_Error_Vzen_Data oDataLog = new tb_sis_Log_Error_Vzen_Data();
                tb_sis_Log_Error_Vzen_Info Log_Error_sis = new tb_sis_Log_Error_Vzen_Info(ex.ToString(), "", arreglo, "", "", "", "", "", DateTime.Now);
                strMensaje = ex.ToString() + " " + ex.Message;
                oDataLog.Guardar_Log_Error(Log_Error_sis, ref strMensaje);
                throw new Exception(ex.ToString());
            }
        }

        private decimal ArmarCobro(int IdEmpresa, 
            int IdSucursal, 
            decimal IdCliente,
            DateTime Fecha,
            string NumRetencion,
            string IdUsuario,
            cxc_XML_DocumentoDet_Info InfoDet)
        {
            try
            {
                EntitiesFacturacion dbFac = new EntitiesFacturacion();
                EntitiesCuentas_x_Cobrar dbCxc = new EntitiesCuentas_x_Cobrar();

                #region Cabecera
                cxc_cobro cobro = new cxc_cobro
                {
                    IdEmpresa = IdEmpresa,
                    IdSucursal = IdSucursal,
                    IdCobro = odata.GetId(IdEmpresa, IdSucursal),
                    IdCobro_tipo = InfoDet.IdCobro_tipo,
                    IdCliente = IdCliente,
                    cr_TotalCobro = Convert.ToDouble(InfoDet.ValorRetenido),
                    cr_fecha = Fecha.Date,
                    cr_fechaCobro = Fecha.Date,
                    cr_fechaDocu = Fecha.Date,
                    cr_observacion = "Canc/:FACT" + InfoDet.NumDocSustento,
                    cr_cuenta = "",
                    cr_NumDocumento = NumRetencion,
                    cr_Tarjeta = "",
                    cr_propietarioCta = "",
                    cr_estado = "A",
                    cr_es_anticipo = "N",
                    IdUsuario = IdUsuario,
                    Fecha_Transac = DateTime.Now,
                    nom_pc = "",
                    ip = "",
                    IdCaja = 1
                };
                dbCxc.cxc_cobro.Add(cobro);
                #endregion

                #region Detalle
                dbCxc.cxc_cobro_det.Add(new cxc_cobro_det
                {
                    IdEmpresa = cobro.IdEmpresa,
                    IdSucursal = cobro.IdSucursal,
                    IdCobro = cobro.IdCobro,
                    secuencial = 1,
                    IdBodega_Cbte = InfoDet.IdBodega_Cbte,
                    IdCbte_vta_nota = InfoDet.IdCbte_vta_nota ?? 0,
                    dc_TipoDocumento = InfoDet.dc_TipoDocumento,
                    dc_ValorPago = Convert.ToDouble(InfoDet.ValorRetenido),
                    IdUsuario = IdUsuario,
                    Fecha_Transac = DateTime.Now,
                    estado = "A"
                });
                #endregion

                dbCxc.SaveChanges();

                return cobro.IdCobro;
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public bool AnularDB(int IdEmpresa, decimal IdDocumento, string IdUsuario)
        {
            try
            {
                using (EntitiesCuentas_x_Cobrar db = new EntitiesCuentas_x_Cobrar())
                {
                    var Entity = db.cxc_XML_Documento.Where(q => q.IdEmpresa == IdEmpresa && q.IdDocumento == IdDocumento).FirstOrDefault();
                    if (Entity != null)
                    {
                        Entity.Estado = false;
                        Entity.FechaAnulacion = DateTime.Now;
                        Entity.IdUsuarioAnulacion = IdUsuario;
                        db.SaveChanges();
                    }
                }

                return true;
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}
