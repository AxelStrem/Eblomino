using System;
using NUnit.Framework;
using UnityEngine.TestTools;

namespace Eblomino
{
    class ConsolePrintingGridListener : IGridListener
    {
        public void onCellCreated(Kreuz cell)
        {
            Console.WriteLine("Kreuz at " + cell);
        }

        public void onSquareFound(Kreuz first, Kreuz second)
        {
            Console.WriteLine("Square at " + first + " @ " + second);
        }
    }
    
    public class KreuzTest
    {
        [Test]
        public void KreuzSimplePasses()
        {
            var grid = new PlayerGrid();
            grid.AddListener(new ConsolePrintingGridListener());
            grid.NewCell(0, 0);
            grid.NewCell(0, 1);
            grid.NewCell(1, 0);
            grid.NewCell(1, 1);
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
