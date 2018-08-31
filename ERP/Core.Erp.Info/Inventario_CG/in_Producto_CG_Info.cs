using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Erp.Info.Inventario_CG
{
    public class in_Producto_CG_Info
    {
        public int IdEmpresa { get; set; }
        public decimal IdProducto { get; set; }
        public string sw_solicita_autorizacion { get; set; }
        public string codigo_alterno { get; set; }
        public string sw_venta_directa { get; set; }
        public string codigo_cnmb { get; set; }
        public string sw_control_fecha_vencimiento { get; set; }
        public string sw_generico { get; set; }
        public string sw_pos { get; set; }
        public string med_cod_forma_farmacologica { get; set; }
        public string med_cod_anatofarmacologico { get; set; }
        public string contenido_unidad_venta { get; set; }
        public string med_cod_principio_activo { get; set; }
        public string med_sw_farmacovigilancia { get; set; }
        public string med_descripcion_alerta { get; set; }
        public string med_sw_alimento_parenteral { get; set; }
        public string med_sw_alimento_enteral { get; set; }
        public string med_sw_manejo_luz { get; set; }
        public string IdUsuario { get; set; }
        public Nullable<System.DateTime> Fecha_Transac { get; set; }
        public string IdUsuarioUltMod { get; set; }
        public Nullable<System.DateTime> Fecha_UltMod { get; set; }
        public string IdUsuarioUltAnu { get; set; }
        public Nullable<System.DateTime> Fecha_UltAnu { get; set; }
        public string pr_motivoAnulacion { get; set; }
        public string nom_pc { get; set; }
        public string ip { get; set; }
        public string Estado { get; set; }
        public string unidad_medida_medicamento_id { get; set; }
        public short med_dias_previos_vencimiento { get; set; }
    }
}
