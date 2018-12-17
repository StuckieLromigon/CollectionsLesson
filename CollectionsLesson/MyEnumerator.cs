using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionsLesson
{
    class MyEnumerator<T> : IEnumerator<T>
    {
        private T[] _innerList;
        private int _length;
        private int head = -1;
        public MyEnumerator(T[] list, int length)
        {
            _innerList = list;
            _length = length;
        }

        public T Current
        {
            get
            {
                return _innerList[head];
            }
        }

        object IEnumerator.Current
        {
            get
            {
                return _innerList[head];
            }
        }

        T IEnumerator<T>.Current
        {
            get
            {
                return _innerList[head];
            }
        }

        public bool MoveNext()
        {
            if (head < _length - 1)
            {
                head++;
                return true;
            }
            return false;
        }

        public void Reset()
        {
            head = -1;
        }

        bool IEnumerator.MoveNext()
        {
            if (head < _length - 1)
            {
                head++;
                return true;
            }
            return false;
        }

        void IEnumerator.Reset()
        {
            head = -1;
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~MyEnumerator() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        void IDisposable.Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }

}
