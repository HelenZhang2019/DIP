//using EContainer;
using Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ApplePad:IPad
    {
        public ApplePad()
        {
            Console.WriteLine("i am creating applepad.");
        }

        public ApplePad(string name)
        {
            Console.WriteLine("i am creating applepad, name is {0}", name);
        }

        //[EInjectionConstruction]
        public ApplePad(IPhone phone, IHeadphone headphone)
        {
            Console.WriteLine("i am creating appplepad with phone");
        }

        public void Show()
        {
            
        }
    }
}
