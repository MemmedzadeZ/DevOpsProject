using IdentityService.Core.Abstruct;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityService.Entitiess
{
    public class User:IdentityUser,IEntitiy
    {

        public int Id { get; set; }
    }
}
