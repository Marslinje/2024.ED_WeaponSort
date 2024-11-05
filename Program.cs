Reader getWeaponsData = new Reader();
List<Weapon>? weaponsList = getWeaponsData.getWeapons;
String? userInput = "null";
List<int> test = new List<int> {3, 2, 5, 0, 1, 8, 7, 6, 9, 4};



StartUser();

void StartUser()
{
    Console.WriteLine("--- IT'S THE AMAZING WEAPONS GALLERY! ---");
    Console.WriteLine("Choose the sorting algorithm (amazing):");
    Console.WriteLine("Type '1' for MergeSort");
    Console.WriteLine("Type '2' for QuickSort");
    Console.WriteLine();

    Console.Write("YOUR PICK: ");
    
    userInput = Console.ReadLine();
    Sort sorter = userInput == "1" ? new MergeSort() : 
                  new QuickSort();
                  

    Console.WriteLine("Type '1' to sort by the alphabet");
    Console.WriteLine("Type '2' to sort by damage");
    Console.WriteLine("Type '3' to sort by rarity");

    Console.Write("YOUR PICK: ");
    userInput = Console.ReadLine();
    sorter.SortList(weaponsList, userInput == "1" ? SortAlphabet :
                                 userInput == "2" ? SortDamage :
                                 SortRarity);
    
    PrintList(weaponsList);
}

void PrintList(List<Weapon>? list)
{
    foreach (Weapon i in list)
    {
        i.PrintWeapon();
        Console.WriteLine("----");
    }
}

bool SortDamage(Weapon indexLeft, Weapon indexRight)
{
    return indexLeft.getDamage > indexRight.getDamage;
}

bool SortRarity(Weapon indexLeft, Weapon indexRight)
{
    return (int?)indexLeft.getRarity > (int?)indexRight.getRarity;
}

bool SortAlphabet(Weapon indexLeft, Weapon indexRight)
{
    return String.Compare(indexLeft.getName, indexRight.getName) < 0;
}

