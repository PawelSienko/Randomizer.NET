using System;
using NUnit.Framework;
using Randomizer.Interfaces.ValueTypes;
using Randomizer.Types;

namespace Randomizer.UnitTests
{
    [TestFixture]
    public class RandomFloatGeneratorTests
    {
        private IRandomFloat floatRandomGenerator;

        public RandomFloatGeneratorTests()
        {
            this.floatRandomGenerator = new RandomFloatGenerator();  
            this.floatRandomGenerator.InitSeed((int)DateTime.Now.Ticks);      
        }

        [Test]
        public void GenerateValueShouldGenerateRandomFloat()
        {
            // Arrange 
            float randomFloat = 0;

            // Act + Assert
            Assert.DoesNotThrow(() => randomFloat = floatRandomGenerator.GenerateValue());
        }
    }
}
