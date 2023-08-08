using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book1Table.Model
{
    public class BookInfo
    {
            public int Id { get; set; }
            public string name { get; set; }
            public string author { get; set; }
            public string genre { get; set; }
            public int pages { get; set; }


            public override string ToString()
            {
                return $"{Id}.{author}. {name} жанр: {genre}, {pages} стр.";

            }
        }
}
