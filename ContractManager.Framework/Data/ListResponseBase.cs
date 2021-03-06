namespace ContractManager.Framework.Data
{
    public class ListResponseBase<T>
    {
        public List<T>? Result { get; set; }
        public ResponseStatus Status { get; set; }

        public static ListResponseBase<T> Success(List<T> result)
            => new ListResponseBase<T> { Result = result, Status = ResponseStatus.Success };

        public static ListResponseBase<T> Failure(ResponseStatus status)
            => new ListResponseBase<T> { Status = status };
    }
}
