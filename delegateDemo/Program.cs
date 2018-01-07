using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace delegateDemo
{
     delegate int AddDel(int a , int b);
    class Program
    {
        
        static void Main(string[] args)
        {
            #region MyRegion 委托
            AddDel del = new AddDel(Addfuc);
            del += new Program().Add2;
            int res = del(3, 4);
            Console.WriteLine(res); 
            #endregion

            #region 泛型委托
            Func<int, int, int> funcDemo = new Func<int, int, int>(Addfuc);//Addfuc;
            int rs = funcDemo(1, 2);
            Console.WriteLine(rs);
            
            #endregion

            #region 匿名方法
            Func<int, int, int> anonymityfunc =
                delegate(int a, int b) { return a + b; };
            #endregion

            #region lambda语句
            Func<int, int, int> lambdafunc = (a, b) => { return a + b; };
            #endregion

            #region lambda表达式
            Func<int, int, int> lambdaexpressionfunc = (a, b) => a+b;
            #endregion

            #region 案列
            List<string> strlist = new List<string> { "1", "2", "3" };
            IEnumerable<string> ls = strlist.Where((string a) => a == "1");
            foreach (var item in ls)
            {
                Console.WriteLine(item.ToString());
            }
            Console.ReadKey();
            #endregion
        }

        static int Addfuc(int a , int b)
        {
            return a+b;
        }

        public int Add2(int a, int b)
        {
            return a + b + 1;
        }

        public void test<T>()
        {
            
        }
    }
}
