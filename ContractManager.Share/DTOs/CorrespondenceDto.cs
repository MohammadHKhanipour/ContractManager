namespace ContractManager.Share.DTOs
{
    public class CorrespondenceDto : BaseDto
    {
        public string Content { get; set; } = string.Empty;
        public CorrespondenceType CorrespondenceType { get; set; }

        public int ContractId { get; set; }
    }
}
