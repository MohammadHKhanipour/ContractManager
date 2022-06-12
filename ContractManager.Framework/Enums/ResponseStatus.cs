namespace ContractManager.Framework.Enums
{
    public enum ResponseStatus
    {
        [EnumMember(Value = "Operation Failed")]
        Fail,

        [EnumMember(Value = "Operation Successful")]
        Success,

        [EnumMember(Value = "Not Found")]
        NotFound,
    }
}
