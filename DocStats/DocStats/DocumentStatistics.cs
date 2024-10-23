using DocStats.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocStats
{
    public class DocumentStatistics
    {
        private readonly IFileManager _fileManager;
        
        public string FileContent { get; private set; }
        public Dictionary<string, int> DistinctWordCount { get; private set; }

        public int CharacterCount { get; private set; }
        public int NonWhiteSpaceCharacterCount { get; private set; }
        public int SentenceCount { get; private set; }
        public int ProperNounCount { get; private set; }
        public double ColemanLieuIndex { get; private set; }

        public event EventHandler? FileContentReady;
        public event EventHandler? TextStatisticsReady;


        public DocumentStatistics(IFileManager fileManager)
        {
            _fileManager = fileManager;
            DistinctWordCount = new Dictionary<string, int>();
        }

        public void Load()
        {
            try
            {
                FileContent = _fileManager.Load();
            }
            catch (FileManagerException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
            OnFileContentReady();
            CharacterCount = FileContent.Length;
            ComputeDistinctWords();
            NonWhiteSpaceCharacterCount = FileContent.Count(c => !char.IsWhiteSpace(c));
            ComputeSentenceCount();
            ComputeProperNounCount();
            ComputeColemanLieuIndex();
            OnTextStatisticsReady();

        }

        private void OnFileContentReady()
        {
            FileContentReady?.Invoke(this, EventArgs.Empty);
        }
        private void OnTextStatisticsReady()
        {
            TextStatisticsReady?.Invoke(this, EventArgs.Empty);
        }

        private void ComputeColemanLieuIndex()
        {
            double ratio = (double)DistinctWordCount.Sum(w => w.Value) / 100;

            double L = NonWhiteSpaceCharacterCount / ratio;
            double S = SentenceCount / ratio;

            ColemanLieuIndex = 0.0588 * L - 0.296 * S - 15.8;
        }

        private void ComputeProperNounCount()
        {
            string text = string.Concat(FileContent.Where(c => !char.IsWhiteSpace(c)));

            int count = 0;
            for (int i = 1; i < text.Length; i++)
            {
                if ((text[i-1] != '.' && text[i-1] != '?' && text[i-1] != '!') && char.IsUpper(text[i]))
                {
                    count++;
                }
            }
            ProperNounCount = count;
        }

        private void ComputeSentenceCount()
        {
            int num = 0;

            var marks = new char[] { '.', '!', '?' };

            for (int i = 1; i < FileContent.Length; ++i)
            {
                if (marks.Contains(FileContent[i]) && !marks.Contains(FileContent[i - 1]))
                {
                    num++;
                }
            }
            SentenceCount = num;
        }

        private void ComputeDistinctWords()
        {
            DistinctWordCount.Clear();
            string[] words = FileContent.Split();
            words = words.Where(s => s.Length > 0).ToArray();

            for (int i = 0; i < words.Length; i++)
            {
                //Szo elso karaktere betu-e, ha nem eltavolitjuk
                while (words[i].Length > 0 && !Char.IsLetter(words[i][0]))
                {
                    words[i] = words[i].Remove(0, 1);
                }

                //Szo utolso karaktere betu-e, ha nem eltavolitjuk
                while (words[i].Length > 0 && !Char.IsLetter(words[i][^1]))
                {
                    words[i] = words[i].Remove(words[i].Length - 1, 1);
                }

                //Alternativkent az elozo kettohoz a SkipWhile fuggvennyel
                string.Concat(words[i].SkipWhile(c => !char.IsLetter(c)).Reverse().SkipWhile(c => !char.IsLetter(c))
                    .Reverse());

                //String.IsNullOrEmpty kene a ciklusban
                if (String.IsNullOrEmpty(words[i]))
                {
                    continue;
                }

                words[i] = words[i].ToLower();

                if (DistinctWordCount.ContainsKey(words[i]))
                {
                    //Novelni 1-el az erteket
                    DistinctWordCount.TryGetValue(words[i], out int val);
                    DistinctWordCount[words[i]] = ++val;
                }
                else
                {
                    DistinctWordCount.Add(words[i], 1);
                }
            }
        }
    }
}