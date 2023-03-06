using System.Text;
using System.Text.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using rabbitmqApi.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});
var app = builder.Build();

var factory = new ConnectionFactory() { 
    HostName = "142.93.173.18",
    UserName = "admin",
    Password = "devintwitter"
};

List<MessagePublish> list = new List<MessagePublish>();



app.MapPost("/", (MessagePublish message) => {



    using(var connection = factory.CreateConnection()) //disposable
    using(var channel = connection.CreateModel())
    {
        channel.QueueDeclare(queue: "a2-renanfortkamp",
                        durable: false,
                        exclusive: false,
                        autoDelete: false,
                        arguments: null);

        var body = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(message));

        channel.BasicPublish(exchange: "",
                            routingKey: "a2-renanfortkamp",
                            basicProperties: null,
                            body: body);

    }


});



app.UseCors();
app.Run();

