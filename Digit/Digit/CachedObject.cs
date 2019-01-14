using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digit
{
    public class CachedObject<T>
    {
        readonly Func<T> creator;
        readonly bool lazy;

        T instance;

        Func<T> getter;
        readonly object getterLock = new object();
        public CachedObject(Func<T> creator, bool lazy = true)
        {
            this.creator = creator;
            this.lazy = lazy;
            Invalidate();
        }

        public void Invalidate()
        {
            lock(getterLock)
            {
                instance = default(T);
                getter = NewInstanceReturner;
                if(!lazy)
                {
                    Get(); //tip off generation here
                }
            }
        }

        private T NewInstanceReturner()
        {
            instance = creator();
            getter = InstanceReturner;
            return instance;
        }

        private T InstanceReturner()
        {
            return instance;
        }

        public T Get()
        {
            lock(getterLock)
            {
                return getter();
            }
        }

        public static implicit operator T(CachedObject<T> me)
        {
            return me.Get();
        }
    }
}
