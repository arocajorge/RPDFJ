﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Erp.Info.CuentasxPagar
{
    public class cp_XML_DocumentoRetAnuladoDet_Info
    {
        public int IdEmpresa { get; set; }
        public decimal IdDocumento { get; set; }
        public int SecuenciaAnu { get; set; }
        public int Secuencia { get; set; }
        public string re_tipoRet { get; set; }
        public double re_baseRetencion { get; set; }
        public int IdCodigo_SRI { get; set; }
        public string re_Codigo_impuesto { get; set; }
        public double re_Porcen_retencion { get; set; }
        public double re_valor_retencion { get; set; }
    }
}
