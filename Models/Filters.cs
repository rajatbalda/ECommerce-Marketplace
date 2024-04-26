namespace AmazonFresh.Models
{
    public class Filters
    {
        public Filters(string filterstring)
        {
            FilterString = filterstring ?? "all-all-all";
            string[] filters = FilterString.Split('-');
            CategoryId = filters[0];
            PriceId = filters[1];
            SpecialId = filters[2];
        }
        public string FilterString { get; }
        public string CategoryId { get; }
        public string PriceId { get; }
        public string SpecialId { get; }


        public bool HasCategory => CategoryId.ToLower() != "all";
        public bool HasPrice => PriceId.ToLower() != "all";
        public bool HasSpecial => SpecialId.ToLower() != "all";
    }
}
