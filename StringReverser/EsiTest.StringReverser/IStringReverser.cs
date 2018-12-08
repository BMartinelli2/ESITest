using System.Collections.Generic;

namespace EsiTest.StringReverser
{
    public interface IStringReverser
    {
        void ParseInputValue(string inputValue);
        void DisplayResults();
        List<(int, string)> GetWordCounts(int duplicateThreshold);
    }
}