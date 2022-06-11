namespace ContractManager.Share.DTOs
{
    public class DocumentationDto : BaseDto
    {
        public string Name { get; set; } = string.Empty;

        public int ContractId { get; set; }
    }
}
