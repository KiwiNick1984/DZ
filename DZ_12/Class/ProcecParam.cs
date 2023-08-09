internal partial class Program
{
    class ProcecParam<T>
    {
        public Memory<T> Memory { get; init; }
        public Memory<T> Memory2 { get; init; } = null;
        public int ThreadIndex { get; init; }
        public int Param1 { get; init; } = 0;
        public int Param2 { get; init; } = 0;
    }


}
