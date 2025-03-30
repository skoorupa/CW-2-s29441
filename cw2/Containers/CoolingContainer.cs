namespace cw2;

public class CoolingContainer : Container
{
    public override string Type() => "C";
    public double TemperatureCls { get; set; }
    
    public CoolingContainer(Product product, double maxLoadMassKg, double containerMassKg, double heightCm, double depthCm, double temperatureCls) : base(product, maxLoadMassKg, containerMassKg, heightCm, depthCm)
    {
        TemperatureCls = temperatureCls;
        
        // wg wymagań, na logike powinno być na odwrót?
        if (temperatureCls < product.MinTemperatureCls && product.MinTemperatureCls != null)
            throw new ArgumentOutOfRangeException("Container's temperature cannot be lower than product's minimum temperature.");
    }

    public override string ToString()
    {
        return $"""Cooling({base.ToString()},TemperatureCls={TemperatureCls})""";
    }
}