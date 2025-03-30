namespace cw2;

public class FluidContainer(Product product, double maxLoadMassKg, double containerMassKg, double heightCm, double depthCm)
    : Container(product, maxLoadMassKg, containerMassKg, heightCm, depthCm),
        IHazardNotifier
{
    public override string Type() => "L";

    public override void Fill(double massKg)
    {
        if (
            (Product.IsHazardous && massKg > 0.5 * MaxLoadMassKg) ||
            massKg > 0.9*MaxLoadMassKg
        )
            NotifyHazard();
        
        base.Fill(massKg);
    }

    public void NotifyHazard()
    {
        Console.WriteLine($"!!! Hazard at container {SerialNumber}");
    } 
}