namespace ContractManager.Share.DTOs
{
    public class ContractDto : BaseDto
    {
        public string Number { get; set; } = string.Empty;
        public string Subject { get; set; } = string.Empty;
        public ContractType ContractType { get; set; }
        public ContractStatus ContractStatus { get; set; }
        public PaymentType PaymentType { get; set; }
        public decimal Cost { get; set; }
        public string ContractSide { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime DueDate { get; set; }
        public decimal FinalCost { get; set; }
    }
}
