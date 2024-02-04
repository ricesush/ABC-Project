namespace ABC.Shared.Models
{
    public class CustomerBasicInfo
    {
        public string Id { get; set; } = String.Empty;
        public string FirstName { get; set; } = String.Empty;
        public string LastName { get; set; }= String.Empty;
        public int ContactNumber { get; set; }= 0;
    }
}