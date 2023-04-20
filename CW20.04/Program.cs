








/*// Создайте приложение для учёта книг. Необходимо хранить следующую информацию:

// Название книги
// ФИО автора
// Жанр книги
// Год выпуска

//Для хранения книг используйте класс LinkedList<T>.

//Приложение должно предоставлять такую функциональность:

// Добавление книг (по одной, массивом, списком)
// Вывод всего списка книг
// Вывод книги по номеру в списке
// Удаление книг
// Изменение информации о книгах (через индекс)
// Поиск книг по параметрам
// Вставка книги в начало списка
// Вставка книги в конец списка
// Вставка книги в определенную позицию
// Удаление книги из начала списка
// Удаление книги из конца списка
//Удаление книги из определенной позиции
// Создать меню/подменю пользователя*/
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks.Dataflow;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CW20._04
{

    class Book
    {
        public  string Name { get; set; }
        public string AuthorName { get; set; }
        public string Genre { get; set; }
        public int year { get; set; }


        public Book() { ChangeInfoBook(); }
        public Book(string name, string authorName, string genre, int year)
        {
            Name = name;
            AuthorName = authorName;
            Genre = genre;
            this.year = year;
        }
        public void ChangeInfoBook()
        {
            Console.WriteLine("Changing info : ");
            Console.WriteLine("Enter a  name");
            Name = Console.ReadLine();
            Console.WriteLine("Enter a  genre");
            Genre = Console.ReadLine();
            Console.WriteLine("Enter a  author");
            AuthorName = Console.ReadLine();
            Console.WriteLine("Enter a new year");
            year = int.Parse(Console.ReadLine());
        }
     
        public void OutputNameBookNameAutor()
        {
            Console.WriteLine("Name : "+ Name + "\nAuthor : " + AuthorName);
        }
        public void OutpullFullInfoBook()
        {
            Console.WriteLine("Name : " + Name + "\nAuthor : " + AuthorName);
            Console.WriteLine("Year : " + year + "\nGenre : " + Genre);
        }
    }





   class Biblioteka
    {
        public LinkedList<Book> books;
        public Biblioteka() { books = new LinkedList<Book>(); }
        public Biblioteka(Book book)  {  books = new LinkedList<Book>(); books.AddLast(book);     }
        public Biblioteka(Book[]book) { books = new LinkedList<Book>(book);  }
        public Biblioteka(List<Book> book) { books = new LinkedList<Book>(book); }



        public void OutputFullInfoBook()
        {
            Console.WriteLine("Full  Book List : \n");
            int count = 1;
            foreach(var book in books)
            {
                Console.Write(count++ + " ");
                book.OutpullFullInfoBook();
                Console.WriteLine();
            }
        }
        public void OutputNameOfBook()
        {
            Console.WriteLine("Full  Book List : \n");
            int count = 1;
            foreach (var book in books)
            {
                Console.Write(count++ + " ");
                book.OutputNameBookNameAutor();
                Console.WriteLine();
            }
        }
        public void OutpoutBookByNumber(int number)
        {
            int count = 0;
            foreach (var book in books)
            {
                count++;
                if(count==number+1) book.OutpullFullInfoBook();
            }
        }

        public void AddBookInEndOfList(Book book)
        {
            books.AddLast(book);
        }
        public void AddBookInBeginOfList(Book book)
        {
            books.AddFirst(book);
        }
        private LinkedListNode<Book> FindBook(int Position)
        {
            LinkedListNode<Book> node = books.First;
            int count = 0;
            foreach(var el in books)
            {
                count++;
                
                if(count==Position)
                {
                    node = node.Next; break;
                }
            }
            return node;
        }

        public void DeleteBookFromList()
        {   List<Book> booksTemp = new List<Book>(books);
            Console.Clear();
            OutputNameOfBook();
            Console.WriteLine("Choose a book : ");
            int choice = int.Parse(Console.ReadLine());
            
            if (choice <= books.Count)
                booksTemp.Remove(booksTemp[choice - 1]);
            else Console.WriteLine("Incorrect choice");
            books.Clear();
            books= new LinkedList<Book>(booksTemp);
        }
        public void ChangeInfoBook()
        {
            OutputNameOfBook();
            Console.WriteLine("Choose a book : ");
            int choice = int.Parse(Console.ReadLine());
            int count = 0;
            foreach (var book in books)
            {
                count++;
                if (count == choice - 1)
                {
                    book.OutpullFullInfoBook();
                    book.ChangeInfoBook();
                    break;
                }
            }
        }

        public void AddBookInSimePosition(int position , Book obj)
        {
            books.AddAfter(FindBook(position) , obj);

        }
        public void SearchBook()
        {
            Console.WriteLine("Select a search term :");
            Console.WriteLine("1-NameBook" + "\n2-Author" + "\n3-Year" + "\n4-Genre");
            int choice = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter a key Word:");
            switch (choice) 
            {
                case 1:

                    {
                        int count = 0;
                        string keyWord = Console.ReadLine(); 
                    foreach(var book in books) 
                        {
                            if (book.Name == keyWord)
                            {
                                book.OutpullFullInfoBook();
                                count++;
                            }
                        }
                        if (count == 0) Console.WriteLine("Not found ");
                    }
                    break;

                case 2:
                    {
                        int count = 0;
                        string keyWord = Console.ReadLine();
                        foreach (var book in books)
                        {
                            if (book.AuthorName == keyWord)
                            {
                                book.OutpullFullInfoBook();
                                count++;
                            }
                            if (count == 0) Console.WriteLine("Not found ");
                        }

                    }
                    break;

                case 3:
                    {
                        int count = 0;
                        int keyWord = int.Parse(Console.ReadLine());
                        foreach (var book in books)
                        {
                            if (book.year == keyWord)
                            {
                                book.OutpullFullInfoBook();
                                count++;
                            }
                            if (count == 0) Console.WriteLine("Not found ");
                        }
                        
                    }
                    break;
                case 4:
                    {
                        {
                            int count = 0;
                            string keyWord = Console.ReadLine();
                            foreach (var book in books)
                            {
                                if (book.Genre == keyWord)
                                {
                                    book.OutpullFullInfoBook();
                                    count++;
                                }
                            }
                            if (count == books.Count) Console.WriteLine("Not found ");
                        }
                        break;
                    }
                    break;

            }


           
        }


    


    }



    class InterfaceLibrary
    {
        Biblioteka Res = new();
        public InterfaceLibrary(Biblioteka obj) 
        {
            Res = obj;
        }
        public int Menu_Main()
        {
            Console.WriteLine("1.AddBook to Begin of List");
            Console.WriteLine("2.AddBook to End of List");
            Console.WriteLine("3.Show Book By Index");
            Console.WriteLine("4.Delete book by Index");
            Console.WriteLine("5.Change book Info by Index");
            Console.WriteLine("6.Search book by parametrs");
            Console.WriteLine("7.Add book in position");
            Console.WriteLine("8.Add book from start of List ");
            Console.WriteLine("9.Show List of Book  ");
            Console.WriteLine("0 Exit");
            return int.Parse(Console.ReadLine());
        }
        public void Menu_1_1()
        {
            int choice = 0;
            do
            {
                choice = Menu_Main();

                switch (choice)

                {
                        case 1: { Book book = new Book(); Res.AddBookInBeginOfList(book); } break;
                        case 2: { Book book = new Book(); Res.AddBookInEndOfList(book); } break;
                        case 3: {
                            Console.WriteLine("enter number for search : ");
                            int temp = int.Parse(Console.ReadLine());
                            Res.OutpoutBookByNumber(--temp); 
                        } break;
                        case 4: {
                            Res.OutputNameOfBook();
                         
                            Res.DeleteBookFromList();
                        
                        } break;
                        case 5: {
                            Res.ChangeInfoBook();
                        
                        } break;
                        case 6: { Res.SearchBook(); } break;
                        case 7: {
                            Res.OutputNameOfBook();
                            Console.WriteLine("enter number of position for added : ");
                          
                            int position = int.Parse(Console.ReadLine());
                            Console.WriteLine("Enter new Book : ");
                            Book temp = new Book();
                            Res.AddBookInSimePosition(position ,temp  );
                        } break;
                        case 8: {
                            
                            Console.WriteLine("Enter new Book : ");
                            Book temp = new Book();
                            Res.AddBookInBeginOfList(temp);
                        } break;
                    case 9:
                        {
                            Res.OutputFullInfoBook();

                        }
                        break;
    
                        
            }
                

            }while(choice!=0);
        }




    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Book[] booksDefault = new[]{new Book("Anna Karenina", "Leo Tolstoy", "novel", 1900), 
            new Book("Madame Bovary" , "Gustave Flaubert", "novel" , 1934) ,
            new Book("In Search of Lost Time" , "Marcel Proust", "novel" , 1977),
            new Book("1984" , "George Orwell" ,"dystopia" , 1948 ),
            new Book("Homage to Catalonia", "George Orwell" ,"dystopia" ,1938 )};

            Biblioteka biblioteka = new Biblioteka(booksDefault);
            InterfaceLibrary interfaceLibrary = new InterfaceLibrary(biblioteka);
            interfaceLibrary.Menu_1_1(); 
        }
    }
}