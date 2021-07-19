using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Erp.Info.Logistica
{
    public class lo_recurso_Info
    {
        public int IdRecurso { get; set; }
        public string NomRecurso { get; set; }
        public bool ControlaSerie { get; set; }
        public bool ControlKardex { get; set; }
        public bool Estado { get; set; }
    }
}
