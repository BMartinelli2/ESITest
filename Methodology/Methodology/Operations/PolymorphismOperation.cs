using System;

namespace EsiTest.Methodology.Operations
{
    public class PolymorphismOperation : IOperation
    {
        public string OperationName => "Polymorphism";

        /// <summary>
        /// Attempts to create an account.
        /// </summary>
        public void PerformOperation()
        {
            Car vehicle = new Car()
            {
                Make = "Dodge",
                Model = "Viper",
                Vin = "ABC12345657",
                Year = 2002
            };
            
            Console.WriteLine($"Class: {nameof(SemiTruck)}, Method: {nameof(vehicle.DisplayVehicleInformation)}");
            vehicle.DisplayVehicleInformation();
        }
    }
}