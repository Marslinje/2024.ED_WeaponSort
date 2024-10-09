class Weapon
{
    private String _name;
    private String _rarity;
    private int _damage;

    public String name => _name;
    public String rarity => _rarity;
    public String damage => _damage;

    public Weapon(String _name, String _rarity, int _damage)
    {
        this._name = _name;
        this._rarity = _rarity;
        this._damage = _damage;
    }
}