namespace EsiTest.AutomatedTellerMachine.Operations
{
    public interface ITellerMachineOperation
    {
        void PerformOperation();
        string OperationName { get; }

    }
}