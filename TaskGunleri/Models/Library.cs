using System;
using System.Collections.Generic;
using System.Text;
using TaskGunleri.Interfaces;
using Utils.Exceptions;


namespace TaskGunleri.Models
{
    class Library : IEntity
    {
        public int BookLimit = 2;

        private List<Book> _books;

        public int Id { get; }

        public Library()
        {
            _books = new List<Book>();
        }

        public void AddBook(Book book)
        {
            if (_books.Exists(e=> e.Name==book.Name && e.IsDeleted==false))
            {
                throw new AlreadyExistsException("Bu kitab movcuddur");
                return;
            }
            if (_books.Count > BookLimit)
            {
                throw new CapacityLimitException("Limiti kecdiz");
            }

            _books.Add(book);

        }

        public Book GetBookById(int? id)
        {
            if (id == null)
            {
                throw new NullReferenceException("id gonderin");
            }

            Book book = _books.Find(b => b.Id == id && b.IsDeleted == false);

            if (book == null)
            {
                throw new NotFoundException("Null");
            }

            return book;
        }

        public List<Book> GetAllBooks()
        {
            List<Book> bookCopy = new List<Book>();

             bookCopy.AddRange(_books);

            return bookCopy;
        }

        public void DeleteBookById(int? id)
        {
            if (id==null)
            {
                throw new NullReferenceException("id gonderin");
                return;
            }

            Book book = _books.Find(b => b.Id == id && b.IsDeleted == false);

            if (book == null)
            {
                throw new NotFoundException("bele kitab yoxdur");
                return;
            }

            book.IsDeleted = true;

        }

        public void EditBookName(int? id,string name)
        {
            if (id == null)
            {
                throw new NullReferenceException("id gonder");
                return;
            }

            Book book = _books.Find(b => b.Id == id);

            if (book == null)
            {
                throw new NotFoundException("bele kitab yoxdur");
                return;
            }

            book.Name = name;
        }

        public List<Book> FilterByPageCount(int minPageCount,int maxPageCount )
        {
            return _books.FindAll(b => b.PageCount >= minPageCount && b.PageCount <= maxPageCount && b.IsDeleted==false);
        }
    }
}
