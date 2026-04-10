namespace BabayanRandomizer.Modeli
{
    // История всех сделанных выборов
    public class SelectionHistory
    {
        private readonly List<SelectionResult> _entries;

        public int Count => _entries.Count;

        public SelectionHistory()
        {
            _entries = new List<SelectionResult>();
        }

        public void AddEntry(SelectionResult result)
        {
            if (result == null)
                throw new ArgumentNullException(nameof(result));

            _entries.Add(result);
        }

        public List<SelectionResult> GetAll()
        {
            return new List<SelectionResult>(_entries);
        }

        public SelectionResult? GetLast()
        {
            return _entries.LastOrDefault();
        }

        public void Clear()
        {
            _entries.Clear();
        }

        public List<SelectionResult> GetSuccessful()
        {
            return _entries.Where(r => r.IsSuccess).ToList();
        }

        public override string ToString()
        {
            return $"История: {Count} записей";
        }
    }
}
