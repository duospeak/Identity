using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public static class ErrorCodes
    {
        public const string StatusChangeErrror = "STATUS_CHANGE_ERROR";
        /// <summary>
        /// 给定条件下无法获取到配货单
        /// </summary>
        public const string DistributionIsNull = "DISTRIBUTION_NOT_EXIST";
        public const string StatusNotSupportUpdate = "STATUS_NOT_SUPPORT_UPDATE";
        public const string CannotCancel = "CANNOT_CANCEL";
    }
}
