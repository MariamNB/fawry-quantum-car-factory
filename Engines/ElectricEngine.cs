using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFactoryApp.Engines
{
    public class ElectricEngine : IEngine
    {
       public int Speed {get; private set;}

        public void Increase() => Speed++;
        public void Decrease()
        {
            if(Speed > 0) Speed--;
        }

        public void OnSpeedChanged(int carSpeed)
        {
           while (Speed < carSpeed) Increase();
           while (Speed > carSpeed) Decrease();
        }

        public override string ToString() => $"ElectronicEngine Speed: {Speed}";
    }
}