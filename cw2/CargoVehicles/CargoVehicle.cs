namespace cw2.CargoVehicles;

public abstract class CargoVehicle
{
    private List<Container> _containers;

    public List<Container> Containers
    {
        get => _containers;
        private set
        {
            if (value.Count > MaxContainers)
                throw new ArgumentException("Container count cannot be larger than vehicle's capacity");
            _containers = value;
        }
    }

    private int _maxContainers;
    public int MaxContainers
    {
        get => _maxContainers;
        set
        {
            if (value < Containers.Count)
                throw new ArgumentOutOfRangeException("Vehicle's max containers cannot be less than the number of containers");
            _maxContainers = value;
        }
    }

    private double _maxLoadMassKg;
    public double MaxLoadMassKg
    {
        get => _maxLoadMassKg;
        set
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException("Vehicle's max load mass kg cannot be less than zero");
            if (value < ContainersMaxLoadMassKg)
                throw new ArgumentException("Vehicle's max load mass kg cannot be less than max load mass kg for all container's combined"); 
            _maxLoadMassKg = value;
        }
    }

    protected CargoVehicle(int maxContainers, double maxLoadMassKg)
    {
        _containers = new List<Container>();
        _maxContainers = maxContainers;
        _maxLoadMassKg = maxLoadMassKg;
    }

    public double ContainersMaxLoadMassKg
    {
        get
        {
            double total = 0;
            foreach (var container in Containers)
                total += container.MaxLoadMassKg;
            
            return total;
        }
    }

    public void AddContainer(Container container)
    {
        _containers.Add(container);
    }

    public void RemoveContainer(Container container)
    {
        _containers.Remove(container);
    }
}