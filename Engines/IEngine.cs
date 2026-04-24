using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFactoryApp.Engines
{
    public interface IEngine
    {
        int Speed { get; }
        void Increase();
        void Decrease();

        void OnSpeedChanged(int carSpeed);   
    }
}