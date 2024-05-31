using System;
using System.Collections.Generic;
using System.Linq;

namespace ScriptureMemorization
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n\nWelcome to the Scripture Memorization Program!");
            string input;
            do
            {
                Console.WriteLine("Enter the scripture you want to memorize (or type 'quit' to exit):");
                input = Console.ReadLine();

                if (input.ToLower() != "quit")
                {
                    ScriptureStorer scriptureStorer = new ScriptureStorer(input);
                    WordRemover wordRemover = new WordRemover(scriptureStorer.GetScripture());

                    Console.WriteLine("Press Enter to start memorizing...");
                    Console.ReadLine();

                    while (!wordRemover.IsCompletelyRemoved())
                    {
                        Console.Clear();
                        Console.WriteLine(wordRemover.GetCurrentScripture());
                        wordRemover.RemoveRandomWord();
                        Console.WriteLine("Press Enter to continue or type 'quit' to exit.");
                        if (Console.ReadLine().ToLower() == "quit")
                            break;
                    }

                    if (wordRemover.IsCompletelyRemoved())
                    {
                        Console.WriteLine("Congratulations! You've memorized the scripture!\n");
                    }
                }

            } while (input.ToLower() != "quit");

            Console.WriteLine("Goodbye!");
        }
    }

    class ScriptureStorer
    {
        private Dictionary<string, string> _scripturesStored;

        public ScriptureStorer(string scriptureAddress)
        {
            _scripturesStored = new Dictionary<string, string>
            {
                { "1 John 3:2", "Beloved, now are we the sons of God, and it doth not yet appear what we shall be: but we know that, when he shall appear, we shall be like him, for we shall see him as he is." },
                { "1 Peter 3:4", "But let it be the hidden man of the heart, in that which is not corruptible, even the ornament of a meek and quiet spirit, which is in the sight of God of great price." },
                {"JST 1 Peter 4:6","Because of this, is the gospel preached to them who are dead, that they might be judged according to the will of God."},
                {"Helaman 11:4","O Lord, do not suffer that this people shall be destroyed by the sword; but O Lord, rather let there be a famine in the land, to stir them up in remembrance of the Lord their God, and perhaps they will repent and turn unto thee."},
                {"Moses 6:55","And the Lord spake unto Adam, saying: Inasmuch as thy children are conceived in sin, even so when they begin to grow up, sin conceiveth in their hearts, and they taste the bitter, that they may know to prize the good."},
                {"2 Nephi 2:2","Nevertheless, Jacob, my firstborn in the wilderness, thou knowest the greatness of God; and he shall consecrate thine afflictions for thy gain."}
            };

            if (!_scripturesStored.ContainsKey(scriptureAddress))
            {
                Console.WriteLine("Scripture not found. By default, let's use JST 1 Peter 4:6.\nIt's a bit long, but actually the shortest one that I've coded in so far.");
                scriptureAddress = "JST 1 Peter 4:6"; // Default scripture
            }

            ScriptureAddress = scriptureAddress;
        }

        public string ScriptureAddress { get; private set; }

        public string GetScripture()
        {
            return _scripturesStored[ScriptureAddress];
        }
    }

    class WordRemover
    {
        private string _originalScripture;
        private List<string> _words;
        private Random _random;

        public WordRemover(string scripture)
        {
            _originalScripture = scripture;
            _words = new List<string>(scripture.Split(' '));
            _random = new Random();
        }

        public void RemoveRandomWord()
        {
            // Just sank in that csharp isn't line-sensitive like Python is!
            var removableIndices = _words.Select((word, index) => new { word, index })
                .Where(x => !x.word.All(c => c == '_')).Select(x => x.index).ToList();

            if (removableIndices.Count > 0)
            {
                int randomIndex = _random.Next(removableIndices.Count);
                int wordIndex = removableIndices[randomIndex];
                _words[wordIndex] = new string('_', _words[wordIndex].Length);
            }
        }

        public bool IsCompletelyRemoved()
        {
            return _words.All(word => word.All(c => c == '_'));
        }

        public string GetCurrentScripture()
        {
            return string.Join(" ", _words);
        }
    }
}
