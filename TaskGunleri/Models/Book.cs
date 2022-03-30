using System;
using System.Collections.Generic;
using System.Text;
using TaskGunleri.Interfaces;

namespace TaskGunleri.Models
{
    class Book: IEntity
    {
        private static int _id;
        public string Name { get; set; }
        public string AuthorName { get; set; }
        public int PageCount { get; set; }
        public bool IsDeleted { get; set; }

        public int Id { get; }

        public Book(string name,string authorName,int pageCount)
        {
            _id++;
            Id = _id;
            Name = name;
            AuthorName = authorName;
            PageCount = pageCount;
        }
        public void ShowInfo()
        {
            Console.WriteLine($"Id: {Id}\nName: {Name}\nAuthorName: {AuthorName}\nPageCount: {PageCount}\nIsDeleted: {IsDeleted}");
        }
    }
}
