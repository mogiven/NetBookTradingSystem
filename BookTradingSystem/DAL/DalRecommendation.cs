using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BookTradingSystem.Model;
using RecommendationEngineAssembly;

namespace BookTradingSystem.DAL
{
    public class DalRecommendation
    {
        public static List<BookTradingSystem.Model.BookInfo> GetRecommendations(int userId)
        {
            // 创建RecommendationEngine实例
            RecommendationEngine engine = new RecommendationEngine();

            // 创建C++/CLI程序集的BookInfo实例列表
            List<RecommendationEngineAssembly.BookInfo> userPurchaseRequests = new List<RecommendationEngineAssembly.BookInfo>();
            List<RecommendationEngineAssembly.BookInfo> availableBooks = new List<RecommendationEngineAssembly.BookInfo>();

            // 使用你的C#项目中的BookInfo数据填充C++/CLI程序集的BookInfo实例列表
            foreach (BookTradingSystem.Model.BookInfo book in DalBookInfo.GetDataList(userId)) // 获取用户的求购信息
            {
                RecommendationEngineAssembly.BookInfo cppBook = new RecommendationEngineAssembly.BookInfo
                {
                    BookInfoId = book.BookInfoId,
                    UserId = book.UserId,
                    Summary = book.Summary,
                    Contents = book.Contents,
                    TransactionType = book.TransactionType,
                    ServerDate = book.ServerDate
                };
                userPurchaseRequests.Add(cppBook);
            }

            foreach (BookTradingSystem.Model.BookInfo book in DalBookInfo.GetDataList()) // 获取所有可供推荐的书籍信息
            {
                RecommendationEngineAssembly.BookInfo cppBook = new RecommendationEngineAssembly.BookInfo
                {
                    BookInfoId = book.BookInfoId,
                    UserId = book.UserId,
                    Summary = book.Summary,
                    Contents = book.Contents,
                    TransactionType = book.TransactionType,
                    ServerDate = book.ServerDate
                };
                availableBooks.Add(cppBook);
            }

            // 获取推荐的C++/CLI程序集的BookInfo实例列表
            List<RecommendationEngineAssembly.BookInfo> cppRecommendations = engine.GetRecommendations(userPurchaseRequests, availableBooks);

            // 创建C#项目的BookInfo实例列表，并使用推荐的C++/CLI程序集的BookInfo数据填充该列表
            List<BookTradingSystem.Model.BookInfo> recommendations = new List<BookTradingSystem.Model.BookInfo>();
            foreach (RecommendationEngineAssembly.BookInfo cppBook in cppRecommendations)
            {
                if (cppBook.TransactionType == (int)BookInfoTransactionType.Sale) // 仅筛选出售类型的书籍
                {
                    BookTradingSystem.Model.BookInfo book = new BookTradingSystem.Model.BookInfo
                    {
                        BookInfoId = cppBook.BookInfoId,
                        UserId = cppBook.UserId,
                        Summary = cppBook.Summary,
                        Contents = cppBook.Contents,
                        TransactionType = cppBook.TransactionType,
                        ServerDate = cppBook.ServerDate
                    };
                    recommendations.Add(book);
                }
            }

            // 返回推荐的C#项目的BookInfo实例列表
            return recommendations;
        }
    }
}
