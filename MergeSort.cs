class MergeSort : Sort
{
    public override void SortList<Type>(List<Type> list, Func<Type, Type, bool> SortMethod)
    {
        // Caso um array tenha 0 ou 1 elementos, ele já está ordenado
        if (list.Count < 2)
        {
            return;
        }

        // O Merge Sort começa dividindo o problema em pedaços menores. Por isso, é
        //feita a divisão do array em 2 sub-arrays.
        int half = list.Count / 2;
        List<Type> left = new List<Type>();
        List<Type> right = new List<Type>();

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
        
        SortList(left, SortMethod);
        SortList(right, SortMethod);

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

        void Merge(Type sortedItem, ref int dir)
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
}