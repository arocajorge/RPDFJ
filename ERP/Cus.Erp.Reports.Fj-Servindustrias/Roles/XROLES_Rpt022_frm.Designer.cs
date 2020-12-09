namespace Cus.Erp.Reports.FJ.Roles
{
    partial class XROLES_Rpt022_frm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.cmbnomina = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ColDescripcion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.cmb_cargo = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btn_buscar = new DevExpress.XtraEditors.SimpleButton();
            this.btn_salir = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.cmbnomina.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_cargo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(7, 8);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(39, 13);
            this.labelControl5.TabIndex = 149;
            this.labelControl5.Text = "Nómina:";
            // 
            // cmbnomina
            // 
            this.cmbnomina.Location = new System.Drawing.Point(73, 5);
            this.cmbnomina.Name = "cmbnomina";
            this.cmbnomina.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbnomina.Properties.DisplayMember = "Descripcion";
            this.cmbnomina.Properties.ValueMember = "IdNomina_Tipo";
            this.cmbnomina.Properties.View = this.searchLookUpEdit1View;
            this.cmbnomina.Size = new System.Drawing.Size(347, 20);
            this.cmbnomina.TabIndex = 148;
            // 
            // searchLookUpEdit1View
            // 
            this.searchLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.ColDescripcion});
            this.searchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpEdit1View.Name = "searchLookUpEdit1View";
            this.searchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // ColDescripcion
            // 
            this.ColDescripcion.Caption = "Nomina";
            this.ColDescripcion.FieldName = "Descripcion";
            this.ColDescripcion.Name = "ColDescripcion";
            this.ColDescripcion.Visible = true;
            this.ColDescripcion.VisibleIndex = 0;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(7, 34);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(33, 13);
            this.labelControl1.TabIndex = 151;
            this.labelControl1.Text = "Cargo:";
            // 
            // cmb_cargo
            // 
            this.cmb_cargo.Location = new System.Drawing.Point(73, 31);
            this.cmb_cargo.Name = "cmb_cargo";
            this.cmb_cargo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmb_cargo.Properties.DisplayMember = "ca_descripcion";
            this.cmb_cargo.Properties.ValueMember = "IdCargo";
            this.cmb_cargo.Properties.View = this.gridView1;
            this.cmb_cargo.Size = new System.Drawing.Size(347, 20);
            this.cmb_cargo.TabIndex = 150;
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1});
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Cargo";
            this.gridColumn1.FieldName = "ca_descripcion";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // btn_buscar
            // 
            this.btn_buscar.Location = new System.Drawing.Point(440, 8);
            this.btn_buscar.Name = "btn_buscar";
            this.btn_buscar.Size = new System.Drawing.Size(75, 23);
            this.btn_buscar.TabIndex = 152;
            this.btn_buscar.Text = "Cargar data";
            this.btn_buscar.Click += new System.EventHandler(this.btn_buscar_Click);
            // 
            // btn_salir
            // 
            this.btn_salir.Location = new System.Drawing.Point(440, 34);
            this.btn_salir.Name = "btn_salir";
            this.btn_salir.Size = new System.Drawing.Size(75, 23);
            this.btn_salir.TabIndex = 153;
            this.btn_salir.Text = "Salir";
            this.btn_salir.Click += new System.EventHandler(this.btn_salir_Click);
            // 
            // XROLES_Rpt022_frm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1042, 64);
            this.Controls.Add(this.btn_salir);
            this.Controls.Add(this.btn_buscar);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.cmb_cargo);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.cmbnomina);
            this.Name = "XROLES_Rpt022_frm";
            this.Text = "XROLES_Rpt022_frm";
            this.Load += new System.EventHandler(this.XROLES_Rpt022_frm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cmbnomina.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_cargo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.SearchLookUpEdit cmbnomina;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
        private DevExpress.XtraGrid.Columns.GridColumn ColDescripcion;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SearchLookUpEdit cmb_cargo;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraEditors.SimpleButton btn_buscar;
        private DevExpress.XtraEditors.SimpleButton btn_salir;

    }
}