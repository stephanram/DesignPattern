using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DesignPattern.Pattern.AbstractFactory.Enumerations;

namespace DesignPattern.Pattern.AbstractFactory.AbstractProduct
{
    public interface IBrand
    {
        Brand GetBrand();
    }
}
