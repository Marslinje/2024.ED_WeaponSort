class QuickSort : Sort
{
    public override void SortList<Type>(List<Type> list, Func<Type, Type, bool> SortMethod)
{
        //Nested QuickSort para poder passar a função como parametro inicial
        DoQuickSort(list, 0, list.Count - 1);
        
        void DoQuickSort(List<Type>? list, int lowValue, int highValue)
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

        int Partition(List<Type> list, int lowValue, int highValue)
        {
            Type pivot = list[highValue];
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

    void Swap<Type>(List<Type> list, int j, int i)
    {
        Type temp = list[j];
        list[j] = list[i];
        list[i] = temp;
    }
}