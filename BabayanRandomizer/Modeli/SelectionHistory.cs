namespace BabayanRandomizer.Modeli
{
    public class SelectionHistory
    {
        private List<SelectionResult> _entries;

        public int Count => _entries.Count;

        public SelectionHistory()
        {
            _entries = new List<SelectionResult>();
        }

        public void AddEntry(SelectionResult result)
        {
            _entries.Add(result);
        }

        public List<SelectionResult> GetAll()
        {
            return _entries;
        }
    }
}
