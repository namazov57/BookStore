using BookStore.StableModels;

namespace BookStore.DataModels
{
    public class Author:IEquatable<Author>
    {
        static int counter = 0;
        public Author() 
        {
            counter++;
            this.Id= counter;
        }

        public int Id { get; private set; }
        public string Name { get;  set; }
        public string Surname { get; set; }
           
        

        public bool Equals(Author? other)
        {
           if(other == null) return false;
            return this.Id == other.Id;
        }

        public override string ToString()
        {
            return $"{Id}. {Name}.{Surname}";
        }
       
    }
}
