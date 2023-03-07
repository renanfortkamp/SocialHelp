using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Newtonsoft.Json;
using System.Text;
using Consumer.Models;

var factory = new ConnectionFactory()
{
    HostName = "142.93.173.18",
    UserName = "admin",
    Password = "devintwitter"
};

using var connection = factory.CreateConnection();
using var channel = connection.CreateModel();


channel.QueueDeclare(queue: "a2-renanfortkamp",
                           durable: true,
                           exclusive: false,
                           autoDelete: false,
                           arguments: null);

var consumer = new EventingBasicConsumer(channel);

consumer.Received += async (model, ea) =>
{
    var body = ea.Body.ToArray();
    var message = Encoding.UTF8.GetString(body);
    var messagePublish = JsonConvert.DeserializeObject<MessagePublish>(message);
    
    try{

        Message message1 = await SaveMessage(messagePublish);

    }catch(Exception e){
        Console.WriteLine("falha ao salvar");
    }

};

channel.BasicConsume(queue: "a2-renanfortkamp",
                        autoAck: true,
                        consumer: consumer);

Console.WriteLine(" Press [enter] to exit.");
Console.ReadLine();

async Task<Message> SaveMessage(MessagePublish messagePublish)
{   
    using var ctx = new CoreApiContext();
    var message = new Message();
    message.Text = messagePublish.Text;
    message.UserName = messagePublish.UserName;
    message.UserId = messagePublish.UserId;
    message.GroupId = messagePublish.GroupId;    

    ctx.DbSetMessages.Add(message);
    await ctx.SaveChangesAsync();

    return message;
}