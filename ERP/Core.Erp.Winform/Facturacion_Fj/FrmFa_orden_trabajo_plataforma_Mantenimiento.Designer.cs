namespace Core.Erp.Winform.Facturacion_Fj
{
    partial class FrmFa_orden_trabajo_plataforma_Mantenimiento
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
            this.ucGe_Menu_Superior_Mant1 = new Core.Erp.Winform.Controles.UCGe_Menu_Superior_Mant();
            this.ucGe_BarraEstadoInferior_Forms1 = new Core.Erp.Winform.Controles.UCGe_BarraEstadoInferior_Forms();
            this.panelPrincipal = new System.Windows.Forms.Panel();
            this.panelDetalle = new System.Windows.Forms.Panel();
            this.groupBoxDetalle = new System.Windows.Forms.GroupBox();
            this.gridControlOrden_Det = new DevExpress.XtraGrid.GridControl();
            this.gridViewOrden_Det = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.coldescrip_equipo_movi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colpunto_partida = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colpunto_llegada = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colhora_ini = new DevExpress.XtraGrid.Columns.GridColumn();
            this.teHoras = new DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit();
            this.colhora_fin = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colValor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelCabecera = new System.Windows.Forms.Panel();
            this.cmb_transportista = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cmb_vendedor = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cmb_punto_cargo = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.txt_num_factura = new DevExpress.XtraEditors.TextEdit();
            this.labelControl10 = new DevExpress.XtraEditors.LabelControl();
            this.lblanulado = new System.Windows.Forms.Label();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.txtKilometraje_llegada = new DevExpress.XtraEditors.TextEdit();
            this.txtKilometraje_salida = new DevExpress.XtraEditors.TextEdit();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.txtDescripcion = new DevExpress.XtraEditors.TextEdit();
            this.ucFa_ClienteCmb1 = new Core.Erp.Winform.Controles.UCFa_ClienteCmb();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtCodigo = new DevExpress.XtraEditors.TextEdit();
            this.deFecha = new DevExpress.XtraEditors.DateEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.panelPrincipal.SuspendLayout();
            this.panelDetalle.SuspendLayout();
            this.groupBoxDetalle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlOrden_Det)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewOrden_Det)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teHoras)).BeginInit();
            this.panelCabecera.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_transportista.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_vendedor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_punto_cargo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_num_factura.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKilometraje_llegada.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKilometraje_salida.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescripcion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCodigo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFecha.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFecha.Properties)).BeginInit();
            this.SuspendLayout();
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
            this.ucGe_Menu_Superior_Mant1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.ucGe_Menu_Superior_Mant1.Name = "ucGe_Menu_Superior_Mant1";
            this.ucGe_Menu_Superior_Mant1.Size = new System.Drawing.Size(1257, 36);
            this.ucGe_Menu_Superior_Mant1.TabIndex = 0;
            this.ucGe_Menu_Superior_Mant1.Visible_bntAnular = true;
            this.ucGe_Menu_Superior_Mant1.Visible_bntAprobar = false;
            this.ucGe_Menu_Superior_Mant1.Visible_bntDiseñoReporte = false;
            this.ucGe_Menu_Superior_Mant1.Visible_bntGuardar_y_Salir = true;
            this.ucGe_Menu_Superior_Mant1.Visible_bntImprimir = true;
            this.ucGe_Menu_Superior_Mant1.Visible_bntImprimir_Guia = false;
            this.ucGe_Menu_Superior_Mant1.Visible_bntLimpiar = true;
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
            // 
            // ucGe_BarraEstadoInferior_Forms1
            // 
            this.ucGe_BarraEstadoInferior_Forms1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ucGe_BarraEstadoInferior_Forms1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ucGe_BarraEstadoInferior_Forms1.Location = new System.Drawing.Point(0, 572);
            this.ucGe_BarraEstadoInferior_Forms1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.ucGe_BarraEstadoInferior_Forms1.Name = "ucGe_BarraEstadoInferior_Forms1";
            this.ucGe_BarraEstadoInferior_Forms1.Size = new System.Drawing.Size(1257, 32);
            this.ucGe_BarraEstadoInferior_Forms1.TabIndex = 1;
            // 
            // panelPrincipal
            // 
            this.panelPrincipal.Controls.Add(this.panelDetalle);
            this.panelPrincipal.Controls.Add(this.panelCabecera);
            this.panelPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelPrincipal.Location = new System.Drawing.Point(0, 36);
            this.panelPrincipal.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelPrincipal.Name = "panelPrincipal";
            this.panelPrincipal.Size = new System.Drawing.Size(1257, 536);
            this.panelPrincipal.TabIndex = 2;
            // 
            // panelDetalle
            // 
            this.panelDetalle.Controls.Add(this.groupBoxDetalle);
            this.panelDetalle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDetalle.Location = new System.Drawing.Point(0, 154);
            this.panelDetalle.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelDetalle.Name = "panelDetalle";
            this.panelDetalle.Size = new System.Drawing.Size(1257, 382);
            this.panelDetalle.TabIndex = 7;
            // 
            // groupBoxDetalle
            // 
            this.groupBoxDetalle.Controls.Add(this.gridControlOrden_Det);
            this.groupBoxDetalle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxDetalle.Location = new System.Drawing.Point(0, 0);
            this.groupBoxDetalle.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBoxDetalle.Name = "groupBoxDetalle";
            this.groupBoxDetalle.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBoxDetalle.Size = new System.Drawing.Size(1257, 382);
            this.groupBoxDetalle.TabIndex = 0;
            this.groupBoxDetalle.TabStop = false;
            this.groupBoxDetalle.Text = "Detalle";
            // 
            // gridControlOrden_Det
            // 
            this.gridControlOrden_Det.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlOrden_Det.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gridControlOrden_Det.Location = new System.Drawing.Point(4, 19);
            this.gridControlOrden_Det.MainView = this.gridViewOrden_Det;
            this.gridControlOrden_Det.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gridControlOrden_Det.Name = "gridControlOrden_Det";
            this.gridControlOrden_Det.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.teHoras});
            this.gridControlOrden_Det.Size = new System.Drawing.Size(1249, 359);
            this.gridControlOrden_Det.TabIndex = 0;
            this.gridControlOrden_Det.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewOrden_Det});
            // 
            // gridViewOrden_Det
            // 
            this.gridViewOrden_Det.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.coldescrip_equipo_movi,
            this.colpunto_partida,
            this.colpunto_llegada,
            this.colhora_ini,
            this.colhora_fin,
            this.colValor});
            this.gridViewOrden_Det.GridControl = this.gridControlOrden_Det;
            this.gridViewOrden_Det.Name = "gridViewOrden_Det";
            this.gridViewOrden_Det.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.gridViewOrden_Det.OptionsView.ShowAutoFilterRow = true;
            this.gridViewOrden_Det.OptionsView.ShowGroupPanel = false;
            this.gridViewOrden_Det.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridViewOrden_Det_KeyDown);
            // 
            // coldescrip_equipo_movi
            // 
            this.coldescrip_equipo_movi.Caption = "Descripción del equipo movilizado";
            this.coldescrip_equipo_movi.FieldName = "descrip_equipo_movi";
            this.coldescrip_equipo_movi.Name = "coldescrip_equipo_movi";
            this.coldescrip_equipo_movi.Visible = true;
            this.coldescrip_equipo_movi.VisibleIndex = 0;
            this.coldescrip_equipo_movi.Width = 282;
            // 
            // colpunto_partida
            // 
            this.colpunto_partida.Caption = "Punto de partida";
            this.colpunto_partida.FieldName = "punto_partida";
            this.colpunto_partida.Name = "colpunto_partida";
            this.colpunto_partida.Visible = true;
            this.colpunto_partida.VisibleIndex = 1;
            this.colpunto_partida.Width = 105;
            // 
            // colpunto_llegada
            // 
            this.colpunto_llegada.Caption = "Punto de llegada";
            this.colpunto_llegada.FieldName = "punto_llegada";
            this.colpunto_llegada.Name = "colpunto_llegada";
            this.colpunto_llegada.Visible = true;
            this.colpunto_llegada.VisibleIndex = 2;
            this.colpunto_llegada.Width = 105;
            // 
            // colhora_ini
            // 
            this.colhora_ini.Caption = "Hora inicio";
            this.colhora_ini.ColumnEdit = this.teHoras;
            this.colhora_ini.FieldName = "hora_ini_D";
            this.colhora_ini.Name = "colhora_ini";
            this.colhora_ini.Visible = true;
            this.colhora_ini.VisibleIndex = 3;
            this.colhora_ini.Width = 105;
            // 
            // teHoras
            // 
            this.teHoras.AutoHeight = false;
            this.teHoras.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.teHoras.Name = "teHoras";
            // 
            // colhora_fin
            // 
            this.colhora_fin.Caption = "Hora fin";
            this.colhora_fin.ColumnEdit = this.teHoras;
            this.colhora_fin.FieldName = "hora_fin_D";
            this.colhora_fin.Name = "colhora_fin";
            this.colhora_fin.Visible = true;
            this.colhora_fin.VisibleIndex = 4;
            this.colhora_fin.Width = 105;
            // 
            // colValor
            // 
            this.colValor.Caption = "Valor";
            this.colValor.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colValor.FieldName = "Valor";
            this.colValor.Name = "colValor";
            this.colValor.Visible = true;
            this.colValor.VisibleIndex = 5;
            this.colValor.Width = 110;
            // 
            // panelCabecera
            // 
            this.panelCabecera.Controls.Add(this.cmb_transportista);
            this.panelCabecera.Controls.Add(this.cmb_vendedor);
            this.panelCabecera.Controls.Add(this.cmb_punto_cargo);
            this.panelCabecera.Controls.Add(this.txt_num_factura);
            this.panelCabecera.Controls.Add(this.labelControl10);
            this.panelCabecera.Controls.Add(this.lblanulado);
            this.panelCabecera.Controls.Add(this.labelControl9);
            this.panelCabecera.Controls.Add(this.txtKilometraje_llegada);
            this.panelCabecera.Controls.Add(this.txtKilometraje_salida);
            this.panelCabecera.Controls.Add(this.labelControl7);
            this.panelCabecera.Controls.Add(this.labelControl8);
            this.panelCabecera.Controls.Add(this.txtDescripcion);
            this.panelCabecera.Controls.Add(this.ucFa_ClienteCmb1);
            this.panelCabecera.Controls.Add(this.labelControl3);
            this.panelCabecera.Controls.Add(this.labelControl6);
            this.panelCabecera.Controls.Add(this.labelControl5);
            this.panelCabecera.Controls.Add(this.labelControl4);
            this.panelCabecera.Controls.Add(this.labelControl1);
            this.panelCabecera.Controls.Add(this.txtCodigo);
            this.panelCabecera.Controls.Add(this.deFecha);
            this.panelCabecera.Controls.Add(this.labelControl2);
            this.panelCabecera.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelCabecera.Location = new System.Drawing.Point(0, 0);
            this.panelCabecera.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelCabecera.Name = "panelCabecera";
            this.panelCabecera.Size = new System.Drawing.Size(1257, 154);
            this.panelCabecera.TabIndex = 6;
            // 
            // cmb_transportista
            // 
            this.cmb_transportista.Location = new System.Drawing.Point(148, 97);
            this.cmb_transportista.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmb_transportista.Name = "cmb_transportista";
            this.cmb_transportista.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmb_transportista.Properties.DisplayMember = "Nombre";
            this.cmb_transportista.Properties.ValueMember = "IdTransportista";
            this.cmb_transportista.Properties.View = this.gridView2;
            this.cmb_transportista.Size = new System.Drawing.Size(381, 22);
            this.cmb_transportista.TabIndex = 6;
            // 
            // gridView2
            // 
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn5,
            this.gridColumn6});
            this.gridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView2.OptionsView.ShowAutoFilterRow = true;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Transportista";
            this.gridColumn5.FieldName = "Nombre";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 0;
            this.gridColumn5.Width = 1581;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "ID";
            this.gridColumn6.FieldName = "IdTransportista";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 1;
            this.gridColumn6.Width = 153;
            // 
            // cmb_vendedor
            // 
            this.cmb_vendedor.Location = new System.Drawing.Point(688, 69);
            this.cmb_vendedor.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmb_vendedor.Name = "cmb_vendedor";
            this.cmb_vendedor.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmb_vendedor.Properties.DisplayMember = "Ve_Vendedor";
            this.cmb_vendedor.Properties.ValueMember = "IdVendedor";
            this.cmb_vendedor.Properties.View = this.gridView1;
            this.cmb_vendedor.Size = new System.Drawing.Size(375, 22);
            this.cmb_vendedor.TabIndex = 5;
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn3,
            this.gridColumn4});
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Vendedor";
            this.gridColumn3.FieldName = "Ve_Vendedor";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 0;
            this.gridColumn3.Width = 1582;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "ID";
            this.gridColumn4.FieldName = "IdVendedor";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 1;
            this.gridColumn4.Width = 152;
            // 
            // cmb_punto_cargo
            // 
            this.cmb_punto_cargo.Location = new System.Drawing.Point(148, 69);
            this.cmb_punto_cargo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmb_punto_cargo.Name = "cmb_punto_cargo";
            this.cmb_punto_cargo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmb_punto_cargo.Properties.DisplayMember = "nom_punto_cargo";
            this.cmb_punto_cargo.Properties.ValueMember = "IdPunto_cargo";
            this.cmb_punto_cargo.Properties.View = this.searchLookUpEdit1View;
            this.cmb_punto_cargo.Size = new System.Drawing.Size(381, 22);
            this.cmb_punto_cargo.TabIndex = 4;
            // 
            // searchLookUpEdit1View
            // 
            this.searchLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2});
            this.searchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpEdit1View.Name = "searchLookUpEdit1View";
            this.searchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpEdit1View.OptionsView.ShowAutoFilterRow = true;
            this.searchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "ID";
            this.gridColumn1.FieldName = "IdPunto_cargo";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 1;
            this.gridColumn1.Width = 193;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Punto de cargo";
            this.gridColumn2.FieldName = "nom_punto_cargo";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 0;
            this.gridColumn2.Width = 1531;
            // 
            // txt_num_factura
            // 
            this.txt_num_factura.Location = new System.Drawing.Point(147, 124);
            this.txt_num_factura.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txt_num_factura.Name = "txt_num_factura";
            this.txt_num_factura.Size = new System.Drawing.Size(383, 22);
            this.txt_num_factura.TabIndex = 9;
            // 
            // labelControl10
            // 
            this.labelControl10.Location = new System.Drawing.Point(28, 128);
            this.labelControl10.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.labelControl10.Name = "labelControl10";
            this.labelControl10.Size = new System.Drawing.Size(61, 16);
            this.labelControl10.TabIndex = 93;
            this.labelControl10.Text = "# Factura:";
            // 
            // lblanulado
            // 
            this.lblanulado.AutoSize = true;
            this.lblanulado.BackColor = System.Drawing.SystemColors.Control;
            this.lblanulado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblanulado.ForeColor = System.Drawing.Color.Red;
            this.lblanulado.Location = new System.Drawing.Point(485, 10);
            this.lblanulado.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblanulado.Name = "lblanulado";
            this.lblanulado.Size = new System.Drawing.Size(147, 20);
            this.lblanulado.TabIndex = 92;
            this.lblanulado.Text = "****ANULADO***";
            this.lblanulado.Visible = false;
            // 
            // labelControl9
            // 
            this.labelControl9.Location = new System.Drawing.Point(565, 73);
            this.labelControl9.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(60, 16);
            this.labelControl9.TabIndex = 19;
            this.labelControl9.Text = "Vendedor:";
            // 
            // txtKilometraje_llegada
            // 
            this.txtKilometraje_llegada.Location = new System.Drawing.Point(943, 97);
            this.txtKilometraje_llegada.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtKilometraje_llegada.Name = "txtKilometraje_llegada";
            this.txtKilometraje_llegada.Properties.Mask.EditMask = "d";
            this.txtKilometraje_llegada.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtKilometraje_llegada.Size = new System.Drawing.Size(120, 22);
            this.txtKilometraje_llegada.TabIndex = 8;
            // 
            // txtKilometraje_salida
            // 
            this.txtKilometraje_salida.Location = new System.Drawing.Point(688, 97);
            this.txtKilometraje_salida.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtKilometraje_salida.Name = "txtKilometraje_salida";
            this.txtKilometraje_salida.Properties.Mask.EditMask = "d";
            this.txtKilometraje_salida.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtKilometraje_salida.Size = new System.Drawing.Size(139, 22);
            this.txtKilometraje_salida.TabIndex = 7;
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(843, 101);
            this.labelControl7.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(85, 16);
            this.labelControl7.TabIndex = 16;
            this.labelControl7.Text = "km de llegada:";
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(565, 101);
            this.labelControl8.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(77, 16);
            this.labelControl8.TabIndex = 15;
            this.labelControl8.Text = "km de salida:";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(147, 41);
            this.txtDescripcion.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(383, 22);
            this.txtDescripcion.TabIndex = 2;
            // 
            // ucFa_ClienteCmb1
            // 
            this.ucFa_ClienteCmb1.Location = new System.Drawing.Point(684, 33);
            this.ucFa_ClienteCmb1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.ucFa_ClienteCmb1.Name = "ucFa_ClienteCmb1";
            this.ucFa_ClienteCmb1.Size = new System.Drawing.Size(379, 32);
            this.ucFa_ClienteCmb1.TabIndex = 3;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(565, 44);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(44, 16);
            this.labelControl3.TabIndex = 10;
            this.labelControl3.Text = "Cliente:";
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(28, 101);
            this.labelControl6.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(43, 16);
            this.labelControl6.TabIndex = 8;
            this.labelControl6.Text = "Chofer:";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(28, 44);
            this.labelControl5.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(70, 16);
            this.labelControl5.TabIndex = 7;
            this.labelControl5.Text = "Descripción:";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(28, 73);
            this.labelControl4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(103, 16);
            this.labelControl4.TabIndex = 6;
            this.labelControl4.Text = "Nombre máquina:";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(28, 16);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(44, 16);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Código:";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(148, 14);
            this.txtCodigo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(133, 22);
            this.txtCodigo.TabIndex = 0;
            // 
            // deFecha
            // 
            this.deFecha.EditValue = null;
            this.deFecha.Location = new System.Drawing.Point(913, 10);
            this.deFecha.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.deFecha.Name = "deFecha";
            this.deFecha.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deFecha.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.deFecha.Size = new System.Drawing.Size(149, 22);
            this.deFecha.TabIndex = 1;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(843, 14);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(39, 16);
            this.labelControl2.TabIndex = 3;
            this.labelControl2.Text = "Fecha:";
            // 
            // FrmFa_orden_trabajo_plataforma_Mantenimiento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1257, 604);
            this.Controls.Add(this.panelPrincipal);
            this.Controls.Add(this.ucGe_BarraEstadoInferior_Forms1);
            this.Controls.Add(this.ucGe_Menu_Superior_Mant1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FrmFa_orden_trabajo_plataforma_Mantenimiento";
            this.Text = "Orden de trabajo mantenimiento";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmFa_orden_trabajo_plataforma_Mantenimiento_FormClosing);
            this.Load += new System.EventHandler(this.FrmFa_orden_trabajo_plataforma_Mantenimiento_Load);
            this.panelPrincipal.ResumeLayout(false);
            this.panelDetalle.ResumeLayout(false);
            this.groupBoxDetalle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlOrden_Det)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewOrden_Det)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teHoras)).EndInit();
            this.panelCabecera.ResumeLayout(false);
            this.panelCabecera.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_transportista.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_vendedor.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_punto_cargo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_num_factura.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKilometraje_llegada.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKilometraje_salida.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescripcion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCodigo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFecha.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFecha.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Controles.UCGe_Menu_Superior_Mant ucGe_Menu_Superior_Mant1;
        private Controles.UCGe_BarraEstadoInferior_Forms ucGe_BarraEstadoInferior_Forms1;
        private System.Windows.Forms.Panel panelPrincipal;
        private DevExpress.XtraEditors.TextEdit txtCodigo;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.DateEdit deFecha;
        private System.Windows.Forms.Panel panelCabecera;
        private System.Windows.Forms.Panel panelDetalle;
        private System.Windows.Forms.GroupBox groupBoxDetalle;
        private DevExpress.XtraGrid.GridControl gridControlOrden_Det;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewOrden_Det;
        private DevExpress.XtraGrid.Columns.GridColumn coldescrip_equipo_movi;
        private DevExpress.XtraGrid.Columns.GridColumn colpunto_partida;
        private DevExpress.XtraGrid.Columns.GridColumn colpunto_llegada;
        private DevExpress.XtraGrid.Columns.GridColumn colhora_ini;
        private DevExpress.XtraGrid.Columns.GridColumn colhora_fin;
        private DevExpress.XtraGrid.Columns.GridColumn colValor;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit txtDescripcion;
        private Controles.UCFa_ClienteCmb ucFa_ClienteCmb1;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit txtKilometraje_llegada;
        private DevExpress.XtraEditors.TextEdit txtKilometraje_salida;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private System.Windows.Forms.Label lblanulado;
        private DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit teHoras;
        private DevExpress.XtraEditors.TextEdit txt_num_factura;
        private DevExpress.XtraEditors.LabelControl labelControl10;
        private DevExpress.XtraEditors.SearchLookUpEdit cmb_punto_cargo;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraEditors.SearchLookUpEdit cmb_vendedor;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraEditors.SearchLookUpEdit cmb_transportista;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
    }
}