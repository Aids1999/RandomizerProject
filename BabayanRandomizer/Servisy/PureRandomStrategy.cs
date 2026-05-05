using BabayanRandomizer.Interfejsy;
using BabayanRandomizer.Modeli;
using System;
using System.Collections.Generic;

namespace BabayanRandomizer.Servisy
{
    public class PureRandomStrategy : ISelectionStrategy
    {
        private readonly Random _random;

        public PureRandomStrategy()
        {
            _random = new Random();
        }

        public Option Select(List<Option> options)
        {
            if (options.Count == 0)
                return null;

            int index = _random.Next(0, options.Count);
            return options[index];
        }
    }
}
