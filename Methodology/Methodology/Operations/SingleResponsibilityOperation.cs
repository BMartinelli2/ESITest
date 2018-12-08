using System;

namespace EsiTest.Methodology.Operations
{
    public class SingleResponsibilityOperation: IOperation
    {
        public string OperationName => "Single Responsibility";

        public void PerformOperation()
        {
            VehicleRegistration registration = new VehicleRegistration();
            Car car = new Car()
            {
                Vin = "TestVin",
                Make = "Make",
                Model = "Model",
                Year = 1028
            };

            registration.Vehicle = car;

            Console.WriteLine($"Class: {nameof(VehicleRegistration)}, Method: {nameof(registration.RegisterVehicle)}");
            registration.RegisterVehicle(2019, 12, "ABC 123");

        }


    }
}
