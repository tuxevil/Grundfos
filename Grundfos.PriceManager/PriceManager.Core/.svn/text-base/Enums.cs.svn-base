namespace PriceManager.Core
{
    #region Statuses

    public enum ImportStatus
    {
        [EnumDescription("Subido")]
        Uploaded = 0,
        [EnumDescription("Inválido")]
        Invalid = 1,
        [EnumDescription("Verificado")]
        Verified = 2,
        [EnumDescription("Verificado/Errores")]
        VerifiedSomeInvalid = 3,
        [EnumDescription("Procesado")]
        Processed = 4,
        [EnumDescription("Ejecutando")]
        Executing = 5,
        [EnumDescription("Enviado a ejecutar")]
        SendToExecute = 6,
        [EnumDescription("Error en ejecución")]
        Failed = 7
    }

    public enum ContactStatus
    {
        [EnumDescription("Inactivo")]
        Disable = 0,
        [EnumDescription("Activo")]
        Active = 1,
    }

    public enum ProviderStatus 
    {
        [EnumDescription("Incompleto")]
        Incomplete = 2,
        [EnumDescription("Activo")]
        Active = 1,
        [EnumDescription("Inactivo")]
        Disable = 0,
    }

    public enum CategoryPageStatus
    {
        [EnumDescription("Activo")]
        Active = 1,
        [EnumDescription("Inactivo")]
        Disable = 0,
    }

    public enum DistributorStatus
    {
        [EnumDescription("Incompleto")]
        Incomplete = 2,
        [EnumDescription("Activo")]
        Active = 1,
        [EnumDescription("Inactivo")]
        Disable = 0,
    }

    public enum ProductStatus
    {
        [EnumDescription("Activo")]
        Active = 1,
        [EnumDescription("Inactivo")]
        Disable = 0,
    }

    public enum WorkListItemStatus
    {
        [EnumDescription("Publicado")]
        Published = 1,
        [EnumDescription("Modificado")]
        Modified = 2,
        [EnumDescription("Aprobado")]
        Approved = 3,
        [EnumDescription("Agregado")]
        Added = 4,
        [EnumDescription("Agregado/Modificado")]
        AddedMod = 5
    }

    public enum PriceListStatus
    {
        [EnumDescription("Nuevo")]
        New = 2,
        [EnumDescription("Activo")]
        Active = 1,
        [EnumDescription("Inactivo")]
        Disable = 0,
        [EnumDescription("Eliminado")]
        Deleted = -1,
    }

    public enum PublishListStatus
    {
        [EnumDescription("Inactiva")]
        Disable = 0,
        [EnumDescription("Modificada")]
        Modified = 1,
        [EnumDescription("Publicada")]
        Published = 2,
        [EnumDescription("Vigente")]
        Current = 3,
        [EnumDescription("Aprobada")]
        Approved = 4,
        [EnumDescription("Nueva")]
        New = 5,
    }

    public enum PriceBaseStatus
    {
        [EnumDescription("Inactivo")]
        Disable = 0,
        [EnumDescription("Fuera de Lista")]
        NotVerified = 1,
        [EnumDescription("Base")]
        Verified = 2,
    }

    public enum PriceImportLogStatus
    {
        Add = 0,
        Modify = 1,
        Error = 2,
    }

    public enum QuoteStatus
    {
        [EnumDescription("Rechazada")]
        Rejected = 0,
        [EnumDescription("Borrador")]
        Draft = 1,
        [EnumDescription("Enviada")]
        Sent = 2,
        [EnumDescription("Asistencia Solicitada")]
        AssistenceRequired = 3,
        [EnumDescription("En Asistencia")]
        InAssistence = 4,
    }

    #endregion

    public enum IndexEnum
    {
        Bajo = 1,
        Medio = 2,
        Alto = 3,
    }

    public enum Frequency
    {
        [EnumDescription("50HZ")]
        Hz50 = 1,
        [EnumDescription("60HZ")]
        Hz60 = 2,
        [EnumDescription("50HZ/60HZ")]
        All = 3,
    }

    public enum EditionMode
    {
        View = 1,
        Edit = 2,
        Create = 3,
    }

    public enum MasterListType
    {
        OutOfGroupView = 1,
        PriceGroupView = 2,
        AdminView = 3,
        MasterPriceView = 4,
        Import = 5,
        PriceList = 6,
        PriceListProducts = 7,
        PublishListProducts = 8,
        Distributors = 9,
        PriceListModifiedProducts = 10,
        DistributorCurrentPriceList = 11,
        ProductsView = 12,
        ProductsBaseHistory = 13,
        ProvidersView = 14,
        ProviderAssignedProducts = 15,
        ProductPriceAttributeHistory = 16,
        ProductWorkListItemHistory = 17,
        CategoryView = 18,
        CurrencyView = 19,
        LookupView = 20,
        PriceCalculation = 21,
        QuoteView = 22,
        PriceGroupDetailsView = 23,
        QuoteProductsView = 24,
        QuoteProductsCreate = 25,
        PageList = 26,
        PageListProducts = 27,
        PageListChilds = 28,
        QuoteRange = 29,
    }

   

    public enum ExecutionStatus
    {
        Start = 1,
        Running = 2,
        Finished = 3,
        FinishedWithErrors = 4
    }

    public enum CategoryType
    {
        [EnumDescription("Familia")]
        Family = 1,
        [EnumDescription("Pagína")]
        CatalogPage = 2,
        [EnumDescription("Tipo")]
        ProductType = 3,
        [EnumDescription("Categoría")]
        Category= 4
    }

    public enum PriceCalculationPriority
    {
        [EnumDescription("Proveedor/Categoria")]
        ProvCat = 1,
        [EnumDescription("Proveedor")]
        Prov = 2,
        [EnumDescription("Categoria")]
        Cat = 3,
        [EnumDescription("Tipo de Producto")]
        ProdType = 4,
        [EnumDescription("Defecto")]
        Default = 99,
    }

    public enum LookupType
    {
        [EnumDescription("Tipo de Canal de Ventas")]
        DistributorType = 1,
        [EnumDescription("Tipo de Lista de Precios")]
        PriceListType = 2,
        [EnumDescription("Tipo de Condición de Compra")]
        PurchaseType = 3,
        [EnumDescription("Texto Introducción de Cotización")]
        QuoteIntroText = 4,
        [EnumDescription("Condición de Cotización")]
        QuoteCondition = 5,
        [EnumDescription("Vigencia de Cotización")]
        QuoteVigency = 6,
        [EnumDescription("Condiciones Comerciales")]
        ComercialCondition = 7,
        [EnumDescription("Mail a Administrador")]
        AdministratorReceiveMail = 8,
        [EnumDescription("Condición de Pago")]
        PaymentTerm = 9,
        [EnumDescription("Plazo de Entrega")]
        DeliveryTerm = 10,
        [EnumDescription("Condición de Venta")]
        Incoterm = 11,
        [EnumDescription("Compromiso de Ctr")]
        CtrCommitment = 12,
        [EnumDescription("Compromiso de Index")]
        IndexCommitment = 13,
        [EnumDescription("Tiempo de Entrega")]
        DeliveryTime = 14,
    }

    //public enum PaymentTerm
    //{
    //    [EnumDescription("No Definida")]
    //    notdefine = 0,
    //    [EnumDescription("Condición 1")]
    //    condition1 = 1,
    //    [EnumDescription("Condición 2")]
    //    condition2 = 2,
    //    [EnumDescription("Condición 3")]
    //    condition3 = 3,
    //}

    public enum HistoryStatus
    {
        [EnumDescription("Eliminación")]
        Delete = 0,
        [EnumDescription("Cambio de Precio")]
        PriceChange = 1,
        [EnumDescription("Cambio de Precio Individual")]
        IndividualPriceChange = 2,
        [EnumDescription("Actualizacion")]
        Update = 3
    }

    
}