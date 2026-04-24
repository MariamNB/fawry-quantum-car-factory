using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFactoryApp.Engines
{
    public class HybridEngine : IEngine
    {
        private const int ElectricThreshold = 50;

        private readonly GasEngine _gasEngine;
        private readonly  ElectricEngine _electricEngine;
        private IEngine _activeEngine;

        public int Speed => _activeEngine.Speed;


        public HybridEngine()
        {
            _gasEngine = new GasEngine();
            _electricEngine = new ElectricEngine();
            _activeEngine = _electricEngine; // starts below 50
        }

        public void Increase() => _activeEngine.Increase();
        public void Decrease()
        {
            if(_activeEngine.Speed > 0)
            {
                _activeEngine.Decrease();
            }
        }

        public void OnSpeedChanged(int carSpeed)
        {
            IEngine targetEgine = carSpeed < ElectricThreshold? _electricEngine : _gasEngine;

            if(_activeEngine != targetEgine)
            {
                while(_activeEngine.Speed > 0) _activeEngine.Decrease();
                _activeEngine = targetEgine;
            }
            _activeEngine.OnSpeedChanged(carSpeed);
            
        }
        public override string ToString()
        {
            return $"HybridEngine Active: {(_activeEngine is ElectricEngine ? "Electric" : "Gas")}, Speed: {Speed}]";
        }

       
    }
}