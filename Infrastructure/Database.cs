using BookStore.DataModels;

namespace BookStore.Infrastructure
{
    [Serializable]
    public class Database
    {
        public GenericStore<Author> Authors { get; set; }
        public GenericStore<BookStructure> bookStructures { get; set; }
    }
}
