using DevExpress.Xpo;

namespace ConsoleApplication1 {

    public class Quote : XPObject {
        public Quote()
            : base() {
            // This constructor is used when an object is loaded from a persistent storage.
            // Do not place any code here.
        }
        public Quote(Session session)
            : base(session) {
            // This constructor is used when an object is loaded from a persistent storage.
            // Do not place any code here.
        }
        public override void AfterConstruction() {
            base.AfterConstruction();
            // Place here your initialization code.
        }
        private string _name;
        public string Name {
            get { return _name; }
            set { SetPropertyValue("Name", ref _name, value); }
        }
        [Association("Quote-QuoteItems"), Aggregated]
        public XPCollection<QuoteItem> QuoteItems {
            get {
                return GetCollection<QuoteItem>("QuoteItems");
            }
        }
    }
}