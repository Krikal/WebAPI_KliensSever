using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi_common.Models
{
    public class Client
    {
        public long Id { get; set; }

        public string ClientName { get; set; }

        public string CarType { get; set; }

        public string CarPlate { get; set; }

        public string IssueDeatils { get; set; }

        public override string ToString()
        {
            return $"{ClientName} - {CarType} - {CarPlate} - {IssueDeatils}";
        }
    }
}
