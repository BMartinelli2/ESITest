using System;

namespace EsiTest.Methodology.Operations
{
    public class OpenClosedOperation : IOperation
    {
        public string OperationName => "Open Closed";

        public void PerformOperation()
        {
            Car car = new Car();
            car.InitializeCar();
            SemiTruck truck = new SemiTruck();
            truck.LoadTruck("TestTruck", "TestModel", 2018, "TestVin");
            
            Console.WriteLine($"Class: {nameof(SemiTruck)}, Method: {nameof(truck.DisplayVehicleInformation)}");
            truck.DisplayVehicleInformation();

        }
    }
}