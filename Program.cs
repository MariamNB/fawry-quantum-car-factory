using CarFactoryApp.Factory;
using CarFactoryApp.Models;
using CarFactoryApp.Enums;

var factory = new CarFactory();

RunDemo("Gas Car", factory.CreateCar(EngineType.Gas));
RunDemo("Electric Car", factory.CreateCar(EngineType.Electric));
RunDemo("Hybrid Car", factory.CreateCar(EngineType.Hybrid));

Console.WriteLine("\n=== Engine Replacement Demo ===");
var car = factory.CreateCar(EngineType.Gas);
car.Start();
car.Accelerate();
car.Brake();
factory.ReplaceEngine(car, EngineType.Hybrid);
car.Accelerate();
car.Brake();
car.Stop();

static void RunDemo(string label, Car car)
{
    Console.WriteLine($"\n=== {label} Demo ===");
    car.Start();
    foreach (var _ in Enumerable.Range(0, 4)) car.Accelerate(); 
    foreach (var _ in Enumerable.Range(0, 4)) car.Brake();     
    car.Stop();
}