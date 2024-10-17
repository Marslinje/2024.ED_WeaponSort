Reader getWeaponsData = new Reader();
List<Weapon>? weaponsList = getWeaponsData.getWeapons;
String? choosenOrder = "null";

StartUser();

void StartUser()
{
    Console.WriteLine("--- IT'S THE AMAZING WEAPONS GALLERY! ---");
    Console.WriteLine("Choose the organization method (amazing):");
    Console.WriteLine("Type '1' for order of the alphabet!");
    Console.WriteLine("Type '2' for order of rarity!");
    Console.WriteLine("Type '3' for order of damage!");
    Console.WriteLine();

    Console.Write("YOUR PICK: ");
    choosenOrder = Console.ReadLine();
    if (choosenOrder != "null")
    {
        MergeSort(weaponsList);
        PrintList(weaponsList);
    }
}

void PrintList(List<Weapon>? list)
{
    foreach (Weapon i in list)
    {
        i.PrintWeapon();
        Console.WriteLine("----");
    }
}

void MergeSort(List<Weapon>? list)
{
    // Caso um array tenha 0 ou 1 elementos, ele já está ordenado
    if (list.Count < 2)
    {
        return;
    }

    // O Merge Sort começa dividindo o problema em pedaços menores. Por isso, é
    //feita a divisão do array em 2 sub-arrays.
    int half = list.Count / 2;
    List<Weapon> left = new List<Weapon>();
    List<Weapon> right = new List<Weapon>();

    // Populando os sub-arrays
    for (int i = 0; i < half; i++)
    {
        left.Add(list[i]);
    }
    for (int i = half; i < list.Count; i++)
    {
        right.Add(list[i]);
    }

    // Ordenação dos sub-arrays com o próprio Merge Sort, recursivamente.
    
    MergeSort(left);
    MergeSort(right);

    // Após a ordenação, é feita a mesclagem(merge) dos dois sub-arrays, copiando
    //seus valores para o array principal. A cópia é feita retirando o menor dos
    //valores de cada sub-array, até que um dos sub-arrays fique vazio.
    int il = 0;// índice da esquerda
    int ir = 0;// índice da direita
    int ix = 0;// índice final
    while (il < left.Count && ir < right.Count)
    {
        CompareValues();
    }

    void CompareValues()
    {
        if (choosenOrder == "1") // Alphabet
        {
            if (String.Compare(left[il].getName, right[ir].getName) < 0)
            {
                Merge(left[il]);
                il++;
            }
            else
            {
                Merge(right[ir]);
                ir++;
            }
            ix++;
        }
        if (choosenOrder == "2") // Rarity
        {

            if ((int?)left[il].getRarity < (int?)right[ir].getRarity)
            {
                Merge(left[il]);
                il++;
            }
            else
            {
                Merge(right[ir]);
                ir++;
            }
            ix++;
        }
        else if (choosenOrder == "3") // Damage
        {
            if (left[il].getDamage < right[ir].getDamage) //Aula 7 bubble generic
            {
                Merge(left[il]);
                il++;
            }
            else
            {
                Merge(right[ir]);
                ir++;
            }
            ix++;
        }

        void Merge(Weapon direction)
        {
            list[ix] = direction;
        }
    }

    // Por fim é feita a cópia dos elementos restantes dos sub-arrays
    while (il < left.Count)
    {
        list[ix] = left[il];
        il++;
        ix++;
    }
    while (ir < right.Count)
    {
        list[ix] = right[ir];
        ir++;
        ix++;
    }
}