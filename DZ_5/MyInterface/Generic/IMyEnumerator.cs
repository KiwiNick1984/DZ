namespace DZ_5.Generic
{
    public interface IMyEnumerator<out T> : IMyEnumerator
    {
        T Current
        {
            get;
        }
    }
}
