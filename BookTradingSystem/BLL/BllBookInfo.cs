using System;
using BookTradingSystem.Model;
using BookTradingSystem.DAL;
using System.Collections.Generic;

namespace BookTradingSystem.BLL
{
    public static class BllBookInfo
    {
        public static int Insert(BookInfo data)
        {
            return DalBookInfo.Insert(data);
        }

        public static int Update(BookInfo data)
        {
            return DalBookInfo.Update(data);
        }

        public static int Delete(int id)
        {
            return DalBookInfo.Delete(id);
        }

        public static BookInfo GetData(int id)
        {
            return DalBookInfo.GetData(id);
        }

        public static List<BookInfo> GetDataList()
        {
            return DalBookInfo.GetDataList();
        }
    }
}
