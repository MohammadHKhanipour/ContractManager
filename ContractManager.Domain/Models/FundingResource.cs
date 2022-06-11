namespace ContractManager.Domain.Models
{
    public class FundingResource : BaseModel
    {
        public decimal Fund { get; set; }
        public string Ownership { get; set; } = string.Empty;

        public int ContractId { get; set; }
        public Contract? Contract { get; set; }
    }
}
