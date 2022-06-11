namespace ContractManager.Share.DTOs
{
    public class FundingResourceDto : BaseDto
    {
        public decimal Fund { get; set; }
        public string Ownership { get; set; } = string.Empty;

        public int ContractId { get; set; }
    }
}
