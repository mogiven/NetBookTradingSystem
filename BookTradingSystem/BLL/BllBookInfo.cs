using System;
using BookTradingSystem.Model;
using BookTradingSystem.DAL;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookTradingSystem.BLL
{
    public static class BllBookInfo
    {
        public static int InsertAsync(BookInfo data)
        {
            Task<int> insertTask = DalBookInfo.InsertAsync(data);
            insertTask.Wait();
            return insertTask.Result;
        }

        public static int UpdateAsync(BookInfo data)
        {
            Task<int> updateTask = DalBookInfo.UpdateAsync(data);
            updateTask.Wait();
            return updateTask.Result;
        }

        public static int DeleteAsync(int id)
        {
            Task<int> deleteTask = DalBookInfo.DeleteAsync(id);
            deleteTask.Wait();
            return deleteTask.Result;
        }

        public static BookInfo GetDataAsync(int id)
        {
            Task<BookInfo> getDataTask = DalBookInfo.GetDataAsync(id);
            getDataTask.Wait();
            return getDataTask.Result;
        }

        public static List<BookInfo> GetDataListAsync()
        {
            Task<List<BookInfo>> getDataListTask = DalBookInfo.GetDataListAsync();
            getDataListTask.Wait();
            return getDataListTask.Result;
        }

        public static List<BookInfo> GetDataListAsync(int user_id)
        {
            Task<List<BookInfo>> getDataListTask = DalBookInfo.GetDataListAsync(user_id);
            getDataListTask.Wait();
            return getDataListTask.Result;
        }
    }
}
