using cw2;
using cw2.CargoVehicles;

var FContainer = new FluidContainer(new Product("paliwo", true), 1000, 100, 50, 3000);
FContainer.Fill(100);

var GContainer = new GasContainer(new Product("hel"), 1000, 80, 70, 2500, 1.5);
GContainer.Fill(1);

var CContainer = new CoolingContainer(new Product("ser", 7.2), 1000, 50, 60, 2800, 10);
CContainer.Fill(100);

var ContainerList = new List<Container>{GContainer, CContainer};

var Ship = new CargoShip(10,100_000, 30);
Ship.AddContainer(FContainer);
Ship.AddContainers(ContainerList);

Ship.RemoveContainer(GContainer);
Ship.ReplaceContainer(CContainer.SerialNumber, GContainer);

var AnotherShip = new CargoShip(5,50_000, 45);
AnotherShip.AddContainer(CContainer);

Ship.MoveContainerToCargo(FContainer, AnotherShip);
Console.WriteLine(Ship);
Console.WriteLine(AnotherShip);

// # TODO: pokazać walidację