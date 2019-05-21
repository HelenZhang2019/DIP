//using EContainer;
using Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class Microphone : IMicrophone
    {
        //[EInjectionConstruction]
        public Microphone(IPower power)
        {
            Console.WriteLine("i am creating Microphone");
        }

        public void Show()
        {
            
        }
    }
}
