using Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ApplePhone : IPhone
    {
        public ApplePhone()
        {
            Console.WriteLine("i am creating apple phone.");
        }

        public void Show()
        {
            
        }
    }
}
