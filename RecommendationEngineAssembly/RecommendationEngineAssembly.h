#pragma once

using namespace System;
using namespace System::Collections::Generic;

namespace RecommendationEngineAssembly {
    public ref class BookInfo
    {
    public:
        int BookInfoId;
        int UserId;
        String^ Summary;
        String^ Contents;
        int TransactionType;
        DateTime ServerDate;
    };

    public ref class RecommendationEngine
    {
    public:
        List<BookInfo^>^ GetRecommendations(List<BookInfo^>^ userPurchaseRequests, List<BookInfo^>^ availableBooks);
    private:
        bool StringContains(String^ str, String^ substr);
    };
}
