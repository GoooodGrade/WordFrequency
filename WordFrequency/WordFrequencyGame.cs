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
            if (Regex.Split(inputStr, pattern).Length == 1)
            {
                return inputStr + " 1";
            }
            else
            {
                //split the input string with 1 to n pieces of spaces
                string[] words = Regex.Split(inputStr, pattern);
                var inputList = words.Select(w=>new WordCount(w,1)).ToList();
                //get the map for the next step of sizing the same word
                Dictionary<string, List<WordCount>> wordListMap = GetListMap(inputList);
                inputList = TransMapToWordCounts(wordListMap);
                inputList.Sort((w1, w2) => w2.Count - w1.Count);
                var result = JoinListToString(inputList);
                return result;
            }
        }

        private string JoinListToString(List<WordCount> inputList)
        {
            List<string> strList = new List<string>();

            foreach (WordCount w in inputList)
            {
                string s = w.Word + " " + w.Count;
                strList.Add(s);
            }

            const string separator = "\n";
            string result = string.Join(separator, strList.ToArray());
            return result;
        }

        private List<WordCount> TransMapToWordCounts(Dictionary<string, List<WordCount>> wordListMap)
        {
            List<WordCount> list = new List<WordCount>();
            foreach (var entry in wordListMap)
            {
                WordCount wordCount = new WordCount(entry.Key, entry.Value.Count);
                list.Add(wordCount);
            }

            return list;
        }

        private Dictionary<string, List<WordCount>> GetListMap(List<WordCount> wordCounts)
        {
            Dictionary<string, List<WordCount>> wordListMap = new Dictionary<string, List<WordCount>>();
            foreach (var wordCount in wordCounts)
            {
                if (!wordListMap.ContainsKey(wordCount.Word))
                {
                    List<WordCount> tmpWordCounts = new List<WordCount>
                    {
                        wordCount
                    };
                    wordListMap.Add(wordCount.Word, tmpWordCounts);
                }
                else
                {
                    wordListMap[wordCount.Word].Add(wordCount);
                }
            }

            return wordListMap;
        }
    }
}
