using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadPoolV2
{
    public class ThreadPoolWorker
    {
        private readonly Action<object> _action;

        public ThreadPoolWorker(Action<object> action)
        {
            _action = action;
        }

        public bool Success { get; private set; } = false;
        public bool Completed { get; private set; } = false;
        public Exception Exception { get; private set; } = null;

        public void Start(object state)
        {
            ThreadPool.QueueUserWorkItem(new WaitCallback(ThreadExecution), state);
        }

        public void Wait()
        {
            while (Completed == false)
            {
                Thread.Sleep(200);
            }

            if (Exception != null)
            {
                throw Exception;
            }
        }

        private void ThreadExecution(object state)
        {
            try
            {
                _action.Invoke(state);
                Success = true;
            }
            catch (Exception ex)
            {
                Exception = ex;
                Success = false;
            }
            finally
            {
                Completed = true;
            }
        }
    }
}
