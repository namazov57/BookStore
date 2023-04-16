using BookStore.DataModels;
using BookStore.Helpers;
using BookStore.Infrastructure;
using BookStore.StableModels;

namespace BookStore
{
    internal class Program
    {
        static void Main(string[] args)
        {

            GenericStore<Author> authors = new GenericStore<Author>();
            GenericStore<BookStructure> bookStructures = new GenericStore<BookStructure>();
            Menu m;

            m = Helper.ReadEnum<Menu>("Siyahidan secin: ");
            Console.WriteLine(m);

        }
    }
}