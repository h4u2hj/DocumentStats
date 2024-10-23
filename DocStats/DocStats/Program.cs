using DocStats.Persistence;

namespace DocStats
{
    internal class Program
    {
        static int Main(string[] args)
        {
            IFileManager fileManager = null;

            do
            {
                Console.WriteLine("---Document Statistics---");
                Console.WriteLine("Please enter the filepath (txt): ");
                string line = Console.ReadLine() ?? "";
                if (File.Exists(line))
                {
                    fileManager = FileManagerFactory.CreateForPath(line);
                }
            }
            while (fileManager == null);

            
            DocumentStatistics ds = new(fileManager);

            try
            {
                ds.Load();
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
                return -1;
            }


            Console.WriteLine(
                $"The file consist of {ds.CharacterCount} characters and {ds.NonWhiteSpaceCharacterCount} non-whitespace characters!");
            Console.WriteLine($"The file consist of {ds.SentenceCount} sentences!");
            Console.WriteLine($"The file consist of {ds.ProperNounCount} Nouns!");
            Console.WriteLine($"Coleman-Lieu index: {ds.ColemanLieuIndex:f2}");

            
            Console.WriteLine();
            int minOccurrence = ReadPositive("Please enter the minimal occurence(positive, max 100)");
            int minLength = ReadPositive("Please enter the minimal length of the word(positive, max 100)");
            List<String> ignoredWords = ReadWords("Please enter the words to ignore separated by commas (,)");

            //LINQ to filter the minimal occurence, length, filter the words and order the dict
            var pairs = ds.DistinctWordCount
                .Where(p => p.Value >= minOccurrence)
                .Where(p => p.Key.Length >= minLength)
                .Where(p => !ignoredWords.Contains(p.Key))
                .OrderByDescending(p => p.Value);


            //LINQ method syntax to order the dict
            //var pairs = ds.DistinctWordCount.OrderByDescending(p => p.Value);

            //Query syntax to order the dict
            var pairs2 = from pair in ds.DistinctWordCount
                         orderby pair.Value descending
                         select pair;

            Console.WriteLine("***");
            foreach (var pair in pairs) 
            { 
                Console.WriteLine($"{pair.Key}: {pair.Value}");
            }


            return 0;
        }

        private static List<string> ReadWords(string message)
        {
            Console.WriteLine(message);
            string words = Console.ReadLine();
            while (words == null)
            {
                Console.WriteLine(message);
                words = Console.ReadLine();

            }
            return words.Trim().Split(',').ToList();
        }

        static int ReadPositive(string message)
        {
            int num = 0;
            while (num < 1 || num > 100)
            {
                Console.WriteLine(message);

                try
                {
                    num = int.Parse(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
            
            return num;
        }
    }
}
