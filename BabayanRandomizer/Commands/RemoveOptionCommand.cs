using BabayanRandomizer.Interfejsy;
using BabayanRandomizer.Modeli;

namespace BabayanRandomizer.Commands
{
    public class RemoveOptionCommand : IRandomizerCommand
    {
        private readonly IOptionList<Option> _list;
        private readonly int _index;

        public RemoveOptionCommand(IOptionList<Option> list, int index)
        {
            _list = list;
            _index = index;
        }

        public void Execute()
        {
            if (_index >= 0 && _index < _list.Count)
            {
                _list.RemoveAt(_index);
            }
        }
    }
}
