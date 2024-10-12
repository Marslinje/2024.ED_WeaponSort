class Weapon
{
    private int _value;
    private String _name;
    private String _rarity;
    private int _damage;

    public int value
    {
        get { return _value; }
        set { _value = value; }
    }

    public String getName => _name;
    public String getRarity => _rarity;
    public int getDamage => _damage;

    public Weapon(String _name, String _rarity, int _damage)
    {
        this._name = _name;
        this._rarity = _rarity;
        this._damage = _damage;
    }

    public void PrintWeapon()
    {
        Console.WriteLine($"Name: {_name}");
        Console.WriteLine($"Rarity: {_rarity}");
        Console.WriteLine($"Damage: {_damage}");
    }
}