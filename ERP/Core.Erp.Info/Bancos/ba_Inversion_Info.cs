﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Erp.Info.Bancos
{
    public class ba_Inversion_Info
    {
        public int IdEmpresa { get; set; }
        public decimal IdInversion { get; set; }
        public string Cod_Inversion { get; set; }
        public int IdBanco { get; set; }
        public string NomBanco { get; set; }
        public DateTime Fecha { get; set; }
        public int Plazo { get; set; }
        public DateTime Fecha_Vct { get; set; }
        public double Monto { get; set; }
        public double Tasa { get; set; }
        public double Por_Retencion { get; set; }
        public double Valor_retencion { get; set; }
        public double Otros { get; set; }
        public double Tasa_interes { get; set; }
        public double Valor_interes { get; set; }
        public double Capital { get; set; }
        public double Total_recibir { get; set; }
        public string Observacion { get; set; }
        public string IdUsuario { get; set; }
        public DateTime Fecha_Transac { get; set; }
        public string IdUsuarioUltMod { get; set; }
        public Nullable< DateTime >Fecha_UltMod { get; set; }
        public string IdUsuarioUltAnu { get; set; }
        public Nullable<DateTime> Fecha_UltAnu { get; set; }
        public string nom_pc { get; set; }
        public string ip { get; set; }
        public string MotiAnula { get; set; }
        public string Estado { get; set; }
        public ba_Inversion_Info()
        {

        }
    }
}
