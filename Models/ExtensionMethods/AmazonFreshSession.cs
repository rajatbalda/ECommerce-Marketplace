
namespace AmazonFresh.Models
{
    public class AmazonFreshSession
    {
        private const string TeamsKey = "myteams";
        private const string CountKey = "teamcount";
        private const string ConfKey = "conf";
        private const string DivKey = "div";

        private ISession session { get; set; }
        public AmazonFreshSession(ISession session)
        {
            this.session = session;
        }

        public void SetMyProducts(List<Product> products)
        {
            session.SetObject(TeamsKey, products);
            session.SetInt32(CountKey, products.Count);
        }
        public List<Product> GetMyProducts() =>
            session.GetObject<List<Product>>(TeamsKey) ?? new List<Product>();
        public int? GetMyTeamCount() => session.GetInt32(CountKey);

        public void SetActiveConf(string activeConf) =>
            session.SetString(ConfKey, activeConf);
        public string GetActiveConf() =>
            session.GetString(ConfKey) ?? string.Empty;

        public void SetActiveDiv(string activeDiv) =>
            session.SetString(DivKey, activeDiv);
        public string GetActiveDiv() =>
            session.GetString(DivKey) ?? string.Empty;

        public void RemoveMyTeams()
        {
            session.Remove(TeamsKey);
            session.Remove(CountKey);
        }
    }
}
