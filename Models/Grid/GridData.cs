﻿namespace AmazonFresh.Models
{
	public abstract class GridData
	{
		// model binding properties
		public int PageNumber { get; set; } = 1;
		public int PageSize { get; set; } = 2;
		public string SortDirection { get; set; } = "asc";
		public string SortField { get; set; } = string.Empty;

		// general purpose methods for paging and sorting
		public int GetTotalPages(int count) => (count + PageSize - 1) / PageSize;

		public void SetSortAndDirection(string newSortField, GridData current)
		{
			// set sort field
			SortField = newSortField;

            // set sort direction based on comparison of new and current sort field. if 
            // sort field is same as current, toggle between ascending and descending. 
            // if it's different, should always be ascending.
            if (current.SortField.EqualsNoCase(newSortField))
                SortDirection = current.SortDirection == "asc" ? "desc" : "asc";
            else
                SortDirection = "asc";
        }

		// make copy of self
		public virtual GridData Clone() => (GridData)MemberwiseClone();

		// return dictionary of route segments for URL building
		public virtual Dictionary<string, string> ToDictionary() =>
			new Dictionary<string, string> {
				{ nameof(PageNumber), PageNumber.ToString() },
				{ nameof(PageSize), PageSize.ToString() },
				{ nameof(SortField), SortField },
				{ nameof(SortDirection), SortDirection },
			};
	}
}
