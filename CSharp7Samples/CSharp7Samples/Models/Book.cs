using CSharp7Samples.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp7Samples.Models
{
    public class Book : BindableBase
    {      
        public int BookId { get; set; }
        private string _publisher;

        public string Publisher
        {
            get => _publisher;
            set => _publisher = value;
        }

        private string _title;
        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        //public void Deconstruct(out int bookId, out string title, out string publisher)
        //{
        //    bookId = BookId;
        //    title = Title;
        //    publisher = Publisher;
        //}

        //public void Deconstruct(out string title, out string publisher)
        //{
        //    title = Title;
        //    publisher = Publisher;
        //}
    }

    public static class BookExtensions
    {
        public static void Deconstruct(this Book book, out int bookId, out string title, out string publisher)
        {
            bookId = book.BookId;
            title = book.Title;
            publisher = book.Publisher;
        }
    }
}
