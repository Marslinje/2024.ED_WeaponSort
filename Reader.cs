using System.IO;

class Reader
{
    public String[]? test;
    private List<weapon>? _weapons = new List<weapon>();

    public Reader()
    {
        ReadLines();
    }

    public void ReadLines()
    {
        String[]? lines = TrySearch("Files\\weapons.txt");

        for (int i = 0; i < lines.Length; i += 3);
        {
            _weapons.Add(new Weapon(lines[i]))
        }
    }

    public String[]? TrySearch(String file)
    {
        String[]? archive = File.ReadAllLines(file);
        return archive;
    }
}