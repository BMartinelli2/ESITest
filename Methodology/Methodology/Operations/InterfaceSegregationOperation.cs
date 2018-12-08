using System;

namespace EsiTest.Methodology.Operations
{
    public class InterfaceSegregationOperation : IOperation
    {
        public string OperationName => "Interface Segregation";

        public void PerformOperation()
        {
            ITruck truck = new SemiTruck();

            Console.WriteLine($"Class: {nameof(ITruck)}, Method: {nameof(truck.LoadTruck)}");
            truck.LoadTruck("TestTruck", "TestModel", 2018, "TestVin");
        }
    }
}