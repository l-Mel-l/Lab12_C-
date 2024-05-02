// а) Создание интерфейса "Издательство"
public interface IPublisher{
    string BookTitle { get; set; }
    string Author { get; set; }
}

// б) Создание интерфейса-наследника "Книга"
public interface IBook<T> : IPublisher{
    T PublicationDate { get; set; }
    int PageCount { get; set; }
}

// в) Создание класса, реализующего интерфейс "Книга"
public class Book<T>(string bookTitle, string author, T publicationDate, int pageCount) : IBook<T>{
    public string BookTitle { get; set; } = bookTitle;
    public string Author { get; set; } = author;
    public T PublicationDate { get; set; } = publicationDate;
    public int PageCount { get; set; } = pageCount;

}

// г) Создание интерфейса "Пользователь"
public interface IUser<T>{
    T Login { get; set; }
    string Password { get; set; }
}

// д) Создание класса, реализующего интерфейс "Пользователь"
public class User<T>(T login, string password) : IUser<T>{
    public T Login { get; set; } = login;
    public string Password { get; set; } = password;
}

// е) Создание класса, реализующего интерфейсы "книга" и "Пользователь"
public class ProductUser<T>(string bookTitle, string author, T publicationDate, int pageCount, T login, string password) : IBook<T>, IUser<T>{
    public string BookTitle { get; set; } = bookTitle;
    public string Author { get; set; } = author;
    public T PublicationDate { get; set; } = publicationDate;
    public int PageCount { get; set; } = pageCount;
    public T Login { get; set; } = login;
    public string Password { get; set; } = password;

    public void BuyBook(){
        Console.WriteLine($"{Login} купил книгу '{BookTitle}' от автора: {Author}.");
    }
}
class Program
{
    static void Main(string[] args)
    {
        // Создание экземпляров классов
        // в) Создание двух экземпляров класса "Book"
        Book<String> firstBook = new Book<String> ("Монолог фармацевта","Сяо Мао","11.05.2023",540);
        Book<int> secondBook = new Book<int> ("Фрирен", "Дань Хен", 120520023, 600);

        // д) Создание двух объектов класса "User"
        User<String> user1 = new User<String> ("Mel","qwert");
        User<int> user2 = new User<int> (123456,"12341234");

        // Создание экземпляра класса "ProductUser" и вызов метода BuyBook()
        ProductUser<String> productUser = new ProductUser<String> (firstBook.BookTitle, firstBook.Author, firstBook.PublicationDate,firstBook.PageCount,user1.Login,user1.Password);
        productUser.BuyBook();
       
    }
}
