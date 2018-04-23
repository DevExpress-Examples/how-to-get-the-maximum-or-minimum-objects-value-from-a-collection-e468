using System;
using System.Diagnostics;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using DevExpress.Xpo.DB;

namespace ConsoleApplication1 {
    class Program {
        static void Main(string[] args) {
            Quote q = Session.DefaultSession.FindObject<Quote>(new OperandProperty("Oid") == 1) as Quote;
            if (q == null) {
                q = new Quote();
                for (int i = 0; i < 5; i++) {
                    QuoteItem qi = new QuoteItem();
                    qi.Sequence = i;
                    q.QuoteItems.Add(qi);
                    qi.Save();
                }
                q.Save();
            }
            int maxValue = Convert.ToInt32(
                Session.DefaultSession.Evaluate<QuoteItem>(
                    CriteriaOperator.Parse("Max(Sequence)"),
                    new OperandProperty("Quote.Oid") == q.Oid
                )
            );
            Debug.Assert(maxValue == 4, "Error");

            XPCollection<QuoteItem> items = new XPCollection<QuoteItem>(
                new OperandProperty("Quote.Oid") == q.Oid,
                new SortProperty("Sequence", SortingDirection.Descending)
            );
            items.TopReturnedObjects = 1;
            if (items.Count != 0) {
                QuoteItem maxQuoteItemObject = items[0] as QuoteItem;
                Debug.Assert(maxQuoteItemObject.Sequence == 4, "Error");
            }
        }
    }
}
