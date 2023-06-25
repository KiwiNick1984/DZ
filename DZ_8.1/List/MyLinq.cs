﻿using System;
using System.Collections.Generic;

namespace DZ_8.Generic
{
    internal static class Mylinq
    {
        class MyLinq_CreateEnumerator<T> : IMyEnumerable<T>
        {
            private readonly Func<IMyEnumerator<T>> _createEnumerator;
            public MyLinq_CreateEnumerator(Func<IMyEnumerator<T>> createEnumerator)
            {
                _createEnumerator = createEnumerator;
            }

            public IMyEnumerator<T> GetEnumerator()
            {
                return _createEnumerator();
            }

            IMyEnumerator IMyEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }
        class MyLinq_CreateSelectEnumerator<T, TResult> : IMyEnumerable<TResult>
        {
            IMyEnumerable<T> _enumerable;
            Func<T, TResult> _selector;
            public MyLinq_CreateSelectEnumerator(IMyEnumerable<T> enumerable, Func<T, TResult> selector)
            {
                _enumerable = enumerable;
                _selector = selector;
            }

            public IMyEnumerator<TResult> GetEnumerator()
            {
                return new MySelectEnumerator<T, TResult>(_enumerable, _selector);
            }

            IMyEnumerator IMyEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }

        class MyWhereEnumerator<T> : IMyEnumerator<T>
        {
            private readonly IMyEnumerator<T> _enumerator;
            private readonly Predicate<T> _predicate;

            public T Current => _enumerator.Current;
            object IMyEnumerator.Current => _enumerator.Current;

            public MyWhereEnumerator(IMyEnumerable<T> enumerator, Predicate<T> predicate)
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
        class MySkipEnumerator<T> : IMyEnumerator<T>
        {
            public readonly IMyEnumerator<T> _enumerator;
            public int _count;

            public T Current => _enumerator.Current;
            object IMyEnumerator.Current => _enumerator.Current;

            public MySkipEnumerator(IMyEnumerable<T> enumerator, int count)
            {
                _enumerator = enumerator.GetEnumerator();
                _count = count;
            }
            
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
        class MySkipWhileEnumerator<T> : IMyEnumerator<T>
        {
            public readonly IMyEnumerator<T> _enumerator;
            private readonly Predicate<T> _predicate;
            bool _noSkip;

            public MySkipWhileEnumerator(IMyEnumerable<T> enumerator, Predicate<T> predicate)
            {
                _enumerator = enumerator.GetEnumerator();
                _predicate = predicate;
                _noSkip = false;
            }

            public T Current => _enumerator.Current;
            object IMyEnumerator.Current => _enumerator.Current;

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
        class MyTakeEnumerator<T> : IMyEnumerator<T>
        {
            public readonly IMyEnumerator<T> _enumerator;
            public int _count;

            public MyTakeEnumerator(IMyEnumerable<T> enumerator, int count)
            {
                _enumerator = enumerator.GetEnumerator();
                _count = count;
            }

            public T Current => _enumerator.Current;
            object IMyEnumerator.Current => _enumerator.Current;
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
        class MyTakeWhileEnumerator<T> : IMyEnumerator<T>
        {
            public readonly IMyEnumerator<T> _enumerator;
            private readonly Predicate<T> _predicate;
            bool _take;

            public MyTakeWhileEnumerator(IMyEnumerable<T> enumerator, Predicate<T> predicate)
            {
                _enumerator = enumerator.GetEnumerator();
                _predicate = predicate;
                _take = true;
            }
            public T Current => _enumerator.Current;
            object IMyEnumerator.Current => _enumerator.Current;

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
        class MySelectEnumerator<T, TResult> : IMyEnumerator<TResult>
        {
            public readonly IMyEnumerator<T> _enumeratorIn;
            private TResult _current;
            private readonly Func<T, TResult> _selector;

            public TResult Current => _current;
            object IMyEnumerator.Current => _current;

            public MySelectEnumerator(IMyEnumerable<T> enumerator, Func<T, TResult> selector)
            {
                _enumeratorIn = enumerator.GetEnumerator();
                _selector = selector;
            }

            public bool MoveNext()
            {
                while (_enumeratorIn.MoveNext())
                {
                    _current = _selector(_enumeratorIn.Current);
                    return true;
                }
                return false;
            }

            public void Reset()
            {
                throw new NotImplementedException();
            }
        }

