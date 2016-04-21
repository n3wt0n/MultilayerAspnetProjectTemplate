using System;
using System.ComponentModel.DataAnnotations;
using EResx = $saferootprojectname$.Localization.Entities;

namespace $safeprojectname$.Entities
{
    public class Example : BaseEntity
    {
        [Display(Name = "MyIntegerProperty", ResourceType = typeof(EResx.Example))]
        public int MyIntegerProperty { get; set; }

        [Display(Name = "MyStringProperty", ResourceType = typeof(EResx.Example))]
        public string MyStringProperty { get; set; }

        [Display(Name = "MyNullableProperty", ResourceType = typeof(EResx.Example))]
        public DateTime MyNullableProperty { get; set; }
    }
}
