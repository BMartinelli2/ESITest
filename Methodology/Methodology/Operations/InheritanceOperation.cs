using System;

namespace EsiTest.Methodology.Operations
{
    public class InheritanceOperation : IOperation
    {
        public string OperationName => "Inheritance";

        public void PerformOperation()
        {
            Car vehicle = new Car();
            vehicle.InitializeCar();

            Console.WriteLine($"Class: {nameof(Car)}, Method: {nameof(vehicle.WriteGeneralInformation)}");

            //The WriteGeneralInformation method is inherited from the base class VehicleBase
            vehicle.WriteGeneralInformation();
            
        }


    }
}