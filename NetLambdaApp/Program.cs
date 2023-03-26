//SendMessage sendMessage = delegate(string message)
//{
//    Console.WriteLine(message);
//};

using System.Threading.Channels;

SendMessage<string> sendMessage = (string message) =>
{
    Console.WriteLine(message);
};

sendMessage += delegate (string message)
{
    ConsoleColor color = Console.ForegroundColor;
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine(message);
    Console.ForegroundColor = color;
};

sendMessage -= delegate (string message)
{
    Console.WriteLine(message);
};

sendMessage?.Invoke("Hello world!");

BinOperation operation = (a, b) => a + b;

Console.WriteLine(Calc(10, 20, operation));
Console.WriteLine(Calc(10, 20, (x, y) => x * y));


var hello = () =>
{
    Console.WriteLine("Hello");
};

SendMessage<Message> sendEmail = (m) =>
{
    EmailMessage em = m as EmailMessage;
    Console.WriteLine($"{em.Text} {em.Subject}");
};

int Calc(int a, int b, BinOperation operation)
{
    return operation(a, b);
}

class Message
{
    public string Text { get; set; }
}

class EmailMessage : Message
{
    public string Subject { set; get; }
}

class SmsMessage : Message
{
    public string Number { set; get; }
}




delegate void SendMessage<T>(T message);

delegate int BinOperation(int a, int b);

delegate void Hello();


delegate void MessageSend(Message message);
