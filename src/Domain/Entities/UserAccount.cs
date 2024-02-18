namespace Domain.Entities
{
    public class UserAccount
    {
        public Guid Id { get; set; }

        public float Balance { get; set; }

        public string Currency { get; set; } = "AED";
    }
}
