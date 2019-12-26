using DesignPattern.Pattern.AbstractFactory.AbstractProduct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Pattern.AbstractFactory.ConcreteProduct
{
    public class Laptop : ISystemType
    {
        public Enumerations.SystemType GetSystemType()
        {
            return Enumerations.SystemType.Laptop;
        }
    }

    public class Desktop : ISystemType
    {
        public Enumerations.SystemType GetSystemType()
        {
            return Enumerations.SystemType.Desktop;
        }
    }

}
