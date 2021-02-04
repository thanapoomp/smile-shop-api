﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmileShopAPI.Models
{
    [Table("Role", Schema = "auth")]
    public class Role : IId
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(20)]
        public string Name { get; set; }
    }
}