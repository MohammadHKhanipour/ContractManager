namespace ContractManager.Framework.Adapter
{
    public interface IBaseAdapter<Model, Dto> where Model : BaseModel where Dto : BaseDto
    {
        public Model GetModel(Dto dto);
        public Dto GetDto(Model model);
        public IEnumerable<Model> GetModels(List<Dto> dtos);
        public IEnumerable<Dto> GetDtos(List<Model> models);
    }
}
