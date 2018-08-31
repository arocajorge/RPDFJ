using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Erp.Info.Academico
{
    public class Aca_tb_bancos_procesos_bancarios_x_empresa_x_Grupo_FE_Info
    {
        public int IdEmpresa { get; set; }
        public string IdProceso_bancario_tipo { get; set; }
        public int IdInstitucion { get; set; }
        public int IdGrupoFE { get; set; }
        public string CodGrupoFE { get; set; }
        public string Codigo_establecimiento { get; set; }
        public Nullable<double> porcentaje_comision { get; set; }
        public Nullable<bool> Estado { get; set; }
        public string Observacion { get; set; }
    }
}
