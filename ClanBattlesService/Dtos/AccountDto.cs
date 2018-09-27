using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ClanBattlesService.Dtos
{
    public class AccountDto
    {
        [Required(AllowEmptyStrings = false)]
        [StringLength(200)]
        public string username { get; set; }

        [Required(AllowEmptyStrings = false)]
        [StringLength(200)]
        public string password { get; set; }

    }
}