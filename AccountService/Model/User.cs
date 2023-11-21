﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AccountService.Model
{
    public class User
    {
       
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int Id { get; set; }
            public string UserName { get; set; }

            public string Password { get; set; }
            public string? Role { get; set; }



        
    }
}
