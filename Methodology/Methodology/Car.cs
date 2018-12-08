using System;

namespace EsiTest.Methodology
{
    /// <summary>
    /// This is to describe the concept of inheritance in object oriented programming.
    /// The goal of this is to create a class that derives from a base class.
    /// It will show the use of shared methods, and virtual methods.
    /// Inheritance allows a user to gain access to public and protected, while
    /// keeping private hidden away.
    /// 
    /// </summary>
    public class Car : VehicleBase, IVehicle
    {
        public Car()
        {
            //We are calling protected members here that are inherited from the base class.
            SetIdentifier(Guid.NewGuid());
        }

        /// <summary>
        /// Here we are calling an initialization method which is unique to the derived class.
        /// however within it we are setting inherited properties.
        /// </summary>
        public void InitializeCar()
        {
            Make = "Chevrolet";
            Model = "Malibu";
            Year = 2018;
            Vin = "1GZ1824M8291099128";
        }

        /// <summary>
        /// This is an example of polymorphism where we are overriding or implementing a virtual / abstract methods.
        /// Polymorphism means "Many forms" and it's where your derived classes can override or take on alternate forms
        /// of method signatures.
        /// However, the behavior of the methods shouldn't change the overall behavior of anything that would call it,
        /// as it is designed to be interchangeable with others of the same base. If that were the case
        /// it would be a violation of Listkov's substitution principle.
        /// </summary>
        public override void DisplayVehicleInformation()
        {
            Console.WriteLine("This is a car!");
            //Same here for calling inherited members.
            WriteGeneralInformation();
        }
    }
}