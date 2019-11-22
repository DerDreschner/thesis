using System;
using System.Collections.Generic;
using System.Linq;
using AutoFixture.Xunit2;
using FluentAssertions;
using SitecoreUrlShorter.Feature.Core.Generators;
using Xunit;

namespace SitecoreUrlShorter.Feature.Core.Tests {
    public class ShorthandGeneratorTest {
        [Theory]
        [AutoData]
        public void ShorthandGeneratorShouldProduceValidShorthands(int length, string pattern) {
            // Arrange
            var shorthandGenerator = new ShorthandGenerator(new Random());

            // Act
            var shorthand = shorthandGenerator.GenerateShorthand(length, pattern);

            // Assert
            shorthand.All(pattern.Contains).Should().BeTrue();
            shorthand.Length.Should().Be(length);
        }

        [Theory]
        [AutoData]
        public void ShorthandGeneratorShouldProduceUniqueShorthands(int length, string pattern) {
            // Arrange
            const int runs = 100000;
            var shorthandGenerator = new ShorthandGenerator(new Random());
            var shorthands = new HashSet<string>();

            // Act
            for (var i = 0; i < runs; i++) {
                shorthands.Add(shorthandGenerator.GenerateShorthand(length, pattern));
            }

            // Assert
            shorthands.Count.Should().Be(runs);
        }
    }
}