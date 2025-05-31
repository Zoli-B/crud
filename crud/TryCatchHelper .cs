using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crud
{
    public class TryCatchHelper
    {
        // retrun nélküli delegálás
        public static void Run(Action action)
        {
            try
            {
                action();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Hiba történt: " + ex.Message);
            }
        }

        //return delegálás
        public static T Run<T>(Func<T> func)
        {
            try
            {
                return func();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Hiba történt: " + ex.Message);
                return default;
            }
        }
    }
   
}


