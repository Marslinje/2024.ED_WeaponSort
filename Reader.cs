using System.IO;

class Reader
{
    public String[]? test;
    private List<Weapon>? _weapons = new List<Weapon>();

    public Reader()
    {
        ReadLines();
    }

    public void ReadLines()
    {
        String[]? lines = TrySearch("Files\\weapons.txt");

        for (int i = 0; i < lines.Length; i += 3)
        {
            _weapons.Add(new Weapon(lines[i], lines[i + 1], int.Parse(lines[i + 2])));
        }
    }

    public String[]? TrySearch(String file)
    {
        String[]? archive = File.ReadAllLines(file);
        return archive;
    }
}