using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Core.Erp.Info.CuentasxCobrar;
using Core.Erp.Business.CuentasxCobrar;
using Core.Erp.Info.General;
using Core.Erp.Business.General;

namespace Core.Erp.Winform.CuentasxCobrar
{
    public partial class frmCXC_XML_Mantenimiento : Form
    {
        #region Variables
        cxc_XML_Documento_Bus busXML;
        cxc_XML_DocumentoDet_Bus busXMLDet;

        #endregion

        public frmCXC_XML_Mantenimiento()
        {
            InitializeComponent();
        }

        private void frmCXC_XML_Mantenimiento_Load(object sender, EventArgs e)
        {

        }
    }
}
