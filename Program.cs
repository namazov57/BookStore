using BookStore.DataModels;
using BookStore.Helpers;
using BookStore.Infrastructure;
using BookStore.StableModels;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization.Formatters.Binary;

namespace BookStore
{
    internal class Program
    {
        const string dataFilePath = "database.dat";
        static GenericStore<Author> authors = new GenericStore<Author>();
        static GenericStore<BookStructure> bookStructures = new GenericStore<BookStructure>();


        static void Main(string[] args)
        {
            try
            {
                using (var fs = File.OpenRead(dataFilePath))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    Database db = bf.Deserialize(fs) as Database;
                    if (db != null)
                    {
                        authors = db.Authors;
                        bookStructures = db.bookStructures;
                    }
                }
            }
            catch(Exception) 
            {

            }


            Menu m;
l1:
            int selectedId;
            Author selectedAuthor;
            BookStructure selectedBookstructure;

        
            m = Helper.ReadEnum<Menu>("Siyahidan secin: ");
            


            switch (m)

            {
                
               
            case Menu.AuthorGetAll:
                    if (authors.Count == 0)
                    {
                        Console.WriteLine("Siyahi bosdur Muellif elave edin...");
                        goto case Menu.AuthorAdd;
                    }
                    GetAllAuthors(true);
                    Console.WriteLine("Menuya qayitmaq ucun,her hansi duymeni sixin.");
                    Console.ReadKey();
                    Console.Clear();
                    goto l1;

                case Menu.AuthorGetById:
                    GetAllAuthors(true);
                    selectedId = Helper.ReadInt("Siyahidan Id secin: ");

                    selectedAuthor = authors.GetById(selectedId);

                    Console.WriteLine(selectedAuthor);
                    Console.WriteLine("Menuya qayitmaq ucun,her hansi duymeni sixin.");
                    Console.ReadKey();
                    Console.Clear();
                    goto l1;
                case Menu.AuthorAdd:
                    selectedAuthor = new Author();
                    selectedAuthor.Name = Helper.ReadString("Muellifin adi: ");
                    authors.Add(selectedAuthor);
                    Console.Clear();
                    goto case Menu.AuthorGetAll;
                case Menu.AuthorEdit:
                l2:
                    GetAllAuthors(true);
                    selectedId = Helper.ReadInt("Siyahidan Id secin: ");

                    selectedAuthor = authors.GetById(selectedId);

                    if (selectedAuthor == null)
                    {
                        goto l2;
                    }
                    selectedAuthor.Name = Helper.ReadString("Muellifin yeni adi: ");
                    Console.Clear();
                    goto case Menu.AuthorGetAll;

                case Menu.AuthorRemove:
                l3:
                    GetAllAuthors(true);
                    selectedId = Helper.ReadInt("Siyahidan Id secin: ");

                    selectedAuthor = authors.GetById(selectedId);

                    if (selectedAuthor == null)
                    {
                        goto l3;
                    }
                    authors.Remove(selectedAuthor);
                    Console.Clear();
                    goto case Menu.AuthorGetAll;


                case Menu.BookStructureGetAll:

                    if (bookStructures.Count == 0)
                    {
                        Console.WriteLine("Siyahi bosdur Muellif elave edin...");
                        goto case Menu.BookStructureAdd;
                    }
                    GetAllBookStructures(true);
                    Console.WriteLine("Menyuya qayitmaq ucun her hansi duymeni sixin...");
                    Console.ReadKey();
                    Console.Clear();
                    GetAllBookStructures(true);
                    goto l1;
                case Menu.BookStructureGetById:

                    GetAllBookStructures(true);
                l4:
                    selectedId = Helper.ReadInt("Siyahidan Id secin: ");

                    selectedBookstructure = bookStructures.GetById(selectedId);
                    if (selectedBookstructure == null)
                    {
                        goto l4;
                    }



                    Console.WriteLine(selectedBookstructure);
                    Console.WriteLine("Menuya qayitmaq ucun,her hansi duymeni sixin.");
                    Console.ReadKey();
                    Console.Clear();
                    goto l1;

                case Menu.BookStructureAdd:

                    selectedBookstructure = new BookStructure();
                    GetAllAuthors(false);

                l5:
                    selectedId = Helper.ReadInt("Muellifin idsini siyahidan secin..");
                    selectedAuthor = authors.GetById(selectedId);
                    if (selectedAuthor == null)
                    {
                        goto l5;
                    }
                    selectedBookstructure.AuthorId = selectedId;
                    selectedBookstructure.Genre = Helper.ReadEnum<Genre>("Janiri siyahidan secin: ");
                    selectedBookstructure.PageCount = Helper.ReadUInt16("Kitab nece seyfe olacaq: ");
                    selectedBookstructure.Price = Helper.ReadDecimal("Kitabin qiymetini daxil edin: ");

                    bookStructures.Add(selectedBookstructure);

                    goto case Menu.BookStructureGetAll;

                case Menu.BookStructureEdit:
                l6:
                    GetAllBookStructures(true);
                    selectedId = Helper.ReadInt("Siyahidan id secin: ");
                    selectedBookstructure = bookStructures.GetById(selectedId);
                    if (selectedBookstructure == null)
                    {
                        goto l6;
                    }
                    selectedBookstructure.Name = Helper.ReadString("Kitabin adi: ");
                    GetAllAuthors(false);
                l7:
                    selectedId = Helper.ReadInt("Muellifin idsini siyahidan secin: ");
                    selectedAuthor = authors.GetById(selectedId);
                    if (selectedAuthor == null)
                    {
                        goto l7;
                    }
                    selectedBookstructure.AuthorId = selectedId;
                    Console.Clear();
                    goto case Menu.BookStructureGetAll;


                case Menu.BookSturctureRemove:

                l8:
                    GetAllBookStructures(true);
                    selectedId = Helper.ReadInt("Siyahidan id secin: ");
                    selectedBookstructure = bookStructures.GetById(selectedId);
                    if (selectedBookstructure == null)
                    {
                        goto l8;
                    }
                    bookStructures.Remove(selectedBookstructure);
                    Console.Clear();
                    goto case Menu.BookStructureGetAll;

                case Menu.SaveAndExit:

                    using (FileStream fs = File.OpenWrite(dataFilePath))
                    {
                        Database db = new Database();

                        db.Authors = authors;
                        db.bookStructures = bookStructures;

                        BinaryFormatter bf = new BinaryFormatter();
                        bf.Serialize(fs, db);

                    }
                    break;
                default:
                    break;

            }

        }
        static void GetAllAuthors(bool clearBefore)
        {
            if (clearBefore)
            {
                Console.Clear();
            }
            Console.WriteLine("Muellifler...");
            foreach (var item in authors)
            {
                Console.WriteLine(item);
            }
        }
        static void GetAllBookStructures(bool clearBefore)
        {
            if (clearBefore)
            {
                Console.Clear();
            }
            Console.WriteLine("Kitablar...");
            foreach (var item in bookStructures)
            {
                var author = authors.GetById(item.AuthorId);
                Console.WriteLine($"{author.Name}-{item}");
            }
        }
    }
}
