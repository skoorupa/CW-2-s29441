namespace cw2;

public class Product
{
    public string Name { get; set; }
    public double? MinTemperatureCls { get; set; }
    public bool IsHazardous { get; set; }

    public Product(string name)
    {
        Name = name;
    }

    public Product(string name, double minTemperatureCls)
    {
        Name = name;
        MinTemperatureCls = minTemperatureCls;
    }
    
    public Product(string name, bool isHazardous)
    {
        Name = name;
        IsHazardous = isHazardous;
    }
}