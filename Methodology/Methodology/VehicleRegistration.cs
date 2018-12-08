using System;

namespace EsiTest.Methodology
{
    /// <summary>
    /// This class is to demonstrate encapsulation and abstraction.
    /// We are encapsulating all vehicle registration information within a single class, and keeping it
    /// separated from the vehicle base class which provides information about the vehicle, but not it's registration.
    /// This also demonstrates the "S" in the solid principle because this class is only responsible for the Vehicle's registration
    /// and nothing else.
    /// </summary>
    public class VehicleRegistration
    {
        public VehicleBase Vehicle { get; set; }

        //We are also showing abstraction by making read only properties of the following fields
        //and are setting them elsewhere, thus controlling the implementation purely with our class
        //while only exposing what is needed to a consumer of the class.
        public int RegistrationYear { get; private set; }

        public byte RegistrationMonth { get; private set; }

        public string LicensePlate { get; private set; }

        /// <summary>
        /// The same thing for single purpose also applies at the method level, we are only registering our vehicle and nothing else.
        /// This method has one responsibility and that is to register the vehicle within the class.
        /// </summary>

        public bool RegisterVehicle(int expirationYear, byte expirationMonth, string plate)
        {
            LicensePlate = plate;
            bool isValid = ValidateMonth(expirationMonth);

            if (isValid)
            {
                RegistrationMonth = expirationMonth;
                RegistrationYear = expirationYear;
            }

            return isValid;
        }

        public bool IsVehicleRegistrationValid()
        {
            DateTimeOffset currentDate = DateTimeOffset.Now;
            return RegistrationYear >= currentDate.Year && RegistrationMonth >= currentDate.Month;
        }

        /// <summary>
        /// We are performing an operation on all vehicle data that this class has access to.
        /// which is all references are encapsulated within this single class. Demonstrating the
        /// encapsulation principle.
        /// We aren't calling properties of other classes, and only calling methods of our dependencies.
        /// </summary>
        public void DisplayRegistration()
        {
            Console.WriteLine("Vehicle Registration:");
            Console.WriteLine($"Expiration: {RegistrationMonth}/{RegistrationYear}");
            Console.WriteLine($"Plate: {LicensePlate} ");
            if (IsVehicleRegistrationValid())
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("Registration is Valid.");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Registration is Expired.");
            }

            Console.ResetColor();
            Vehicle?.DisplayVehicleInformation();
        }

        /// <summary>
        /// Here we are hiding a validation method because we don't want to expose it publicly.
        /// </summary>
        private bool ValidateMonth(byte monthValue)
        {
            return monthValue >= 1 && monthValue <= 12;
        }

    }

}