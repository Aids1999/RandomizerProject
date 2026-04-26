using BabayanRandomizer.Interfejsy;

namespace BabayanRandomizer.Modeli
{
    public class OptionList : IOptionList<Option>
    {
        private List<Option> _options;

        public string Title { get; set; }
        public int Count => _options.Count;

        public OptionList(string title)
        {
            Title = title;
            _options = new List<Option>();
        }

        public void Add(Option element)
        {
            _options.Add(element);
        }

        public void RemoveAt(int index)
        {
            _options.RemoveAt(index);
        }

        public void Edit(int index, Option newElement)
        {
            _options[index].Text = newElement.Text;
        }

        public void ClearAll()
        {
            _options.Clear();
        }

        public Option GetAt(int index)
        {
            return _options[index];
        }

        public List<Option> GetAll()
        {
            return _options;
        }
    }
}
