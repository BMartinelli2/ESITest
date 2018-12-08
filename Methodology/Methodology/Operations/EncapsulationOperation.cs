using System;
using EsiTest.Methodology;

namespace EsiTest.Methodology.Operations
{
    public class EncapsulationOperation : IOperation
    {
        public string OperationName => "Encapsulation";

        public void PerformOperation()
        {
            VehicleRegistration registration = new VehicleRegistration();
            registration.RegisterVehicle(2019, 12, "ABC 123");

            Console.WriteLine($"Class: {nameof(VehicleRegistration)}, Method: {nameof(registration.DisplayRegistration)}");
            registration.DisplayRegistration();
        }
    }
}