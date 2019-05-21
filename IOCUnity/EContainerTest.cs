using EContainer;
using Interface;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOCUnity
{
    public class EContainerTest
    {
        public static void Show()
        {
            var container = new Container();
            container.RegisterType<IPhone, ApplePhone>();
            container.RegisterType<IPad, ApplePad>();
            container.RegisterType<IHeadphone, Headphone>();
            container.RegisterType<IMicrophone, Microphone>();
            container.RegisterType<IPower, Power>();

            var pad = container.Resolve<IPad>();
        }
    }
}
