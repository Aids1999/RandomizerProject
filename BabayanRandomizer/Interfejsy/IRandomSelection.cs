using BabayanRandomizer.Modeli;

namespace BabayanRandomizer.Interfejsy
{
    public interface IRandomSelection
    {
        SelectionResult PickRandom(List<Option> options);
    }
}
