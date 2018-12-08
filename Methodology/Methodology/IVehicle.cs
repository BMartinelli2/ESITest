namespace EsiTest.Methodology
{
    public interface IVehicle
    {
        string Vin { get; set; }

        string Make { get; set; }

        string Model { get; set; }

        int Year { get; set; }

        void DisplayVehicleInformation();

    }
}