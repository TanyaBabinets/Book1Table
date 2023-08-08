using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.Linq;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//Использовать EF(Code First)

//Создать приложение - библиотека
//Сущность - книга:
//// Книга (id, название,категория,издательство, количество страниц,автор)
//Предусмотреть следующие возможности 
//добавление книги
//удаление
//изменение
//поиск: по автору, по названию, по категории, по издательству
namespace Book1Table.Model
{
    public class BookContext: DbContext
    {
        public BookContext()
           // : base(ConfigurationManager.ConnectionStrings["DbBooks"].ConnectionString)
          : base ("DbBooks")
        { }


        public DbSet<BookInfo> Books { get; set; }

        public void AddBook(BookInfo temp)
        {
            Books.Add(temp);
            SaveChanges();
        }
        public void DeleteBook(BookInfo temp)
        {
            
            if (temp != null)
            {
                temp = Books.Find(temp.Id);
                Books.Remove(temp);
                SaveChanges();
            }

        }
        
        public List<BookInfo> GetInfo()
        {
            string commandText = "SELECT * FROM BookTable";
            List<BookInfo> bookList = new List<BookInfo>();
            SqlConnection connection = null;
            var command = connection.CreateCommand();
            command.CommandText = commandText;
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                bookList.Add(new BookInfo()
                {
                    Id = (int)reader["Id"],
                    name = (string)reader["name"],
                    author = (string)reader["author"],
                    genre = (string)reader["genre"],
                    pages = (int)reader["pages"]

                });
            }

            reader.Close();


            return bookList;
        }
    }
}
