using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDDChallenge.Services
{
    /// <summary>Format words service</summary>
    public class FormatWordsService
    {
        /// <summary>Input list with words</summary>
        protected readonly List<string> WordsList;

        /// <summary>Service constructor. Accepts an list with words</summary>
        /// <param name="wordsList">List containing names</param>
        public FormatWordsService(string[] wordsList)
        {
            WordsList = wordsList?.ToList() ?? new List<string>();
            WordsList.RemoveAll(s => string.IsNullOrEmpty(s));
        }

        /// <summary>Formats the input list into words with comma separated. Appends "and" when necessary</summary>
        public string CommaSeparatedFormat()
        {
            var wordAppender = new StringBuilder();
            var wordCount = 0;

            foreach (var word in WordsList)
            {
                wordCount++;
                var wordWithFormat = $"{word}, ";

                if (string.IsNullOrEmpty(word))
                    wordWithFormat = "";

                if (wordCount == WordsList.Count)
                    wordWithFormat = $"{word}";

                wordAppender.Append(wordWithFormat);
            }
                
            var wordsFormated = wordAppender.ToString();
            var lastCommaIndex = wordsFormated.LastIndexOf(",");

            if (lastCommaIndex > 0)
            {
                wordsFormated = wordsFormated.Remove(lastCommaIndex, 1);
                wordsFormated = wordsFormated.Insert(lastCommaIndex, " and");
            }
            
            return wordsFormated;
        }
    }
}
