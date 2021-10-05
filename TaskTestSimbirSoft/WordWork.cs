using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace TaskTestSimbirSoft
{
    public class WordWork
    {
        private readonly char[] delimiter = { ' ', ',', '.', '!', '?', '"', ';', ':', '/', '&', '#', '[', ']', '(', ')', '«', '»', '<', '>', '@', '{', '}', '+', '-', '*', '\n', '\r', '\t' };
        Dictionary<string, int> _wordDict = new Dictionary<string, int>();

        private string ClearText(string text)
        {
            text = text.Substring(text.IndexOf("<body"));

            while (text.IndexOf("<style") > 0)
            {
                text = text.Replace(text.Substring(text.IndexOf("<style"),
                    text.IndexOf("</style>") - text.IndexOf("<style>") + "</style>".Length), "\n");
            }

            while (text.IndexOf("<script") > 0)
            {
                text = text.Replace(text.Substring(text.IndexOf("<script"), 
                    text.IndexOf("</script>") - text.IndexOf("<script") + "</script>".Length), "\n");
            }

            text = Regex.Replace(text, @"<(.|\n)*?>", "\n");
            
            return text;
        }

        public Dictionary<string, int> SplitWord(string text)
        {
            string _clearText = ClearText(text);

            foreach (var word in _clearText.Split(delimiter))
            {
                if (word != string.Empty)
                {
                    if (_wordDict.ContainsKey(word))
                    {
                        _wordDict[word]++;
                    }
                    else
                    {
                        _wordDict.Add(word, 1);
                    }
                }
            }
            return _wordDict;
        }

        public void PrintWord(string text)
        {
            SplitWord(text);

            foreach (var word in _wordDict) 
            {
                Console.WriteLine($"{word.Key} - {word.Value}");
            }
        }
    }
}
