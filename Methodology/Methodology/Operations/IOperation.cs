namespace EsiTest.Methodology.Operations
{
    public interface IOperation
    {
        void PerformOperation();
        string OperationName { get; }

    }
}