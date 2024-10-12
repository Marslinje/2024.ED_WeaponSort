Reader getWeaponsData = new Reader();

List<Weapon> weaponsList = getWeaponsData.getWeapons;

Console.WriteLine($"------------------------UNSORTED LIST--------------------------------");
PrintList(weaponsList);
//WeaponSetIntBasedValues(weaponsList);
//WeaponSetAlphabetBasedValues(weaponsList);
WeaponSetTermBasedValues(weaponsList);
MergeSort(weaponsList);
Console.WriteLine($"------------------------SORTED LIST--------------------------------");
PrintList(weaponsList);

void PrintList(List<Weapon> list)
{
    foreach (Weapon i in list)
    {
        Console.WriteLine($">>>>>>>>  Value: {i.value}");
        i.PrintWeapon();
    }
}

#region Set Values

void WeaponSetAlphabetBasedValues(List<Weapon> weapons)
{
    foreach (Weapon weapon in weapons)
    {
        //Atribui a posição numérica em ASCII do primeiro caractere de 'name' á variavel 'value' em int
        weapon.value = (int)weapon.getName[0] - 'A'; //subtrai char 'A' para pegar números desde letras maiúsculas
        //Console.WriteLine(weapon.value);
    }
}

//HACK
void WeaponSetTermBasedValues(List<Weapon> weapons)
{
    foreach (Weapon weapon in weapons)
    {
        if (weapon.getRarity == "common")
            weapon.value = 1;
            else if (weapon.getRarity == "rare")
                weapon.value = 2;
                else if (weapon.getRarity == "epic")
                    weapon.value = 3;
                    else
                        weapon.value = 4;
        Console.WriteLine(weapon.value);
    }
}

void WeaponSetIntBasedValues(List<Weapon> weapons)
{
    foreach (Weapon weapon in weapons)
    {
        weapon.value = weapon.getDamage;
    }
}

#endregion

void MergeSort(List<Weapon> list)
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
        if (left[il].value < right[ir].value)
        {
            list[ix] = left[il];
            il++;
        }
        else
        {
            list[ix] = right[ir];
            ir++;
        }
        ix++;
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
