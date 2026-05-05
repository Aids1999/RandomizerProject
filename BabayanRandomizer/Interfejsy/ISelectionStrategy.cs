using BabayanRandomizer.Modeli;

namespace BabayanRandomizer.Interfejsy
{
    public interface ISelectionStrategy
    {
        Option Select(List<Option> options);
    }
}
