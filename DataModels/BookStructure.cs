using BookStore.StableModels;

namespace BookStore.DataModels
{
    public class BookStructure:IEquatable<BookStructure>
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
            return $"Id: {Id}./n Name: {Name}./n AuthorId: {AuthorId}./n Genre: {Genre}./n*" +
                $" PageCount: {PageCount}./n Price: {Price}";
        }
    }
}
