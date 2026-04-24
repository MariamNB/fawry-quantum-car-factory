using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarFactoryApp.Engines;

namespace CarFactoryApp.Models
{
    public class Car
    {
        private IEngine _engine;
        private int _speed;
        private const int MaxSpeed = 200;
        private const int SpeedStep = 20;

        public int Speed => _speed;
        public IEngine Engine => _engine;

        public Car(IEngine engine)
        {
            _engine = engine;
        } 

        public void ReplaceEngine(IEngine newEngine)
        {
            _engine = newEngine;
            Console.WriteLine($"Engine replaced with: {newEngine}");
        }

        public void Start()
        {
            _speed = 0;
            _engine.OnSpeedChanged(_speed);
            Console.WriteLine($"Car started. Speed: {_speed} km/h | Engine: {_engine}");

        }

        public void Stop()
        {
            if(_speed != 0)
            {
                Console.WriteLine("cannot stop: speed must be 0 first.");
                return;
            }
            _engine.OnSpeedChanged(0);
            Console.WriteLine($"Car stopped. Engine: {_engine}");
        }

        public void Accelerate()
        {
            if(_speed > MaxSpeed)
            {
                Console.WriteLine($"Already at max speed: {MaxSpeed} km/h.");
                return;
            }
            _speed += SpeedStep;
            _engine.OnSpeedChanged(_speed);
            Console.WriteLine($"Accelerated → Speed: {_speed} km/h | Engine: {_engine}");
        }

        public void Brake()
        {
            if(_speed <= 0)
            {
                Console.WriteLine("Already stopped");
                return;
            }
            _speed -= SpeedStep;
            _engine.OnSpeedChanged(_speed);
            Console.WriteLine($"Braked → Speed: {_speed} km/h | Engine: {_engine}");
        }

    }
}