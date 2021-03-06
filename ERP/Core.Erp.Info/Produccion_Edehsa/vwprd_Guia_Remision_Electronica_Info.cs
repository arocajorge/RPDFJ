﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Erp.Info.Produccion_Edehsa
{
    public class vwprd_Guia_Remision_Electronica_Info
    {
        public int IdEmpresa { get; set; }
        public int IdSucursal { get; set; }
        public int IdBodega { get; set; }
        public decimal IdGuiaRemision { get; set; }
        public string CodGuiaRemision { get; set; }
        public string CodDocumentoTipo { get; set; }
        public string Serie1 { get; set; }
        public string Serie2 { get; set; }
        public string NumGuia_Preimpresa { get; set; }
        public string NUAutorizacion { get; set; }
        public Nullable<System.DateTime> Fecha_Autorizacion { get; set; }
        public decimal IdCliente { get; set; }
        public int IdVendedor { get; set; }
        public System.DateTime gi_fecha { get; set; }
        public Nullable<System.DateTime> gi_fech_venc { get; set; }
        public string gi_Observacion { get; set; }
        public Nullable<double> gi_TotalKilos { get; set; }
        public Nullable<decimal> gi_plazo { get; set; }
        public Nullable<double> gi_TotalQuintales { get; set; }
        public string IdUsuario { get; set; }
        public string IdUsuarioUltMod { get; set; }
        public System.DateTime Fecha_Transac { get; set; }
        public Nullable<System.DateTime> Fecha_UltMod { get; set; }
        public string IdUsuarioUltAnu { get; set; }
        public string nom_pc { get; set; }
        public Nullable<System.DateTime> Fecha_UltAnu { get; set; }
        public string ip { get; set; }
        public string Estado { get; set; }
        public string MotiAnula { get; set; }
        public string Impreso { get; set; }
        public Nullable<int> IdPeriodo { get; set; }
        public double gi_flete { get; set; }
        public double gi_interes { get; set; }
        public double gi_seguro { get; set; }
        public double gi_OtroValor1 { get; set; }
        public double gi_OtroValor2 { get; set; }
        public System.DateTime gi_FechaIniTraslado { get; set; }
        public string placa { get; set; }
        public System.DateTime gi_FechaFinTraslado { get; set; }
        public string ruta { get; set; }
        public string Direccion_Origen { get; set; }
        public string Direccion_Destino { get; set; }
        public Nullable<int> idMotivo_traslado { get; set; }
        public decimal IdTransportista { get; set; }
        public string Cedula_Transportista { get; set; }
        public string Nombre_Transportista { get; set; }
        public decimal IdProducto { get; set; }
        public double gi_cantidad { get; set; }
        public double gi_Precio { get; set; }
        public double gi_PorDescUnitario { get; set; }
        public double gi_DescUnitario { get; set; }
        public double gi_PrecioFinal { get; set; }
        public double gi_Subtotal { get; set; }
        public double gi_iva { get; set; }
        public double gi_total { get; set; }
        public double gi_costo { get; set; }
        public string gi_tieneIVA { get; set; }
        public string gi_detallexItems { get; set; }
        public Nullable<double> gi_peso { get; set; }
        public string pe_cedulaRuc { get; set; }
        public int IdTipoPersona { get; set; }
        public string IdTipoDocumento { get; set; }
        public string pe_razonSocial { get; set; }
        public string pe_nombreCompleto { get; set; }
        public string pe_apellido { get; set; }
        public string pe_nombre { get; set; }
        public string pe_direccion { get; set; }
        public string pe_correo { get; set; }
        public string em_nombre { get; set; }
        public string RazonSocial { get; set; }
        public string NombreComercial { get; set; }
        public string em_direccion { get; set; }
        public string descripcion_motivo_traslado { get; set; }
        public string em_ruc { get; set; }
        public string Su_Direccion { get; set; }
        public string ObligadoAllevarConta { get; set; }
        public string ContribuyenteEspecial { get; set; }
        public string pr_codigo { get; set; }
        public string pr_descripcion { get; set; }
        public string pr_descripcion_2 { get; set; }
        public string unidad_medida_consumo { get; set; }
        public string CodObra { get; set; }
        public string descripcion_obra { get; set; }

        public vwprd_Guia_Remision_Electronica_Info() { }
    }
}
