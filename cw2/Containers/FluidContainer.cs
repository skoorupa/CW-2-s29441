namespace cw2;

public class FluidContainer(double maxLoadMassKg, double containerMassKg, double heightCm, double depthCm)
    : Container(maxLoadMassKg, containerMassKg, heightCm, depthCm),
        IHazardNotifier
{
    public override string Type => "L";
    
    public override double LoadMassKg
    {
        get => _loadMassKg;
        protected set
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException("Product's mass cannot be lower than zero");
            if (value > MaxLoadMassKg)
                throw new OverfillException(this, value);
            if (
                (Product is HazardProduct && value > 0.5 * MaxLoadMassKg) ||
                value > 0.9*MaxLoadMassKg
                )
                NotifyHazard();
            
            _loadMassKg = value;
        }
    }

    public void NotifyHazard()
    {
        Console.WriteLine($"!!! Hazard at container {SerialNumber}");
    } 
}