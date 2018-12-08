using System;
using System.Collections.Generic;
using System.Text;

namespace EsiTest.Methodology.Operations
{
    public class DependencyInversionOperation : IOperation
    {
        public string OperationName => "Dependency Inversion";

        public void PerformOperation()
        {
            Car myCar = new Car();
            myCar.InitializeCar();

            VehicleChecker checker = new VehicleChecker(myCar);
            
            Console.WriteLine($"Class: {nameof(VehicleChecker)}, Method: {nameof(checker.CheckVehicle)}");
            checker.CheckVehicle();
        }
    }
}
