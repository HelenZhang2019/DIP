using Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class Power : IPower
    {
        public Power()
        {
            Console.WriteLine("i am creating Power.");
        }
        public void Show()
        {
            throw new NotImplementedException();
        }
    }
}
