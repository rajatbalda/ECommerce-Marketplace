using System.Text.Json.Serialization;

namespace AmazonFresh.Models
{
	public class ProductGridData : GridData
	{
		// set initial sort field in constructor
		public ProductGridData() => SortField = nameof(Product.Name);

        // sort flags
        [JsonIgnore]
        public bool IsSortByPriceLowToHigh =>
        SortField.EqualsNoCase(nameof(Product.Price)) && SortDirection == "asc";

        [JsonIgnore]
        public bool IsSortByPriceHighToLow =>
            SortField.EqualsNoCase(nameof(Product.Price)) && SortDirection == "desc";

        [JsonIgnore]
        public bool IsSoldCount =>
            SortField.EqualsNoCase(nameof(Product.SoldCount)) && SortDirection == "desc";
    }
}

