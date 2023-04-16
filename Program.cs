using BookStore.DataModels;
using BookStore.Helpers;
using BookStore.Infrastructure;
using BookStore.StableModels;

namespace BookStore
{
    internal class Program
    {
        static GenericStore<Author> authors = new GenericStore<Author>();
        static GenericStore<BookStructure> bookStructures = new GenericStore<BookStructure>();
        static void Main(string[] args)
        {
            authors.Add(new Author { Name = "Cingiz Abdulayev" });
            authors.Add(new Author { Name = "Aqil Veliyev" });
            authors.Add(new Author { Name = "Vuqar Abilov" });

            bookStructures.Add(new BookStructure { AuthorId = 1, Name = "Qorxu" });
            bookStructures.Add(new BookStructure { AuthorId = 2, Name = "Detektiv" });
            bookStructures.Add(new BookStructure { AuthorId = 3, Name = "Klassik" });

            Menu m;

            int selectedId;
            Author selectedAuthor;
            BookStructure selectedBookstructure;

        l1:
            m = Helper.ReadEnum<Menu>("Siyahidan secin: ");
            Console.WriteLine(m);


            switch (m)

            {
                case Menu.AuthorGetAll:
                    if (authors.Count==0)
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
                    l5:
                    if (bookStructures.Count==0)
                    {
                        Console.WriteLine("Siyahi bosdur Muellif elave edin...");
                        goto case Menu.BookStructureAdd;
                    }
                  GetAllBookStructures(true);
                    Console.WriteLine("Menyuya qayitmaq ucun her hansi duymeni sixin...");  
                    Console.ReadKey();
                    Console.Clear();
                    GetAllBookStructures(true);
                    goto l5;
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

                    selectedBookstructure= new BookStructure();
                    selectedBookstructure.Name = Helper.ReadString("Kitabin adini daxil edin: ");
                    GetAllAuthors(false);
                l6:
                    selectedId = Helper.ReadInt("Muellifin idsini siyahidan secin..");
                    selectedAuthor= authors.GetById(selectedId);
                    if (selectedAuthor == null)
                    {
                        goto l6;
                    }
                    selectedBookstructure.AuthorId = selectedId;
                    selectedBookstructure.Genre = Helper.ReadEnum<Genre>("Janiri siyahidan secin: ");
                    selectedBookstructure.PageCount = Helper.ReadUInt16("Kitab nece seyfe olacaq: ");
                    selectedBookstructure.Price = Helper.ReadDecimal("Kitabin qiymetini daxil edin: ");

                bookStructures.Add(selectedBookstructure);
                   
                    Console.ReadKey();
                    Console.Clear();
                    goto case Menu.BookStructureGetAll;

                case Menu.BookStructureEdit:
                    break;
                case Menu.BookSturctureRemove:
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
                var author= authors.GetById(item.AuthorId);
                Console.WriteLine($"{author.Name}-{item}");
            }
        }
    }
}
