using System;
using System.Threading.Tasks;
using Google.Protobuf;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;
using WebApiProtobufFormatter.Utils;

namespace WebApiProtobufFormatter;

public class ProtobufOutputFormatter : OutputFormatter
{
  private readonly ProtobufFormatterOptions.ProtobufOutputFormatterOptions _options;

  public ProtobufOutputFormatter() : this(new ProtobufFormatterOptions())
  {
  }

  public ProtobufOutputFormatter(ProtobufFormatterOptions options)
  {
    _options = options.OutputFormatterOptions;
    Init();
  }

  private void Init()
  {
    foreach (var mediaType in _options.SupportedMediaTypes)
      SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse(mediaType));
  }

  protected override bool CanWriteType(Type? type)
  {
    return type?.IsAssignableTo(typeof(IMessage)) ?? false;
  }

  public override async Task WriteResponseBodyAsync(OutputFormatterWriteContext context)
  {
    if (context == null) throw new ArgumentNullException(nameof(context));
    if (context.Object is IMessage m)
    {
      var response = context.HttpContext.Response;
      if (string.IsNullOrWhiteSpace(response.ContentType)) response.ContentType = _options.ContentTypeDefault;
      await m.StreamToAsync(response.Body);
    }
  }
}