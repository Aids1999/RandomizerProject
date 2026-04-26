namespace BabayanRandomizer.Interfejsy
{
    public interface IOptionList<T>
    {
        int Count { get; }
        void Add(T element);
        void RemoveAt(int index);
        void Edit(int index, T newElement);
        void ClearAll();
        T GetAt(int index);
        List<T> GetAll();
    }
}
