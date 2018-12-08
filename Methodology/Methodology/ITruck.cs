namespace EsiTest.Methodology
{
    internal interface ITruck : IVehicle
    {
        void LoadTruck(string make, string model, int year, string vin);
    }
}