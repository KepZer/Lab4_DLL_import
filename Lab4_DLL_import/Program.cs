using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Runtime.InteropServices;

namespace Lab4_DLL_import
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,,] array = new int[2, 3, 4];
            try
            {
                Console.WriteLine(DynamicLoad(array));
                Console.WriteLine(StaticLoad("easy"));
            }
            catch (InvalidCastException e)
            {
                Console.WriteLine(e);
            }
            Console.ReadLine();
        }
        public static int DynamicLoad(Array array)
        {
            var assembly = Assembly.Load("ArrayLibrary");
            Object obj = assembly.CreateInstance("ArrayParity");
            var type = assembly.GetType("ArrayParity");
            var mInfo = type.GetMethod("CalcParity");
            return (int)mInfo.Invoke(obj, new object[] { array });
        }
        public static string StaticLoad(string str)
        {
            var revObj = new ReverseString();
            return revObj.Reverse(str);
        }
    }
}
