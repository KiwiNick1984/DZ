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
        class MyWhereEnumerator : IMyEnumerator
        {
            public readonly IMyEnumerator _enumerator;
            private readonly Predicate<object> _predicate;
            public object Current => _enumerator.Current;

            public MyWhereEnumerator(IMyEnumerable enumerator, Predicate<object> predicate)
            {
                _enumerator = enumerator.GetEnumerator();
                _predicate = predicate;
            }

            public bool MoveNext()
            {
                while (_enumerator.MoveNext())
                {
                    if (_predicate(Current))
                        return true;
                }
                return false;
            }
            public void Reset()
            {
                throw new NotImplementedException();
            }
        }
        class MySkipEnumerator : IMyEnumerator
        {
            public readonly IMyEnumerator _enumerator;
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
        class MySkipWhileEnumerator : IMyEnumerator
        {
            public readonly IMyEnumerator _enumerator;
            private readonly Predicate<object> _predicate;
            bool _noSkip;

            public MySkipWhileEnumerator(IMyEnumerable enumerator, Predicate<object> predicate)
            {
                _enumerator = enumerator.GetEnumerator();
                _predicate = predicate;
                _noSkip = false;
            }

            public object Current => _enumerator.Current;
            public bool MoveNext()
            {
                while(_enumerator.MoveNext())
                {
                    if(_noSkip || !_predicate(Current))
                    {
                        _noSkip = true;
                        return true;
                    }                        
                }
                return false;
            }
            public void Reset()
            {
                throw new NotImplementedException();
            }
        }
        class MyTakeEnumerator : IMyEnumerator
        {
            public readonly IMyEnumerator _enumerator;
            public int _count;

            public MyTakeEnumerator(IMyEnumerable enumerator, int count)
            {
                _enumerator = enumerator.GetEnumerator();
                _count = count;
            }

            public object Current => _enumerator.Current;
            public bool MoveNext()
            {
                while(_enumerator.MoveNext() && _count>0)
                {
                    _count--;
                    return true;
                }
                return false;
            }

            public void Reset()
            {
                throw new NotImplementedException();
            }
        }
        class MyTakeWhileEnumerator : IMyEnumerator
        {
            public readonly IMyEnumerator _enumerator;
            private readonly Predicate<object> _predicate;
            bool _take;

            public MyTakeWhileEnumerator(IMyEnumerable enumerator, Predicate<object> predicate)
            {
                _enumerator = enumerator.GetEnumerator();
                _predicate = predicate;
                _take = true;
            }

            public object Current => _enumerator.Current;
            public bool MoveNext()
            {
                while (_enumerator.MoveNext() && _take)
                {
                    if (_predicate(Current))
                        return true;
                    else
                        _take = false;
                }
                return false;
            }
            public void Reset()
            {
                throw new NotImplementedException();
            }
        }
        class MyFirstEnumerator : IMyEnumerator
        {
            public readonly IMyEnumerator _enumerator;
            private readonly Predicate<object> _predicate;
            bool _take;

            public MyFirstEnumerator(IMyEnumerable enumerator, Predicate<object> predicate)
            {
                _enumerator = enumerator.GetEnumerator();
                _predicate = predicate;
                _take = true;
            }

            public object Current => _enumerator.Current;
            public bool MoveNext()
            {
                while (_enumerator.MoveNext() && _take)
                {
                    if (_predicate == null)
                    {
                        _take = false;
                        return true;
                    }
                    if (_predicate(Current))
                    {
                        _take = false;
                        return true;
                    }
                }
                return false;
            }
            public void Reset()
            {
                throw new NotImplementedException();
            }
        }
        class MyLastEnumerator : IMyEnumerator
        {
            public readonly IMyEnumerator _enumerator;
            private readonly Predicate<object> _predicate;
            object _current;
            bool _take;

            public MyLastEnumerator(IMyEnumerable enumerator, Predicate<object> predicate)
            {
                _enumerator = enumerator.GetEnumerator();
                _predicate = predicate;
                _current = _enumerator.Current;
            }

            public object Current => _current;
            public bool MoveNext()
            {
                _take = false;
                while (_enumerator.MoveNext())
                {
                    if (_predicate == null)
                    {
                        _current = _enumerator.Current;
                        _take = true;
                    }
                    else if (_predicate(_enumerator.Current))
                    {
                        _current = _enumerator.Current;
                        _take = true;
                    }
                }
                return _take;
            }
            public void Reset()
            {
                throw new NotImplementedException();
            }
        }

        public static IMyEnumerable MyWhere(this IMyEnumerable enumerable, Predicate<object> predicate)
        {
            return new MyLinq_CreateEnumerator(() => new MyWhereEnumerator(enumerable, predicate));
        }
        public static IMyEnumerable MySkip(this IMyEnumerable enumerable, int count)
        {
            return new MyLinq_CreateEnumerator(() => new MySkipEnumerator(enumerable, count));
        }
        public static IMyEnumerable MySkipWhile(this IMyEnumerable enumerable, Predicate<object> predicate)
        {
            return new MyLinq_CreateEnumerator(() => new MySkipWhileEnumerator(enumerable, predicate));
        }
        public static IMyEnumerable MyTake(this IMyEnumerable enumerable, int count)
        {
            return new MyLinq_CreateEnumerator(() => new MyTakeEnumerator(enumerable, count));
        }
        public static IMyEnumerable MyTakeWhile(this IMyEnumerable enumerable, Predicate<object> predicate)
        {
            return new MyLinq_CreateEnumerator(() => new MyTakeWhileEnumerator(enumerable, predicate));
        }
        public static IMyEnumerable MyFirst(this IMyEnumerable enumerable, Predicate<object> predicate = null)
        {
            return new MyLinq_CreateEnumerator(() => new MyFirstEnumerator(enumerable, predicate));
        }
        public static IMyEnumerable MyLast(this IMyEnumerable enumerable, Predicate<object> predicate = null)
        {
            return new MyLinq_CreateEnumerator(() => new MyLastEnumerator(enumerable, predicate));
        }
        public static IMyEnumerable MySelect(this IMyEnumerable enumerable, Predicate<object> predicate = null)
        {
            return new MyLinq_CreateEnumerator(() => new MyLastEnumerator(enumerable, predicate));
        }

    }
}
