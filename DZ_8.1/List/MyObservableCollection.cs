using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DZ_5.Generic.MyObservableCollection<T>;

namespace DZ_5.Generic
{
    internal class MyObservableCollection<T> : MyList<T>, IMyList<T>, IMyList, IMyCollection<T>, IMyCollection, IMyEnumerable<T>, IMyEnumerable
    {
        //public delegate void EventLogAction(string message);
        //public event EventLogAction EventLog;
        public Action<string> AddLogAction;
        
        public override void Add(T inItem)
        {
            base.Add(inItem);
        }
        public void Add(T inItem, Action<string> addLogAction)
        {
            base.Add(inItem);
        }
    }
}
