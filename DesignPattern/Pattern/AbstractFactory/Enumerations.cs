using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Pattern.AbstractFactory
{
    public class Enumerations
    {
        public enum SystemType
        {
            Desktop,
            Laptop
        }

        public enum Processor
        {
            I7,
            I5,
            I3
        }

        public enum Brand
        {
            Dell,
            Mac
        }
    }
}
