using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Collections.Generic;
using Core.Erp.Business.General;

namespace Cus.Erp.Reports.FJ.Roles
{
    public partial class XROLES_Rpt022_Rpt : DevExpress.XtraReports.UI.XtraReport
    {
        public XROLES_Rpt022_Rpt()
        {
            InitializeComponent();
        }
        XROLES_Rpt022_Bus oReporteBus = new XROLES_Rpt022_Bus();
        List<XROLES_Rpt022_Info> oListado = new List<XROLES_Rpt022_Info>();
        cl_parametrosGenerales_Bus param = cl_parametrosGenerales_Bus.Instance;

        private void XROLES_Rpt022_Rpt_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            try
            {
           

             int IdEmpresa = Convert.ToInt32(Parameters["p_IdEmpresa"].Value);
             int IdNomina = Convert.ToInt32(Parameters["p_IdNomina"].Value);
             int idDepartamento = Convert.ToInt32(Parameters["p_idDepartamento"].Value);

                
             empresa.Text = param.NombreEmpresa;
             oListado = oReporteBus.get_list(IdEmpresa, IdNomina, idDepartamento);
             DataSource = oListado;
            }
            catch (Exception)
            {
                
                throw;
            }
        }

    }
}
