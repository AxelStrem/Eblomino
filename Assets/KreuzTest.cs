using System.Collections;
using NUnit.Framework;
using UnityEngine.TestTools;

namespace Eblomino
{
    public class KreuzTest
    {
        [Test]
        public void KreuzSimplePasses()
        {
            new PlayerGrid().Print();
            Assert.IsTrue(true);
        }

        // A UnityTest behaves like a coroutine in PlayMode
        // and allows you to yield null to skip a frame in EditMode
        /*[UnityTest]
        public IEnumerator KreuzTestWithEnueratorPasses()
        {
            // Use the Assert class to test conditions.
            // yield to skip a frame
            yield return null;
        }*/
    }
}
