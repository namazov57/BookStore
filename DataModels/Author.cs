﻿using BookStore.Infrastructure;
using BookStore.StableModels;

namespace BookStore.DataModels
{
    [Serializable]
    public class Author : IEquatable<Author>, IEntity
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
            return $"Id nomresi:{Id}.\nMuellifin adi: {Name}.";
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Author);
        }
    }
}
