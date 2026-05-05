using BabayanRandomizer.Interfejsy;
using BabayanRandomizer.Modeli;

namespace BabayanRandomizer.Commands
{
    public class AddOptionCommand : IRandomizerCommand
    {
        private readonly IOptionList<Option> _list;
        private readonly string _text;

        public AddOptionCommand(IOptionList<Option> list, string text)
        {
            _list = list;
            _text = text;
        }

        public void Execute()
        {
            if (!string.IsNullOrEmpty(_text))
            {
                _list.Add(new Option(_text));
            }
        }
    }
}
