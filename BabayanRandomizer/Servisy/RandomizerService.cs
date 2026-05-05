using BabayanRandomizer.Interfejsy;
using BabayanRandomizer.Modeli;

namespace BabayanRandomizer.Servisy
{
    public class RandomizerService : IRandomSelection
    {
        private readonly SelectionHistory _history;
        private ISelectionStrategy _strategy;

        public RandomizerService(SelectionHistory history, ISelectionStrategy strategy)
        {
            _history = history;
            _strategy = strategy;
        }

        public void SetStrategy(ISelectionStrategy strategy)
        {
            _strategy = strategy;
        }

        public SelectionResult PickRandom(List<Option> options)
        {
            if (options.Count == 0)
            {
                var fail = new SelectionResult("Список пуст.");
                _history.AddEntry(fail);
                return fail;
            }

            var selected = _strategy.Select(options);
            if (selected == null)
            {
                return new SelectionResult("Ошибка выбора.");
            }

            selected.IsSelected = true;

            var result = new SelectionResult(selected);
            _history.AddEntry(result);
            return result;
        }
    }
}
