using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 抽象类
{
    class Program
    {
        static void Main(string[] args)
        {
            Person t = new Teacher();
            Person d = new Doctor();
            t.SayHi();
            d.SayHi();


        }
    }

    public abstract class MyClass
    {
        public int Age { get; set; }

        //抽象成员不能有任何实现
        public abstract void Func();
    }

    class Myclass1 : MyClass
    {
        public override void Func()
        {
            Console.WriteLine("子类中的方法");
        }
    }

    //抽象父类
    abstract class Person
    {
        public abstract void SayHi();
        public abstract void Standup();
    }
    //实现子类
    class Teacher : Person
    {
        public override void SayHi()
        {
            throw new NotImplementedException();
        }

        public override void Standup()
        {
            throw new NotImplementedException();
        }
    }
    class Doctor : Person
    {
        public override void SayHi()
        {
            throw new NotImplementedException();
        }

        public override void Standup()
        {
            throw new NotImplementedException();
        }
    }
}
