namespace cw2;

public class GasContainer(Product product, double maxLoadMassKg, double containerMassKg, double heightCm, double depthCm, double pressureAtm)
    : Container(product, maxLoadMassKg, containerMassKg, heightCm, depthCm),
        IHazardNotifier
{
    public override string Type() => "G";
    public double PressureAtm { get; set; } = pressureAtm;

    public override void Fill(double massKg)
    {
        if (
            (Product is HazardProduct && massKg > 0.5 * MaxLoadMassKg) ||
            massKg > 0.9*MaxLoadMassKg
        )
            NotifyHazard();
        
        base.Fill(massKg);
    }

    public override void Empty()
    {
        LoadMassKg = MaxLoadMassKg * 0.05;
    }

    public void NotifyHazard()
    {
        Console.WriteLine($"!!! Hazard at container {SerialNumber}");
    } 
}