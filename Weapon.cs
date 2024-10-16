class Weapon
{
    private String _name;
    private Rarity _rarity;
    private int _damage;
    
    // Get variables

    public String getName => _name;
    public Rarity getRarity => _rarity;
    public int getDamage => _damage;

    // Constructor

    public enum Rarity
    {
        common,
        rare,
        epic,
        legendary
    }

    public Weapon(String _name, String _rarity, int _damage)
    {
        this._name = _name;
        this._rarity = SetEnum(_rarity);
        this._damage = _damage;
        SetEnum(_rarity);
    }

    public void PrintWeapon()
    {
        Console.WriteLine($"Name: {_name}");
        Console.WriteLine($"Rarity: {_rarity}");
        Console.WriteLine($"Damage: {_damage}");
    }

    Rarity SetEnum(String stringRarity)
    {
        return (Rarity) Enum.Parse(typeof(Rarity), stringRarity);
    }
}