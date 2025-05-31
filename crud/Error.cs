using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crud
{

    internal class Error
    {
        //JSON exist ellenörzés
        public void CheckJsonExist()
        {
            if (!File.Exists("prod.json"))
            {
                Console.WriteLine("A fájl nem létezik, létrehozok egy új listát.");
                CreateJson createJson = new CreateJson();
                createJson.MakeJson();
            }
        }


    }

}
