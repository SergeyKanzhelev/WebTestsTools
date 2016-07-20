namespace WebTestsTools.Results
{
    public class Certificate
    {
        public bool Error { get; internal set; }
        public string ExpirationDate { get; set; }
        public bool ExpiresIn10Days { get; set; }
        public object IssuerName { get; internal set; }
        public string Subject { get; internal set; }
    }
}