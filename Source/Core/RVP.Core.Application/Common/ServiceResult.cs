using RVP.Core.Application.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RVP.Core.Application.Common
{
    public class ServiceResult<T>
    {
        public bool Success { get; private set; }
        public T? Data { get; private set; }
        public ServiceErrorCode ErrorCode { get; private set; }

        public static ServiceResult<T> Ok(T data) =>
            new() { Success = true, Data = data, ErrorCode = ServiceErrorCode.None };

        public static ServiceResult<T> Fail(ServiceErrorCode code) =>
            new() { Success = false, ErrorCode = code };
    }
}
