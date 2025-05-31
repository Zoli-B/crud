namespace crud
{
    class App
    {
        static void Main(string[] args)
        {
            Crud crud = new Crud();
            CreateJson cj = new CreateJson();
           
            //Menü
            bool ervenyes = false;

            while (!ervenyes) {
                Console.WriteLine("Válassz a lehetőségek közül. 1 Create, 2 Read, 3 Update, 4 Delete, 5 Dummy Json létrehozása");
                int gomb = Convert.ToInt32(Console.ReadLine());
                
                switch (gomb)
                {
                    case 1:
                        TryCatchHelper.Run(() => crud.Create());
                        Main(args);   
                        ervenyes = true;
                        break;

                    case 2:
                        TryCatchHelper.Run(() => crud.Read());
                        Main(args);
                        ervenyes = true;
                        break;

                    case 3:
                        TryCatchHelper.Run(() => crud.Update());
                        Main(args);
                        ervenyes = true;
                        break;

                    case 4:
                        TryCatchHelper.Run(() => crud.Delete());
                        Main(args);
                        ervenyes = true;
                        break;

                    case 5:
                        TryCatchHelper.Run(() => cj.MakeJson());
                        Main(args);
                        ervenyes = true;
                        break;

                    default:
                        Console.WriteLine("Nincs ilyen lehetőség");
                        Main(args);
                        break;
                }
            }

        }
    }
}
