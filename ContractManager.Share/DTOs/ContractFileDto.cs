namespace ContractManager.Share.DTOs
{
    public class ContractFileDto : BaseDto
    {
        public string Name { get; set; } = string.Empty;

        public int ContractId { get; set; }
    }
}
