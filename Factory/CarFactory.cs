using CarFactoryApp.Engines;
using CarFactoryApp.Models;
using CarFactoryApp.Enums;

namespace CarFactoryApp.Factory
{
    public class CarFactory
    {

        public Car CreateCar(EngineType engineType)
        {
            IEngine engine = CreateEngine(engineType);
            Console.WriteLine($"Factory created car with: {engine}");
            return new Car(engine);
        }

        public void ReplaceEngine(Car car, EngineType engineType)
        {
            IEngine engine = CreateEngine(engineType);
            car.ReplaceEngine(engine);
        }

     private IEngine CreateEngine(EngineType engineType) => engineType switch
        {
            EngineType.Gas      => new GasEngine(),
            EngineType.Electric => new ElectricEngine(),
            EngineType.Hybrid   => new HybridEngine(),
            _ => throw new ArgumentException("Unknown engine type")
        };
    }
}