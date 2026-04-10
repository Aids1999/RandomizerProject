using BabayanRandomizer.Interfejsy;
using BabayanRandomizer.Modeli;

namespace BabayanRandomizer.Servisy
{
    // Сервис для случайного выбора
    public class RandomizerService : IRandomSelection
    {
        private readonly SelectionHistory _history;
        private readonly Random _generator;

        public RandomizerService(SelectionHistory history)
        {
            _history = history ?? throw new ArgumentNullException(nameof(history));
            _generator = new Random();
        }

        public SelectionResult PickRandom(List<Option> options)
        {
            return PickRandom(options, new List<Option>());
        }

        public SelectionResult PickRandom(List<Option> options, List<Option> excluded)
        {
            if (options == null || options.Count == 0)
                return RecordAndReturn(new SelectionResult("Список пуст."));

            var excludedIds = excluded?.Select(v => v.Id).ToHashSet() ?? new HashSet<Guid>();
            var available = options.Where(v => !excludedIds.Contains(v.Id) && !v.IsSelected).ToList();

            if (available.Count == 0)
                return RecordAndReturn(new SelectionResult("Нет доступных вариантов."));

            var selected = available[_generator.Next(0, available.Count)];
            selected.MarkAsSelected();

            return RecordAndReturn(new SelectionResult(selected, available.Count));
        }

        private SelectionResult RecordAndReturn(SelectionResult result)
        {
            _history.AddEntry(result);
            return result;
        }
    }
}
