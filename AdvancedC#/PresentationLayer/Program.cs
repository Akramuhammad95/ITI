using BusinessLogicLayer;
using BusinessLogicLayer.models;

class Program
{
    static void Main()
    {
        AutherManager manager = new AutherManager();

        SeedRealData(manager);

        while (true)
        {
            Console.Clear();
            Console.WriteLine("===== Authors System =====");
            Console.WriteLine("1. View All");
            Console.WriteLine("2. Add");
            Console.WriteLine("3. Update");
            Console.WriteLine("4. Delete");
            Console.WriteLine("5. Exit");
            Console.Write("Choose: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1": ViewAll(manager); break;
                case "2": Add(manager); break;
                case "3": Update(manager); break;
                case "4": Delete(manager); break;
                case "5": return;
                default: Console.WriteLine("Invalid"); break;
            }

            Console.WriteLine("\nPress any key...");
            Console.ReadKey();
        }
    }

    static void ViewAll(AutherManager manager)
    {
        var authors = manager.GetAllAuthers();

        Console.WriteLine("\n--- Authors ---");

        foreach (var a in authors)
        {
            Console.WriteLine($"{a.Id} | {a.FirstName} {a.LastName} | {a.Phone}");
        }
    }

    static void Add(AutherManager manager)
    {
        try
        {
            Authers a = new Authers();

            Console.Write("First Name: ");
            a.FirstName = Console.ReadLine();

            Console.Write("Last Name: ");
            a.LastName = Console.ReadLine();

            Console.Write("Phone: ");
            a.Phone = Console.ReadLine();

            Console.Write("Email: ");
            a.Email = Console.ReadLine();

            Console.Write("Address: ");
            a.Address = Console.ReadLine();

            int result = manager.AddAuther(a);

            Console.WriteLine(result > 0 ? "Added ✔" : "Failed ❌");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    static void Update(AutherManager manager)
    {
        try
        {
            Authers a = new Authers();

            Console.Write("Enter ID: ");
            a.Id = int.Parse(Console.ReadLine());

            Console.Write("New First Name: ");
            a.FirstName = Console.ReadLine();

            Console.Write("New Last Name: ");
            a.LastName = Console.ReadLine();

            Console.Write("New Phone: ");
            a.Phone = Console.ReadLine();

            Console.Write("New Email: ");
            a.Email = Console.ReadLine();

            Console.Write("New Address: ");
            a.Address = Console.ReadLine();

            int result = manager.UpdateAuther(a);

            Console.WriteLine(result > 0 ? "Updated ✔" : "Failed ❌");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    static void Delete(AutherManager manager)
    {
        Console.Write("Enter ID: ");
        int id = int.Parse(Console.ReadLine());

        int result = manager.DeleteAuther(id);

        Console.WriteLine(result > 0 ? "Deleted ✔" : "Failed ❌");
    }

    static void SeedRealData(AutherManager manager)
    {
        var existing = manager.GetAllAuthers();

        if (existing.Count > 0)
            return;

        var authors = new List<Authers>
    {
        new Authers { FirstName="Ahmed", LastName="Hassan", Phone="01012345678", Email="ahmed.hassan@gmail.com", Address="Cairo" },
        new Authers { FirstName="Mohamed", LastName="Ali", Phone="01123456789", Email="mohamed.ali@yahoo.com", Address="Giza" },
        new Authers { FirstName="Mahmoud", LastName="Ibrahim", Phone="01234567890", Email="mahmoud.ibrahim@gmail.com", Address="Alexandria" },
        new Authers { FirstName="Mostafa", LastName="Saeed", Phone="01098765432", Email="mostafa.saeed@hotmail.com", Address="Mansoura" },
        new Authers { FirstName="Omar", LastName="Khaled", Phone="01111112222", Email="omar.khaled@gmail.com", Address="Tanta" },

        new Authers { FirstName="Youssef", LastName="Adel", Phone="01222223333", Email="youssef.adel@yahoo.com", Address="Zagazig" },
        new Authers { FirstName="Karim", LastName="Nabil", Phone="01033334444", Email="karim.nabil@gmail.com", Address="Cairo" },
        new Authers { FirstName="Amr", LastName="Fathy", Phone="01144445555", Email="amr.fathy@gmail.com", Address="Giza" },
        new Authers { FirstName="Hossam", LastName="Magdy", Phone="01255556666", Email="hossam.magdy@yahoo.com", Address="Alexandria" },
        new Authers { FirstName="Tamer", LastName="Gamal", Phone="01066667777", Email="tamer.gamal@gmail.com", Address="Mansoura" },

        new Authers { FirstName="Sherif", LastName="Yassin", Phone="01177778888", Email="sherif.yassin@gmail.com", Address="Cairo" },
        new Authers { FirstName="Ayman", LastName="Samir", Phone="01288889999", Email="ayman.samir@yahoo.com", Address="Giza" },
        new Authers { FirstName="Wael", LastName="Hegazy", Phone="01099990000", Email="wael.hegazy@gmail.com", Address="Alexandria" },
        new Authers { FirstName="Khaled", LastName="Hamdy", Phone="01100001111", Email="khaled.hamdy@gmail.com", Address="Tanta" },
        new Authers { FirstName="Sameh", LastName="Lotfy", Phone="01211112222", Email="sameh.lotfy@yahoo.com", Address="Mansoura" },

        new Authers { FirstName="Ehab", LastName="Rashad", Phone="01022223333", Email="ehab.rashad@gmail.com", Address="Cairo" },
        new Authers { FirstName="Nader", LastName="Fouad", Phone="01133334444", Email="nader.fouad@yahoo.com", Address="Giza" },
        new Authers { FirstName="Hany", LastName="Shawky", Phone="01244445555", Email="hany.shawky@gmail.com", Address="Alexandria" },
        new Authers { FirstName="Ashraf", LastName="Zaki", Phone="01055556666", Email="ashraf.zaki@gmail.com", Address="Zagazig" },
        new Authers { FirstName="Adel", LastName="Farouk", Phone="01166667777", Email="adel.farouk@yahoo.com", Address="Tanta" },

        new Authers { FirstName="Ibrahim", LastName="Salem", Phone="01277778888", Email="ibrahim.salem@gmail.com", Address="Cairo" },
        new Authers { FirstName="Sami", LastName="Hussein", Phone="01088889999", Email="sami.hussein@yahoo.com", Address="Giza" },
        new Authers { FirstName="Fadi", LastName="Nasser", Phone="01199990000", Email="fadi.nasser@gmail.com", Address="Alexandria" },
        new Authers { FirstName="Raed", LastName="Sabry", Phone="01200001111", Email="raed.sabry@yahoo.com", Address="Mansoura" },
        new Authers { FirstName="Bassem", LastName="Kamal", Phone="01011112222", Email="bassem.kamal@gmail.com", Address="Tanta" },

        // كمل بنفس النمط لحد 50
        new Authers { FirstName="Ali", LastName="Reda", Phone="01122223334", Email="ali.reda@gmail.com", Address="Cairo" },
        new Authers { FirstName="Ziad", LastName="Hossam", Phone="01233334445", Email="ziad.hossam@yahoo.com", Address="Giza" },
        new Authers { FirstName="Mina", LastName="George", Phone="01044445556", Email="mina.george@gmail.com", Address="Alexandria" },
        new Authers { FirstName="Peter", LastName="Nagy", Phone="01155556667", Email="peter.nagy@gmail.com", Address="Cairo" },
        new Authers { FirstName="Mark", LastName="Fares", Phone="01266667778", Email="mark.fares@yahoo.com", Address="Giza" },

        new Authers { FirstName="Samy", LastName="Boulos", Phone="01077778889", Email="samy.boulos@gmail.com", Address="Alexandria" },
        new Authers { FirstName="Ramy", LastName="Tawfik", Phone="01188889990", Email="ramy.tawfik@yahoo.com", Address="Mansoura" },
        new Authers { FirstName="Fady", LastName="Karam", Phone="01299990001", Email="fady.karam@gmail.com", Address="Tanta" },
        new Authers { FirstName="Nagy", LastName="Aziz", Phone="01000001112", Email="nagy.aziz@yahoo.com", Address="Cairo" },
        new Authers { FirstName="Hesham", LastName="Saad", Phone="01111112223", Email="hesham.saad@gmail.com", Address="Giza" },

        new Authers { FirstName="Tarek", LastName="Mounir", Phone="01222223334", Email="tarek.mounir@yahoo.com", Address="Alexandria" },
        new Authers { FirstName="Walid", LastName="Saber", Phone="01033334445", Email="walid.saber@gmail.com", Address="Cairo" },
        new Authers { FirstName="Emad", LastName="Zaher", Phone="01144445556", Email="emad.zaher@yahoo.com", Address="Giza" },
        new Authers { FirstName="Gaber", LastName="Lotfy", Phone="01255556667", Email="gaber.lotfy@gmail.com", Address="Tanta" },
        new Authers { FirstName="Fouad", LastName="Hanna", Phone="01066667778", Email="fouad.hanna@yahoo.com", Address="Alexandria" },

        new Authers { FirstName="Nabil", LastName="Shaker", Phone="01177778889", Email="nabil.shaker@gmail.com", Address="Cairo" },
        new Authers { FirstName="Magdy", LastName="Salib", Phone="01288889990", Email="magdy.salib@yahoo.com", Address="Giza" },
        new Authers { FirstName="Hatem", LastName="Rizk", Phone="01099990001", Email="hatem.rizk@gmail.com", Address="Alexandria" },
        new Authers { FirstName="Sabry", LastName="Fahmy", Phone="01100001112", Email="sabry.fahmy@yahoo.com", Address="Mansoura" },
        new Authers { FirstName="Lotfy", LastName="Gerges", Phone="01211112223", Email="lotfy.gerges@gmail.com", Address="Tanta" }
    };

        foreach (var a in authors)
        {
            manager.AddAuther(a);
        }

        Console.WriteLine(" Real Data Added");
    }
}