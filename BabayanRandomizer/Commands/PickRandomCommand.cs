using BabayanRandomizer.Interfejsy;
using BabayanRandomizer.Modeli;
using System;

namespace BabayanRandomizer.Commands
{
    public class PickRandomCommand : IRandomizerCommand
    {
        private readonly IRandomSelection _service;
        private readonly IOptionList<Option> _list;
        private readonly Action<SelectionResult> _onResult;

        public PickRandomCommand(IRandomSelection service, IOptionList<Option> list, Action<SelectionResult> onResult)
        {
            _service = service;
            _list = list;
            _onResult = onResult;
        }

        public void Execute()
        {
            var result = _service.PickRandom(_list.GetAll());
            _onResult?.Invoke(result);
        }
    }
}
