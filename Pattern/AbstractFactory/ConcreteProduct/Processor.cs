using DesignPattern.Pattern.AbstractFactory.AbstractProduct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Pattern.AbstractFactory.ConcreteProduct
{
    public class I7 : IProcessor
    {
        public Enumerations.Processor GetProcessor()
        {
            return Enumerations.Processor.I7;
        }
    }
    public class I5 : IProcessor
    {
        public Enumerations.Processor GetProcessor()
        {
            return Enumerations.Processor.I5;
        }
    }

    public class I3 : IProcessor
    {
        public Enumerations.Processor GetProcessor()
        {
            return Enumerations.Processor.I3;
        }
    }
}
