using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LocAndAsync
{
    public class Locks
    {
        private static SemaphoreSlim semaphore = new SemaphoreSlim(1);

        public static string FuncA(string Msg)
        {
            semaphore.Wait();
            //slow long code...
            Console.WriteLine("Slow Code Started");
            Thread.Sleep(3000);
            Console.WriteLine("Slow Code Done");
            semaphore.Release();

            return Msg;
        }
        public static string FuncB(string Msg)
        {
            semaphore.Wait();
            semaphore.Release();
            return Msg;
        }
    }
    public class useExampleAsyncLock
    {
        public static void LockExample()
        {
            object Data = "my data";
            Thread t;

            t = new Thread(new ParameterizedThreadStart(SomeMethod1));
            t.SetApartmentState(ApartmentState.STA);
            t.Start(Data);

            Thread.Sleep(200);

            t = new Thread(new ParameterizedThreadStart(SomeMethod2));
            t.SetApartmentState(ApartmentState.STA);
            t.Start(Data);

            Thread.Sleep(5000);
            Console.WriteLine("Done, please press any key to continue");
            Console.ReadKey();
        }

        private static void SomeMethod1(object obj)
        {
            Console.WriteLine(Locks.FuncA("SomeMethod1"));
        }
        private static void SomeMethod2(object obj)
        {
            Console.WriteLine(Locks.FuncB("SomeMethod2"));
        }
    }
    class SyncLocks
    {
        public static Object thisLock = new Object();
        public void func()
        {
            lock (thisLock)
            {
                //Slow code...
                Thread.Sleep(3000);
                
            }
        }
    }
}
