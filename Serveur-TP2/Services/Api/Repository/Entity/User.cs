using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.DTO;

namespace Api.Repository.Entity
{
    public class User
    {
        public string Name { get; set; }
        public List<MessageDTO> SentMessages { get; set; } = new List<MessageDTO>();
    }
}
