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
            {"2 Nephi 2:2","Nevertheless, Jacob, my firstborn in the wilderness, thou knowest the greatness of God; and he shall consecrate thine afflictions for thy gain."},
            {"","Trust in the Lord with all thine heart; and lean not unto thine own understanding.\nIn all thy ways acknowledge him, and he shall direct thy paths."}
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

