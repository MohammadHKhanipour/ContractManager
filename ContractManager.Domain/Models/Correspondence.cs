namespace ContractManager.Domain.Models
{
    public class Correspondence : BaseModel
    {
        public string CorrespondenceContent { get; set; } = string.Empty;
        public CorrespondenceType CorrespondenceType { get; set; }

        public int ContractId { get; set; }
        public Contract? Contract { get; set; }
    }
}
