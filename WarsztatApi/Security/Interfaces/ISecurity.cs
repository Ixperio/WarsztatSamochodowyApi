namespace WarsztatApi.Security.Interfaces
{
    public interface ISecurity
    {
        public string GetTrustString();

        public bool CompareSHA256(string defaultString, string hashedString);

        public string CalculateSHA256(string input);

    }
}
