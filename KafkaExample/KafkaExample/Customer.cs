using System;

namespace KafkaExample
{
    public class Customer
    {
        public Guid Key { get; set; }
        public DateTime CreatedAt { get; set; }
        public string FullName { get; set; }
    }
}
