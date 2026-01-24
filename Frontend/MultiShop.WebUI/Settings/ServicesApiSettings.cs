namespace MultiShop.WebUI.Settings;

public class ServicesApiSettings
{
    public string OcelotUrl { get; set; }
    public string IdentityServerUrl { get; set; }
    public ServicesApi Catalog { get; set; }
    public ServicesApi Image { get; set; }
    public ServicesApi Discount { get; set; }
    public ServicesApi Order { get; set; }
    public ServicesApi Cargo { get; set; }
    public ServicesApi Basket { get; set; }
    public ServicesApi Payment { get; set; }
    public ServicesApi Comment { get; set; }
}

public class ServicesApi
{
    public string Path { get; set; }
}