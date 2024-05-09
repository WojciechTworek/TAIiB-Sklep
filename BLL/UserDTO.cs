using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class UserDTO
    {
        public int Id { get; init; }
        public string Login { get; set; }
        public Type Type { get; set; }
        public bool IsActived { get; set; }
    }
}
