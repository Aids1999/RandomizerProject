using BabayanRandomizer.Interfejsy;
using BabayanRandomizer.Modeli;

namespace BabayanRandomizer.Servisy
{
    public class RandomizerService : IRandomSelection
    {
        private readonly SelectionHistory _history;
        private readonly Random _random;

        public RandomizerService(SelectionHistory history)
        {
            _history = history;
            _random = new Random();
        }

        public SelectionResult PickRandom(List<Option> options)
        {
            if (options.Count == 0)
            {
                var fail = new SelectionResult("Список пуст.");
                _history.AddEntry(fail);
                return fail;
            }

            int index = _random.Next(0, options.Count);
            var selected = options[index];
            selected.IsSelected = true;

            var result = new SelectionResult(selected);
            _history.AddEntry(result);
            return result;
        }
    }
}
