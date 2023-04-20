using BookStore.Infrastructure;
using BookStore.StableModels;

namespace BookStore.DataModels
{
    [Serializable]
    public class BookStructure:IEquatable<BookStructure>,IEntity
    {
      
        static int counter = 0;
        public BookStructure()
        {
            counter++;
            this.Id = counter;
        }

        public int Id { get; private set; }
        public string Name { get; set; }
        public int AuthorId { get;  set; }
        public Genre Genre { get; set; }
        public int PageCount { get; set; }  
        public decimal Price { get; set; }

        public bool Equals(BookStructure? other)
        {
            if (other == null) return false;
            return this.Id == other.Id;
        }

        public override string ToString()
        {
            return $" {Name} \n Muellifin ID: {AuthorId}.\n Janr: {Genre}.\n*" +
                $"\n Seyfe sayi: {PageCount}.\n Qoymeti: {Price}";
        }
    }
}
