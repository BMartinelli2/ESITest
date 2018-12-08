using System;
using System.Threading;
using System.Threading.Tasks;

namespace EsiTest.WebRequest
{
    class Program
    {
        private static CancellationTokenSource _tokenSource;

        static void Main(string[] args)
        {
            _tokenSource = new CancellationTokenSource();

            Console.WriteLine("Press Any key to request a web page:");
            Console.ReadKey();
            Console.WriteLine("-------------------------------------");

                using (RequestPage request = new RequestPage())
                {
                    Console.WriteLine("Press any key to stop the request.");
                    var requestTask = request.MakeBasicRequest(_tokenSource.Token);
                    requestTask.GetAwaiter().OnCompleted(() => _tokenSource.Cancel());

                    while (!requestTask.GetAwaiter().IsCompleted)
                    {
                        if (ReadKey() && !requestTask.GetAwaiter().IsCompleted)
                        {
                            _tokenSource.Cancel();
                        }
                    }

                    if (requestTask.IsCompletedSuccessfully)
                    {
                        Console.WriteLine(requestTask.Result);
                    }
                }

                Console.WriteLine("-------------------------------------");
                Console.ReadKey();

        }

        private static bool ReadKey()
        {
            try
            {
                var task = Task.Run(() => Console.ReadKey(true), _tokenSource.Token);
                return task.Wait(1000,_tokenSource.Token); // Avoid the task.wait in production applications because there can be a deadlocking issue: 
            }
            catch (OperationCanceledException ex)
            {
                //We don't care if the task is cancelled here, we will catch it to prevent the application from crashing.
            }

            return false;
        }
    }
}
