using System;

namespace KafkaExampleApi.Model
{
    public class User
    {
        public User()
        {
            Key = Guid.NewGuid();
            CreatedAt = DateTime.UtcNow;
        }
        public Guid Key { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
