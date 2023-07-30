using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DZ_5.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DZ_10
{
    [TestClass]
    public class List_Tests
    {

        public List_Tests() 
        {
        }
        [TestInitialize]
        public void InitTest()
        { 

        }
        [TestCleanup]
        public void CleanTest()
        {
        }

        [TestMethod]
        [TestCategory("MyList")]
        public void List_Tests_Add()
        {
            GenericAdd<int>();
            GenericAdd<bool>();
            GenericAdd<float>();
            GenericAdd<double>();
            GenericAdd<string>();

            MyList<int> myList = new MyList<int>();
            myList.Add(0);
            Assert.AreEqual(0, myList[myList.Count - 1]);
            myList.Add(1);
            Assert.AreEqual(1, myList[myList.Count - 1]);
            myList.Add(2);
            Assert.AreEqual(2, myList[myList.Count - 1]);
            myList.Add(3);
            Assert.AreEqual(3, myList[myList.Count - 1]);
            myList.Add(4);
            Assert.AreEqual(4, myList[myList.Count - 1]);
            myList.Add(5);
            Assert.AreEqual(5, myList[myList.Count - 1]);
            for (int i = 0; i < myList.Count; i++) 
            {
                Assert.AreEqual(i, myList[i]);
            }
            Assert.AreEqual(6, myList.Count);
        }

        [TestMethod]
        [TestCategory("MyList")]
        public void List_Tests_Clear()
        {
            MyList<int> myList = new MyList<int>();
            myList.Add(0);
            myList.Add(1);
            myList.Add(2);
            myList.Add(3);
            myList.Add(4);
            myList.Add(5);
            myList.Clear();
            for (int i = 0; i < myList.Capacity; i++)
            {
                Assert.AreEqual(default(int), myList[i]);
            }
        }

        [TestMethod]
        [TestCategory("MyList")]
        public void List_Tests_Contains()
        {
            MyList<int> myList = new MyList<int>();
            myList.Add(0);
            Assert.AreEqual(true, myList.Contains(0));
            myList.Add(1);
            Assert.AreEqual(true, myList.Contains(1));
            myList.Add(2);
            Assert.AreEqual(true, myList.Contains(2));
            myList.Add(3);
            Assert.AreEqual(true, myList.Contains(3));
            myList.Add(4);
            Assert.AreEqual(true, myList.Contains(4));
            Assert.AreEqual(false, myList.Contains(5));
        }

        [TestMethod]
        [TestCategory("MyList")]
        [DataRow(5, 50)]
        [DataRow(0, 10)]
        [DataRow(3, 30)]
        public void List_Tests_Insert(int index, int val)
        {
            MyList<int> myList = new MyList<int>();
            myList.Add(0);
            myList.Add(1);
            myList.Add(2);
            myList.Add(3);
            myList.Add(4);
            myList.Insert(index, val);
            if (index == 0)
            {
                Assert.AreEqual(10, myList[index]);
            }
            else
            {
                Assert.AreEqual(index * 10, myList[index]);
            }
        }

        [TestMethod]
        [TestCategory("MyList")]
        public void List_Tests_Remove()
        {
            MyList<int> myList = new MyList<int>();
            myList.Add(0);
            myList.Add(1);
            myList.Add(2);
            myList.Add(3);
            myList.Add(4);
            myList.Add(5);
            myList.Remove(3);            
            for (int i = 0; i < myList.Count; i++)
            {
                if (myList[i] == 3)
                    Assert.Fail("Найден удаленный элемент");
            }
            if(myList.Count != 5)
            {
                Assert.Fail("Колличество элементов не верно");
            }

        }

        [TestMethod]
        [TestCategory("MyList")]
        public void List_Tests_ToAraay()
        {
            MyList<int> myList = new MyList<int>();
            myList.Add(0);
            myList.Add(1);
            myList.Add(2);
            myList.Add(3);
            myList.Add(4);
            myList.Add(5);
            var MyArr = myList.ToArray();

            Assert.AreEqual(myList.Count, MyArr.Length);
            for (int i = 0; i < MyArr.Length; i++)
            {
                Assert.AreEqual(i, MyArr[i]);
            }            
        }

        [TestMethod]
        [TestCategory("MyList")]
        public void List_Tests_Reverse()
        {
            MyList<int> myList = new MyList<int>();
            myList.Add(5);
            myList.Add(4);
            myList.Add(3);
            myList.Add(2);
            myList.Add(1);
            myList.Add(0);
            myList.Reverse();

            for (int i = 0; i < myList.Count; i++)
            {
                Assert.AreEqual(i, myList[i]);
            }
        }

        [TestMethod]
        [TestCategory("MyList")]
        public void List_Tests_Sort()
        {
            MyList<int> myList = new MyList<int>();
            myList.Add(25);
            myList.Add(1);
            myList.Add(68);
            myList.Add(33);
            myList.Add(148);
            myList.Add(560);
            myList.Sort();

            for (int i = 1; i < myList.Count; i++)
            {
                if(myList[i-1] > myList[i])
                    Assert.Fail("Тест не пройден");
            }
        }

        private void GenericAdd<T>()
        {
            MyList<T> myList = new MyList<T>();
            myList.Add(default(T));
            myList.Add(default(T));
            myList.Add(default(T));
            Assert.AreEqual(3, myList.Count);
            Assert.AreEqual(typeof(T), myList.GetType().GenericTypeArguments[0]);
        }
    }
}
