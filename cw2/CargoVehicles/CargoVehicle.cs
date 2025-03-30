namespace cw2.CargoVehicles;

public abstract class CargoVehicle
{
    public List<Container> Containers { get; } = new List<Container>();
    protected static List<CargoVehicle> _allCargoVehicles = new List<CargoVehicle>();

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
                throw new ArgumentException("Vehicle's max load mass kg cannot be less than max load mass kg for all containers combined"); 
            _maxLoadMassKg = value;
        }
    }

    protected CargoVehicle(int maxContainers, double maxLoadMassKg)
    {
        _maxContainers = maxContainers;
        _maxLoadMassKg = maxLoadMassKg;
        _allCargoVehicles.Add(this);
    }

    protected static bool IsContainerInAnyCargo(Container container)
    {
        foreach (var cargoVehicle in _allCargoVehicles)
        {
            if (cargoVehicle.IsContainerInCargo(container))
                return true;
        }
        return false;
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
        if (Containers.Count > MaxContainers)
            throw new ArgumentException("Container count cannot be larger than vehicle's capacity");
        if (ContainersMaxLoadMassKg + container.MaxLoadMassKg > MaxLoadMassKg)
            throw new ArgumentException("Max load for all containers combined needs to be lower than vehicle's max load mass kg");
        if (IsContainerInCargo(container))
            throw new ArgumentException("Container is already in this cargo");
        if (IsContainerInAnyCargo(container))
            throw new ArgumentException("Container is already in another container");
        
        Containers.Add(container);
    }

    public void AddContainers(List<Container> containers)
    {
        containers.ForEach(container => AddContainer(container));
    }

    public void RemoveContainer(Container container)
    {
        Containers.Remove(container);
    }

    public void ReplaceContainer(string containerSerialNumber, Container container)
    {
        if (!IsContainerInCargo(containerSerialNumber))
            throw new ArgumentException("Container is not in cargo");
        Containers.RemoveAll(c => c.SerialNumber == containerSerialNumber);
        AddContainer(container);
    }

    public bool IsContainerInCargo(string containerSerialNumber)
    {
        return Containers.Any(c => c.SerialNumber == containerSerialNumber);
    }

    public bool IsContainerInCargo(Container container)
    {
        return IsContainerInCargo(container.SerialNumber);
    }

    public void MoveContainerToCargo(Container container, CargoVehicle cargoVehicle)
    {
        if (!IsContainerInCargo(container))
            throw new ArgumentException("Container is not in cargo");
        if (cargoVehicle == this)
            throw new ArgumentException("Cannot move container to the same cargo");
        
        RemoveContainer(container);
        cargoVehicle.AddContainer(container);
    }

    public override string ToString()
    {
        return $"""
                CargoVehicle(
                    MaxContainers: {MaxContainers}
                    MaxLoadMassKg: {MaxLoadMassKg}
                    ContainersMaxLoadMassKg: {ContainersMaxLoadMassKg}
                    Containers:
                [{string.Join(",", Containers)}]
                )
                """;
    }
}