using System.Reflection;
using System.Text;
using System.Threading.Channels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using PublishApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PublishApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly ConnectionFactory _factory;
        public MessageController()
        {
            _factory = new ConnectionFactory()
            {
                HostName = "142.93.173.18",
                UserName = "admin",
                Password = "devintwitter"
            };
        }

        // POST api/<MessageController>
        [HttpPost]
        public ActionResult Post([FromBody] MessagePublish messagePublish)
        {
            if (messagePublish == null)
            {
                return BadRequest(ModelState);
            }

            using var connection = _factory.CreateConnection();
            using var channel = connection.CreateModel();

            try
            {
                PublishMessage(messagePublish, channel);
                return Ok("publicado com sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        private void PublishMessage(MessagePublish messagePublish, IModel channel)
        {
            channel.QueueDeclare(queue: "a2-renanfortkamp",
                     durable: true,
                     exclusive: false,
                     autoDelete: false,
            arguments: null);

            var body = JsonConvert.SerializeObject(messagePublish);

            var modelBytes = Encoding.UTF8.GetBytes(body);
            channel.BasicPublish(exchange: "a2-ex-renanfortkamp",
                            routingKey: "rekey",
                            basicProperties: null,
                            body: modelBytes);
        }


    }
}
