namespace cw2;

public abstract class Container
{
    public abstract string Type();
    private static int _numberCounter = 0;
    
    private Product? _product;
    public Product Product { get; }

    private double _loadMassKg;
    public double LoadMassKg
    {
        get => _loadMassKg;
        protected set
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException("Product's mass cannot be lower than zero");
            if (value > MaxLoadMassKg)
                throw new OverfillException(this, value);
            _loadMassKg = value;
        }
    }

    private double _maxLoadMassKg;
    public double MaxLoadMassKg
    {
        get => _maxLoadMassKg;
        set
        {
            if (value <= 0)
                throw new ArgumentOutOfRangeException("Container's max load cannot be lower or equal to zero");
            if (value < LoadMassKg)
                throw new ArgumentException("Container's max load mass cannot be lower than current's load mass");
            _maxLoadMassKg = value;
        }
    }

    private double _containerMassKg;
    public double ContainerMassKg
    {
        get => _containerMassKg;
        set
        {
            if (value <= 0) 
                throw new ArgumentOutOfRangeException("Container's mass cannot be lower or equal to zero");
            _containerMassKg = value;
        }
    }
    
    private double _heightCm;
    public double HeightCm
    {
        get => _heightCm;
        set
        {
            if (value <= 0)
                throw new ArgumentOutOfRangeException("Container's height cannot be lower or equal to zero");
            _heightCm = value;
        }
    }
    private double _depthCm;
    public double DepthCm
    {
        get => _depthCm;
        set
        {
            if (value <= 0)
                throw new ArgumentOutOfRangeException("Container's depth cannot be lower or equal to zero");
            _depthCm = value;
        }
    }
    public string SerialNumber { get; }

    public Container(double maxLoadMassKg, double containerMassKg, double heightCm, double depthCm)
    {
        MaxLoadMassKg = maxLoadMassKg;
        ContainerMassKg = containerMassKg;
        HeightCm = heightCm;
        DepthCm = depthCm;
        SerialNumber = $"KON-{Type}-{++_numberCounter}";
    }
    
    public virtual void Fill(double massKg) => LoadMassKg += massKg;
    
    public virtual void Empty() => LoadMassKg = 0;
}

class OverfillException : Exception
{
    public OverfillException(Container container, double massKg) : base($"{container.SerialNumber} cannot be filled with {massKg}") { }
}