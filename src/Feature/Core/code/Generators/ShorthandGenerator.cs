using System;

namespace SitecoreUrlShorter.Feature.Core.Generators {
    public class ShorthandGenerator : IShorthandGenerator {
        private readonly Random _random;

        public ShorthandGenerator(Random random) {
            _random = random;
        }

        public string GenerateShorthand(int length, string pattern) {
            var generatedShorthand = string.Empty;

            for (var i = 0; i < length; i++) {
                var number = _random.Next(pattern.Length - 1);
                generatedShorthand += pattern[number];
            }

            return generatedShorthand;
        }
    }
}