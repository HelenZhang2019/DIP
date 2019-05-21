//using EContainer;
using Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class Headphone: IHeadphone
    {
        //[EInjectionConstruction]
        public Headphone(IMicrophone microphone)
        {
            Console.WriteLine("i am creating Headphone");
        }

        public void Show()
        {
            throw new NotImplementedException();
        }
    }
}
