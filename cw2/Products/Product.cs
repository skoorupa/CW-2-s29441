namespace cw2;

public class Product
{
    public string Name { get; set; }
    public double? MinTemperatureCls { get; set; }

    public Product(string name)
    {
        Name = name;
    }

    public Product(string name, double minTemperatureCls)
    {
        Name = name;
        MinTemperatureCls = minTemperatureCls;
    }
}