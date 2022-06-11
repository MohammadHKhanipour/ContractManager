namespace ContractManager.Domain.Models
{
    public class Documentation : BaseModel
    {
        public string Name { get; set; } = string.Empty;

        public int ContractId { get; set; }
        public Contract? Contract { get; set; }
    }
}
