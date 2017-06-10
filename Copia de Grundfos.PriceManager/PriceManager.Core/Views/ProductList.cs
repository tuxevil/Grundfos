using System;
using System.Collections.Generic;
using System.Text;

namespace PriceManager.Core
{
    public class ProductList
    {
        private string prod_Codigo;
        private string prod_Descripcion;
        private ProductStatus prod_Status;
        private string prod_Modelo;
        private string prod_Claves;
        private decimal baseP_TP;
        private decimal baseP_GRP;
        private string baseP_CodProveedor;
        private Status baseP_Status;
        private string prov_Nombre;
        private string prov_Descripcion;
        private string prov_CondVentas;
        private string prov_CondCompras;
        private string prov_Ciudad;
        private string prov_Email;
        private string prov_Telefono;
        private string prov_Contacto;
        private ProviderStatus prov_Status;
        private string priceG_Nombre;
        private string priceG_Descripcion;
        private string moneda_Descripcion;
        private decimal moneda_Valor;
        private decimal priceA_PrecioLista;
        private decimal priceA_PrecioVenta;
        private string priceA_AtribProducto;
        private string pais_Nombre;

        public virtual string ProdCodigo
        {
            get { return prod_Codigo; }
            set { prod_Codigo = value; }
        }

        public virtual string ProdDescripcion
        {
            get { return prod_Descripcion; }
            set { prod_Descripcion = value; }
        }

        public virtual ProductStatus ProdStatus
        {
            get { return prod_Status; }
            set { prod_Status = value; }
        }

        public virtual string ProdModelo
        {
            get { return prod_Modelo; }
            set { prod_Modelo = value; }
        }

        public virtual string ProdClaves
        {
            get { return prod_Claves; }
            set { prod_Claves = value; }
        }

        public virtual decimal BasePTp
        {
            get { return baseP_TP; }
            set { baseP_TP = value; }
        }

        public virtual decimal BasePGrp
        {
            get { return baseP_GRP; }
            set { baseP_GRP = value; }
        }

        public virtual string BasePCodProveedor
        {
            get { return baseP_CodProveedor; }
            set { baseP_CodProveedor = value; }
        }

        public virtual Status BasePStatus
        {
            get { return baseP_Status; }
            set { baseP_Status = value; }
        }

        public virtual string ProvNombre
        {
            get { return prov_Nombre; }
            set { prov_Nombre = value; }
        }

        public virtual string ProvDescripcion
        {
            get { return prov_Descripcion; }
            set { prov_Descripcion = value; }
        }

        public virtual string ProvCondVentas
        {
            get { return prov_CondVentas; }
            set { prov_CondVentas = value; }
        }

        public virtual string ProvCondCompras
        {
            get { return prov_CondCompras; }
            set { prov_CondCompras = value; }
        }

        public virtual string ProvCiudad
        {
            get { return prov_Ciudad; }
            set { prov_Ciudad = value; }
        }

        public virtual string ProvEmail
        {
            get { return prov_Email; }
            set { prov_Email = value; }
        }

        public virtual string ProvTelefono
        {
            get { return prov_Telefono; }
            set { prov_Telefono = value; }
        }

        public virtual string ProvContacto
        {
            get { return prov_Contacto; }
            set { prov_Contacto = value; }
        }

        public virtual ProviderStatus ProvStatus
        {
            get { return prov_Status; }
            set { prov_Status = value; }
        }

        public virtual string PriceGNombre
        {
            get { return priceG_Nombre; }
            set { priceG_Nombre = value; }
        }

        public virtual string PriceGDescripcion
        {
            get { return priceG_Descripcion; }
            set { priceG_Descripcion = value; }
        }

        public virtual string MonedaDescripcion
        {
            get { return moneda_Descripcion; }
            set { moneda_Descripcion = value; }
        }

        public virtual decimal MonedaValor
        {
            get { return moneda_Valor; }
            set { moneda_Valor = value; }
        }

        public virtual decimal PriceAPrecioLista
        {
            get { return priceA_PrecioLista; }
            set { priceA_PrecioLista = value; }
        }

        public virtual decimal PriceAPrecioVenta
        {
            get { return priceA_PrecioVenta; }
            set { priceA_PrecioVenta = value; }
        }

        public virtual string PriceAAtribProducto
        {
            get { return priceA_AtribProducto; }
            set { priceA_AtribProducto = value; }
        }

        public virtual string PaisNombre
        {
            get { return pais_Nombre; }
            set { pais_Nombre = value; }
        }
    }
}
