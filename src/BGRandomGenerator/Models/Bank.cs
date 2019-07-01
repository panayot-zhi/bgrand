using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BGRandomGenerator.Models
{
    public class Bank
    {
        public string Name { get; set; }

        [JsonProperty("BIC")]
        public string BussinessIdentifierCode { get; set; }

        [JsonProperty("BAE")]
        public string BankAddressingEntity { get; set; }

        public Bank(string name, string bussinessIdentifierCode, string bankAddressingEntity)
        {
            Name = name;
            BussinessIdentifierCode = bussinessIdentifierCode;
            BankAddressingEntity = bankAddressingEntity;
        }
    }
}
