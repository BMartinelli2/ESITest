using System;

namespace EsiTest.Methodology
{

    public class VehicleChecker : IVehicleChecker
    {
        private readonly IVehicle _vehicle;

        ///<summary>
        /// Here we are demonstrating the dependency inversion principle.
        ///This means that all dependencies of this class should come from outside of it.
        ///We are already doing this with our Operations handler class by injecting all the operations into it
        ///via an IOC container, but this is to serve as a simpler version of it.
        ///</summary>
        public VehicleChecker(IVehicle vehicle)
        {
            _vehicle = vehicle;
        }


        public void CheckVehicle()
        {
            bool isValid = _vehicle.Year != 0
                           && !string.IsNullOrWhiteSpace(_vehicle.Make)
                           && !string.IsNullOrWhiteSpace(_vehicle.Model)
                           && !string.IsNullOrWhiteSpace(_vehicle.Vin);

            _vehicle.DisplayVehicleInformation();
            Console.WriteLine($"Vehicle validated: {isValid}");
        }
    }

}