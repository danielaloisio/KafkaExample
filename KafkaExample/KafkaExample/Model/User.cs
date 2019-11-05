using System;

namespace KafkaExample.Model
{
    public class User
    {
        public Guid Key { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
