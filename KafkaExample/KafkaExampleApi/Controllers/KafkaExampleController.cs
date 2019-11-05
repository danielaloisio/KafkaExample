using InsideTechConf.Library.KafkaLite;
using KafkaExampleApi.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace KafkaExampleApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class KafkaExampleController : ControllerBase
    {
        [HttpPost("topic")]
        public async Task<ActionResult<string>> TopicAsync()
        {
            string topic = "insidetech-5";
            string host = "127.0.0.1:9092";

            var management = new Management(host);
            try
            {
                await management.CreateTopicAsync(topic);
                return Ok("Success");
            }

            catch (Exception err)
            {
                return err.Message;
            }
        }


        [HttpPost("producer")]
        public async Task<ActionResult<string>> ProducerAsync([FromBody] UserViewModel userViewModel)
        {
            try
            {
                string topic = "insidetech-5";
                string host = "127.0.0.1:9092";

                var producerSettings = new ProducerSettings(host);

                var producer = new Producer(producerSettings);

                var payload = new Model.User
                {
                    Email = userViewModel.Email,
                    Name = userViewModel.Name
                };

                var result = await producer.SendAsync(topic, payload);

                return Ok(result.Value);
            }
            catch
            {
                return new StatusCodeResult(500);
            }
        }

    }
}
