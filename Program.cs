Reader reader = new Reader();

foreach (Weapon weapon in reader.getWeapons)
{
    Console.WriteLine(weapon.name);
    Console.WriteLine(weapon.rarity);
    Console.WriteLine(weapon.damage);
    Console.WriteLine();
}