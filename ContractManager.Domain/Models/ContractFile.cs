namespace ContractManager.Domain.Models
{
    public class ContractFile : BaseModel
    {
        public string Name { get; set; } = string.Empty;
        public string FileAddress { get; set; } = string.Empty;
        public DateTime DateAdded { get; set; }

        public int ContractId { get; set; }
        public Contract? Contract { get; set; }
    }
}
