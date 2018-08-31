using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Erp.Info.Inventario_CG
{
    public class vw_in_Producto_x_inv_Producto_CG_Info
    {
        public int IdEmpresa { get; set; }
        public decimal IdProducto { get; set; }
        public string pr_codigo { get; set; }
        public string IdCategoria { get; set; }
        public int IdLinea { get; set; }
        public int IdGrupo { get; set; }
        public string IdUnidadMedida { get; set; }
        public string pr_codigo_barra { get; set; }
        public Nullable<int> IdMotivo_Vta { get; set; }
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
        public string pr_descripcion { get; set; }
        public string IdUnidadMedida_Consumo { get; set; }
        public string estado_medicina { get; set; }
        public string estado_producto { get; set; }
        public int IdProductoTipo { get; set; }
        public string pr_ManejaIva { get; set; }
        public string unidad_medida_medicamento_id { get; set; }

    }
}
