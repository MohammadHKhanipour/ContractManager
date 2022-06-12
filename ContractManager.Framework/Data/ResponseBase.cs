namespace ContractManager.Framework.Data
{
    public class ResponseBase<T>
    {
        public T? Result { get; set; }
        public ResponseStatus Status { get; set; }

        public static ResponseBase<T> Success(T result)
            => new ResponseBase<T> { Result = result, Status = ResponseStatus.Success };

        public static ResponseBase<T> Failure(ResponseStatus status)
            => new ResponseBase<T> { Status = status };
    }
}
