using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Day3
{
    public class Book
    {
        public string ISBN { get; set; }
        public string Title { get; set; }
        public string[] Authors { get; set; }
        public DateTime PublicationDate { get; set; }
        public decimal Price { get; set; }

        public Book(string _ISBN, string _Title,DateTime _PublicationDate, decimal _Price)
        {
            ISBN = _ISBN;
            Title= _Title;
            PublicationDate = _PublicationDate;
            Price = _Price;
        }

        public override string ToString()
        {
            return $"ISBN: {ISBN}, Title: {Title}, Authors: {string.Join(", ", Authors)}, Publication Date: {PublicationDate.ToShortDateString()}, Price: {Price:C}";
        }
    }

    public class BookFunctions
    {
        public static string GetTitle(Book b)
        {
            return b.Title;
        }

        public static string GetAuthors(Book B)
        {
            throw new NotImplementedException();
        }

        public static string GetPrice(Book B)
        {
            throw new NotImplementedException();
        }
    }

    public class LibraryEngine
    {
        public static void ProcessBooks(List<Book> bList, Func<Book, string> bookfunc)
        {
            foreach (Book B in bList)
            {
                Console.WriteLine(bookfunc(B)); 
            }
        }
    }
}
