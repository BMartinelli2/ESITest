using System;

namespace EsiTest.Methodology
{
    /// <summary>
    /// This is to describe the concept of inheritance in object oriented programming.
    /// The goal of this is to create a base class for use to be inherited from.
    /// It will show the use of shared methods, and virtual methods.
    /// Inheritance allows a user to gain access to public and protected, while
    /// keeping private hidden away.
    /// </summary>
    public abstract class VehicleBase : IVehicle
    {
        private Guid _identifier;

        public string Vin { get; set; }

        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }

        public abstract void DisplayVehicleInformation();

        /// <summary>
        /// This method is inherited by all derived classes and is used to indicate / show that
        /// the method called for the derived classes is that from the base class.
        /// </summary>
        public void WriteGeneralInformation()
        {
            Console.WriteLine("Vehicle Information:");
            Console.WriteLine($"ID: {_identifier}");
            Console.WriteLine($"Vin: {Vin}");
            Console.WriteLine($"Type of Vehicle: {Year} {Make} {Model}");
        }

        protected void SetIdentifier(Guid identifierValue)
        {
            _identifier = identifierValue;
        }
    }
}