using System;
using System.Threading;
using System.Threading.Tasks;

namespace ServerCore
{ 
    class Program
    {
        static object _lock = new object();
        static SpinLock _lock2 = new SpinLock();

        class Reward
        {

        }

        // RWLock ReaderWriteLock
        static ReaderWriterLockSlim _lock3 = new ReaderWriterLockSlim();

        static Reward GetRewardById(int id)
        {
            _lock3.EnterReadLock();

            _lock3.ExitReadLock();
            return null;
        }

        static void AddReward(Reward reward)
        {
            _lock3.EnterReadLock();

            _lock3.ExitReadLock();

            lock (_lock)
            {

            }
        }

        static void Main(string[] args)
        {
            lock (_lock)
            {

            }

            bool lockTaken = false;
            try
            {
                _lock2.Enter(ref lockTaken);
            }
            finally
            {
                if (lockTaken)
                    _lock2.Exit();
            }
        }
    }
}