﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FCourse.Models
{

    [Table("Level")]
    public class Level
    {
        [Key]
        [StringLength(10)]
        private string Id { get; set; }
        [StringLength(20)]
        private string Name { get; set; }
    }
}