// Adam Skorupski s29441 PJATK

using cw2;
using cw2.CargoVehicles;

// basic instructions

Console.WriteLine("--- Basic part ---");

var fContainer = new FluidContainer(new Product("paliwo", true), 1000, 100, 50, 3000);
fContainer.Fill(100);

var gContainer = new GasContainer(new Product("hel"), 1000, 80, 70, 2500, 1.5);
gContainer.Fill(1);

var cContainer = new CoolingContainer(new Product("ser", 7.2), 1000, 50, 60, 2800, 10);
cContainer.Fill(100);

var containerList = new List<Container>{gContainer, cContainer};

var ship = new CargoShip(10,100_000, 30);
ship.AddContainer(fContainer);
ship.AddContainers(containerList);

ship.RemoveContainer(gContainer);
ship.ReplaceContainer(cContainer.SerialNumber, gContainer);

var anotherShip = new CargoShip(2,50_000, 45);
anotherShip.AddContainer(cContainer);

ship.MoveContainerToCargo(fContainer, anotherShip);
Console.WriteLine(ship);
Console.WriteLine(anotherShip);

// additional instrucitons

Console.WriteLine("--- Additional part ---");

fContainer.Empty();
Console.WriteLine($"fContainer LoadMassKg after Empty: {fContainer.LoadMassKg}");
gContainer.Empty();
Console.WriteLine($"gContainer LoadMassKg after Empty: {gContainer.LoadMassKg}");
cContainer.Empty();
Console.WriteLine($"cContainer LoadMassKg after Empty: {cContainer.LoadMassKg}");
fContainer.Fill(100);
gContainer.Fill(200);
cContainer.Fill(300);

// validation instructions

Console.WriteLine("--- Validation part ---");

try
{
    anotherShip.AddContainer(fContainer); // exception - container already in this ship
} catch (Exception e) { Console.WriteLine(e.ToString()); } 

try
{
    ship.AddContainer(fContainer); // exception - container already in another ship
} catch (Exception e) { Console.WriteLine(e.ToString()); }

try
{
    anotherShip.MoveContainerToCargo(fContainer, anotherShip); // exception - cannot move container to the same ship
} catch (Exception e) { Console.WriteLine(e.ToString()); }

var smallShip = new CargoShip(2, 1500, 1);
try
{
    ship.MoveContainerToCargo(fContainer, smallShip); // exception - container not in this ship
} catch (Exception e) { Console.WriteLine(e.ToString()); }

try
{
    anotherShip.ReplaceContainer("KON-X-1", fContainer); // exception - cannot find container with this id
} catch (Exception e) { Console.WriteLine(e.ToString()); }

anotherShip.MoveContainerToCargo(fContainer, smallShip);
try
{
    ship.MoveContainerToCargo(gContainer, smallShip); // exception - cannot fit container
} catch (Exception e) { Console.WriteLine(e.ToString()); }

try
{
    smallShip.MaxLoadMassKg = 100; // exception - cannot shrink maxloadmasskg below all containers total maxloadmasskg
} catch (Exception e) { Console.WriteLine(e.ToString()); }

try
{
    fContainer.Fill(2000); // exception - overfill exception
} catch (Exception e) { Console.WriteLine(e.ToString()); }

try
{
    var smallContainer = new CoolingContainer(new Product("masło", 20.5), 1500, 100, 40, 900, 2); // exception - container temperature cannot be lower than product
} catch (Exception e) { Console.WriteLine(e.ToString()); }


try
{
    smallShip.MoveContainerToCargo(fContainer, anotherShip);
    smallShip.MoveContainerToCargo(gContainer, anotherShip); // exception - exceeded container count in ship
} catch (Exception e) { Console.WriteLine(e.ToString()); }

Console.WriteLine("--- End of validation part ---");
