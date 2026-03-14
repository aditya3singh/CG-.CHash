using System;
using System.Collections.Generic;
using System.Text;

namespace Facade
{
    public class FlavorService
    {
        public string GetFlavor()
        {
            Console.WriteLine("Checking Available flavor");
            return "Vanilla";
        }
    }
}
