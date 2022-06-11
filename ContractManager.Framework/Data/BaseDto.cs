namespace ContractManager.Framework.Data
{
    public class BaseDto
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
