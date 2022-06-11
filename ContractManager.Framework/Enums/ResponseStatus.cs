using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ContractManager.Framework.Enums
{
    public enum ResponseStatus
    {
        [EnumMember(Value = "خطا در انجام عملیات")]
        Fail,

        [EnumMember(Value = "عملیات با موفقیت انجام شد")]
        Success,

        [EnumMember(Value = "موردی یافت نشد")]
        NotFound,
    }
}
