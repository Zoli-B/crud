namespace crud
{
    class App
    {
        static void Main(string[] args)
        {
            Crud crud = new Crud();
           
            //Menü
            bool ervenyes = false;

            while (!ervenyes) {
                Console.WriteLine("Válassz a lehetőségek közül. 1 Create, 2 Read, 3 Update, 4 Delete, 5 Dummy Json létrehozása");
                int gomb = Convert.ToInt32(Console.ReadLine());
                
                switch (gomb)
                {
                    case 1:
                        crud.Create();
                        Main(args);   
                        ervenyes = true;
                        break;

                    case 2:
                        crud.Read();
                        Main(args);
                        ervenyes = true;
                        break;

                    case 3:
                        crud.Update();
                        Main(args);
                        ervenyes = true;
                        break;

                    case 4:
                        crud.Delete();
                        Main(args);
                        ervenyes = true;
                        break;

                    case 5:
                        cj.MakeJson();
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
