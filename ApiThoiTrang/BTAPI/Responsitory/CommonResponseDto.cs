using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Responsitory
{
    public class CommonResponseDto
    {
        public CommonEnum.ResponseCodeStatus Code { get; set; }

        public string ErrorCode { get; set; }
        public string Message { get; set; }
        public object ReturnValue { get; set; }

        public CommonResponseDto()
        {
            Code = CommonEnum.ResponseCodeStatus.ThatBai;
            ErrorCode = "";
            Message = "Có lỗi xảy ra";
        }
    }
}