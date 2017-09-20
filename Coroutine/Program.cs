using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;

namespace Coroutine
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("main thread: " + Thread.CurrentThread.ManagedThreadId);
            CoroutineManager.Instance.StartCoroutine(SelfCoroutine());
            Console.ReadKey();
        }
        static IEnumerator SelfCoroutine()
        {
            Console.WriteLine("Self coroutine begin at time : " + DateTime.Now.ToString("HH:mm:ss.fff")+" at thread: "+Thread.CurrentThread.ManagedThreadId);

            yield return new CoroutineWaitForSeconds(5);

            Console.WriteLine("Self coroutine begin at time : " + DateTime.Now.ToString("HH:mm:ss.fff") + " at thread: " + Thread.CurrentThread.ManagedThreadId);
        }
    }
}
