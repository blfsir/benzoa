using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace DAL
{
   public  interface INews
    {
       DataTable GetNewsByID(int newsID);
       int InsertNews(string title, string content);

    }
    class NewsDAL
    {
    }
}
