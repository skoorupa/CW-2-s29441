namespace cw2.CargoVehicles;

public class CargoShip(int maxContainers, double maxLoadMassKg, double maxSpeedKnots) : 
    CargoVehicle(maxContainers, maxLoadMassKg)
{
    public double MaxSpeedKnots { get; set; } = maxSpeedKnots;
}