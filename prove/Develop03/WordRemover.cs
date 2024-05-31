class WordRemover
{
    // I prefer to keep my definitions outside of my methods.
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
