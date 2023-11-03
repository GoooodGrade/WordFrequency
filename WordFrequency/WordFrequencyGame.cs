using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace WordFrequency
{
    public class WordFrequencyGame
    {
        public string GetResult(string inputStr)
        {
            const string pattern = @"\s+";
            string[] words = Regex.Split(inputStr, pattern);

            List<string> inputList = words.GroupBy(w => w).OrderByDescending(wc => wc.Count()).Select(g=>g+" "+g.Count()).ToList();
            var resultWordCount = string.Join("\n", inputList);
            return resultWordCount;
        }
    }
}
