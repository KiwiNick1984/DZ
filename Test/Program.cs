

using System.Reflection;

internal class Program
{
    [System.AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = true)]
    sealed class MyAttribute : Attribute
    {
        // See the attribute guidelines at 
        //  http://go.microsoft.com/fwlink/?LinkId=85236
        readonly string _className;
        readonly int _numOfProp;

        // This is a positional argument
        public MyAttribute(string className, int numOfProp)
        {
            _className = className;
            _numOfProp = numOfProp;
        }

        public string ClassName
        {
            get { return _className; }
        }

        public int NumOfProp
        {
            get { return _numOfProp; }
        }
    }
    [My("MyTestClass", 2)]
    class MyTestClass
    {
        public int XPos { get; set; }
        public int YPos { get; set; }
        public void PrintPoint()
        {
            Console.WriteLine($"XPos = {XPos}, YPos = {YPos}");
        }
    }
    static void Main(string[] args)
    {
        MyTestClass myTestObj = new MyTestClass();
        var type = myTestObj.GetType();
        var atr = type.GetCustomAttributes<MyAttribute>();

    }
}