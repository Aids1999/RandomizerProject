using BabayanRandomizer.Interfejsy;

namespace BabayanRandomizer.Modeli
{
    // Список всех вариантов
    public sealed class OptionList : IOptionList<Option>
    {
        private readonly List<Option> _options;

        public string Title { get; set; }
        public int Count => _options.Count;
        public int AvailableCount => _options.Count(v => !v.IsSelected);
        public bool IsEmpty => _options.Count == 0;

        public OptionList(string title = "Мой список")
        {
            if (string.IsNullOrWhiteSpace(title))
                title = "Без названия";

            Title = title.Trim();
            _options = new List<Option>();
        }

        public void Add(Option element)
        {
            if (element == null)
                throw new ArgumentNullException(nameof(element));

            bool asDuplicate = _options.Any(v =>
                string.Equals(v.Text, element.Text, StringComparison.OrdinalIgnoreCase));

            if (asDuplicate)
                throw new InvalidOperationException($"Вариант \"{element.Text}\" уже есть.");

            _options.Add(element);
        }

        public void RemoveAt(int index)
        {
            VerifyIndex(index);
            _options.RemoveAt(index);
        }

        public void Edit(int index, Option next)
        {
            VerifyIndex(index);
            if (next == null)
                throw new ArgumentNullException(nameof(next));

            _options[index].Text = next.Text;
        }

        public void ClearAll()
        {
            _options.Clear();
        }

        public Option GetAt(int index)
        {
            VerifyIndex(index);
            return _options[index];
        }

        public List<Option> GetAll()
        {
            return new List<Option>(_options);
        }

        private void VerifyIndex(int index)
        {
            if (index < 0 || index >= _options.Count)
                throw new ArgumentOutOfRangeException(nameof(index));
        }

        public override string ToString()
        {
            return $"Список \"{Title}\": {Count} вар.";
        }
    }
}
