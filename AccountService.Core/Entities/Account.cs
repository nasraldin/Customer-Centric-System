namespace AccountService.Core.Entities
{
    public class Account : BaseEntity
    {
        public int Number { get; set; }
        public string Type { get; set; }
        public float Balance { get; set; }
        public int CustomerId { get; set; }
    }
}
