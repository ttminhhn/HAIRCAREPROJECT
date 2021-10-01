using Newtonsoft.Json;
using HAIRCARE.CORE.Base;
using System.Collections.Generic;

namespace HAIRCARE.WEBAPI.Models
{
    public class BaseResponseModel
    {
        [JsonProperty("success")]
        public bool ExecuteSuccess { get; set; }

        [JsonProperty("message")]
        public string ExecuteMessage { get; set; }

        [JsonProperty("code")]
        public string ExecuteCode { get; set; }

        [JsonProperty("data")]
        public Dictionary<string, object> Data { get; set; }

        public BaseResponseModel()
        {
            ExecuteSuccess = CommonConstants.EXECUTE_SUCCESS;
            ExecuteMessage = "It works";
            ExecuteCode = "200";
            Data = new Dictionary<string, object>();
        }

        public void Add(string propertyName, object value)
        {
            if (value != null)
            {
                Data.Add(propertyName, value);
            }
        }
    }
}
