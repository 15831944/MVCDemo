using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
namespace ThreadDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //ParameterizedThreadStart
            ThreadStart thdstart =  delegate() {
                while (true)
                {
                    Console.WriteLine(DateTime.Now);
                    Thread.Sleep(100);
                }
            };

            Thread thread = new Thread(thdstart);
            //线程默认是前台线程，一个进程退出标志：所有前台线程都结束之后
            thread.IsBackground = true;
            //后台线程不会阻塞进程的退出
            thread.Start();
            thread.Join(5000);//等待thread线程执行完成
            //thread.Abort();//直接终止线程
            Console.WriteLine(  "主线程");
            //Console.ReadKey();
        }
    }
}
