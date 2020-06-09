using Core.Erp.Info.CuentasxCobrar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Erp.Data.CuentasxCobrar
{
    public class cxc_XML_Documento_Data
    {
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
                using (EntitiesCuentas_x_Cobrar db = new EntitiesCuentas_x_Cobrar())
                {
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
                        Observacion = info.Observacion
                    };

                    db.cxc_XML_Documento.Add(entity);
                    db.SaveChanges();
                }

                return true;
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
