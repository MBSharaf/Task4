
namespace TaskLibarry
{
    class Book
    {
        public string title;
        public string author;
        public Guid ISBN;
        public bool isAvailable;

        public Book(string title, string author, Guid iSBN)
        {
            this.title = title;
            this.author = author;
            ISBN = iSBN;
            isAvailable = true;
        }
        void intuial()
        {
            //Account Acc1 = new Account(1, "mohamed", "010", "12345678", 1000);
            Console.WriteLine("enter your book title");
            string title = Console.ReadLine();
            Console.WriteLine("enter your book auther");
            string auther = Console.ReadLine();
            Book book1 = new Book();


        }
    }
    
    
    class library
    {
        //List<string> books = new list<string>();
        public string Booktitle;
        public string Bookauthor;
            
    }


    internal class Program
        {
            static void Main(string[] args)
            {

            }
        }

   
}


