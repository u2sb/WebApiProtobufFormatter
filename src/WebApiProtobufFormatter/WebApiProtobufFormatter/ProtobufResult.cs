using System.IO;
using System.Threading.Tasks;
using Google.Protobuf;
using Microsoft.AspNetCore.Mvc;

namespace WebApiProtobufFormatter;

public class ProtobufResult<T> : ActionResult where T : IMessage
{
  private readonly ProtobufFormatterOptions.ProtobufOutputFormatterOptions _options;
  private readonly T _value;

  public ProtobufResult(T value)
  {
    _value = value;
    _options = new ProtobufFormatterOptions.ProtobufOutputFormatterOptions();
  }

  public ProtobufResult(T value, ProtobufFormatterOptions.ProtobufOutputFormatterOptions options) : this(value)
  {
    _options = options;
  }

  public override void ExecuteResult(ActionContext context)
  {
    var response = context.HttpContext.Response;
    if (string.IsNullOrWhiteSpace(response.ContentType)) response.ContentType = _options.ContentTypeDefault;

    using var ms = new MemoryStream();
    _value.WriteTo(ms);
    ms.Position = 0;
    ms.CopyTo(response.Body);
  }

  public override async Task ExecuteResultAsync(ActionContext context)
  {
    var response = context.HttpContext.Response;
    if (string.IsNullOrWhiteSpace(response.ContentType)) response.ContentType = _options.ContentTypeDefault;
    using var ms = new MemoryStream();
    _value.WriteTo(ms);
    ms.Position = 0;
    await ms.CopyToAsync(response.Body);
  }
}