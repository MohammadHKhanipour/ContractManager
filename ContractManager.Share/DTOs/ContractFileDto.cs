namespace ContractManager.Share.DTOs
{
    public class ContractFileDto : BaseDto
    {
        public string Name { get; set; } = string.Empty;
        public string FileAddress { get; set; } = string.Empty;
        public DateTime DateAdded { get; set; }

        public int ContractId { get; set; }
    }
}
