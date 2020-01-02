namespace Core.Erp.Winform.Roles_Fj
{
    partial class frm_Ro_empleados_x_extension_salud
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Ro_empleados_x_extension_salud));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.gridControl_parametros = new DevExpress.XtraGrid.GridControl();
            this.gridView_parametros = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col_NomCompleto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cmb_empleado = new DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit();
            this.repositoryItemSearchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Col_Descripcion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Observacion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cmb_nomina_tipo = new DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Col_DescripcionProcesoNomina = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cmb_rubro = new DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Col_ru_descripcion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cmb_catalogo = new DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit();
            this.gridView3 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Col_ca_descripcion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemImageComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.label1 = new System.Windows.Forms.Label();
            this.cmb_nomina = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col_ca_desp = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ucGe_Menu = new Core.Erp.Winform.Controles.UCGe_Menu_Superior_Mant();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_parametros)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_parametros)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_empleado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSearchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_nomina_tipo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_rubro)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_catalogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_nomina.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.gridControl_parametros);
            this.panelControl1.Controls.Add(this.groupControl1);
            this.panelControl1.Controls.Add(this.ucGe_Menu);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1025, 479);
            this.panelControl1.TabIndex = 0;
            // 
            // gridControl_parametros
            // 
            this.gridControl_parametros.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl_parametros.Location = new System.Drawing.Point(2, 80);
            this.gridControl_parametros.MainView = this.gridView_parametros;
            this.gridControl_parametros.Name = "gridControl_parametros";
            this.gridControl_parametros.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.cmb_empleado,
            this.cmb_nomina_tipo,
            this.cmb_rubro,
            this.cmb_catalogo,
            this.repositoryItemImageComboBox1});
            this.gridControl_parametros.Size = new System.Drawing.Size(1021, 397);
            this.gridControl_parametros.TabIndex = 4;
            this.gridControl_parametros.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_parametros});
            this.gridControl_parametros.Click += new System.EventHandler(this.gridControl_parametros_Click);
            // 
            // gridView_parametros
            // 
            this.gridView_parametros.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col_NomCompleto,
            this.Observacion});
            this.gridView_parametros.GridControl = this.gridControl_parametros;
            this.gridView_parametros.Name = "gridView_parametros";
            this.gridView_parametros.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.gridView_parametros.OptionsView.ShowAutoFilterRow = true;
            this.gridView_parametros.OptionsView.ShowFooter = true;
            this.gridView_parametros.OptionsView.ShowGroupPanel = false;
            this.gridView_parametros.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView_parametros_FocusedRowChanged);
            this.gridView_parametros.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridView_parametros_KeyDown);
            // 
            // col_NomCompleto
            // 
            this.col_NomCompleto.Caption = "Empleado";
            this.col_NomCompleto.ColumnEdit = this.cmb_empleado;
            this.col_NomCompleto.FieldName = "IdEmpleado";
            this.col_NomCompleto.Name = "col_NomCompleto";
            this.col_NomCompleto.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count)});
            this.col_NomCompleto.Visible = true;
            this.col_NomCompleto.VisibleIndex = 0;
            this.col_NomCompleto.Width = 541;
            // 
            // cmb_empleado
            // 
            this.cmb_empleado.AutoHeight = false;
            this.cmb_empleado.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmb_empleado.DisplayMember = "NomCompleto";
            this.cmb_empleado.Name = "cmb_empleado";
            this.cmb_empleado.ValueMember = "IdEmpleado";
            this.cmb_empleado.View = this.repositoryItemSearchLookUpEdit1View;
            this.cmb_empleado.EditValueChanged += new System.EventHandler(this.cmb_nomina_EditValueChanged);
            // 
            // repositoryItemSearchLookUpEdit1View
            // 
            this.repositoryItemSearchLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.Col_Descripcion});
            this.repositoryItemSearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.repositoryItemSearchLookUpEdit1View.Name = "repositoryItemSearchLookUpEdit1View";
            this.repositoryItemSearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.repositoryItemSearchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // Col_Descripcion
            // 
            this.Col_Descripcion.Caption = "Nombres";
            this.Col_Descripcion.FieldName = "NomCompleto";
            this.Col_Descripcion.Name = "Col_Descripcion";
            this.Col_Descripcion.Visible = true;
            this.Col_Descripcion.VisibleIndex = 0;
            // 
            // Observacion
            // 
            this.Observacion.Caption = "Observacion";
            this.Observacion.FieldName = "Observacion";
            this.Observacion.Name = "Observacion";
            this.Observacion.Width = 462;
            // 
            // cmb_nomina_tipo
            // 
            this.cmb_nomina_tipo.AutoHeight = false;
            this.cmb_nomina_tipo.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmb_nomina_tipo.Name = "cmb_nomina_tipo";
            this.cmb_nomina_tipo.View = this.gridView1;
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.Col_DescripcionProcesoNomina});
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // Col_DescripcionProcesoNomina
            // 
            this.Col_DescripcionProcesoNomina.Caption = "Proceso";
            this.Col_DescripcionProcesoNomina.FieldName = "DescripcionProcesoNomina";
            this.Col_DescripcionProcesoNomina.Name = "Col_DescripcionProcesoNomina";
            this.Col_DescripcionProcesoNomina.Visible = true;
            this.Col_DescripcionProcesoNomina.VisibleIndex = 0;
            // 
            // cmb_rubro
            // 
            this.cmb_rubro.AutoHeight = false;
            this.cmb_rubro.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmb_rubro.Name = "cmb_rubro";
            this.cmb_rubro.View = this.gridView2;
            // 
            // gridView2
            // 
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.Col_ru_descripcion});
            this.gridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            // 
            // Col_ru_descripcion
            // 
            this.Col_ru_descripcion.Caption = "Rubro";
            this.Col_ru_descripcion.FieldName = "ru_descripcion";
            this.Col_ru_descripcion.Name = "Col_ru_descripcion";
            this.Col_ru_descripcion.Visible = true;
            this.Col_ru_descripcion.VisibleIndex = 0;
            // 
            // cmb_catalogo
            // 
            this.cmb_catalogo.AutoHeight = false;
            this.cmb_catalogo.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmb_catalogo.Name = "cmb_catalogo";
            this.cmb_catalogo.View = this.gridView3;
            // 
            // gridView3
            // 
            this.gridView3.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.Col_ca_descripcion});
            this.gridView3.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView3.Name = "gridView3";
            this.gridView3.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView3.OptionsView.ShowGroupPanel = false;
            // 
            // Col_ca_descripcion
            // 
            this.Col_ca_descripcion.Caption = "Grupo";
            this.Col_ca_descripcion.FieldName = "ca_descripcion";
            this.Col_ca_descripcion.Name = "Col_ca_descripcion";
            this.Col_ca_descripcion.Visible = true;
            this.Col_ca_descripcion.VisibleIndex = 0;
            // 
            // repositoryItemImageComboBox1
            // 
            this.repositoryItemImageComboBox1.AutoHeight = false;
            this.repositoryItemImageComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemImageComboBox1.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("", true, 0)});
            this.repositoryItemImageComboBox1.Name = "repositoryItemImageComboBox1";
            this.repositoryItemImageComboBox1.SmallImages = this.imageList1;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "anular2_32.x32png.png");
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.label1);
            this.groupControl1.Controls.Add(this.cmb_nomina);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(2, 31);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(1021, 49);
            this.groupControl1.TabIndex = 3;
            this.groupControl1.Text = "Empleados con extension de salud";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Nomina";
            // 
            // cmb_nomina
            // 
            this.cmb_nomina.Location = new System.Drawing.Point(69, 24);
            this.cmb_nomina.Name = "cmb_nomina";
            this.cmb_nomina.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmb_nomina.Properties.DisplayMember = "Descripcion";
            this.cmb_nomina.Properties.ValueMember = "IdNomina_Tipo";
            this.cmb_nomina.Properties.View = this.searchLookUpEdit1View;
            this.cmb_nomina.Size = new System.Drawing.Size(475, 20);
            this.cmb_nomina.TabIndex = 3;
            this.cmb_nomina.EditValueChanged += new System.EventHandler(this.cmb_nomina_EditValueChanged_1);
            // 
            // searchLookUpEdit1View
            // 
            this.searchLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col_ca_desp});
            this.searchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpEdit1View.Name = "searchLookUpEdit1View";
            this.searchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // col_ca_desp
            // 
            this.col_ca_desp.Caption = "Nomina";
            this.col_ca_desp.FieldName = "Descripcion";
            this.col_ca_desp.Name = "col_ca_desp";
            this.col_ca_desp.Visible = true;
            this.col_ca_desp.VisibleIndex = 0;
            // 
            // ucGe_Menu
            // 
            this.ucGe_Menu.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucGe_Menu.Enabled_bnRetImprimir = true;
            this.ucGe_Menu.Enabled_bntAnular = true;
            this.ucGe_Menu.Enabled_bntAprobar = true;
            this.ucGe_Menu.Enabled_bntGuardar_y_Salir = true;
            this.ucGe_Menu.Enabled_bntImprimir = true;
            this.ucGe_Menu.Enabled_bntImprimir_Guia = true;
            this.ucGe_Menu.Enabled_bntLimpiar = true;
            this.ucGe_Menu.Enabled_bntSalir = true;
            this.ucGe_Menu.Enabled_btn_conciliacion_Auto = true;
            this.ucGe_Menu.Enabled_btn_DiseñoReporte = true;
            this.ucGe_Menu.Enabled_btn_Generar_XML = true;
            this.ucGe_Menu.Enabled_btn_Imprimir_Cbte = true;
            this.ucGe_Menu.Enabled_btn_Imprimir_Cheq = true;
            this.ucGe_Menu.Enabled_btn_Imprimir_Reten = true;
            this.ucGe_Menu.Enabled_btnAceptar = true;
            this.ucGe_Menu.Enabled_btnAprobarGuardarSalir = true;
            this.ucGe_Menu.Enabled_btnEstadosOC = true;
            this.ucGe_Menu.Enabled_btnGuardar = true;
            this.ucGe_Menu.Enabled_btnImpFrm = true;
            this.ucGe_Menu.Enabled_btnImpLote = true;
            this.ucGe_Menu.Enabled_btnImpRep = true;
            this.ucGe_Menu.Enabled_btnImprimirSoporte = true;
            this.ucGe_Menu.Enabled_btnproductos = true;
            this.ucGe_Menu.Location = new System.Drawing.Point(2, 2);
            this.ucGe_Menu.Name = "ucGe_Menu";
            this.ucGe_Menu.Size = new System.Drawing.Size(1021, 29);
            this.ucGe_Menu.TabIndex = 0;
            this.ucGe_Menu.Visible_bntAnular = false;
            this.ucGe_Menu.Visible_bntAprobar = false;
            this.ucGe_Menu.Visible_bntDiseñoReporte = false;
            this.ucGe_Menu.Visible_bntGuardar_y_Salir = true;
            this.ucGe_Menu.Visible_bntImprimir = false;
            this.ucGe_Menu.Visible_bntImprimir_Guia = false;
            this.ucGe_Menu.Visible_bntLimpiar = false;
            this.ucGe_Menu.Visible_bntReImprimir = false;
            this.ucGe_Menu.Visible_bntSalir = true;
            this.ucGe_Menu.Visible_btn_Actualizar = false;
            this.ucGe_Menu.Visible_btn_conciliacion_Auto = false;
            this.ucGe_Menu.Visible_btn_Generar_XML = false;
            this.ucGe_Menu.Visible_btn_Imprimir_Cbte = false;
            this.ucGe_Menu.Visible_btn_Imprimir_Cheq = false;
            this.ucGe_Menu.Visible_btn_Imprimir_Reten = false;
            this.ucGe_Menu.Visible_btnAceptar = false;
            this.ucGe_Menu.Visible_btnAprobarGuardarSalir = false;
            this.ucGe_Menu.Visible_btnContabilizar = false;
            this.ucGe_Menu.Visible_btnEstadosOC = false;
            this.ucGe_Menu.Visible_btnGuardar = true;
            this.ucGe_Menu.Visible_btnImpFrm = false;
            this.ucGe_Menu.Visible_btnImpLote = false;
            this.ucGe_Menu.Visible_btnImpRep = false;
            this.ucGe_Menu.Visible_btnImprimirSoporte = false;
            this.ucGe_Menu.Visible_btnModificar = false;
            this.ucGe_Menu.Visible_btnproductos = false;
            this.ucGe_Menu.event_btnGuardar_Click += new Core.Erp.Winform.Controles.UCGe_Menu_Superior_Mant.delegate_btnGuardar_Click(this.ucGe_Menu_event_btnGuardar_Click);
            this.ucGe_Menu.event_btnGuardar_y_Salir_Click += new Core.Erp.Winform.Controles.UCGe_Menu_Superior_Mant.delegate_btnGuardar_y_Salir_Click(this.ucGe_Menu_event_btnGuardar_y_Salir_Click);
            this.ucGe_Menu.event_btnSalir_Click += new Core.Erp.Winform.Controles.UCGe_Menu_Superior_Mant.delegate_btnSalir_Click(this.ucGe_Menu_event_btnSalir_Click);
            this.ucGe_Menu.Load += new System.EventHandler(this.ucGe_Menu_Load);
            // 
            // frm_Ro_empleados_x_extension_salud
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1025, 479);
            this.Controls.Add(this.panelControl1);
            this.Name = "frm_Ro_empleados_x_extension_salud";
            this.Text = "frm_Ro_empleados_x_extension_salud";
            this.Load += new System.EventHandler(this.frm_Ro_empleados_x_extension_salud_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_parametros)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_parametros)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_empleado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSearchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_nomina_tipo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_rubro)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_catalogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_nomina.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private Controles.UCGe_Menu_Superior_Mant ucGe_Menu;
        private System.Windows.Forms.ImageList imageList1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraGrid.GridControl gridControl_parametros;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_parametros;
        private DevExpress.XtraGrid.Columns.GridColumn col_NomCompleto;
        private DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit cmb_empleado;
        private DevExpress.XtraGrid.Views.Grid.GridView repositoryItemSearchLookUpEdit1View;
        private DevExpress.XtraGrid.Columns.GridColumn Col_Descripcion;
        private DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit cmb_nomina_tipo;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn Col_DescripcionProcesoNomina;
        private DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit cmb_rubro;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Columns.GridColumn Col_ru_descripcion;
        private DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit cmb_catalogo;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView3;
        private DevExpress.XtraGrid.Columns.GridColumn Col_ca_descripcion;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemImageComboBox1;
        private DevExpress.XtraGrid.Columns.GridColumn Observacion;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.SearchLookUpEdit cmb_nomina;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
        private DevExpress.XtraGrid.Columns.GridColumn col_ca_desp;
    }
}