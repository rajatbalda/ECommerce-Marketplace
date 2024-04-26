namespace AmazonFresh.Models
{
    public class AmazonFreshCookies
    {
            private const string TeamsKey = "myteams";
            private const string Delimiter = "-";

            private IRequestCookieCollection requestCookies { get; set; }
            private IResponseCookies responseCookies { get; set; }
            public AmazonFreshCookies(IRequestCookieCollection cookies)
            {
                requestCookies = cookies;
                responseCookies = null!;
            }
            public AmazonFreshCookies(IResponseCookies cookies)
            {
                responseCookies = cookies;
                requestCookies = null!;
            }

            public void SetMyTeamIds(List<Product> myteams)
            {
                List<string> ids = myteams.Select(t => t.ProductID.ToString()).ToList();
                string idsString = String.Join(Delimiter, ids);
                CookieOptions options = new CookieOptions { Expires = DateTime.Now.AddDays(30) };
                RemoveMyTeamIds();     // delete old cookie first
                responseCookies.Append(TeamsKey, idsString, options);
            }

            public string[] GetMyTeamIds()
            {
                string cookie = requestCookies[TeamsKey] ?? string.Empty;
                if (string.IsNullOrEmpty(cookie))
                    return Array.Empty<string>();   // empty string array
                else
                    return cookie.Split(Delimiter);
            }

            public void RemoveMyTeamIds()
            {
                responseCookies.Delete(TeamsKey);
            }
        }
}
