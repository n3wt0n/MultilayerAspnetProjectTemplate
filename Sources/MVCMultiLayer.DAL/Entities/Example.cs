using System;

namespace MVCMultiLayer.DAL.Entities
{
    public class Example : BaseEntity
    {
        public int MyIntegerProperty { get; set; }

        public string MyStringProperty { get; set; }

        public DateTime MyNullableProperty { get; set; }
    }
}
