using System;
using BookTradingSystem.Model;
using BookTradingSystem.DAL;
using System.Collections.Generic;

namespace BookTradingSystem.BLL
{
    public static class BllUser
    {
        public static int Insert(User data)
        {
            return DalUser.Insert(data);
        }

        public static int Update(User data)
        {
            return DalUser.Update(data);
        }

        public static int Delete(int id)
        {
            return DalUser.Delete(id);
        }

        public static User GetData(int id)
        {
            return DalUser.GetData(id);
        }

        public static List<User> GetDataList()
        {
            return DalUser.GetDataList();
        }
    }
}
