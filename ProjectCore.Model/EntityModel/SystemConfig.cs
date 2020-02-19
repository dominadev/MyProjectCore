using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ProjectCore.Model.EntityModel
{
    [Table("SystemConfigs")]
    public class SystemConfig
    {
        [Key]
        public int Id { get; set; }
        [StringLength(20)]
        public string Key { get; set; }
        [StringLength(500)]
        public string Value { get; set; }
        [StringLength(200)]
        public string Description { get; set; }

    }
}
