using DesignPattern.Pattern.AbstractFactory.AbstractProduct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Pattern.AbstractFactory
{
    public class EmployeeSystemManager
    {
        IComputerFactory computerFactory = null;

        public EmployeeSystemManager(IComputerFactory computerFactory)
        {
            this.computerFactory = computerFactory;
        }

        public string GetDetails()
        {
            IBrand brand = this.computerFactory.Brand();
            IProcessor processor = this.computerFactory.Processor();
            ISystemType systemType = this.computerFactory.SystemType();

            var returnValue = $"{brand.GetBrand().ToString()} {processor.GetProcessor().ToString()} {systemType.GetSystemType().ToString()}";

            return returnValue;
        }
    }
}
