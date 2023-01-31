using InfallibleCode;
using NUnit.Framework;
using UnityEngine;

namespace Tests
{
    public class DirectionTests
    {
        [Test]
        public void North()
        {
            Assert.AreEqual(new Vector3(0, 1, 0), Direction.North.Vector);
        }

        [Test]
        public void South()
        {
            Assert.AreEqual(new Vector3(0, -1, 0), Direction.South.Vector);
        }

        [Test]
        public void West()
        {
            Assert.AreEqual(new Vector3(1, 0, 0), Direction.West.Vector);
        }
           
        [Test]
        public void East_Test()
        {
            Assert.AreEqual(new Vector3(-1, 1, 1), Direction.East.Vector);
        }
    }
}
