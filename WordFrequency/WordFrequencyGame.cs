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
                Dictionary<string, List<WordCount>> map = GetListMap(inputList);

                List<WordCount> list = new List<WordCount>();
                foreach (var entry in map)
                {
                    WordCount wordCount = new WordCount(entry.Key, entry.Value.Count);
                    list.Add(wordCount);
                }

                inputList = list;

                inputList.Sort((w1, w2) => w2.Count - w1.Count);

                List<string> strList = new List<string>();

                //stringJoiner joiner = new stringJoiner("\n");
                foreach (WordCount w in inputList)
                {
                    string s = w.Word + " " + w.Count;
                    strList.Add(s);
                }

                return string.Join("\n", strList.ToArray());
            }
        }

        private Dictionary<string, List<WordCount>> GetListMap(List<WordCount> inputList)
        {
            Dictionary<string, List<WordCount>> map = new Dictionary<string, List<WordCount>>();
            foreach (var input in inputList)
            {
                //       map.computeIfAbsent(input.getValue(), k -> new ArrayList<>()).add(input);
                if (!map.ContainsKey(input.Word))
                {
                    List<WordCount> arr = new List<WordCount>();
                    arr.Add(input);
                    map.Add(input.Word, arr);
                }
                else
                {
                    map[input.Word].Add(input);
                }
            }

            return map;
        }
    }
}
