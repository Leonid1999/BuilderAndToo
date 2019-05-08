using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class MainClass
{
    public static void Main(string[] args)
    {
        ApiManager apiManager = new ApiManager();

        MessageBuilder builder = new VoiceMessageBuilder();
        Messege voiceMessage = apiManager.Record(builder);
        Console.WriteLine(voiceMessage.ToString());

        builder = new SimpleMessageBuilder();
        Messege SimpleMessage = apiManager.Record(builder);
        Console.WriteLine(SimpleMessage.ToString());

        builder = new VideoMessageBuilder();
        Messege videoMessage = apiManager.Record(builder);
        Console.WriteLine(videoMessage.ToString());

        Console.Read();
    }
}

class MessageType
{
    // What a type Messege
    public string Type { get; set; }
}


class TimeToSend
{
    public string Time { get; set; }
}

class Messege
{

    public MessageType MessageType { get; set; }

    public TimeToSend TimeToSend { get; set; }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        if (MessageType != null)
            sb.Append("Type: " + MessageType.Type + "\n");
        if (TimeToSend != null)
            sb.Append("Time: " + TimeToSend.Time + "\n");

        return sb.ToString();
    }
}

// абстрактный класс строителя
abstract class MessageBuilder
{
    public Messege Messege { get; private set; }
    public void CreateMessage()
    {
        Messege = new Messege();
    }
    public abstract void SetType();
    public abstract void SetLen();
}

class ApiManager
{
    public Messege Record(MessageBuilder MessageBuilder)
    {
        MessageBuilder.CreateMessage();
        MessageBuilder.SetType();
        MessageBuilder.SetLen();
        return MessageBuilder.Messege;
    }
}
// строитель для voice Messege
class VoiceMessageBuilder : MessageBuilder
{
    public override void SetType()
    {
        this.Messege.MessageType = new MessageType { Type = " Voice Messege" };
    }

    public override void SetLen()
    {
        this.Messege.TimeToSend = new TimeToSend { Time = "7:48 pm" };
    }

}
// строитель video
class VideoMessageBuilder : MessageBuilder
{
    public override void SetType()
    {
        this.Messege.MessageType = new MessageType { Type = " Video Messege" };
    }

    public override void SetLen()
    {
        this.Messege.TimeToSend = new TimeToSend { Time = "2:55 am" };
    }
}

class SimpleMessageBuilder : MessageBuilder
{
    public override void SetType()
    {
        this.Messege.MessageType = new MessageType { Type = " Simple Messege" };
    }

    public override void SetLen()
    {
        this.Messege.TimeToSend = new TimeToSend { Time = "12:35 pm" };
    }
}
