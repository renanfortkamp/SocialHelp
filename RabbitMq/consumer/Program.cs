using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

var factory = new ConnectionFactory() { 
    HostName = "142.93.173.18",
    UserName = "admin",
    Password = "devintwitter"
};

try{

    var connection = factory.CreateConnection();
    var channel = connection.CreateModel();

     channel.QueueDeclare(queue: "a2-renanfortkamp",
                        durable: false,
                        exclusive: false,
                        autoDelete: false,
                        arguments: null);
                            

    
    RecebeMensagensChat(channel);
    


    
    do{
        Console.WriteLine("escreva /sair para sair");
        var message = Console.ReadLine();
        if(message != "/sair"){
        }
        
    }while(message != "/sair");

}catch(Exception e){
   
}
Console.WriteLine(" Press [enter] to exit.");
Console.ReadLine();


static void RecebeMensagensChat(IModel channel){
    var consumer = new EventingBasicConsumer(channel);
   
    consumer.Received += (model, ea) =>
    {
        var body = ea.Body.ToArray();
        var message = Encoding.UTF8.GetString(body);
        SaveData(message);
    };
    channel.BasicConsume(queue: "a2-renanfortkamp",
                            autoAck: true,
                            consumer: consumer);
}


static void SaveData(message){
    return ok();
}