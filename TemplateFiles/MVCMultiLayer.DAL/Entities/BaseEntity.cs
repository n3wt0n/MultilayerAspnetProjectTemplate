using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace $safeprojectname$.Entities
{
    public class BaseEntity
    {
        [Key]
        public int ID { get; set; }

        [MaxLength(50)]
        public string UserCreation { get; set; }

        public DateTime DateCreation { get; set; }

        [MaxLength(50)]
        public string UserLastChange { get; set; }

        public DateTime? DateLastChange { get; set; }

        [DefaultValue(false)]
        public bool IsDeleted { get; set; }
    }
}
