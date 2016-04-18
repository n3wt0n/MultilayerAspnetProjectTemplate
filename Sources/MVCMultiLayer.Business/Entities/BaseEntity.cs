using System;
using System.ComponentModel.DataAnnotations;

namespace MVCMultiLayer.Business.Entities
{
    public class BaseEntity
    {        
        public int ID { get; set; }
        
        //[Display(Name = "UserCreation", ResourceType = typeof(EResx.BaseEntity))]
        [MaxLength(50)]
        public string UserCreation { get; set; }

        //[Display(Name = "DateCreation", ResourceType = typeof(EResx.BaseEntity))]
        [DataType(DataType.DateTime)]
        public DateTime DateCreation { get; set; }

        //[Display(Name = "UserLastChange", ResourceType = typeof(EResx.BaseEntity))]
        [MaxLength(50)]
        public string UserLastChange { get; set; }

        //[Display(Name = "DateLastChange", ResourceType = typeof(EResx.BaseEntity))]
        [DataType(DataType.DateTime)]
        public DateTime? DateLastChange { get; set; }
    }
}
