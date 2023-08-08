using Book1Table.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Book1Table
{
    public partial class Form1 : Form
    {
        BookContext db = null;
        public Form1()
        {
            InitializeComponent();
            using (db = new BookContext())
            {
              listBox1INFO.DataSource = db.Books.ToList();
            }
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (db = new BookContext())
            {
                string menu = comboBox1.SelectedItem.ToString();
             
                BookInfo temp=null;
                switch (menu)
                {
                    case "Добавить книгу":
                        temp= new BookInfo();
                        temp.author = textBox1.Text;
                        temp.name = textBox2.Text;
                        temp.genre = textBox3.Text;
                        temp.pages= int.Parse(textBox4.Text );

                        db.AddBook(temp);
                        break;
                    case "Удалить книгу":
                        db.DeleteBook(GetBook());

                        break;
                    case "Внести изменения":

                        temp = GetBook();
                        temp = db.Books.Find(temp.Id);
                        temp.author = textBox1.Text;
                        temp.name = textBox2.Text;
                        temp.genre = textBox3.Text;
                        temp.pages = int.Parse(textBox4.Text);
                      db.SaveChanges(); 
                 
                        break;
                }
                listBox1INFO.DataSource = db.Books.ToList();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (db = new BookContext())
            {
                listBox1INFO.DataSource = db.Books.ToList();
            }
        }

        private void button2_Click(object sender, EventArgs e)//clear all
        {
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
            textBox3.Text = string.Empty;
            textBox4.Text = string.Empty;

        }
        public BookInfo GetBook()
        {
            BookInfo temp = (BookInfo)listBox1INFO.SelectedItem;
            
            return temp;
        }

        private void listBox1INFO_SelectedIndexChanged(object sender, EventArgs e)
        {          
            BookInfo temp = GetBook();
            //textBox1.Text = string.Empty;
            //textBox2.Text = string.Empty;
            //textBox3.Text = string.Empty;
            //textBox4.Text = string.Empty;

            textBox1.Text = temp.author;
            textBox2.Text = temp.name;
            textBox3.Text = temp.genre;
            textBox4.Text = temp.pages.ToString();
           // db.SaveChanges();
        }

       
    }
}
