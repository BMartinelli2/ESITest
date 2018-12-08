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
    /// We are also implementing the interface segregation principle with the ITruck interface
    /// as we are separating the interface of IVehicle and ITruck apart with the
    /// Truck only methods implemented in ITruck, because it is a special type of vehicle.
    ///
    /// The truck interface could be used for other types of trucks such as light trucks, or
    /// tow trucks, or any other classification.
    /// </summary>
    public class SemiTruck : VehicleBase, ITruck
    {
        public SemiTruck()
        {
            //We are calling protected members here that are inherited from the base class.
            SetIdentifier(Guid.NewGuid());
        }

        /// <summary>
        /// Method used for interface segregation principle, to show that this is a SemiTruck specific item.
        /// </summary>
        public void LoadTruck(string make, string model, int year, string vin)
        {
            Make = make;
            Model = model;
            Year = year;
            Vin = vin;
        }

        // Open closed is a bit more tricky to try to show, but the principle basically says that everything should be 
        // open to extension closed to modification. 

        //Which basically means, we are free to add or extend the classes functionality,
        // However, we should not change it's public facing API or how methods behave.

        // If we were to create a method that takes cars and outputs all of it's data via the "DisplayCarInfo" on our "DisplayHandler" class.
        // Then we decided to add a truck class and that has a method called "DisplayTruckInfo"
        // We wanted one method to display both on our display handler:
        // Ex:
        // void DisplayVehicleData(Car cars)
        // {
        //      car.DisplayCarInfo();
        // }

        // INCORRECT would be modify this method to the following, since we are modifying both the API and functionality of the method:
        // void DisplayVehicleData(object vehicle)
        // {
        // if(ourObject is SemiTruck){
        //      SemiTruck semiTruckObject = ourObject as SemiTruck;
        //      semiTruckObject.DisplayTruckInfo()
        // }
        // else
        // {
        //      Car car = ourObject as Car;
        //      car.DisplayCarInfo();
        // }

        // Correct would be to create a base class and add the following method to dour display handler:
        // void DisplayVehicleInfo(VehicleBase vehicle)
        // {
        //      vehicle.DisplayVehicleInformation();
        // }
        public override void DisplayVehicleInformation()
        {
            Console.WriteLine("This is a truck!");
            //Same here for calling inherited members.
            WriteGeneralInformation();
        }
    }
}