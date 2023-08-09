internal partial class Program
{
    class FrequncyDictionary
    {
        private readonly Thread[] _threads;
        private readonly Memory<string> _arrMem;
        private readonly int _numOfThreads;
        private readonly int _numOfElements;
        private Dictionary<char, int>[] _dictionariesChars;
        private Dictionary<string, int>[] _dictionariesWords;
        private string[] _arrStr;

        public FrequncyDictionary(string[] arrStr, int numOfThreads) 
        {
            _numOfThreads = numOfThreads;
            _threads = new Thread[_numOfThreads];
            _dictionariesChars = new Dictionary<char, int>[_numOfThreads];
            _dictionariesWords = new Dictionary<string, int>[_numOfThreads];
            _arrMem = arrStr.AsMemory();
            _numOfElements = arrStr.Length / _numOfThreads;
            for (int i = 0; i < _numOfThreads; i++)
            {
                _dictionariesChars[i] = new Dictionary<char, int>();
            }
            for (int i = 0; i < _numOfThreads; i++)
            {
                _dictionariesWords[i] = new Dictionary<string, int>();
            }
            _arrStr = arrStr;
        }

        //Простой словарь символов
        public void GetDictionaryChar()
        {
            var dic = new Dictionary<char, int>();
            for (int i = 0; i < _arrStr.Length; i++)
            {
                foreach (var ch in _arrStr[i])
                {
                    if (!dic.TryGetValue(ch, out int count))
                    {
                        dic[ch] = 1;
                    }
                    else
                    {
                        dic[ch] += 1;
                    }
                }
            }
        }

        //Словарь символов с потоками
        public void GetDictionaryCharThreads() 
        {
            for (int i = 0; i < _numOfThreads; i++)
            {
                _threads[i] = new Thread(GetDictionaryCharThreadsProc);
                Memory<string> arrSlice;
                if (i == _numOfThreads-1)
                {
                    arrSlice = _arrMem.Slice(i * _numOfElements);
                }
                else
                {
                    arrSlice = _arrMem.Slice(i * _numOfElements, _numOfElements);
                }                
                _threads[i].Start(new ProcecParam<string> { Memory = arrSlice, ThreadIndex = i });
            }
            Wait();
            var result = new Dictionary<char, int>();
            foreach (var dic in _dictionariesChars)
            {
                foreach(var itemDic in dic)
                {
                    if(!result.TryGetValue(itemDic.Key, out int count))
                    {
                        result.Add(itemDic.Key, itemDic.Value);
                    }
                    else 
                    {
                        result[itemDic.Key] += count;
                    }
                }
            }
        }
        private void GetDictionaryCharThreadsProc(object? state)
        {
            ProcecParam<string> param = (ProcecParam<string>)state;
            Span<string> span = param.Memory.Span;
            var dic = _dictionariesChars[param.ThreadIndex];
            for (int i = 0; i < span.Length; i++)
            {
                foreach (var item in span[i])
                {
                    if(!dic.TryGetValue(item, out int count))
                    {
                        dic[item] = 1;
                    }
                    else
                    {
                        dic[item] += 1;
                    }
                }
            }
        }

        //Простой словарь слов
        public void GetDictionaryWords()
        {
            var dic = new Dictionary<string, int>();
            for (int i = 0; i < _arrStr.Length; i++)
            {
                foreach (var word in _arrStr[i].Split(' ', ',', '.', ':', '\t'))
                {
                    if (!dic.TryGetValue(word, out int count))
                    {
                        dic[word] = 1;
                    }
                    else
                    {
                        dic[word] += 1;
                    }
                }
            }
            dic.Remove("");
        }
        //Словарь слов с потоками
        public void GetDictionaryWordThreads()
        {
            for (int i = 0; i < _numOfThreads; i++)
            {
                _threads[i] = new Thread(GetDictionaryWordThreadsProc);
                Memory<string> arrSlice;
                if (i == _numOfThreads - 1)
                {
                    arrSlice = _arrMem.Slice(i * _numOfElements);
                }
                else
                {
                    arrSlice = _arrMem.Slice(i * _numOfElements, _numOfElements);
                }
                _threads[i].Start(new ProcecParam<string> { Memory = arrSlice, ThreadIndex = i });
            }
            Wait();
            var result = new Dictionary<string, int>();
            foreach (var dic in _dictionariesWords)
            {
                foreach (var itemDic in dic)
                {
                    if (!result.TryGetValue(itemDic.Key, out int count))
                    {
                        result.Add(itemDic.Key, itemDic.Value);
                    }
                    else
                    {
                        result[itemDic.Key] += count;
                    }
                }
            }
        }
        private void GetDictionaryWordThreadsProc(object? state)
        {
            ProcecParam<string> param = (ProcecParam<string>)state;
            Span<string> span = param.Memory.Span;
            var dic = _dictionariesWords[param.ThreadIndex];
            for (int i = 0; i < span.Length; i++)
            {
                foreach (var word in span[i].Split(' ', ',', '.', ':', '\t'))
                {
                    if (!dic.TryGetValue(word, out int count))
                    {
                        dic[word] = 1;
                    }
                    else
                    {
                        dic[word] += 1;
                    }
                }
            }
            dic.Remove("");
        }
        private void Wait()
        {
            foreach (var item in _threads)
            {
                item.Join();
            }
        }
    }


}
