namespace ContractManager.Framework.Data
{
    public class BaseModel
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
