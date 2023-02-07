using System;
using System.IO;
using System.Threading.Tasks;
using Google.Protobuf;
using Microsoft.AspNetCore.Mvc.Formatters;

namespace WebApiProtobufFormatter;

public class ProtobufOutputFormatter : IOutputFormatter
{
  private readonly ProtobufFormatterOptions.ProtobufOutputFormatterOptions _options;

  public ProtobufOutputFormatter()
  {
    _options = new ProtobufFormatterOptions().OutputFormatterOptions;
  }

  public ProtobufOutputFormatter(ProtobufFormatterOptions options)
  {
    _options = options.OutputFormatterOptions;
  }

  public bool CanWriteResult(OutputFormatterCanWriteContext context)
  {
    if (context == null) throw new ArgumentNullException(nameof(context));
    if (context.Object is IMessage) return true;
    return false;
  }

  public async Task WriteAsync(OutputFormatterWriteContext context)
  {
    if (context == null) throw new ArgumentNullException(nameof(context));
    if (context.Object is IMessage m)
    {
      var response = context.HttpContext.Response;
      response.ContentType ??= _options.ContentTypeDefault;
      using var ms = new MemoryStream();
      m.WriteTo(ms);
      ms.Position = 0;
      await ms.CopyToAsync(response.Body);
    }
  }
}
