using System;

namespace EsiTest.Methodology.Operations
{
    public class ListkovOperation : IOperation
    {
        public string OperationName => "Listkov";

        public void PerformOperation()
        {
            //So Listkov's substitution principle, states that you can replace any subtype with it's base type and the behavior of the application should be the same.
            //So each of the operations that are written follow this principle, each one is substituted out for a different command on the "Perform Operation", however the
            //overall behavior of the application does not change. 

            //For instance if i were to replace the "PerformOperation" method with an exception that throws and says "NotImplementedException" this is a violation of listkov's
            //because it behaves differently than other methods.
            
            //However since every perform operation is not changing the calling behavior, this does not violate listkov's principle.
            Console.WriteLine($"Class: {nameof(ListkovOperation)}, Method: {nameof(PerformOperation)}");


        }
    }
}