namespace ContractManager.Share.DTOs
{
    public class ShowContractDto
    {
        public int Id { get; set; }
        public string Number { get; set; } = string.Empty;
        public string Subject { get; set; } = string.Empty;
        public ContractType ContractType { get; set; }
        public ContractStatus ContractStatus { get; set; }
        public PaymentType PaymentType { get; set; }
        public decimal Cost { get; set; }
        public string ContractSide { get; set; } = string.Empty;
        public string StartDate { get; set; } = string.Empty;
        public string DueDate { get; set; } = string.Empty;
        public decimal FinalCost { get; set; }
        public int FundingResourcesCount { get; set; }
        public int DocumentationsCount { get; set; }
        public int CorrespondencesCount { get; set; }
    }
}
