using BabayanRandomizer.Interfejsy;
using BabayanRandomizer.Modeli;

namespace BabayanRandomizer.Commands
{
    public class ClearOptionsCommand : IRandomizerCommand
    {
        private readonly IOptionList<Option> _list;

        public ClearOptionsCommand(IOptionList<Option> list)
        {
            _list = list;
        }

        public void Execute()
        {
            _list.ClearAll();
        }
    }
}
