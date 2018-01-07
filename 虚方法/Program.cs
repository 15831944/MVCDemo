using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 虚方法
{
    public class Person
    {
        public virtual void  SayHi()
        {
            Console.Write("我是地球人");
        }
    }

    public class USA:Person
    {
        //public override void SayHi()
        //{
        //    Console.Write("我是美国人");
        //}
    }

    class Program
    {
        static void Main(string[] args)
        {
            Person p = new USA();
            p.SayHi();
            Console.ReadKey();
        }
    }
}
