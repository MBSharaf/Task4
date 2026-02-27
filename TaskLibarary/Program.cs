namespace TaskLibarary
{
    public class Book 
    {   
        public String title;
        public String Auther;
        public Guid ISBN;
        public bool IsAvailable;

        public Book(string title, string auther, Guid iSBN)
        {
            this.title = title;
            Auther = auther;
            ISBN = iSBN;
            IsAvailable = true;
        }
        public void Books()
        {
            Book book1 = new Book("Book1", "Auther1", Guid.NewGuid());
        }
    }

    
    class Library
    {
        List<Book> Books = new List<Book>();

        public void AddBook()
        {
            Console.WriteLine("add your book details");
            Console.WriteLine("add your book Name");
            string Booktitle = Console.ReadLine();

            Console.WriteLine("add your Aurther");
            string AutherName = Console.ReadLine();

            new Book(Booktitle, AutherName, Guid.NewGuid());
            Books.Add(new Book(Booktitle, AutherName, Guid.NewGuid()));

            Console.WriteLine("Book added successfully");
        }
        public void SearchBook(string title, string auther, Guid iSBN)
        {
            for (int i = 0; i < Books.Count; i++) {
                Book book = Books[i];
                if (book.title == title || book.Auther == auther || book.ISBN == iSBN)
                {
                    Console.WriteLine($"Book found: {book.title} by {book.Auther}");
                    return;
                }
            }

        }
        public void BorrowBook()
        {
            Console.WriteLine("Enter the book title or author:");
            string searchInput = Console.ReadLine();

            for (int i = 0; i < Books.Count; i++)
            {
                Book book = Books[i];  
                if (book.title == searchInput || book.Auther == searchInput)
                {
                 Console.WriteLine($"Book found: {book.title} by {book.Auther}");
                    if (book.IsAvailable)
                    {
                        book.IsAvailable = false;  
                        Console.WriteLine($"You have successfully borrowed '{book.title}'.");
                    }
                    else
                    {
                        Console.WriteLine("Sorry, this book is currently not available.");
                    }
                    break;
                }
            }
        }
        public void ReturnBook()
        {
            Console.WriteLine("Enter the book title or author:");
            string searchInput = Console.ReadLine();

            bool found = false;

            foreach (var book in Books)
            {
                if (book.title == searchInput || book.Auther == searchInput)
                {
                    found = true;

                    if (!book.IsAvailable) 
                    {
                        book.IsAvailable = true;
                        Console.WriteLine($"Book '{book.title}' has been returned successfully.");
                    }
                    else
                    {
                        Console.WriteLine("This book was not borrowed.");
                    }

                    break; 
                }
            }

            if (!found)
            {
                Console.WriteLine("Book not found in the library.");
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Library library = new Library();
            bool exit = false;

            Console.WriteLine("Welcome to the Library!");

            while (!exit)
            {
                Console.WriteLine("\nChoose an option:");
                Console.WriteLine("1 - Add Book");
                Console.WriteLine("2 - Search Book");
                Console.WriteLine("3 - Borrow Book");
                Console.WriteLine("4 - Return Book");
                Console.WriteLine("5 - Exit");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        library.AddBook();
                        break;

                    case "2":
                        Console.WriteLine("Enter the book title or author to search:");
                        string searchInput = Console.ReadLine();
                        library.SearchBook(searchInput, searchInput, Guid.NewGuid()); // مجرد مثال لتوافق signature الحالي
                        break;

                    case "3":
                        library.BorrowBook();
                        break;

                    case "4":
                        library.ReturnBook();
                        break;

                    case "5":
                        exit = true;
                        Console.WriteLine("Exiting the library. Goodbye!");
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }
            }
            }
    }
}
