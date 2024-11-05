abstract class Sort
{
    public abstract void SortList<Type>(List<Type> list, Func<Type,Type, bool> order);
}