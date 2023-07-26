using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DZ_5.Generic;

namespace DZ_10
{
    [TestClass]
    public class List_Tests
    {
        [TestMethod]
        [TestCategory("MyList")]
        public void List_Tests_Add()
        {
            MyList<int> myList = new MyList<int>();
            myList.Add(0);
            myList.Add(1);
            myList.Add(2);
            myList.Add(3);
            myList.Add(4);
            myList.Add(5);
            for (int i = 0; i < myList.Count; i++) 
            {
                Assert.AreEqual(i, myList[i]);
            }
        }
    }
}
