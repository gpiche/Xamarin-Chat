using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.DTO;
using Microsoft.AspNetCore.Identity;

namespace Api.Repository.Entity
{
    public class User : IdentityUser
    {
        public bool IsAdmin { get; set; }
        public string DataEventRecordsRole { get; set; }
        public string SecuredFilesRole { get; set; }
        public string Password { get; set; }
    }
}
