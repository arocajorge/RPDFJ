namespace Core.Erp.Winform.Academico
{
    partial class FrmAcaExepciones_x_Estudiante
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
            this.gridCtrlExepcion_x_Estudiante = new DevExpress.XtraGrid.GridControl();
            this.gridvwExepcion_x_Estudiante = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Col_CodRubro = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Col_Descripcion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cmbRubro = new DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit();
            this.repositoryItemSearchLookUpEdit2View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Col_IdRubro = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Col_desc_rubro = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Col_ValorRubro = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Col_ValorExcepcion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Col_check = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Col_AnioLectivo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Col_IdPeriodo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cmbPeriodo = new DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit();
            this.repositoryItemSearchLookUpEdit3View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Col_Id_Periodo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Col_descripcion_Periodo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColDescuento = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cmbDescuento = new DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit();
            this.repositoryItemSearchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Col_Id_dscto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Col_descripcion_dscto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Col_porcentaje_excepcion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ucGe_Menu_Superior_Mant1 = new Core.Erp.Winform.Controles.UCGe_Menu_Superior_Mant();
            this.panel2 = new System.Windows.Forms.Panel();
            this.chkAplicarDescuento = new DevExpress.XtraEditors.CheckEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.ucAca_Estudiante1 = new Core.Erp.Winform.Controles.UCAca_Estudiante();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.gridCtrlExepcion_x_Estudiante)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridvwExepcion_x_Estudiante)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbRubro)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSearchLookUpEdit2View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPeriodo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSearchLookUpEdit3View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbDescuento)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSearchLookUpEdit1View)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkAplicarDescuento.Properties)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridCtrlExepcion_x_Estudiante
            // 
            this.gridCtrlExepcion_x_Estudiante.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridCtrlExepcion_x_Estudiante.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gridCtrlExepcion_x_Estudiante.Location = new System.Drawing.Point(0, 0);
            this.gridCtrlExepcion_x_Estudiante.MainView = this.gridvwExepcion_x_Estudiante;
            this.gridCtrlExepcion_x_Estudiante.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gridCtrlExepcion_x_Estudiante.Name = "gridCtrlExepcion_x_Estudiante";
            this.gridCtrlExepcion_x_Estudiante.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.cmbDescuento,
            this.cmbRubro,
            this.cmbPeriodo});
            this.gridCtrlExepcion_x_Estudiante.Size = new System.Drawing.Size(1473, 599);
            this.gridCtrlExepcion_x_Estudiante.TabIndex = 2;
            this.gridCtrlExepcion_x_Estudiante.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridvwExepcion_x_Estudiante});
            // 
            // gridvwExepcion_x_Estudiante
            // 
            this.gridvwExepcion_x_Estudiante.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.Col_CodRubro,
            this.Col_Descripcion,
            this.Col_ValorRubro,
            this.Col_ValorExcepcion,
            this.Col_check,
            this.Col_AnioLectivo,
            this.Col_IdPeriodo,
            this.ColDescuento,
            this.Col_porcentaje_excepcion});
            this.gridvwExepcion_x_Estudiante.GridControl = this.gridCtrlExepcion_x_Estudiante;
            this.gridvwExepcion_x_Estudiante.Name = "gridvwExepcion_x_Estudiante";
            this.gridvwExepcion_x_Estudiante.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.gridvwExepcion_x_Estudiante.OptionsView.ShowFooter = true;
            this.gridvwExepcion_x_Estudiante.OptionsView.ShowGroupedColumns = true;
            this.gridvwExepcion_x_Estudiante.OptionsView.ShowGroupPanel = false;
            this.gridvwExepcion_x_Estudiante.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridvwExepcion_x_Estudiante_CellValueChanged);
            this.gridvwExepcion_x_Estudiante.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridvwExepcion_x_Estudiante_KeyDown);
            // 
            // Col_CodRubro
            // 
            this.Col_CodRubro.Caption = "Codigo Rubro";
            this.Col_CodRubro.FieldName = "IdRubro";
            this.Col_CodRubro.Name = "Col_CodRubro";
            this.Col_CodRubro.OptionsColumn.AllowEdit = false;
            this.Col_CodRubro.Width = 124;
            // 
            // Col_Descripcion
            // 
            this.Col_Descripcion.Caption = "Rubro";
            this.Col_Descripcion.ColumnEdit = this.cmbRubro;
            this.Col_Descripcion.FieldName = "IdRubro";
            this.Col_Descripcion.Name = "Col_Descripcion";
            this.Col_Descripcion.Visible = true;
            this.Col_Descripcion.VisibleIndex = 2;
            this.Col_Descripcion.Width = 297;
            // 
            // cmbRubro
            // 
            this.cmbRubro.AutoHeight = false;
            this.cmbRubro.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbRubro.Name = "cmbRubro";
            this.cmbRubro.View = this.repositoryItemSearchLookUpEdit2View;
            // 
            // repositoryItemSearchLookUpEdit2View
            // 
            this.repositoryItemSearchLookUpEdit2View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.Col_IdRubro,
            this.Col_desc_rubro});
            this.repositoryItemSearchLookUpEdit2View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.repositoryItemSearchLookUpEdit2View.Name = "repositoryItemSearchLookUpEdit2View";
            this.repositoryItemSearchLookUpEdit2View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.repositoryItemSearchLookUpEdit2View.OptionsView.ShowGroupPanel = false;
            // 
            // Col_IdRubro
            // 
            this.Col_IdRubro.Caption = "Id";
            this.Col_IdRubro.FieldName = "IdRubro";
            this.Col_IdRubro.Name = "Col_IdRubro";
            this.Col_IdRubro.Visible = true;
            this.Col_IdRubro.VisibleIndex = 0;
            // 
            // Col_desc_rubro
            // 
            this.Col_desc_rubro.Caption = "Descripción";
            this.Col_desc_rubro.FieldName = "Descripcion_rubro";
            this.Col_desc_rubro.Name = "Col_desc_rubro";
            this.Col_desc_rubro.Visible = true;
            this.Col_desc_rubro.VisibleIndex = 1;
            // 
            // Col_ValorRubro
            // 
            this.Col_ValorRubro.Caption = "Valor Rubro";
            this.Col_ValorRubro.FieldName = "ValorRubro";
            this.Col_ValorRubro.Name = "Col_ValorRubro";
            this.Col_ValorRubro.Visible = true;
            this.Col_ValorRubro.VisibleIndex = 3;
            this.Col_ValorRubro.Width = 103;
            // 
            // Col_ValorExcepcion
            // 
            this.Col_ValorExcepcion.Caption = "Valor Excepcion";
            this.Col_ValorExcepcion.FieldName = "ValorExepcion";
            this.Col_ValorExcepcion.Name = "Col_ValorExcepcion";
            this.Col_ValorExcepcion.Visible = true;
            this.Col_ValorExcepcion.VisibleIndex = 6;
            this.Col_ValorExcepcion.Width = 151;
            // 
            // Col_check
            // 
            this.Col_check.Caption = "*";
            this.Col_check.FieldName = "check";
            this.Col_check.Name = "Col_check";
            this.Col_check.Width = 36;
            // 
            // Col_AnioLectivo
            // 
            this.Col_AnioLectivo.Caption = "Anio Lectivo";
            this.Col_AnioLectivo.FieldName = "AnioLectivo";
            this.Col_AnioLectivo.Name = "Col_AnioLectivo";
            this.Col_AnioLectivo.Visible = true;
            this.Col_AnioLectivo.VisibleIndex = 1;
            this.Col_AnioLectivo.Width = 90;
            // 
            // Col_IdPeriodo
            // 
            this.Col_IdPeriodo.Caption = "Periodo";
            this.Col_IdPeriodo.ColumnEdit = this.cmbPeriodo;
            this.Col_IdPeriodo.FieldName = "IdPeriodo";
            this.Col_IdPeriodo.Name = "Col_IdPeriodo";
            this.Col_IdPeriodo.Visible = true;
            this.Col_IdPeriodo.VisibleIndex = 0;
            this.Col_IdPeriodo.Width = 91;
            // 
            // cmbPeriodo
            // 
            this.cmbPeriodo.AutoHeight = false;
            this.cmbPeriodo.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbPeriodo.Name = "cmbPeriodo";
            this.cmbPeriodo.View = this.repositoryItemSearchLookUpEdit3View;
            // 
            // repositoryItemSearchLookUpEdit3View
            // 
            this.repositoryItemSearchLookUpEdit3View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.Col_Id_Periodo,
            this.Col_descripcion_Periodo});
            this.repositoryItemSearchLookUpEdit3View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.repositoryItemSearchLookUpEdit3View.Name = "repositoryItemSearchLookUpEdit3View";
            this.repositoryItemSearchLookUpEdit3View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.repositoryItemSearchLookUpEdit3View.OptionsView.ShowGroupPanel = false;
            // 
            // Col_Id_Periodo
            // 
            this.Col_Id_Periodo.Caption = "Id";
            this.Col_Id_Periodo.FieldName = "IdPeriodo";
            this.Col_Id_Periodo.Name = "Col_Id_Periodo";
            this.Col_Id_Periodo.Visible = true;
            this.Col_Id_Periodo.VisibleIndex = 0;
            // 
            // Col_descripcion_Periodo
            // 
            this.Col_descripcion_Periodo.Caption = "Descripción";
            this.Col_descripcion_Periodo.FieldName = "pe_Descripcion";
            this.Col_descripcion_Periodo.Name = "Col_descripcion_Periodo";
            // 
            // ColDescuento
            // 
            this.ColDescuento.Caption = "Descuento";
            this.ColDescuento.ColumnEdit = this.cmbDescuento;
            this.ColDescuento.FieldName = "IdDescuento";
            this.ColDescuento.Name = "ColDescuento";
            this.ColDescuento.Visible = true;
            this.ColDescuento.VisibleIndex = 4;
            this.ColDescuento.Width = 310;
            // 
            // cmbDescuento
            // 
            this.cmbDescuento.AutoHeight = false;
            this.cmbDescuento.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbDescuento.Name = "cmbDescuento";
            this.cmbDescuento.View = this.repositoryItemSearchLookUpEdit1View;
            // 
            // repositoryItemSearchLookUpEdit1View
            // 
            this.repositoryItemSearchLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.Col_Id_dscto,
            this.Col_descripcion_dscto});
            this.repositoryItemSearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.repositoryItemSearchLookUpEdit1View.Name = "repositoryItemSearchLookUpEdit1View";
            this.repositoryItemSearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.repositoryItemSearchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // Col_Id_dscto
            // 
            this.Col_Id_dscto.Caption = "Id";
            this.Col_Id_dscto.FieldName = "IdDescuento";
            this.Col_Id_dscto.Name = "Col_Id_dscto";
            this.Col_Id_dscto.Visible = true;
            this.Col_Id_dscto.VisibleIndex = 0;
            // 
            // Col_descripcion_dscto
            // 
            this.Col_descripcion_dscto.Caption = "Descripción";
            this.Col_descripcion_dscto.FieldName = "de_nombre";
            this.Col_descripcion_dscto.Name = "Col_descripcion_dscto";
            this.Col_descripcion_dscto.Visible = true;
            this.Col_descripcion_dscto.VisibleIndex = 1;
            // 
            // Col_porcentaje_excepcion
            // 
            this.Col_porcentaje_excepcion.Caption = "% Descuento";
            this.Col_porcentaje_excepcion.FieldName = "porcentaje_excepcion";
            this.Col_porcentaje_excepcion.Name = "Col_porcentaje_excepcion";
            this.Col_porcentaje_excepcion.Visible = true;
            this.Col_porcentaje_excepcion.VisibleIndex = 5;
            this.Col_porcentaje_excepcion.Width = 138;
            // 
            // ucGe_Menu_Superior_Mant1
            // 
            this.ucGe_Menu_Superior_Mant1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucGe_Menu_Superior_Mant1.Enabled_bnRetImprimir = true;
            this.ucGe_Menu_Superior_Mant1.Enabled_bntAnular = true;
            this.ucGe_Menu_Superior_Mant1.Enabled_bntAprobar = true;
            this.ucGe_Menu_Superior_Mant1.Enabled_bntGuardar_y_Salir = true;
            this.ucGe_Menu_Superior_Mant1.Enabled_bntImprimir = true;
            this.ucGe_Menu_Superior_Mant1.Enabled_bntImprimir_Guia = true;
            this.ucGe_Menu_Superior_Mant1.Enabled_bntLimpiar = true;
            this.ucGe_Menu_Superior_Mant1.Enabled_bntSalir = true;
            this.ucGe_Menu_Superior_Mant1.Enabled_btn_conciliacion_Auto = true;
            this.ucGe_Menu_Superior_Mant1.Enabled_btn_DiseñoReporte = true;
            this.ucGe_Menu_Superior_Mant1.Enabled_btn_Generar_XML = true;
            this.ucGe_Menu_Superior_Mant1.Enabled_btn_Imprimir_Cbte = true;
            this.ucGe_Menu_Superior_Mant1.Enabled_btn_Imprimir_Cheq = true;
            this.ucGe_Menu_Superior_Mant1.Enabled_btn_Imprimir_Reten = true;
            this.ucGe_Menu_Superior_Mant1.Enabled_btnAceptar = true;
            this.ucGe_Menu_Superior_Mant1.Enabled_btnAprobarGuardarSalir = true;
            this.ucGe_Menu_Superior_Mant1.Enabled_btnEstadosOC = true;
            this.ucGe_Menu_Superior_Mant1.Enabled_btnGuardar = true;
            this.ucGe_Menu_Superior_Mant1.Enabled_btnImpFrm = true;
            this.ucGe_Menu_Superior_Mant1.Enabled_btnImpLote = true;
            this.ucGe_Menu_Superior_Mant1.Enabled_btnImpRep = true;
            this.ucGe_Menu_Superior_Mant1.Enabled_btnImprimirSoporte = true;
            this.ucGe_Menu_Superior_Mant1.Enabled_btnproductos = true;
            this.ucGe_Menu_Superior_Mant1.Location = new System.Drawing.Point(0, 0);
            this.ucGe_Menu_Superior_Mant1.Margin = new System.Windows.Forms.Padding(5);
            this.ucGe_Menu_Superior_Mant1.Name = "ucGe_Menu_Superior_Mant1";
            this.ucGe_Menu_Superior_Mant1.Size = new System.Drawing.Size(1473, 26);
            this.ucGe_Menu_Superior_Mant1.TabIndex = 3;
            this.ucGe_Menu_Superior_Mant1.Visible_bntAnular = false;
            this.ucGe_Menu_Superior_Mant1.Visible_bntAprobar = false;
            this.ucGe_Menu_Superior_Mant1.Visible_bntDiseñoReporte = false;
            this.ucGe_Menu_Superior_Mant1.Visible_bntGuardar_y_Salir = true;
            this.ucGe_Menu_Superior_Mant1.Visible_bntImprimir = false;
            this.ucGe_Menu_Superior_Mant1.Visible_bntImprimir_Guia = false;
            this.ucGe_Menu_Superior_Mant1.Visible_bntLimpiar = false;
            this.ucGe_Menu_Superior_Mant1.Visible_bntReImprimir = false;
            this.ucGe_Menu_Superior_Mant1.Visible_bntSalir = true;
            this.ucGe_Menu_Superior_Mant1.Visible_btn_Actualizar = false;
            this.ucGe_Menu_Superior_Mant1.Visible_btn_conciliacion_Auto = false;
            this.ucGe_Menu_Superior_Mant1.Visible_btn_Generar_XML = false;
            this.ucGe_Menu_Superior_Mant1.Visible_btn_Imprimir_Cbte = false;
            this.ucGe_Menu_Superior_Mant1.Visible_btn_Imprimir_Cheq = false;
            this.ucGe_Menu_Superior_Mant1.Visible_btn_Imprimir_Reten = false;
            this.ucGe_Menu_Superior_Mant1.Visible_btnAceptar = false;
            this.ucGe_Menu_Superior_Mant1.Visible_btnAprobarGuardarSalir = false;
            this.ucGe_Menu_Superior_Mant1.Visible_btnContabilizar = false;
            this.ucGe_Menu_Superior_Mant1.Visible_btnEstadosOC = false;
            this.ucGe_Menu_Superior_Mant1.Visible_btnGuardar = true;
            this.ucGe_Menu_Superior_Mant1.Visible_btnImpFrm = false;
            this.ucGe_Menu_Superior_Mant1.Visible_btnImpLote = false;
            this.ucGe_Menu_Superior_Mant1.Visible_btnImpRep = false;
            this.ucGe_Menu_Superior_Mant1.Visible_btnImprimirSoporte = false;
            this.ucGe_Menu_Superior_Mant1.Visible_btnModificar = false;
            this.ucGe_Menu_Superior_Mant1.Visible_btnproductos = false;
            this.ucGe_Menu_Superior_Mant1.event_btnGuardar_Click += new Core.Erp.Winform.Controles.UCGe_Menu_Superior_Mant.delegate_btnGuardar_Click(this.ucGe_Menu_Superior_Mant1_event_btnGuardar_Click);
            this.ucGe_Menu_Superior_Mant1.event_btnGuardar_y_Salir_Click += new Core.Erp.Winform.Controles.UCGe_Menu_Superior_Mant.delegate_btnGuardar_y_Salir_Click(this.ucGe_Menu_Superior_Mant1_event_btnGuardar_y_Salir_Click);
            this.ucGe_Menu_Superior_Mant1.event_btnSalir_Click += new Core.Erp.Winform.Controles.UCGe_Menu_Superior_Mant.delegate_btnSalir_Click(this.ucGe_Menu_Superior_Mant1_event_btnSalir_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.chkAplicarDescuento);
            this.panel2.Controls.Add(this.labelControl1);
            this.panel2.Controls.Add(this.ucAca_Estudiante1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 26);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1473, 64);
            this.panel2.TabIndex = 26;
            // 
            // chkAplicarDescuento
            // 
            this.chkAplicarDescuento.Location = new System.Drawing.Point(597, 16);
            this.chkAplicarDescuento.Margin = new System.Windows.Forms.Padding(4);
            this.chkAplicarDescuento.Name = "chkAplicarDescuento";
            this.chkAplicarDescuento.Properties.Caption = "Aplicar descuento a todos";
            this.chkAplicarDescuento.Size = new System.Drawing.Size(193, 21);
            this.chkAplicarDescuento.TabIndex = 151;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(25, 18);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(59, 16);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "Estudiante";
            // 
            // ucAca_Estudiante1
            // 
            this.ucAca_Estudiante1.Location = new System.Drawing.Point(116, 10);
            this.ucAca_Estudiante1.Margin = new System.Windows.Forms.Padding(5);
            this.ucAca_Estudiante1.Name = "ucAca_Estudiante1";
            this.ucAca_Estudiante1.Size = new System.Drawing.Size(413, 33);
            this.ucAca_Estudiante1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.gridCtrlExepcion_x_Estudiante);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 90);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1473, 599);
            this.panel1.TabIndex = 27;
            // 
            // FrmAcaExepciones_x_Estudiante
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1473, 689);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.ucGe_Menu_Superior_Mant1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FrmAcaExepciones_x_Estudiante";
            this.Text = "FrmExepciones_x_Estudiante";
            this.Load += new System.EventHandler(this.FrmAcaExepciones_x_Estudiante_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridCtrlExepcion_x_Estudiante)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridvwExepcion_x_Estudiante)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbRubro)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSearchLookUpEdit2View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPeriodo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSearchLookUpEdit3View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbDescuento)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSearchLookUpEdit1View)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkAplicarDescuento.Properties)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Controles.UCGe_Menu_Superior_Mant ucGe_Menu_Superior_Mant1;
        private DevExpress.XtraGrid.GridControl gridCtrlExepcion_x_Estudiante;
        private DevExpress.XtraGrid.Columns.GridColumn Col_CodRubro;
        private DevExpress.XtraGrid.Columns.GridColumn Col_Descripcion;
        private DevExpress.XtraGrid.Columns.GridColumn Col_ValorRubro;
        private DevExpress.XtraGrid.Columns.GridColumn Col_ValorExcepcion;
        private DevExpress.XtraGrid.Columns.GridColumn Col_check;
        private DevExpress.XtraGrid.Columns.GridColumn Col_AnioLectivo;
        private DevExpress.XtraGrid.Columns.GridColumn Col_IdPeriodo;
        private DevExpress.XtraGrid.Columns.GridColumn ColDescuento;
        private DevExpress.XtraGrid.Columns.GridColumn Col_porcentaje_excepcion;
        private DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit cmbDescuento;
        private DevExpress.XtraGrid.Views.Grid.GridView repositoryItemSearchLookUpEdit1View;
        private DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit cmbRubro;
        private DevExpress.XtraGrid.Views.Grid.GridView repositoryItemSearchLookUpEdit2View;
        private DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit cmbPeriodo;
        private DevExpress.XtraGrid.Views.Grid.GridView repositoryItemSearchLookUpEdit3View;
        private DevExpress.XtraGrid.Columns.GridColumn Col_IdRubro;
        private DevExpress.XtraGrid.Columns.GridColumn Col_desc_rubro;
        private DevExpress.XtraGrid.Columns.GridColumn Col_Id_Periodo;
        private DevExpress.XtraGrid.Columns.GridColumn Col_descripcion_Periodo;
        private DevExpress.XtraGrid.Columns.GridColumn Col_Id_dscto;
        private DevExpress.XtraGrid.Columns.GridColumn Col_descripcion_dscto;
        public DevExpress.XtraGrid.Views.Grid.GridView gridvwExepcion_x_Estudiante;
        private System.Windows.Forms.Panel panel2;
        private DevExpress.XtraEditors.CheckEdit chkAplicarDescuento;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private Controles.UCAca_Estudiante ucAca_Estudiante1;
        private System.Windows.Forms.Panel panel1;
    }
}