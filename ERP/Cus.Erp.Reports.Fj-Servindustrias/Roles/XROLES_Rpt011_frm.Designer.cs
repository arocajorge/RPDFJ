namespace Cus.Erp.Reports.FJ.Roles
{
    partial class XROLES_Rpt011_frm
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
            this.pivotGridControl1 = new DevExpress.XtraPivotGrid.PivotGridControl();
            this.Col_pe_cedulaRuc = new DevExpress.XtraPivotGrid.PivotGridField();
            this.Col_zo_descripcion = new DevExpress.XtraPivotGrid.PivotGridField();
            this.Col_ru_descripcion = new DevExpress.XtraPivotGrid.PivotGridField();
            this.Col_em_fechaIngaRol = new DevExpress.XtraPivotGrid.PivotGridField();
            this.Col_em_status = new DevExpress.XtraPivotGrid.PivotGridField();
            this.Col_Empleado = new DevExpress.XtraPivotGrid.PivotGridField();
            this.Col_ca_descripcion = new DevExpress.XtraPivotGrid.PivotGridField();
            this.Col_SueldoActual = new DevExpress.XtraPivotGrid.PivotGridField();
            this.Col_Valor_bono = new DevExpress.XtraPivotGrid.PivotGridField();
            this.Col_dias_trabajados = new DevExpress.XtraPivotGrid.PivotGridField();
            this.Col_diasefectivos = new DevExpress.XtraPivotGrid.PivotGridField();
            this.Col_Efectividad_Entrega = new DevExpress.XtraPivotGrid.PivotGridField();
            this.Col_Efectividad_Volumen = new DevExpress.XtraPivotGrid.PivotGridField();
            this.Col_Recuperacion_cartera = new DevExpress.XtraPivotGrid.PivotGridField();
            this.Col_Efectividad_Entrega_aplica = new DevExpress.XtraPivotGrid.PivotGridField();
            this.Col_Efectividad_Volumen_aplica = new DevExpress.XtraPivotGrid.PivotGridField();
            this.Col_Recuperacion_cartera_aplica = new DevExpress.XtraPivotGrid.PivotGridField();
            this.Col_variable = new DevExpress.XtraPivotGrid.PivotGridField();
            this.Col_Rubro = new DevExpress.XtraPivotGrid.PivotGridField();
            this.Col_Valor = new DevExpress.XtraPivotGrid.PivotGridField();
            this.ucRo_Menu = new Core.Erp.Reportes.Controles.UCRo_Menu_Reportes();
            ((System.ComponentModel.ISupportInitialize)(this.pivotGridControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // pivotGridControl1
            // 
            this.pivotGridControl1.Appearance.ColumnHeaderArea.ForeColor = System.Drawing.Color.Yellow;
            this.pivotGridControl1.Appearance.ColumnHeaderArea.Options.UseForeColor = true;
            this.pivotGridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pivotGridControl1.Fields.AddRange(new DevExpress.XtraPivotGrid.PivotGridField[] {
            this.Col_pe_cedulaRuc,
            this.Col_zo_descripcion,
            this.Col_ru_descripcion,
            this.Col_em_fechaIngaRol,
            this.Col_em_status,
            this.Col_Empleado,
            this.Col_ca_descripcion,
            this.Col_SueldoActual,
            this.Col_Valor_bono,
            this.Col_dias_trabajados,
            this.Col_diasefectivos,
            this.Col_Efectividad_Entrega,
            this.Col_Efectividad_Volumen,
            this.Col_Recuperacion_cartera,
            this.Col_Efectividad_Entrega_aplica,
            this.Col_Efectividad_Volumen_aplica,
            this.Col_Recuperacion_cartera_aplica,
            this.Col_variable,
            this.Col_Rubro,
            this.Col_Valor});
            this.pivotGridControl1.Location = new System.Drawing.Point(0, 74);
            this.pivotGridControl1.Name = "pivotGridControl1";
            this.pivotGridControl1.OptionsBehavior.HorizontalScrolling = DevExpress.XtraPivotGrid.PivotGridScrolling.Control;
            this.pivotGridControl1.OptionsPrint.MergeColumnFieldValues = false;
            this.pivotGridControl1.OptionsPrint.MergeRowFieldValues = false;
            this.pivotGridControl1.OptionsPrint.PrintUnusedFilterFields = false;
            this.pivotGridControl1.OptionsPrint.UsePrintAppearance = true;
            this.pivotGridControl1.OptionsView.ShowColumnGrandTotalHeader = false;
            this.pivotGridControl1.OptionsView.ShowColumnGrandTotals = false;
            this.pivotGridControl1.OptionsView.ShowColumnTotals = false;
            this.pivotGridControl1.OptionsView.ShowRowGrandTotalHeader = false;
            this.pivotGridControl1.OptionsView.ShowRowGrandTotals = false;
            this.pivotGridControl1.OptionsView.ShowRowTotals = false;
            this.pivotGridControl1.Size = new System.Drawing.Size(1354, 343);
            this.pivotGridControl1.TabIndex = 147;
            // 
            // Col_pe_cedulaRuc
            // 
            this.Col_pe_cedulaRuc.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.Col_pe_cedulaRuc.AreaIndex = 0;
            this.Col_pe_cedulaRuc.Caption = "Cedula";
            this.Col_pe_cedulaRuc.FieldName = "pe_cedulaRuc";
            this.Col_pe_cedulaRuc.Name = "Col_pe_cedulaRuc";
            this.Col_pe_cedulaRuc.Options.ReadOnly = true;
            this.Col_pe_cedulaRuc.SortOrder = DevExpress.XtraPivotGrid.PivotSortOrder.Descending;
            this.Col_pe_cedulaRuc.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Min;
            // 
            // Col_zo_descripcion
            // 
            this.Col_zo_descripcion.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.Col_zo_descripcion.AreaIndex = 1;
            this.Col_zo_descripcion.Caption = "Sector";
            this.Col_zo_descripcion.FieldName = "zo_descripcion";
            this.Col_zo_descripcion.Name = "Col_zo_descripcion";
            // 
            // Col_ru_descripcion
            // 
            this.Col_ru_descripcion.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.Col_ru_descripcion.AreaIndex = 2;
            this.Col_ru_descripcion.Caption = "Ruta";
            this.Col_ru_descripcion.FieldName = "ru_descripcion";
            this.Col_ru_descripcion.Name = "Col_ru_descripcion";
            // 
            // Col_em_fechaIngaRol
            // 
            this.Col_em_fechaIngaRol.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.Col_em_fechaIngaRol.AreaIndex = 3;
            this.Col_em_fechaIngaRol.Caption = "Fecha Ingreso";
            this.Col_em_fechaIngaRol.FieldName = "em_fechaIngaRol";
            this.Col_em_fechaIngaRol.Name = "Col_em_fechaIngaRol";
            // 
            // Col_em_status
            // 
            this.Col_em_status.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.Col_em_status.AreaIndex = 4;
            this.Col_em_status.Caption = "Fecha Salida";
            this.Col_em_status.FieldName = "em_status";
            this.Col_em_status.Name = "Col_em_status";
            // 
            // Col_Empleado
            // 
            this.Col_Empleado.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.Col_Empleado.AreaIndex = 5;
            this.Col_Empleado.Caption = "Nombres";
            this.Col_Empleado.FieldName = "Empleado";
            this.Col_Empleado.Name = "Col_Empleado";
            // 
            // Col_ca_descripcion
            // 
            this.Col_ca_descripcion.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.Col_ca_descripcion.AreaIndex = 6;
            this.Col_ca_descripcion.Caption = "Cargo";
            this.Col_ca_descripcion.FieldName = "ca_descripcion";
            this.Col_ca_descripcion.Name = "Col_ca_descripcion";
            // 
            // Col_SueldoActual
            // 
            this.Col_SueldoActual.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.Col_SueldoActual.AreaIndex = 7;
            this.Col_SueldoActual.Caption = "Sueldo";
            this.Col_SueldoActual.FieldName = "SueldoActual";
            this.Col_SueldoActual.Name = "Col_SueldoActual";
            // 
            // Col_Valor_bono
            // 
            this.Col_Valor_bono.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.Col_Valor_bono.AreaIndex = 8;
            this.Col_Valor_bono.Caption = "Bono";
            this.Col_Valor_bono.FieldName = "Valor_bono";
            this.Col_Valor_bono.Name = "Col_Valor_bono";
            // 
            // Col_dias_trabajados
            // 
            this.Col_dias_trabajados.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.Col_dias_trabajados.AreaIndex = 9;
            this.Col_dias_trabajados.Caption = "Dias";
            this.Col_dias_trabajados.FieldName = "dias_trabajados";
            this.Col_dias_trabajados.Name = "Col_dias_trabajados";
            // 
            // Col_diasefectivos
            // 
            this.Col_diasefectivos.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.Col_diasefectivos.AreaIndex = 10;
            this.Col_diasefectivos.Caption = "Dias Efectivo";
            this.Col_diasefectivos.FieldName = "dias_Efectivos";
            this.Col_diasefectivos.Name = "Col_diasefectivos";
            // 
            // Col_Efectividad_Entrega
            // 
            this.Col_Efectividad_Entrega.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.Col_Efectividad_Entrega.AreaIndex = 11;
            this.Col_Efectividad_Entrega.Caption = "Efectividad Entrega";
            this.Col_Efectividad_Entrega.CellFormat.FormatString = "p1";
            this.Col_Efectividad_Entrega.CellFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.Col_Efectividad_Entrega.FieldName = "Efectividad_Entrega";
            this.Col_Efectividad_Entrega.Name = "Col_Efectividad_Entrega";
            // 
            // Col_Efectividad_Volumen
            // 
            this.Col_Efectividad_Volumen.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.Col_Efectividad_Volumen.AreaIndex = 12;
            this.Col_Efectividad_Volumen.Caption = "Efectividad Volumen";
            this.Col_Efectividad_Volumen.CellFormat.FormatString = "p1";
            this.Col_Efectividad_Volumen.CellFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.Col_Efectividad_Volumen.FieldName = "Efectividad_Volumen";
            this.Col_Efectividad_Volumen.Name = "Col_Efectividad_Volumen";
            // 
            // Col_Recuperacion_cartera
            // 
            this.Col_Recuperacion_cartera.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.Col_Recuperacion_cartera.AreaIndex = 13;
            this.Col_Recuperacion_cartera.Caption = "Recuperacion Cartera";
            this.Col_Recuperacion_cartera.CellFormat.FormatString = "p1";
            this.Col_Recuperacion_cartera.CellFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.Col_Recuperacion_cartera.FieldName = "Recuperacion_cartera";
            this.Col_Recuperacion_cartera.Name = "Col_Recuperacion_cartera";
            // 
            // Col_Efectividad_Entrega_aplica
            // 
            this.Col_Efectividad_Entrega_aplica.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.Col_Efectividad_Entrega_aplica.AreaIndex = 17;
            this.Col_Efectividad_Entrega_aplica.Caption = "Pedido";
            this.Col_Efectividad_Entrega_aplica.CellFormat.FormatString = "p1";
            this.Col_Efectividad_Entrega_aplica.CellFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.Col_Efectividad_Entrega_aplica.FieldName = "Efectividad_Entrega_aplica";
            this.Col_Efectividad_Entrega_aplica.Name = "Col_Efectividad_Entrega_aplica";
            // 
            // Col_Efectividad_Volumen_aplica
            // 
            this.Col_Efectividad_Volumen_aplica.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.Col_Efectividad_Volumen_aplica.AreaIndex = 16;
            this.Col_Efectividad_Volumen_aplica.Caption = "Volumen";
            this.Col_Efectividad_Volumen_aplica.CellFormat.FormatString = "p1";
            this.Col_Efectividad_Volumen_aplica.CellFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.Col_Efectividad_Volumen_aplica.FieldName = "Efectividad_Volumen_aplica";
            this.Col_Efectividad_Volumen_aplica.Name = "Col_Efectividad_Volumen_aplica";
            // 
            // Col_Recuperacion_cartera_aplica
            // 
            this.Col_Recuperacion_cartera_aplica.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.Col_Recuperacion_cartera_aplica.AreaIndex = 15;
            this.Col_Recuperacion_cartera_aplica.Caption = "Cartera";
            this.Col_Recuperacion_cartera_aplica.CellFormat.FormatString = "p1";
            this.Col_Recuperacion_cartera_aplica.CellFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.Col_Recuperacion_cartera_aplica.FieldName = "Recuperacion_cartera_aplica";
            this.Col_Recuperacion_cartera_aplica.Name = "Col_Recuperacion_cartera_aplica";
            // 
            // Col_variable
            // 
            this.Col_variable.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.Col_variable.AreaIndex = 14;
            this.Col_variable.Caption = "Variable";
            this.Col_variable.FieldName = "variable";
            this.Col_variable.Name = "Col_variable";
            // 
            // Col_Rubro
            // 
            this.Col_Rubro.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
            this.Col_Rubro.AreaIndex = 0;
            this.Col_Rubro.Caption = "Rubro";
            this.Col_Rubro.FieldName = "Rubro";
            this.Col_Rubro.Name = "Col_Rubro";
            // 
            // Col_Valor
            // 
            this.Col_Valor.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            this.Col_Valor.AreaIndex = 0;
            this.Col_Valor.Caption = "Valor";
            this.Col_Valor.FieldName = "Valor";
            this.Col_Valor.Name = "Col_Valor";
            // 
            // ucRo_Menu
            // 
            this.ucRo_Menu.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucRo_Menu.EnableBotonImprimir = true;
            this.ucRo_Menu.Location = new System.Drawing.Point(0, 0);
            this.ucRo_Menu.Name = "ucRo_Menu";
            this.ucRo_Menu.Size = new System.Drawing.Size(1354, 74);
            this.ucRo_Menu.TabIndex = 146;
            this.ucRo_Menu.VisibleCmbCentroCosto = DevExpress.XtraBars.BarItemVisibility.Never;
            this.ucRo_Menu.VisibleCmbDivision = DevExpress.XtraBars.BarItemVisibility.Never;
            this.ucRo_Menu.VisibleCmbEmpleado = DevExpress.XtraBars.BarItemVisibility.Never;
            this.ucRo_Menu.VisibleCmbNominaTipo = DevExpress.XtraBars.BarItemVisibility.Always;
            this.ucRo_Menu.VisibleCmbNominaTipoLiqui = DevExpress.XtraBars.BarItemVisibility.Always;
            this.ucRo_Menu.VisibleCmbPeriodo = DevExpress.XtraBars.BarItemVisibility.Always;
            this.ucRo_Menu.VisibleCmbRubro = DevExpress.XtraBars.BarItemVisibility.Never;
            this.ucRo_Menu.VisibleDepartamento = DevExpress.XtraBars.BarItemVisibility.Always;
            this.ucRo_Menu.VisibleEstado = DevExpress.XtraBars.BarItemVisibility.Always;
            this.ucRo_Menu.VisibleGrupoFecha = false;
            this.ucRo_Menu.VisibleGrupoFiltro1 = true;
            this.ucRo_Menu.VisibleGrupoFiltro2 = false;
            this.ucRo_Menu.VisubleArea = DevExpress.XtraBars.BarItemVisibility.Always;
            this.ucRo_Menu.event_cmbPeriodo_EditValueChanged += new Core.Erp.Reportes.Controles.UCRo_Menu_Reportes.delegate_cmbPeriodo_EditValueChanged(this.ucRo_Menu_event_cmbPeriodo_EditValueChanged_1);
            this.ucRo_Menu.event_cmdCargar_ItemClick += new Core.Erp.Reportes.Controles.UCRo_Menu_Reportes.delegate_cmdCargar_ItemClick(this.ucRo_Menu_event_cmdCargar_ItemClick);
            this.ucRo_Menu.event_btnsalir_ItemClick += new Core.Erp.Reportes.Controles.UCRo_Menu_Reportes.delegate_btnsalir_ItemClick(this.ucRo_Menu_event_btnsalir_ItemClick);
            // 
            // XROLES_Rpt011_frm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1354, 417);
            this.Controls.Add(this.pivotGridControl1);
            this.Controls.Add(this.ucRo_Menu);
            this.Name = "XROLES_Rpt011_frm";
            this.Text = "CONTROL DE ASISTENCIA TRANSGANDIA FJ FIJOS";
            this.Load += new System.EventHandler(this.XROLES_Rpt011_frm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pivotGridControl1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Core.Erp.Reportes.Controles.UCRo_Menu_Reportes ucRo_Menu;
        private DevExpress.XtraPivotGrid.PivotGridControl pivotGridControl1;
        private DevExpress.XtraPivotGrid.PivotGridField Col_pe_cedulaRuc;
        private DevExpress.XtraPivotGrid.PivotGridField Col_zo_descripcion;
        private DevExpress.XtraPivotGrid.PivotGridField Col_ru_descripcion;
        private DevExpress.XtraPivotGrid.PivotGridField Col_em_fechaIngaRol;
        private DevExpress.XtraPivotGrid.PivotGridField Col_em_status;
        private DevExpress.XtraPivotGrid.PivotGridField Col_Empleado;
        private DevExpress.XtraPivotGrid.PivotGridField Col_ca_descripcion;
        private DevExpress.XtraPivotGrid.PivotGridField Col_SueldoActual;
        private DevExpress.XtraPivotGrid.PivotGridField Col_Valor_bono;
        private DevExpress.XtraPivotGrid.PivotGridField Col_dias_trabajados;
        private DevExpress.XtraPivotGrid.PivotGridField Col_diasefectivos;
        private DevExpress.XtraPivotGrid.PivotGridField Col_Efectividad_Entrega;
        private DevExpress.XtraPivotGrid.PivotGridField Col_Efectividad_Volumen;
        private DevExpress.XtraPivotGrid.PivotGridField Col_Recuperacion_cartera;
        private DevExpress.XtraPivotGrid.PivotGridField Col_Efectividad_Entrega_aplica;
        private DevExpress.XtraPivotGrid.PivotGridField Col_Efectividad_Volumen_aplica;
        private DevExpress.XtraPivotGrid.PivotGridField Col_Recuperacion_cartera_aplica;
        private DevExpress.XtraPivotGrid.PivotGridField Col_variable;
        private DevExpress.XtraPivotGrid.PivotGridField Col_Rubro;
        private DevExpress.XtraPivotGrid.PivotGridField Col_Valor;



    }
}