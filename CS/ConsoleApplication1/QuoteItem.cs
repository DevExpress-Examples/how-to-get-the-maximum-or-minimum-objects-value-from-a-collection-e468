using DevExpress.Xpo;

namespace ConsoleApplication1 {

    public class QuoteItem : XPObject {
        public QuoteItem()
            : base() {
            // This constructor is used when an object is loaded from a persistent storage.
            // Do not place any code here.
        }
        public QuoteItem(Session session)
            : base(session) {
            // This constructor is used when an object is loaded from a persistent storage.
            // Do not place any code here.
        }
        public override void AfterConstruction() {
            base.AfterConstruction();
            // Place here your initialization code.
        }
        private int _sequence;
        public int Sequence {
            get { return _sequence; }
            set { SetPropertyValue("Sequence", ref _sequence, value); }
        }
        private Quote _quote;
        [Association("Quote-QuoteItems")]
        public Quote Quote {
            get { return _quote; }
            set { SetPropertyValue("Quote", ref _quote, value); }
        }
    }
}