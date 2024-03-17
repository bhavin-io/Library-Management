using System;
using System.Collections.Generic;

class Book
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int Year { get; set; }

    public Book(string title, string author, int year)
    {
        Title = title;
        Author = author;
        Year = year;
    }
}

class Library
{
    private List<Book> books = new List<Book>();

    public void AddBook(Book book)
    {
        books.Add(book);
        Console.WriteLine("Book added to the library.");
    }

    public void RemoveBook(string title)
    {
        Book bookToRemove = books.Find(b => b.Title == title);
        if (bookToRemove != null)
        {
            books.Remove(bookToRemove);
            Console.WriteLine("Book removed from the library.");
        }
        else
        {
            Console.WriteLine("Book not found in the library.");
        }
    }

    public void SearchBook(string title)
    {
        Book foundBook = books.Find(b => b.Title == title);
        if (foundBook != null)
        {
            Console.WriteLine($"Title: {foundBook.Title}, Author: {foundBook.Author}, Year: {foundBook.Year}");
        }
        else
        {
            Console.WriteLine("Book not found in the library.");
        }
    }

    public void DisplayAllBooks()
    {
        if (books.Count == 0)
        {
            Console.WriteLine("No books in the library.");
        }
        else
        {
            Console.WriteLine("Books in the library:");
            foreach (var book in books)
            {
                Console.WriteLine($"Title: {book.Title}, Author: {book.Author}, Year: {book.Year}");
            }
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Library library = new Library();

        while (true)
        {
            Console.WriteLine("\nLibrary Management System");
            Console.WriteLine("1. Add Book");
            Console.WriteLine("2. Remove Book");
            Console.WriteLine("3. Search Book");
            Console.WriteLine("4. Display All Books");
            Console.WriteLine("5. Exit");
            Console.Write("Enter your choice: ");

            int choice;
            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Invalid choice. Please enter a number between 1 and 5.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    Console.Write("Enter title: ");
                    string title = Console.ReadLine();
                    Console.Write("Enter author: ");
                    string author = Console.ReadLine();
                    Console.Write("Enter year: ");
                    int year;
                    if (!int.TryParse(Console.ReadLine(), out year))
                    {
                        Console.WriteLine("Invalid year. Please enter a valid number.");
                        continue;
                    }
                    library.AddBook(new Book(title, author, year));
                    break;
                case 2:
                    Console.Write("Enter title of the book to remove: ");
                    string titleToRemove = Console.ReadLine();
                    library.RemoveBook(titleToRemove);
                    break;
                case 3:
                    Console.Write("Enter title of the book to search: ");
                    string titleToSearch = Console.ReadLine();
                    library.SearchBook(titleToSearch);
                    break;
                case 4:
                    library.DisplayAllBooks();
                    break;
                case 5:
                    Console.WriteLine("Exiting the program.");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please enter a number between 1 and 5.");
                    break;
            }
        }
    }
}
