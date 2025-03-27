namespace cw2;

abstract class Container(double maxLoadMassKg, double containerMassKg, double heightCm, double depthCm)
{
    private static string _typeLetter = "C";
    private static int _numberCounter = 1;
    
    public double LoadMassKg { get; private set; } = 0;
    public double MaxLoadMassKg { get; set; } = maxLoadMassKg;
    public double ContainerMassKg { get; set; } = containerMassKg;
    public double HeightCm { get; set; } = heightCm;
    public double DepthCm { get; set; } = depthCm;
    public string SerialNumber { get; } = $"KON-{_typeLetter}-{_numberCounter++}";
    
    public void Empty() => LoadMassKg = 0;

    public void Fill(double massKg)
    {
        if (massKg + LoadMassKg > MaxLoadMassKg)
            throw new OverfillException(this, massKg);
        
        LoadMassKg += massKg;
    }
}

class OverfillException : Exception
{
    public OverfillException(Container container, double massKg) : base($"{container.SerialNumber} cannot be filled with {massKg}") { }
}