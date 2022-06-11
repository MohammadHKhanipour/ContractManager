namespace ContractManager.Share.DTOs
{
    public class CorrespondenceDto : BaseDto
    {
        public string CorrespondenceContent { get; set; } = string.Empty;
        public CorrespondenceType CorrespondenceType { get; set; }

        public int ContractId { get; set; }
    }
}
