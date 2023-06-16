#include "pch.h"

#include "RecommendationEngineAssembly.h"

namespace RecommendationEngineAssembly {
    List<BookInfo^>^ RecommendationEngine::GetRecommendations(List<BookInfo^>^ userPurchaseRequests, List<BookInfo^>^ availableBooks)
    {
        List<BookInfo^>^ recommendations = gcnew List<BookInfo^>();

        // 对于用户的每一条求购信息
        for each (BookInfo ^ request in userPurchaseRequests)
        {
            // 对于所有可供推荐的书籍信息
            for each (BookInfo ^ book in availableBooks)
            {
                // 如果书籍的Summary或Contents包含求购信息的Summary，或者求购信息的Contents包含书籍的Summary，则将这本书加入推荐列表
                if ((StringContains(book->Summary, request->Summary) || StringContains(book->Contents, request->Summary) || StringContains(request->Contents, book->Summary))
                    && !recommendations->Contains(book))
                {
                    recommendations->Add(book);
                }
            }
        }

        return recommendations;
    }

    bool RecommendationEngine::StringContains(String^ str, String^ substr)
    {
        return str->IndexOf(substr, StringComparison::CurrentCultureIgnoreCase) >= 0;
    }
}