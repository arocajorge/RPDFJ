namespace Core.Erp.Winform.Academico
{
    partial class Frm_Aca_Apertura_Ciclo_Facturacion
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnPeriodoSiguiente = new DevExpress.XtraEditors.SimpleButton();
            this.btnPeriodoAnterior = new DevExpress.XtraEditors.SimpleButton();
            this.btnAperturaAnual = new DevExpress.XtraEditors.SimpleButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.gridCtrlEstudianteCurso = new DevExpress.XtraGrid.GridControl();
            this.gridvwEstudianteCurso = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Col_seleccionar = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColCod_Estudiante = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColEstudiante = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColCurso = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColParalelo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lblAnioLectivo = new DevExpress.XtraEditors.LabelControl();
            this.txtAnioLectivo = new DevExpress.XtraEditors.TextEdit();
            this.txtPeriodo = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            this.galleryControlGallery1 = new DevExpress.XtraBars.Ribbon.Gallery.GalleryControlGallery();
            this.ucGe_Menu_Superior_Mant1 = new Core.Erp.Winform.Controles.UCGe_Menu_Superior_Mant();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblNumRegistros = new DevExpress.XtraEditors.LabelControl();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.Col_pe_apellido = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Col_pe_nombre = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridCtrlEstudianteCurso)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridvwEstudianteCurso)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtAnioLectivo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPeriodo.Properties)).BeginInit();
            this.xtraTabPage2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnPeriodoSiguiente);
            this.groupBox3.Controls.Add(this.btnPeriodoAnterior);
            this.groupBox3.Location = new System.Drawing.Point(35, 15);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Size = new System.Drawing.Size(125, 110);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Mover Periodo";
            // 
            // btnPeriodoSiguiente
            // 
            this.btnPeriodoSiguiente.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPeriodoSiguiente.Appearance.Options.UseFont = true;
            this.btnPeriodoSiguiente.Location = new System.Drawing.Point(11, 60);
            this.btnPeriodoSiguiente.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnPeriodoSiguiente.Name = "btnPeriodoSiguiente";
            this.btnPeriodoSiguiente.Size = new System.Drawing.Size(97, 34);
            this.btnPeriodoSiguiente.TabIndex = 4;
            this.btnPeriodoSiguiente.Text = "Cerrar";
            this.btnPeriodoSiguiente.Click += new System.EventHandler(this.btnPeriodoSiguiente_Click);
            // 
            // btnPeriodoAnterior
            // 
            this.btnPeriodoAnterior.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPeriodoAnterior.Appearance.Options.UseFont = true;
            this.btnPeriodoAnterior.Location = new System.Drawing.Point(11, 18);
            this.btnPeriodoAnterior.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnPeriodoAnterior.Name = "btnPeriodoAnterior";
            this.btnPeriodoAnterior.Size = new System.Drawing.Size(97, 34);
            this.btnPeriodoAnterior.TabIndex = 6;
            this.btnPeriodoAnterior.Text = "Reversar";
            this.btnPeriodoAnterior.Click += new System.EventHandler(this.btnPeriodoAnterior_Click);
            // 
            // btnAperturaAnual
            // 
            this.btnAperturaAnual.Appearance.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAperturaAnual.Appearance.Options.UseFont = true;
            this.btnAperturaAnual.Image = global::Core.Erp.Winform.Properties.Resources.system_software_update;
            this.btnAperturaAnual.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnAperturaAnual.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnAperturaAnual.Location = new System.Drawing.Point(218, 18);
            this.btnAperturaAnual.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAperturaAnual.Name = "btnAperturaAnual";
            this.btnAperturaAnual.Size = new System.Drawing.Size(396, 127);
            this.btnAperturaAnual.TabIndex = 5;
            this.btnAperturaAnual.Text = "Apertura Anual";
            this.btnAperturaAnual.Click += new System.EventHandler(this.btnAperturaAnual_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.gridCtrlEstudianteCurso);
            this.groupBox2.Location = new System.Drawing.Point(4, 268);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(960, 411);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            // 
            // gridCtrlEstudianteCurso
            // 
            this.gridCtrlEstudianteCurso.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridCtrlEstudianteCurso.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gridCtrlEstudianteCurso.Location = new System.Drawing.Point(3, 17);
            this.gridCtrlEstudianteCurso.MainView = this.gridvwEstudianteCurso;
            this.gridCtrlEstudianteCurso.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gridCtrlEstudianteCurso.Name = "gridCtrlEstudianteCurso";
            this.gridCtrlEstudianteCurso.Size = new System.Drawing.Size(954, 392);
            this.gridCtrlEstudianteCurso.TabIndex = 0;
            this.gridCtrlEstudianteCurso.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridvwEstudianteCurso});
            // 
            // gridvwEstudianteCurso
            // 
            this.gridvwEstudianteCurso.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.Col_seleccionar,
            this.ColCod_Estudiante,
            this.ColEstudiante,
            this.ColCurso,
            this.ColParalelo,
            this.Col_pe_apellido,
            this.Col_pe_nombre});
            this.gridvwEstudianteCurso.GridControl = this.gridCtrlEstudianteCurso;
            this.gridvwEstudianteCurso.Name = "gridvwEstudianteCurso";
            this.gridvwEstudianteCurso.OptionsView.ShowAutoFilterRow = true;
            // 
            // Col_seleccionar
            // 
            this.Col_seleccionar.Caption = "*";
            this.Col_seleccionar.FieldName = "seleccionar";
            this.Col_seleccionar.Name = "Col_seleccionar";
            this.Col_seleccionar.Visible = true;
            this.Col_seleccionar.VisibleIndex = 0;
            this.Col_seleccionar.Width = 38;
            // 
            // ColCod_Estudiante
            // 
            this.ColCod_Estudiante.Caption = "Cod. Estudiante";
            this.ColCod_Estudiante.FieldName = "cod_estudiante";
            this.ColCod_Estudiante.Name = "ColCod_Estudiante";
            this.ColCod_Estudiante.Visible = true;
            this.ColCod_Estudiante.VisibleIndex = 1;
            this.ColCod_Estudiante.Width = 170;
            // 
            // ColEstudiante
            // 
            this.ColEstudiante.Caption = "Estudiante";
            this.ColEstudiante.FieldName = "pe_nombreCompleto";
            this.ColEstudiante.Name = "ColEstudiante";
            // 
            // ColCurso
            // 
            this.ColCurso.Caption = "Curso";
            this.ColCurso.FieldName = "Curso";
            this.ColCurso.Name = "ColCurso";
            this.ColCurso.Visible = true;
            this.ColCurso.VisibleIndex = 4;
            this.ColCurso.Width = 381;
            // 
            // ColParalelo
            // 
            this.ColParalelo.Caption = "Paralelo";
            this.ColParalelo.FieldName = "Paralelo";
            this.ColParalelo.Name = "ColParalelo";
            this.ColParalelo.Visible = true;
            this.ColParalelo.VisibleIndex = 5;
            this.ColParalelo.Width = 383;
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Location = new System.Drawing.Point(4, 4);
            this.xtraTabControl1.Margin = new System.Windows.Forms.Padding(4);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage1;
            this.xtraTabControl1.Size = new System.Drawing.Size(960, 194);
            this.xtraTabControl1.TabIndex = 9;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1,
            this.xtraTabPage2});
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.groupBox4);
            this.xtraTabPage1.Controls.Add(this.groupBox3);
            this.xtraTabPage1.Margin = new System.Windows.Forms.Padding(4);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(954, 163);
            this.xtraTabPage1.Text = "Administrar Periodos";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.lblAnioLectivo);
            this.groupBox4.Controls.Add(this.txtAnioLectivo);
            this.groupBox4.Controls.Add(this.txtPeriodo);
            this.groupBox4.Controls.Add(this.labelControl1);
            this.groupBox4.Location = new System.Drawing.Point(227, 15);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox4.Size = new System.Drawing.Size(242, 110);
            this.groupBox4.TabIndex = 9;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Periodo Activo";
            // 
            // lblAnioLectivo
            // 
            this.lblAnioLectivo.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAnioLectivo.Location = new System.Drawing.Point(5, 34);
            this.lblAnioLectivo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lblAnioLectivo.Name = "lblAnioLectivo";
            this.lblAnioLectivo.Size = new System.Drawing.Size(83, 19);
            this.lblAnioLectivo.TabIndex = 1;
            this.lblAnioLectivo.Text = "Año Lectivo";
            // 
            // txtAnioLectivo
            // 
            this.txtAnioLectivo.Enabled = false;
            this.txtAnioLectivo.Location = new System.Drawing.Point(97, 31);
            this.txtAnioLectivo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtAnioLectivo.Name = "txtAnioLectivo";
            this.txtAnioLectivo.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAnioLectivo.Properties.Appearance.Options.UseFont = true;
            this.txtAnioLectivo.Size = new System.Drawing.Size(128, 26);
            this.txtAnioLectivo.TabIndex = 0;
            // 
            // txtPeriodo
            // 
            this.txtPeriodo.Enabled = false;
            this.txtPeriodo.Location = new System.Drawing.Point(97, 70);
            this.txtPeriodo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPeriodo.Name = "txtPeriodo";
            this.txtPeriodo.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPeriodo.Properties.Appearance.Options.UseFont = true;
            this.txtPeriodo.Size = new System.Drawing.Size(128, 26);
            this.txtPeriodo.TabIndex = 2;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Location = new System.Drawing.Point(5, 74);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(54, 19);
            this.labelControl1.TabIndex = 3;
            this.labelControl1.Text = "Periodo";
            // 
            // xtraTabPage2
            // 
            this.xtraTabPage2.Controls.Add(this.btnAperturaAnual);
            this.xtraTabPage2.Margin = new System.Windows.Forms.Padding(4);
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.Size = new System.Drawing.Size(954, 163);
            this.xtraTabPage2.Text = "Apertura Ciclo";
            // 
            // ucGe_Menu_Superior_Mant1
            // 
            this.ucGe_Menu_Superior_Mant1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucGe_Menu_Superior_Mant1.Enabled_bnRetImprimir = false;
            this.ucGe_Menu_Superior_Mant1.Enabled_bntAnular = false;
            this.ucGe_Menu_Superior_Mant1.Enabled_bntAprobar = false;
            this.ucGe_Menu_Superior_Mant1.Enabled_bntGuardar_y_Salir = false;
            this.ucGe_Menu_Superior_Mant1.Enabled_bntImprimir = false;
            this.ucGe_Menu_Superior_Mant1.Enabled_bntImprimir_Guia = false;
            this.ucGe_Menu_Superior_Mant1.Enabled_bntLimpiar = false;
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
            this.ucGe_Menu_Superior_Mant1.Enabled_btnproductos = false;
            this.ucGe_Menu_Superior_Mant1.Location = new System.Drawing.Point(0, 0);
            this.ucGe_Menu_Superior_Mant1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ucGe_Menu_Superior_Mant1.Name = "ucGe_Menu_Superior_Mant1";
            this.ucGe_Menu_Superior_Mant1.Size = new System.Drawing.Size(962, 36);
            this.ucGe_Menu_Superior_Mant1.TabIndex = 11;
            this.ucGe_Menu_Superior_Mant1.Visible_bntAnular = false;
            this.ucGe_Menu_Superior_Mant1.Visible_bntAprobar = false;
            this.ucGe_Menu_Superior_Mant1.Visible_bntDiseñoReporte = false;
            this.ucGe_Menu_Superior_Mant1.Visible_bntGuardar_y_Salir = false;
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
            this.ucGe_Menu_Superior_Mant1.Visible_btnGuardar = false;
            this.ucGe_Menu_Superior_Mant1.Visible_btnImpFrm = false;
            this.ucGe_Menu_Superior_Mant1.Visible_btnImpLote = false;
            this.ucGe_Menu_Superior_Mant1.Visible_btnImpRep = false;
            this.ucGe_Menu_Superior_Mant1.Visible_btnImprimirSoporte = false;
            this.ucGe_Menu_Superior_Mant1.Visible_btnModificar = false;
            this.ucGe_Menu_Superior_Mant1.Visible_btnproductos = false;
            this.ucGe_Menu_Superior_Mant1.event_btnSalir_Click += new Core.Erp.Winform.Controles.UCGe_Menu_Superior_Mant.delegate_btnSalir_Click(this.ucGe_Menu_Superior_Mant1_event_btnSalir_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.xtraTabControl1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 36);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(962, 199);
            this.panel1.TabIndex = 12;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblNumRegistros);
            this.panel2.Controls.Add(this.progressBar);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 235);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(962, 28);
            this.panel2.TabIndex = 13;
            // 
            // lblNumRegistros
            // 
            this.lblNumRegistros.Location = new System.Drawing.Point(13, 7);
            this.lblNumRegistros.Margin = new System.Windows.Forms.Padding(4);
            this.lblNumRegistros.Name = "lblNumRegistros";
            this.lblNumRegistros.Size = new System.Drawing.Size(0, 16);
            this.lblNumRegistros.TabIndex = 5;
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(223, 1);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(736, 22);
            this.progressBar.TabIndex = 0;
            // 
            // Col_pe_apellido
            // 
            this.Col_pe_apellido.Caption = "Apellidos";
            this.Col_pe_apellido.FieldName = "pe_apellido";
            this.Col_pe_apellido.Name = "Col_pe_apellido";
            this.Col_pe_apellido.Visible = true;
            this.Col_pe_apellido.VisibleIndex = 2;
            this.Col_pe_apellido.Width = 381;
            // 
            // Col_pe_nombre
            // 
            this.Col_pe_nombre.Caption = "Nombres";
            this.Col_pe_nombre.FieldName = "pe_nombre";
            this.Col_pe_nombre.Name = "Col_pe_nombre";
            this.Col_pe_nombre.Visible = true;
            this.Col_pe_nombre.VisibleIndex = 3;
            this.Col_pe_nombre.Width = 381;
            // 
            // Frm_Aca_Apertura_Ciclo_Facturacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(962, 680);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ucGe_Menu_Superior_Mant1);
            this.Controls.Add(this.groupBox2);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Frm_Aca_Apertura_Ciclo_Facturacion";
            this.Text = "Frm_Aca_Apertura_Ciclo_Facturacion";
            this.Load += new System.EventHandler(this.Frm_Aca_Apertura_Ciclo_Facturacion_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridCtrlEstudianteCurso)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridvwEstudianteCurso)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtAnioLectivo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPeriodo.Properties)).EndInit();
            this.xtraTabPage2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private DevExpress.XtraGrid.GridControl gridCtrlEstudianteCurso;
        private DevExpress.XtraGrid.Views.Grid.GridView gridvwEstudianteCurso;
        private DevExpress.XtraGrid.Columns.GridColumn ColCod_Estudiante;
        private DevExpress.XtraGrid.Columns.GridColumn ColEstudiante;
        private DevExpress.XtraGrid.Columns.GridColumn ColCurso;
        private DevExpress.XtraGrid.Columns.GridColumn ColParalelo;
        private DevExpress.XtraEditors.SimpleButton btnAperturaAnual;
        private DevExpress.XtraEditors.SimpleButton btnPeriodoSiguiente;
        private DevExpress.XtraEditors.SimpleButton btnPeriodoAnterior;
        private System.Windows.Forms.GroupBox groupBox3;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private System.Windows.Forms.GroupBox groupBox4;
        private DevExpress.XtraEditors.LabelControl lblAnioLectivo;
        private DevExpress.XtraEditors.TextEdit txtAnioLectivo;
        private DevExpress.XtraEditors.TextEdit txtPeriodo;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
        private DevExpress.XtraBars.Ribbon.Gallery.GalleryControlGallery galleryControlGallery1;
        private Controles.UCGe_Menu_Superior_Mant ucGe_Menu_Superior_Mant1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ProgressBar progressBar;
        private DevExpress.XtraEditors.LabelControl lblNumRegistros;
        private DevExpress.XtraGrid.Columns.GridColumn Col_seleccionar;
        private DevExpress.XtraGrid.Columns.GridColumn Col_pe_apellido;
        private DevExpress.XtraGrid.Columns.GridColumn Col_pe_nombre;

    }
}