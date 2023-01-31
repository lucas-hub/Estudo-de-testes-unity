using System.Collections;
using InfallibleCode;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class SheepTests
    {
        [UnityTest]
        public IEnumerator MoveNorth()
        {
            var gameObject = new GameObject();
            var sheep = gameObject.AddComponent<Sheep>();
                
            sheep.Move(Direction.North);
            
            yield return new WaitForSeconds(Sheep.JumpDuration);
            
            Assert.AreEqual(new Vector3(0, 1, 0), gameObject.transform.position); 
        }
    }
}