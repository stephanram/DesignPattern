using DesignPattern.Pattern.AbstractFactory.AbstractProduct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DesignPattern.Pattern.AbstractFactory.Enumerations;

namespace DesignPattern.Pattern.AbstractFactory.ConcreteProduct
{
    public class MAC : IBrand
    {
        public Brand GetBrand()
        {
            return Brand.Mac;
        }
    }

    public class MACLapTop : IBrand
    {
        public Brand GetBrand()
        {
            return Brand.Mac;
        }
    }
}
