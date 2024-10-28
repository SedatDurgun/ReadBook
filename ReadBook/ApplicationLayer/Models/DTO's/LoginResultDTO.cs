using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Models.DTO_s
{
    public class LoginResultDTO
    {
        public bool IsManager { get; set; }
        public bool IsUser { get; set; }
        public bool HasUser { get; set; }
    }
}
