using System;

namespace EsiTest.StringReverser
{
    public interface IConsoleReader
    {
        string ReadLine();
        ConsoleKeyInfo ReadKey();
    }
}