﻿namespace Core.Erp.Winform.Inventario
{
    partial class FrmIn_Ingreso_varios_Mant
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmIn_Ingreso_varios_Mant));
            this.ucGe_BarraEstadoInferior_Forms1 = new Core.Erp.Winform.Controles.UCGe_BarraEstadoInferior_Forms();
            this.ucGe_Menu_Superior_Mant1 = new Core.Erp.Winform.Controles.UCGe_Menu_Superior_Mant();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txt_orden_mantenimiento = new DevExpress.XtraEditors.TextEdit();
            this.lbl_orden_mantenimiento = new System.Windows.Forms.Label();
            this.lblPlantilla = new System.Windows.Forms.LinkLabel();
            this.cmb_Estado_apro_x_Ing_Egr_Inven1 = new Core.Erp.Winform.Controles.UCInv_Estado_apro_x_Ing_Egr_Inven();
            this.lblNum_Movi_Inven = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbTipoMovi = new Core.Erp.Winform.Controles.UCIn_TipoMoviInv_Cmb();
            this.cmbMotivoInv = new Core.Erp.Winform.Controles.UCIn_MotivoInvCmb();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblAnulado = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtObservacion = new System.Windows.Forms.TextBox();
            this.ucIn_Sucursal_Bodega1 = new Core.Erp.Winform.Controles.UCIn_Sucursal_Bodega();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.txtNumIngreso = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.gridControlProductos = new DevExpress.XtraGrid.GridControl();
            this.gridViewProductos = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colNuevoProducto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemImageEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemImageEdit();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.colSecuencia = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIdProducto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cmbProducto_grid = new DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit();
            this.repositoryItemSearchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colIdProducto_cmbgrid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colpr_codigo_cmbgrid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colpr_descripcion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colpr_precio_publico = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colpr_stock = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colpr_pedidos = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colpr_ManejaIva = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colpr_costo_promedio = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colpr_peso = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coldm_cantidad_sin_conversion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coldm_cantidad_convertida = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colmv_costo_sin_conversion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colmv_costo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coldm_observacion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIdCentroCosto_grid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cmbCentroCosto_grid = new DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colIdCentroCosto_cmbgrid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCentro_costo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colpc_Estado = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIdPunto_cargo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cmbPuntoCargo_grid = new DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit();
            this.gridView4 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colIdPunto_cargo_cmbgrid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colnom_punto_cargo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIdRegistro_subcentro = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cmb_subcentrocosto = new DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col_IdCentroCosto_sub_centro_costo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_Centro_costo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_IdUnidadMedida = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cmb_unidad_medida_convertida = new DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit();
            this.gridView5 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colIdUnidadMedida_sinConversion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cmb_unidad_medida = new DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit();
            this.gridView3 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.collIdCentroCosto_sub_centro_costo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_grupo_pto_cargo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cmb_Punto_cargo_grupo = new DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit();
            this.gridView6 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colIdPunto_cargo_grupo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colnom_punto_cargo_grupo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.ucInv_GridCbte_Cble_x_Ing_Egr_Inv = new Core.Erp.Winform.Controles.UCInv_GridCbte_Cble_x_Ing_Egr_Inv();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.col_punto_cargo_fj = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cmb_punto_cargo_fj = new DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit();
            this.gridView7 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_orden_mantenimiento.Properties)).BeginInit();
            this.panel2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlProductos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewProductos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbProducto_grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSearchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbCentroCosto_grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPuntoCargo_grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_subcentrocosto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_unidad_medida_convertida)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_unidad_medida)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_Punto_cargo_grupo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView6)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_punto_cargo_fj)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView7)).BeginInit();
            this.SuspendLayout();
            // 
            // ucGe_BarraEstadoInferior_Forms1
            // 
            this.ucGe_BarraEstadoInferior_Forms1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ucGe_BarraEstadoInferior_Forms1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ucGe_BarraEstadoInferior_Forms1.Location = new System.Drawing.Point(0, 686);
            this.ucGe_BarraEstadoInferior_Forms1.Margin = new System.Windows.Forms.Padding(5);
            this.ucGe_BarraEstadoInferior_Forms1.Name = "ucGe_BarraEstadoInferior_Forms1";
            this.ucGe_BarraEstadoInferior_Forms1.Size = new System.Drawing.Size(1283, 32);
            this.ucGe_BarraEstadoInferior_Forms1.TabIndex = 0;
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
            this.ucGe_Menu_Superior_Mant1.Size = new System.Drawing.Size(1283, 36);
            this.ucGe_Menu_Superior_Mant1.TabIndex = 1;
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
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 36);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1283, 236);
            this.panel1.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txt_orden_mantenimiento);
            this.groupBox1.Controls.Add(this.lbl_orden_mantenimiento);
            this.groupBox1.Controls.Add(this.lblPlantilla);
            this.groupBox1.Controls.Add(this.cmb_Estado_apro_x_Ing_Egr_Inven1);
            this.groupBox1.Controls.Add(this.lblNum_Movi_Inven);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.cmbTipoMovi);
            this.groupBox1.Controls.Add(this.cmbMotivoInv);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.lblAnulado);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtObservacion);
            this.groupBox1.Controls.Add(this.ucIn_Sucursal_Bodega1);
            this.groupBox1.Controls.Add(this.dtpFecha);
            this.groupBox1.Controls.Add(this.txtCodigo);
            this.groupBox1.Controls.Add(this.txtNumIngreso);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(1283, 236);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos Generales:";
            // 
            // txt_orden_mantenimiento
            // 
            this.txt_orden_mantenimiento.Location = new System.Drawing.Point(628, 17);
            this.txt_orden_mantenimiento.Margin = new System.Windows.Forms.Padding(4);
            this.txt_orden_mantenimiento.Name = "txt_orden_mantenimiento";
            this.txt_orden_mantenimiento.Properties.Mask.EditMask = "[0-9]{1,10}";
            this.txt_orden_mantenimiento.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.txt_orden_mantenimiento.Size = new System.Drawing.Size(244, 22);
            this.txt_orden_mantenimiento.TabIndex = 31;
            this.txt_orden_mantenimiento.Visible = false;
            // 
            // lbl_orden_mantenimiento
            // 
            this.lbl_orden_mantenimiento.AutoSize = true;
            this.lbl_orden_mantenimiento.Location = new System.Drawing.Point(452, 19);
            this.lbl_orden_mantenimiento.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_orden_mantenimiento.Name = "lbl_orden_mantenimiento";
            this.lbl_orden_mantenimiento.Size = new System.Drawing.Size(168, 17);
            this.lbl_orden_mantenimiento.TabIndex = 30;
            this.lbl_orden_mantenimiento.Text = "Orden de mantenimiento:";
            this.lbl_orden_mantenimiento.Visible = false;
            // 
            // lblPlantilla
            // 
            this.lblPlantilla.AutoSize = true;
            this.lblPlantilla.Location = new System.Drawing.Point(16, 135);
            this.lblPlantilla.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPlantilla.Name = "lblPlantilla";
            this.lblPlantilla.Size = new System.Drawing.Size(342, 17);
            this.lblPlantilla.TabIndex = 22;
            this.lblPlantilla.TabStop = true;
            this.lblPlantilla.Text = "Descargar plantilla para funcionalidad copiar y pegar";
            this.lblPlantilla.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblPlantilla_LinkClicked);
            // 
            // cmb_Estado_apro_x_Ing_Egr_Inven1
            // 
            this.cmb_Estado_apro_x_Ing_Egr_Inven1.Location = new System.Drawing.Point(879, 135);
            this.cmb_Estado_apro_x_Ing_Egr_Inven1.Margin = new System.Windows.Forms.Padding(5);
            this.cmb_Estado_apro_x_Ing_Egr_Inven1.Name = "cmb_Estado_apro_x_Ing_Egr_Inven1";
            this.cmb_Estado_apro_x_Ing_Egr_Inven1.Size = new System.Drawing.Size(331, 42);
            this.cmb_Estado_apro_x_Ing_Egr_Inven1.TabIndex = 21;
            this.cmb_Estado_apro_x_Ing_Egr_Inven1.Visible = false;
            // 
            // lblNum_Movi_Inven
            // 
            this.lblNum_Movi_Inven.AutoSize = true;
            this.lblNum_Movi_Inven.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNum_Movi_Inven.ForeColor = System.Drawing.Color.Blue;
            this.lblNum_Movi_Inven.Location = new System.Drawing.Point(547, 148);
            this.lblNum_Movi_Inven.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNum_Movi_Inven.Name = "lblNum_Movi_Inven";
            this.lblNum_Movi_Inven.Size = new System.Drawing.Size(108, 20);
            this.lblNum_Movi_Inven.TabIndex = 19;
            this.lblNum_Movi_Inven.Text = "#Movi Inven";
            this.lblNum_Movi_Inven.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(740, 150);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(132, 17);
            this.label6.TabIndex = 18;
            this.label6.Text = "Estado Aprobacion:";
            this.label6.Visible = false;
            // 
            // cmbTipoMovi
            // 
            this.cmbTipoMovi.Location = new System.Drawing.Point(748, 64);
            this.cmbTipoMovi.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbTipoMovi.Name = "cmbTipoMovi";
            this.cmbTipoMovi.Size = new System.Drawing.Size(461, 41);
            this.cmbTipoMovi.TabIndex = 16;
            this.cmbTipoMovi.Visible_buton_Acciones = true;
            // 
            // cmbMotivoInv
            // 
            this.cmbMotivoInv.Location = new System.Drawing.Point(748, 102);
            this.cmbMotivoInv.Margin = new System.Windows.Forms.Padding(5);
            this.cmbMotivoInv.Name = "cmbMotivoInv";
            this.cmbMotivoInv.Size = new System.Drawing.Size(461, 32);
            this.cmbMotivoInv.TabIndex = 15;
            this.cmbMotivoInv.Tipo_Ing_Egr = ein_Tipo_Ing_Egr.ING;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(665, 64);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 17);
            this.label5.TabIndex = 0;
            this.label5.Text = "Concepto:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(664, 106);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 17);
            this.label7.TabIndex = 13;
            this.label7.Text = "Motivo Inv:";
            // 
            // lblAnulado
            // 
            this.lblAnulado.AutoSize = true;
            this.lblAnulado.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAnulado.ForeColor = System.Drawing.Color.Red;
            this.lblAnulado.Location = new System.Drawing.Point(366, 109);
            this.lblAnulado.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAnulado.Name = "lblAnulado";
            this.lblAnulado.Size = new System.Drawing.Size(158, 25);
            this.lblAnulado.TabIndex = 10;
            this.lblAnulado.Text = "*** Anulado ***";
            this.lblAnulado.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 166);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 17);
            this.label4.TabIndex = 8;
            this.label4.Text = "Observación:";
            // 
            // txtObservacion
            // 
            this.txtObservacion.Location = new System.Drawing.Point(103, 185);
            this.txtObservacion.Margin = new System.Windows.Forms.Padding(4);
            this.txtObservacion.Multiline = true;
            this.txtObservacion.Name = "txtObservacion";
            this.txtObservacion.Size = new System.Drawing.Size(1132, 43);
            this.txtObservacion.TabIndex = 7;
            // 
            // ucIn_Sucursal_Bodega1
            // 
            this.ucIn_Sucursal_Bodega1.Location = new System.Drawing.Point(8, 48);
            this.ucIn_Sucursal_Bodega1.Margin = new System.Windows.Forms.Padding(5);
            this.ucIn_Sucursal_Bodega1.Name = "ucIn_Sucursal_Bodega1";
            this.ucIn_Sucursal_Bodega1.Size = new System.Drawing.Size(588, 63);
            this.ucIn_Sucursal_Bodega1.TabIndex = 6;
            this.ucIn_Sucursal_Bodega1.TipoCarga = Core.Erp.Info.General.Cl_Enumeradores.eTipoFiltro.Normal;
            this.ucIn_Sucursal_Bodega1.Visible_cmb_bodega = true;
            // 
            // dtpFecha
            // 
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(1077, 16);
            this.dtpFecha.Margin = new System.Windows.Forms.Padding(4);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(139, 22);
            this.dtpFecha.TabIndex = 5;
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(316, 16);
            this.txtCodigo.Margin = new System.Windows.Forms.Padding(4);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(132, 22);
            this.txtCodigo.TabIndex = 4;
            // 
            // txtNumIngreso
            // 
            this.txtNumIngreso.Location = new System.Drawing.Point(103, 16);
            this.txtNumIngreso.Margin = new System.Windows.Forms.Padding(4);
            this.txtNumIngreso.Name = "txtNumIngreso";
            this.txtNumIngreso.Size = new System.Drawing.Size(132, 22);
            this.txtNumIngreso.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1004, 20);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Fecha:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(251, 20);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Código:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 20);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "# Ingreso:";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tabControl1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 272);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1283, 414);
            this.panel2.TabIndex = 3;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1283, 414);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.gridControlProductos);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage1.Size = new System.Drawing.Size(1275, 385);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Productos";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // gridControlProductos
            // 
            this.gridControlProductos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlProductos.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4);
            this.gridControlProductos.Location = new System.Drawing.Point(4, 4);
            this.gridControlProductos.MainView = this.gridViewProductos;
            this.gridControlProductos.Margin = new System.Windows.Forms.Padding(4);
            this.gridControlProductos.Name = "gridControlProductos";
            this.gridControlProductos.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.cmbProducto_grid,
            this.cmbCentroCosto_grid,
            this.cmbPuntoCargo_grid,
            this.repositoryItemImageEdit1,
            this.cmb_subcentrocosto,
            this.cmb_unidad_medida,
            this.cmb_unidad_medida_convertida,
            this.cmb_Punto_cargo_grupo,
            this.cmb_punto_cargo_fj});
            this.gridControlProductos.Size = new System.Drawing.Size(1267, 377);
            this.gridControlProductos.TabIndex = 0;
            this.gridControlProductos.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewProductos});
            // 
            // gridViewProductos
            // 
            this.gridViewProductos.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colNuevoProducto,
            this.colSecuencia,
            this.colIdProducto,
            this.coldm_cantidad_sin_conversion,
            this.coldm_cantidad_convertida,
            this.colmv_costo_sin_conversion,
            this.colmv_costo,
            this.coldm_observacion,
            this.colIdCentroCosto_grid,
            this.colIdPunto_cargo,
            this.colIdRegistro_subcentro,
            this.col_IdUnidadMedida,
            this.colIdUnidadMedida_sinConversion,
            this.collIdCentroCosto_sub_centro_costo,
            this.col_grupo_pto_cargo,
            this.col_punto_cargo_fj});
            this.gridViewProductos.CustomizationFormBounds = new System.Drawing.Rectangle(796, 401, 216, 192);
            this.gridViewProductos.GridControl = this.gridControlProductos;
            this.gridViewProductos.Images = this.imageList1;
            this.gridViewProductos.Name = "gridViewProductos";
            this.gridViewProductos.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.gridViewProductos.OptionsView.ShowGroupPanel = false;
            this.gridViewProductos.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.gridViewProductos_RowCellClick);
            this.gridViewProductos.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.gridViewProductos_RowCellStyle);
            this.gridViewProductos.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridViewProductos_FocusedRowChanged);
            this.gridViewProductos.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridViewProductos_CellValueChanged);
            this.gridViewProductos.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridViewProductos_KeyDown);
            // 
            // colNuevoProducto
            // 
            this.colNuevoProducto.Caption = "*";
            this.colNuevoProducto.ColumnEdit = this.repositoryItemImageEdit1;
            this.colNuevoProducto.Name = "colNuevoProducto";
            this.colNuevoProducto.OptionsColumn.AllowEdit = false;
            this.colNuevoProducto.Visible = true;
            this.colNuevoProducto.VisibleIndex = 0;
            this.colNuevoProducto.Width = 44;
            // 
            // repositoryItemImageEdit1
            // 
            this.repositoryItemImageEdit1.AutoHeight = false;
            this.repositoryItemImageEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemImageEdit1.Images = this.imageList1;
            this.repositoryItemImageEdit1.Name = "repositoryItemImageEdit1";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "nuevo_32x32.png");
            // 
            // colSecuencia
            // 
            this.colSecuencia.Caption = "Secuencia";
            this.colSecuencia.FieldName = "Secuencia";
            this.colSecuencia.Name = "colSecuencia";
            // 
            // colIdProducto
            // 
            this.colIdProducto.Caption = "Producto";
            this.colIdProducto.ColumnEdit = this.cmbProducto_grid;
            this.colIdProducto.FieldName = "IdProducto";
            this.colIdProducto.Name = "colIdProducto";
            this.colIdProducto.Visible = true;
            this.colIdProducto.VisibleIndex = 1;
            this.colIdProducto.Width = 390;
            // 
            // cmbProducto_grid
            // 
            this.cmbProducto_grid.AutoHeight = false;
            this.cmbProducto_grid.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbProducto_grid.Name = "cmbProducto_grid";
            this.cmbProducto_grid.View = this.repositoryItemSearchLookUpEdit1View;
            // 
            // repositoryItemSearchLookUpEdit1View
            // 
            this.repositoryItemSearchLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colIdProducto_cmbgrid,
            this.colpr_codigo_cmbgrid,
            this.colpr_descripcion,
            this.colpr_precio_publico,
            this.colpr_stock,
            this.colpr_pedidos,
            this.colpr_ManejaIva,
            this.colpr_costo_promedio,
            this.colpr_peso});
            this.repositoryItemSearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.repositoryItemSearchLookUpEdit1View.Name = "repositoryItemSearchLookUpEdit1View";
            this.repositoryItemSearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.repositoryItemSearchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // colIdProducto_cmbgrid
            // 
            this.colIdProducto_cmbgrid.Caption = "IdProducto";
            this.colIdProducto_cmbgrid.FieldName = "IdProducto";
            this.colIdProducto_cmbgrid.Name = "colIdProducto_cmbgrid";
            this.colIdProducto_cmbgrid.Visible = true;
            this.colIdProducto_cmbgrid.VisibleIndex = 2;
            this.colIdProducto_cmbgrid.Width = 98;
            // 
            // colpr_codigo_cmbgrid
            // 
            this.colpr_codigo_cmbgrid.Caption = "Código";
            this.colpr_codigo_cmbgrid.FieldName = "pr_codigo";
            this.colpr_codigo_cmbgrid.Name = "colpr_codigo_cmbgrid";
            this.colpr_codigo_cmbgrid.Visible = true;
            this.colpr_codigo_cmbgrid.VisibleIndex = 1;
            this.colpr_codigo_cmbgrid.Width = 102;
            // 
            // colpr_descripcion
            // 
            this.colpr_descripcion.Caption = "Descripción";
            this.colpr_descripcion.FieldName = "pr_descripcion";
            this.colpr_descripcion.Name = "colpr_descripcion";
            this.colpr_descripcion.Visible = true;
            this.colpr_descripcion.VisibleIndex = 0;
            this.colpr_descripcion.Width = 287;
            // 
            // colpr_precio_publico
            // 
            this.colpr_precio_publico.Caption = "P.V.P.";
            this.colpr_precio_publico.FieldName = "pr_precio_publico";
            this.colpr_precio_publico.Name = "colpr_precio_publico";
            this.colpr_precio_publico.Visible = true;
            this.colpr_precio_publico.VisibleIndex = 3;
            this.colpr_precio_publico.Width = 77;
            // 
            // colpr_stock
            // 
            this.colpr_stock.Caption = "Stock";
            this.colpr_stock.FieldName = "pr_stock_Bodega";
            this.colpr_stock.Name = "colpr_stock";
            this.colpr_stock.Visible = true;
            this.colpr_stock.VisibleIndex = 4;
            this.colpr_stock.Width = 101;
            // 
            // colpr_pedidos
            // 
            this.colpr_pedidos.Caption = "Pedidos";
            this.colpr_pedidos.FieldName = "pr_pedidos";
            this.colpr_pedidos.Name = "colpr_pedidos";
            this.colpr_pedidos.Visible = true;
            this.colpr_pedidos.VisibleIndex = 5;
            this.colpr_pedidos.Width = 101;
            // 
            // colpr_ManejaIva
            // 
            this.colpr_ManejaIva.Caption = "Maneja Iva";
            this.colpr_ManejaIva.FieldName = "pr_ManejaIva";
            this.colpr_ManejaIva.Name = "colpr_ManejaIva";
            this.colpr_ManejaIva.Visible = true;
            this.colpr_ManejaIva.VisibleIndex = 6;
            this.colpr_ManejaIva.Width = 101;
            // 
            // colpr_costo_promedio
            // 
            this.colpr_costo_promedio.Caption = "Costo";
            this.colpr_costo_promedio.FieldName = "pr_costo_promedio";
            this.colpr_costo_promedio.Name = "colpr_costo_promedio";
            this.colpr_costo_promedio.Visible = true;
            this.colpr_costo_promedio.VisibleIndex = 7;
            this.colpr_costo_promedio.Width = 101;
            // 
            // colpr_peso
            // 
            this.colpr_peso.Caption = "Peso";
            this.colpr_peso.FieldName = "pr_peso";
            this.colpr_peso.Name = "colpr_peso";
            this.colpr_peso.Visible = true;
            this.colpr_peso.VisibleIndex = 8;
            this.colpr_peso.Width = 101;
            // 
            // coldm_cantidad_sin_conversion
            // 
            this.coldm_cantidad_sin_conversion.Caption = "Cantidad";
            this.coldm_cantidad_sin_conversion.FieldName = "dm_cantidad_sinConversion";
            this.coldm_cantidad_sin_conversion.Name = "coldm_cantidad_sin_conversion";
            this.coldm_cantidad_sin_conversion.Visible = true;
            this.coldm_cantidad_sin_conversion.VisibleIndex = 3;
            this.coldm_cantidad_sin_conversion.Width = 193;
            // 
            // coldm_cantidad_convertida
            // 
            this.coldm_cantidad_convertida.Caption = "Cantidad convertida";
            this.coldm_cantidad_convertida.FieldName = "dm_cantidad";
            this.coldm_cantidad_convertida.Name = "coldm_cantidad_convertida";
            this.coldm_cantidad_convertida.OptionsColumn.AllowEdit = false;
            this.coldm_cantidad_convertida.Width = 154;
            // 
            // colmv_costo_sin_conversion
            // 
            this.colmv_costo_sin_conversion.Caption = "Costo";
            this.colmv_costo_sin_conversion.FieldName = "mv_costo_sinConversion";
            this.colmv_costo_sin_conversion.Name = "colmv_costo_sin_conversion";
            this.colmv_costo_sin_conversion.Visible = true;
            this.colmv_costo_sin_conversion.VisibleIndex = 4;
            this.colmv_costo_sin_conversion.Width = 193;
            // 
            // colmv_costo
            // 
            this.colmv_costo.Caption = "Costo convertido";
            this.colmv_costo.FieldName = "mv_costo";
            this.colmv_costo.Name = "colmv_costo";
            this.colmv_costo.OptionsColumn.AllowEdit = false;
            this.colmv_costo.Width = 133;
            // 
            // coldm_observacion
            // 
            this.coldm_observacion.Caption = "Observación por Producto";
            this.coldm_observacion.FieldName = "dm_observacion";
            this.coldm_observacion.Name = "coldm_observacion";
            this.coldm_observacion.Width = 202;
            // 
            // colIdCentroCosto_grid
            // 
            this.colIdCentroCosto_grid.Caption = "Centro de Costo";
            this.colIdCentroCosto_grid.ColumnEdit = this.cmbCentroCosto_grid;
            this.colIdCentroCosto_grid.FieldName = "IdCentroCosto";
            this.colIdCentroCosto_grid.Name = "colIdCentroCosto_grid";
            this.colIdCentroCosto_grid.Visible = true;
            this.colIdCentroCosto_grid.VisibleIndex = 5;
            this.colIdCentroCosto_grid.Width = 152;
            // 
            // cmbCentroCosto_grid
            // 
            this.cmbCentroCosto_grid.AutoHeight = false;
            this.cmbCentroCosto_grid.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbCentroCosto_grid.DisplayMember = "Centro_costo2";
            this.cmbCentroCosto_grid.Name = "cmbCentroCosto_grid";
            this.cmbCentroCosto_grid.ValueMember = "IdCentroCosto";
            this.cmbCentroCosto_grid.View = this.gridView1;
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colIdCentroCosto_cmbgrid,
            this.colCentro_costo,
            this.colpc_Estado});
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // colIdCentroCosto_cmbgrid
            // 
            this.colIdCentroCosto_cmbgrid.Caption = "Código";
            this.colIdCentroCosto_cmbgrid.FieldName = "IdCentroCosto";
            this.colIdCentroCosto_cmbgrid.Name = "colIdCentroCosto_cmbgrid";
            this.colIdCentroCosto_cmbgrid.Visible = true;
            this.colIdCentroCosto_cmbgrid.VisibleIndex = 1;
            this.colIdCentroCosto_cmbgrid.Width = 179;
            // 
            // colCentro_costo
            // 
            this.colCentro_costo.Caption = "Descripción";
            this.colCentro_costo.FieldName = "Centro_costo";
            this.colCentro_costo.Name = "colCentro_costo";
            this.colCentro_costo.Visible = true;
            this.colCentro_costo.VisibleIndex = 0;
            this.colCentro_costo.Width = 820;
            // 
            // colpc_Estado
            // 
            this.colpc_Estado.Caption = "Estado";
            this.colpc_Estado.FieldName = "pc_Estado";
            this.colpc_Estado.Name = "colpc_Estado";
            this.colpc_Estado.Visible = true;
            this.colpc_Estado.VisibleIndex = 2;
            this.colpc_Estado.Width = 181;
            // 
            // colIdPunto_cargo
            // 
            this.colIdPunto_cargo.Caption = "Punto Cargo";
            this.colIdPunto_cargo.ColumnEdit = this.cmbPuntoCargo_grid;
            this.colIdPunto_cargo.FieldName = "IdPunto_cargo";
            this.colIdPunto_cargo.Name = "colIdPunto_cargo";
            this.colIdPunto_cargo.Visible = true;
            this.colIdPunto_cargo.VisibleIndex = 7;
            this.colIdPunto_cargo.Width = 84;
            // 
            // cmbPuntoCargo_grid
            // 
            this.cmbPuntoCargo_grid.AllowDropDownWhenReadOnly = DevExpress.Utils.DefaultBoolean.False;
            this.cmbPuntoCargo_grid.AutoHeight = false;
            this.cmbPuntoCargo_grid.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbPuntoCargo_grid.DisplayMember = "nom_punto_cargo";
            this.cmbPuntoCargo_grid.Name = "cmbPuntoCargo_grid";
            this.cmbPuntoCargo_grid.ReadOnly = true;
            this.cmbPuntoCargo_grid.ValueMember = "IdPunto_cargo";
            this.cmbPuntoCargo_grid.View = this.gridView4;
            this.cmbPuntoCargo_grid.Click += new System.EventHandler(this.cmbPuntoCargo_grid_Click);
            // 
            // gridView4
            // 
            this.gridView4.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colIdPunto_cargo_cmbgrid,
            this.colnom_punto_cargo});
            this.gridView4.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView4.Name = "gridView4";
            this.gridView4.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView4.OptionsView.ShowGroupPanel = false;
            // 
            // colIdPunto_cargo_cmbgrid
            // 
            this.colIdPunto_cargo_cmbgrid.Caption = "Código";
            this.colIdPunto_cargo_cmbgrid.FieldName = "IdPunto_cargo";
            this.colIdPunto_cargo_cmbgrid.Name = "colIdPunto_cargo_cmbgrid";
            this.colIdPunto_cargo_cmbgrid.Visible = true;
            this.colIdPunto_cargo_cmbgrid.VisibleIndex = 1;
            this.colIdPunto_cargo_cmbgrid.Width = 293;
            // 
            // colnom_punto_cargo
            // 
            this.colnom_punto_cargo.Caption = "Nombre";
            this.colnom_punto_cargo.FieldName = "nom_punto_cargo";
            this.colnom_punto_cargo.Name = "colnom_punto_cargo";
            this.colnom_punto_cargo.Visible = true;
            this.colnom_punto_cargo.VisibleIndex = 0;
            this.colnom_punto_cargo.Width = 887;
            // 
            // colIdRegistro_subcentro
            // 
            this.colIdRegistro_subcentro.Caption = "Subcentro de costo";
            this.colIdRegistro_subcentro.ColumnEdit = this.cmb_subcentrocosto;
            this.colIdRegistro_subcentro.FieldName = "IdRegistro";
            this.colIdRegistro_subcentro.Name = "colIdRegistro_subcentro";
            this.colIdRegistro_subcentro.Visible = true;
            this.colIdRegistro_subcentro.VisibleIndex = 6;
            this.colIdRegistro_subcentro.Width = 84;
            // 
            // cmb_subcentrocosto
            // 
            this.cmb_subcentrocosto.AllowDropDownWhenReadOnly = DevExpress.Utils.DefaultBoolean.False;
            this.cmb_subcentrocosto.AutoHeight = false;
            this.cmb_subcentrocosto.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmb_subcentrocosto.DisplayMember = "Centro_costo2";
            this.cmb_subcentrocosto.Name = "cmb_subcentrocosto";
            this.cmb_subcentrocosto.ReadOnly = true;
            this.cmb_subcentrocosto.ValueMember = "IdRegistro";
            this.cmb_subcentrocosto.View = this.gridView2;
            this.cmb_subcentrocosto.Click += new System.EventHandler(this.cmb_subcentrocosto_Click);
            // 
            // gridView2
            // 
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col_IdCentroCosto_sub_centro_costo,
            this.col_Centro_costo});
            this.gridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            // 
            // col_IdCentroCosto_sub_centro_costo
            // 
            this.col_IdCentroCosto_sub_centro_costo.Caption = "ID";
            this.col_IdCentroCosto_sub_centro_costo.FieldName = "IdCentroCosto_sub_centro_costo";
            this.col_IdCentroCosto_sub_centro_costo.Name = "col_IdCentroCosto_sub_centro_costo";
            this.col_IdCentroCosto_sub_centro_costo.Visible = true;
            this.col_IdCentroCosto_sub_centro_costo.VisibleIndex = 1;
            this.col_IdCentroCosto_sub_centro_costo.Width = 76;
            // 
            // col_Centro_costo
            // 
            this.col_Centro_costo.Caption = "Descripción";
            this.col_Centro_costo.FieldName = "Centro_costo";
            this.col_Centro_costo.Name = "col_Centro_costo";
            this.col_Centro_costo.Visible = true;
            this.col_Centro_costo.VisibleIndex = 0;
            this.col_Centro_costo.Width = 1104;
            // 
            // col_IdUnidadMedida
            // 
            this.col_IdUnidadMedida.Caption = "IdUnidadMedida convertida";
            this.col_IdUnidadMedida.ColumnEdit = this.cmb_unidad_medida_convertida;
            this.col_IdUnidadMedida.FieldName = "IdUnidadMedida";
            this.col_IdUnidadMedida.Name = "col_IdUnidadMedida";
            this.col_IdUnidadMedida.OptionsColumn.AllowEdit = false;
            this.col_IdUnidadMedida.OptionsColumn.ReadOnly = true;
            this.col_IdUnidadMedida.Width = 140;
            // 
            // cmb_unidad_medida_convertida
            // 
            this.cmb_unidad_medida_convertida.AllowDropDownWhenReadOnly = DevExpress.Utils.DefaultBoolean.False;
            this.cmb_unidad_medida_convertida.AutoHeight = false;
            this.cmb_unidad_medida_convertida.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmb_unidad_medida_convertida.DisplayMember = "Descripcion2";
            this.cmb_unidad_medida_convertida.Name = "cmb_unidad_medida_convertida";
            this.cmb_unidad_medida_convertida.ReadOnly = true;
            this.cmb_unidad_medida_convertida.ValueMember = "IdUnidadMedida";
            this.cmb_unidad_medida_convertida.View = this.gridView5;
            // 
            // gridView5
            // 
            this.gridView5.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView5.Name = "gridView5";
            this.gridView5.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView5.OptionsView.ShowGroupPanel = false;
            // 
            // colIdUnidadMedida_sinConversion
            // 
            this.colIdUnidadMedida_sinConversion.Caption = "Unidad medida";
            this.colIdUnidadMedida_sinConversion.ColumnEdit = this.cmb_unidad_medida;
            this.colIdUnidadMedida_sinConversion.FieldName = "IdUnidadMedida_sinConversion";
            this.colIdUnidadMedida_sinConversion.Name = "colIdUnidadMedida_sinConversion";
            this.colIdUnidadMedida_sinConversion.OptionsColumn.AllowEdit = false;
            this.colIdUnidadMedida_sinConversion.OptionsColumn.ReadOnly = true;
            this.colIdUnidadMedida_sinConversion.Visible = true;
            this.colIdUnidadMedida_sinConversion.VisibleIndex = 2;
            this.colIdUnidadMedida_sinConversion.Width = 125;
            // 
            // cmb_unidad_medida
            // 
            this.cmb_unidad_medida.AllowDropDownWhenReadOnly = DevExpress.Utils.DefaultBoolean.False;
            this.cmb_unidad_medida.AutoHeight = false;
            this.cmb_unidad_medida.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmb_unidad_medida.DisplayMember = "Descripcion2";
            this.cmb_unidad_medida.Name = "cmb_unidad_medida";
            this.cmb_unidad_medida.ReadOnly = true;
            this.cmb_unidad_medida.ValueMember = "IdUnidadMedida";
            this.cmb_unidad_medida.View = this.gridView3;
            // 
            // gridView3
            // 
            this.gridView3.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView3.Name = "gridView3";
            this.gridView3.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView3.OptionsView.ShowGroupPanel = false;
            // 
            // collIdCentroCosto_sub_centro_costo
            // 
            this.collIdCentroCosto_sub_centro_costo.Caption = "IdSubcentro";
            this.collIdCentroCosto_sub_centro_costo.FieldName = "IdCentroCosto_sub_centro_costo";
            this.collIdCentroCosto_sub_centro_costo.Name = "collIdCentroCosto_sub_centro_costo";
            this.collIdCentroCosto_sub_centro_costo.OptionsColumn.AllowEdit = false;
            // 
            // col_grupo_pto_cargo
            // 
            this.col_grupo_pto_cargo.Caption = "Grupo";
            this.col_grupo_pto_cargo.ColumnEdit = this.cmb_Punto_cargo_grupo;
            this.col_grupo_pto_cargo.FieldName = "IdPunto_cargo_grupo";
            this.col_grupo_pto_cargo.Name = "col_grupo_pto_cargo";
            // 
            // cmb_Punto_cargo_grupo
            // 
            this.cmb_Punto_cargo_grupo.AutoHeight = false;
            this.cmb_Punto_cargo_grupo.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmb_Punto_cargo_grupo.DisplayMember = "nom_punto_cargo_grupo";
            this.cmb_Punto_cargo_grupo.Name = "cmb_Punto_cargo_grupo";
            this.cmb_Punto_cargo_grupo.ValueMember = "IdPunto_cargo_grupo";
            this.cmb_Punto_cargo_grupo.View = this.gridView6;
            // 
            // gridView6
            // 
            this.gridView6.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colIdPunto_cargo_grupo,
            this.colnom_punto_cargo_grupo});
            this.gridView6.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView6.Name = "gridView6";
            this.gridView6.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView6.OptionsView.ShowGroupPanel = false;
            // 
            // colIdPunto_cargo_grupo
            // 
            this.colIdPunto_cargo_grupo.Caption = "IdPuntoCargo";
            this.colIdPunto_cargo_grupo.FieldName = "IdPunto_cargo_grupo";
            this.colIdPunto_cargo_grupo.Name = "colIdPunto_cargo_grupo";
            this.colIdPunto_cargo_grupo.Visible = true;
            this.colIdPunto_cargo_grupo.VisibleIndex = 0;
            // 
            // colnom_punto_cargo_grupo
            // 
            this.colnom_punto_cargo_grupo.Caption = "Grupo";
            this.colnom_punto_cargo_grupo.FieldName = "nom_punto_cargo_grupo";
            this.colnom_punto_cargo_grupo.Name = "colnom_punto_cargo_grupo";
            this.colnom_punto_cargo_grupo.Visible = true;
            this.colnom_punto_cargo_grupo.VisibleIndex = 1;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.ucInv_GridCbte_Cble_x_Ing_Egr_Inv);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage2.Size = new System.Drawing.Size(1275, 385);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Diario Contable";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // ucInv_GridCbte_Cble_x_Ing_Egr_Inv
            // 
            this.ucInv_GridCbte_Cble_x_Ing_Egr_Inv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucInv_GridCbte_Cble_x_Ing_Egr_Inv.Location = new System.Drawing.Point(4, 4);
            this.ucInv_GridCbte_Cble_x_Ing_Egr_Inv.Margin = new System.Windows.Forms.Padding(5);
            this.ucInv_GridCbte_Cble_x_Ing_Egr_Inv.Name = "ucInv_GridCbte_Cble_x_Ing_Egr_Inv";
            this.ucInv_GridCbte_Cble_x_Ing_Egr_Inv.Size = new System.Drawing.Size(1267, 377);
            this.ucInv_GridCbte_Cble_x_Ing_Egr_Inv.TabIndex = 0;
            // 
            // col_punto_cargo_fj
            // 
            this.col_punto_cargo_fj.Caption = "Punto de cargo";
            this.col_punto_cargo_fj.ColumnEdit = this.cmb_punto_cargo_fj;
            this.col_punto_cargo_fj.FieldName = "IdPunto_cargo";
            this.col_punto_cargo_fj.Name = "col_punto_cargo_fj";
            this.col_punto_cargo_fj.Visible = true;
            this.col_punto_cargo_fj.VisibleIndex = 8;
            this.col_punto_cargo_fj.Width = 104;
            // 
            // cmb_punto_cargo_fj
            // 
            this.cmb_punto_cargo_fj.AutoHeight = false;
            this.cmb_punto_cargo_fj.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmb_punto_cargo_fj.DisplayMember = "nom_punto_cargo";
            this.cmb_punto_cargo_fj.Name = "cmb_punto_cargo_fj";
            this.cmb_punto_cargo_fj.ValueMember = "IdPunto_cargo";
            this.cmb_punto_cargo_fj.View = this.gridView7;
            // 
            // gridView7
            // 
            this.gridView7.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2});
            this.gridView7.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView7.Name = "gridView7";
            this.gridView7.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView7.OptionsView.ShowAutoFilterRow = true;
            this.gridView7.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "ID";
            this.gridColumn1.FieldName = "IdPunto_cargo";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 1;
            this.gridColumn1.Width = 228;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Punto de cargo";
            this.gridColumn2.FieldName = "nom_punto_cargo";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 0;
            this.gridColumn2.Width = 1506;
            // 
            // FrmIn_Ingreso_varios_Mant
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1283, 718);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ucGe_Menu_Superior_Mant1);
            this.Controls.Add(this.ucGe_BarraEstadoInferior_Forms1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmIn_Ingreso_varios_Mant";
            this.Text = "Ingresos Varios";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmIn_Ingreso_varios_Mant_FormClosing);
            this.Load += new System.EventHandler(this.FrmIn_Ingreso_varios_Mant_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_orden_mantenimiento.Properties)).EndInit();
            this.panel2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlProductos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewProductos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbProducto_grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSearchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbCentroCosto_grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPuntoCargo_grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_subcentrocosto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_unidad_medida_convertida)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_unidad_medida)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_Punto_cargo_grupo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView6)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cmb_punto_cargo_fj)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView7)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Controles.UCGe_BarraEstadoInferior_Forms ucGe_BarraEstadoInferior_Forms1;
        private Controles.UCGe_Menu_Superior_Mant ucGe_Menu_Superior_Mant1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtObservacion;
        private Controles.UCIn_Sucursal_Bodega ucIn_Sucursal_Bodega1;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.TextBox txtNumIngreso;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private DevExpress.XtraGrid.GridControl gridControlProductos;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewProductos;
        private System.Windows.Forms.TabPage tabPage2;
        private DevExpress.XtraGrid.Columns.GridColumn colSecuencia;
        private DevExpress.XtraGrid.Columns.GridColumn colIdProducto;
        private DevExpress.XtraGrid.Columns.GridColumn coldm_cantidad_convertida;
        private DevExpress.XtraGrid.Columns.GridColumn coldm_observacion;
        private DevExpress.XtraGrid.Columns.GridColumn colmv_costo;
        private DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit cmbProducto_grid;
        private DevExpress.XtraGrid.Views.Grid.GridView repositoryItemSearchLookUpEdit1View;
        private DevExpress.XtraGrid.Columns.GridColumn colIdProducto_cmbgrid;
        private DevExpress.XtraGrid.Columns.GridColumn colpr_codigo_cmbgrid;
        private DevExpress.XtraGrid.Columns.GridColumn colpr_descripcion;
        private DevExpress.XtraGrid.Columns.GridColumn colpr_precio_publico;
        private DevExpress.XtraGrid.Columns.GridColumn colpr_stock;
        private DevExpress.XtraGrid.Columns.GridColumn colpr_pedidos;
        private DevExpress.XtraGrid.Columns.GridColumn colpr_ManejaIva;
        private DevExpress.XtraGrid.Columns.GridColumn colpr_costo_promedio;
        private DevExpress.XtraGrid.Columns.GridColumn colpr_peso;
        private System.Windows.Forms.Label lblAnulado;
        private DevExpress.XtraGrid.Columns.GridColumn colIdCentroCosto_grid;
        private DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit cmbCentroCosto_grid;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colIdCentroCosto_cmbgrid;
        private DevExpress.XtraGrid.Columns.GridColumn colCentro_costo;
        private DevExpress.XtraGrid.Columns.GridColumn colpc_Estado;
        private DevExpress.XtraGrid.Columns.GridColumn colIdPunto_cargo;
        private DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit cmbPuntoCargo_grid;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView4;
        private DevExpress.XtraGrid.Columns.GridColumn colIdPunto_cargo_cmbgrid;
        private DevExpress.XtraGrid.Columns.GridColumn colnom_punto_cargo;
        private System.Windows.Forms.Label label7;
        private Controles.UCIn_MotivoInvCmb cmbMotivoInv;
        private DevExpress.XtraGrid.Columns.GridColumn colIdRegistro_subcentro;
        private Controles.UCIn_TipoMoviInv_Cmb cmbTipoMovi;
        private Controles.UCInv_GridCbte_Cble_x_Ing_Egr_Inv ucInv_GridCbte_Cble_x_Ing_Egr_Inv;
        private DevExpress.XtraGrid.Columns.GridColumn col_IdUnidadMedida;
        private DevExpress.XtraGrid.Columns.GridColumn colIdUnidadMedida_sinConversion;
        private System.Windows.Forms.Label lblNum_Movi_Inven;
        private System.Windows.Forms.Label label6;
        private Controles.UCInv_Estado_apro_x_Ing_Egr_Inven cmb_Estado_apro_x_Ing_Egr_Inven1;
        private DevExpress.XtraGrid.Columns.GridColumn colNuevoProducto;
        private System.Windows.Forms.ImageList imageList1;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageEdit repositoryItemImageEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit cmb_subcentrocosto;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Columns.GridColumn col_IdCentroCosto_sub_centro_costo;
        private DevExpress.XtraGrid.Columns.GridColumn col_Centro_costo;
        private DevExpress.XtraGrid.Columns.GridColumn coldm_cantidad_sin_conversion;
        private DevExpress.XtraGrid.Columns.GridColumn colmv_costo_sin_conversion;
        private DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit cmb_unidad_medida;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView3;
        private DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit cmb_unidad_medida_convertida;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView5;
        private DevExpress.XtraGrid.Columns.GridColumn collIdCentroCosto_sub_centro_costo;
        private DevExpress.XtraGrid.Columns.GridColumn col_grupo_pto_cargo;
        private DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit cmb_Punto_cargo_grupo;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView6;
        private DevExpress.XtraGrid.Columns.GridColumn colIdPunto_cargo_grupo;
        private DevExpress.XtraGrid.Columns.GridColumn colnom_punto_cargo_grupo;
        private System.Windows.Forms.LinkLabel lblPlantilla;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private DevExpress.XtraEditors.TextEdit txt_orden_mantenimiento;
        private System.Windows.Forms.Label lbl_orden_mantenimiento;
        private DevExpress.XtraGrid.Columns.GridColumn col_punto_cargo_fj;
        private DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit cmb_punto_cargo_fj;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
    }
}