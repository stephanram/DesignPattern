using DesignPattern.Pattern.AbstractFactory.AbstractProduct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DesignPattern.Pattern.AbstractFactory.Enumerations;

namespace DesignPattern.Pattern.AbstractFactory.ConcreteProduct
{
    public class Dell : IBrand
    {
        public Brand GetBrand()
        {
            return Brand.Dell;
        }
    }

    public class DellLapTop : IBrand
    {
        public Brand GetBrand()
        {
            return Brand.Dell;
        }
    }
}
