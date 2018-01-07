using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 抽象类练习
{
    class Program
    {
        static void Main(string[] args)
        {
            computer dell = new computer();
            Udisk sandisk = new Udisk();
            dell.dev = sandisk;
            dell.PC_Read();
        }

        
    }
    class computer
    {
        public MobileStorage dev { get; set; }

        public void PC_Read()
        {
            dev.Read();
        }
        public void PC_Write()
        {
            dev.Write();
        }
    }



    abstract class MobileStorage
    {
        public abstract void Read();
        public abstract void Write();

    }

    class Udisk : MobileStorage
    {
        public override void Read()
        {
            Console.WriteLine("Udisk Read");
        }

        public override void Write()
        {
            Console.WriteLine("Udisk Write");
        }
    }

    class MobileDisk : MobileStorage
    {
        public override void Read()
        {
            Console.WriteLine("MobileDisk Read");
        }

        public override void Write()
        {
            Console.WriteLine("MobileDisk Write");
        }
    }
}