        public static IMyEnumerable<T> MyWhere<T>(this IMyEnumerable<T> enumerable, Predicate<T> predicate)
        {
            return new MyLinq_CreateEnumerator<T>(() => new MyWhereEnumerator<T>(enumerable, predicate));
        }
        public static IMyEnumerable<T> MySkip<T>(this IMyEnumerable<T> enumerable, int count)
        {
            return new MyLinq_CreateEnumerator<T>(() => new MySkipEnumerator<T>(enumerable, count));
        }
        public static IMyEnumerable<T> MySkipWhile<T>(this IMyEnumerable<T> enumerable, Predicate<T> predicate)
        {
            return new MyLinq_CreateEnumerator<T>(() => new MySkipWhileEnumerator<T>(enumerable, predicate));
        }
        public static IMyEnumerable<T> MyTake<T>(this IMyEnumerable<T> enumerable, int count)
        {
            return new MyLinq_CreateEnumerator<T>(() => new MyTakeEnumerator<T>(enumerable, count));
        }
        public static IMyEnumerable<T> MyTakeWhile<T>(this IMyEnumerable<T> enumerable, Predicate<T> predicate)
        {
            return new MyLinq_CreateEnumerator<T>(() => new MyTakeWhileEnumerator<T>(enumerable, predicate));
        }
        public static T MyFirst<T>(this IMyEnumerable<T> enumerable, Predicate<T> predicate = null)
        {
            if (enumerable == null)
            {
                throw new Exception("Ошибка!!! Аргумент = null");
            }

            if(predicate == null)
            {
                if (enumerable is IMyList<T> list)
                {
                    if (list.Count > 0)
                        return list[0];
                }
            }
            else
            {
                foreach (T item in enumerable)
                {
                    if (predicate(item))
                    {
                        return item;
                    }
                }
            }
            throw new Exception("Ошибка!!! Элемент не найден, или список пуст!");
        }
        public static T MyFirstOrDefault<T>(this IMyEnumerable<T> enumerable, Predicate<T> predicate = null)
        {
            if (enumerable == null)
            {
                throw new Exception("Ошибка!!! Аргумент = null");
            }

            if (predicate == null)
            {
                if (enumerable is IMyList<T> list)
                {
                    if (list.Count > 0)
                        return list[0];
                }
            }
            else
            {
                foreach (T item in enumerable)
                {
                    if (predicate(item))
                    {
                        return item;
                    }
                }
            }
            return default(T);
        }    
        public static T MyLast<T>(this IMyEnumerable<T> enumerable, Predicate<T> predicate = null)
        {
            T lastItem = default(T);
            bool itemFound = false;
            if (enumerable == null)
            {
                throw new Exception("Ошибка!!! Аргумент = null");
            }

            if (predicate == null)
            {
                if (enumerable is IMyList<T> list)
                {
                    if (list.Count > 0)
                        return list[list.Count-1];
                }
            }
            else
            {
                foreach (T item in enumerable)
                {
                    if (predicate(item))
                    {
                        itemFound = true;
                        lastItem = item;
                    }
                }
                if(itemFound)
                { return lastItem; }
            }
            throw new Exception("Ошибка!!! Элемент не найден, или список пуст!");
        }
        public static T MyLastOrDefault<T>(this IMyEnumerable<T> enumerable, Predicate<T> predicate = null)
        {
            T lastItem = default(T);
            bool itemFound = false;
            if (enumerable == null)
            {
                throw new Exception("Ошибка!!! Аргумент = null");
            }

            if (predicate == null)
            {
                if (enumerable is IMyList<T> list)
                {
                    if (list.Count > 0)
                        return list[list.Count - 1];
                }
            }
            else
            {
                foreach (T item in enumerable)
                {
                    if (predicate(item))
                    {
                        itemFound = true;
                        lastItem = item;
                    }
                }
                if (itemFound)
                { return lastItem; }
            }
            return default(T);
        }
        public static IMyEnumerable<TResult> Select<T, TResult>(this IMyEnumerable<T> enumerable, Func<T, TResult> selector)
        {
            return new MyLinq_CreateSelectEnumerator<T, TResult>(enumerable, selector);
        }
        public static IEnumerable<TResult> SelectMany<T, TResult>(this IMyEnumerable<T> enumerable, Func<T, IMyEnumerable<TResult>> selector)
        {
            return SelectManyIterator(enumerable, selector);
        }
        private static IEnumerable<TResult> SelectManyIterator<T, TResult>(this IMyEnumerable<T> enumerable, Func<T, IMyEnumerable<TResult>> selector)
        {
            foreach (T item in enumerable)
            {
                foreach (TResult item2 in selector(item))
                {
                    yield return item2;
                }
            }
        }
        public static bool All<T>(this IMyEnumerable<T> enumerable, Predicate<T> predicate)
        {
            foreach(T item in enumerable)
            {
                if(!predicate(item))
                    return false;
            }
            return true;
        }
        public static bool Any<T>(this IMyEnumerable<T> enumerable, Predicate<T> predicate)
        {
            foreach (T item in enumerable)
            {
                if (predicate(item))
                    return true;
            }
            return false;
        }
        public static T[] ToArray<T>(this IMyEnumerable<T> enumerable)
        {
            if (enumerable is IMyCollection<T> collection)
            {
                int i = 0;
                T[] array = new T[collection.Count];
                foreach (T item in enumerable)
                    array[i++] = item;
                return array;
            }
            throw new Exception("Ошибка!!!");
        }
        public static List<T> ToList<T>(this IMyEnumerable<T> enumerable)
        {
            List<T> list = new List<T>();
            foreach (T item in enumerable)
            {
                list.Add(item);
            }
            return list;
        }
    }
}
