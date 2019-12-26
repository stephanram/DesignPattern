using DesignPattern.Pattern.AbstractFactory.AbstractProduct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Pattern.AbstractFactory.ConcreteProduct
{
    public class MACComputerFactory : IComputerFactory
    {
        public IBrand Brand()
        {
            return new MAC();
        }

        public IProcessor Processor()
        {
            return new I7();
        }

        public virtual ISystemType SystemType()
        {
            return new Desktop();
        }
    }

    public class MACLaptonFactory : MACComputerFactory
    {
        public override ISystemType SystemType()
        {
            return new Laptop();
        }
    }
}
