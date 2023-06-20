using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ_8
{
    internal static class Mylinq
    {
        class MyLinq_CreateEnumerator : IMyEnumerable
        {
            private readonly Func<IMyEnumerator> _createEnumerator;
            public MyLinq_CreateEnumerator(Func<IMyEnumerator> createEnumerator)
            {
                _createEnumerator = createEnumerator;
            }

            public IMyEnumerator GetEnumerator()
            {
                return _createEnumerator();
            }
        }
        class MySkipEnumerator : IMyEnumerator
        {
            public IMyEnumerator _enumerator;
            public int _count;

            public MySkipEnumerator(IMyEnumerable enumerator, int count)
            {
                _enumerator = enumerator.GetEnumerator();
                _count = count;
            }

            public object Current => _enumerator.Current;
            public bool MoveNext()
            {
                for (; _count > 0; _count--)
                    _enumerator.MoveNext();
                return _enumerator.MoveNext();
            }
            public void Reset()
            {
                throw new NotImplementedException();
            }
        }

        public static IMyEnumerable MySkip(this IMyEnumerable enumerable, int count)
        {
            return new MyLinq_CreateEnumerator(() => new MySkipEnumerator(enumerable, count));
        }
    }
}
