using System.IO;
using System.Threading.Tasks;
using Google.Protobuf;

namespace WebApiProtobufFormatter.Utils;

public static class Serialize
{
  public static IMessage Parse(Stream sr, MessageParser parser)
  {
    sr.Position = 0;
    return parser.ParseFrom(sr);
  }

  public static IMessage Parse(byte[] data, MessageParser parser)
  {
    return parser.ParseFrom(data);
  }

  public static T Parse<T>(Stream sr, MessageParser<T> parser) where T : IMessage<T>
  {
    return parser.ParseFrom(sr);
  }

  public static T Parse<T>(byte[] data, MessageParser<T> parser) where T : IMessage<T>
  {
    return parser.ParseFrom(data);
  }

  public static async Task StreamToAsync(this IMessage message, Stream dest)
  {
    using var ms = new MemoryStream();
    message.WriteTo(ms);
    ms.Position = 0;
    await ms.CopyToAsync(dest);
  }

  public static void StreamTo(this IMessage message, Stream dest)
  {
    using var ms = new MemoryStream();
    message.WriteTo(ms);
    ms.Position = 0;
    ms.CopyTo(dest);
  }
}