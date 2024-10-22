Reader getWeaponsData = new Reader();
List<Weapon>? weaponsList = getWeaponsData.getWeapons;
String? choosenOrder = "null";
List<int> test = new List<int> {3, 2, 5, 0, 1, 8, 7, 6, 9, 4};

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
        if (choosenOrder == "3")
        {
            MergeSort(weaponsList, SortDamage);
            QuickSort(weaponsList, SortDamage);
        }
        else if (choosenOrder == "2")
        {
            MergeSort(weaponsList, SortRarity);
            QuickSort(weaponsList, SortRarity);
            
        }
        else if (choosenOrder == "1")
        {
            MergeSort(weaponsList, SortAlphabet);
            QuickSort(weaponsList, SortAlphabet);
        }
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

#region SortFunctions

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

#endregion

// ##########  ##############  MERGE-SORT  ##################  ################

#region MergeSort

void MergeSort(List<Weapon>? list, Func<Weapon, Weapon, bool> SortMethod)
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
    
    MergeSort(left, SortMethod);
    MergeSort(right, SortMethod);

    // Após a ordenação, é feita a mesclagem(merge) dos dois sub-arrays, copiando
    //seus valores para o array principal. A cópia é feita retirando o menor dos
    //valores de cada sub-array, até que um dos sub-arrays fique vazio.
    int il = 0;// índice da esquerda
    int ir = 0;// índice da direita
    int ix = 0;// índice final
    while (il < left.Count && ir < right.Count)
    {
        if (SortMethod(left[il], right[ir]))
        {
            Merge(left[il], ref il);
            }
            else
            {
            Merge(right[ir], ref ir);
            }
            ix++;
    }

    void Merge(Weapon sortedItem, ref int dir)
        {
            list[ix] = sortedItem;
            dir++;
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

#endregion

// ##########  ##############  QUICK-SORT  ##################  ################

#region QuickSort

void QuickSort(List<Weapon>? list, Func<Weapon, Weapon, bool> SortMethod)
{
    //Nested QuickSort para poder passar a função como parametro inicial
    DoQuickSort(list, 0, list.Count - 1);
    
    void DoQuickSort(List<Weapon>? list, int lowValue, int highValue)
    {
        if (lowValue < highValue)
        {
            //Print(list);
            int pivotID = Partition(list, lowValue, highValue);
            //Print(list);

            DoQuickSort(list, lowValue, pivotID - 1);
            //Print(list);
            DoQuickSort(list, pivotID + 1, highValue);
            //Print(list);
        }
    }

    int Partition(List<Weapon> list, int lowValue, int highValue)
    {
        Weapon pivot = list[highValue];
        int j = lowValue - 1;

        for (int i = lowValue; i <= highValue - 1; i++)
        {
            if (SortMethod(list[i], pivot)) //(list[i] < pivot) 
            {
                j++;
                Swap(list, j, i);
            }
            // se i > pv -> pass
            // j continua igual; i++
        }
        Swap(list, j + 1, highValue);

        return j + 1;
    }

}

void Swap(List<Weapon> list, int j, int i)
{
    Weapon temp = list[j];
    list[j] = list[i];
    list[i] = temp;
}

void Print(List<int> list)
{
    Console.WriteLine();
    foreach (int i in list)
        Console.Write(i);
}

#endregion