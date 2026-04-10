using BabayanRandomizer.Modeli;

namespace BabayanRandomizer.Interfejsy
{
    // Интерфейс для логики рандома
    public interface IRandomSelection
    {
        SelectionResult PickRandom(List<Option> options);
        SelectionResult PickRandom(List<Option> options, List<Option> excluded);
    }
}
