using System;
using BookTradingSystem.Model;
using BookTradingSystem.DAL;
using System.Collections.Generic;

namespace BookTradingSystem.BLL
{
    public static class BllMessage
    {
        public static int Insert(Message data)
        {
            return DalMessage.Insert(data);
        }

        public static int Update(Message data)
        {
            return DalMessage.Update(data);
        }

        public static int Delete(int id)
        {
            return DalMessage.Delete(id);
        }

        public static Message GetData(int id)
        {
            return DalMessage.GetData(id);
        }

        public static List<Message> GetDataList()
        {
            return DalMessage.GetDataList();
        }
    }
}
