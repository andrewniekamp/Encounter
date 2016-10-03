using Encounter.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Encounter.Tests
{
    public class CharacterTest
    {
        [Fact]
        public void GetNameTest()
        {
            //arrange
            var character = new Character();
            character.Name = "Clementine";

            //act
            var result = character.Name;

            //assert
            Assert.Equal("Clementine", result);
        }
    }
}
