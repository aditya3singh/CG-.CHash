using System;
using System.Collections.Generic;
using System.Text;

namespace Facade
{
    public class ConeService
    {
        public string GetCone()
        {
            Console.WriteLine("Selecting a cone...");
            return "Waffle Cone";
        }
    }
}
