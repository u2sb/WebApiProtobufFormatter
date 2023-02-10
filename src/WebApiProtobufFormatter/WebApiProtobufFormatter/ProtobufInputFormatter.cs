using System;
using System.IO;
using System.Threading.Tasks;
using Google.Protobuf;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;
using static WebApiProtobufFormatter.Utils.Serialize;

namespace WebApiProtobufFormatter;

public class ProtobufInputFormatter : InputFormatter
{
  private readonly ProtobufFormatterOptions.ProtobufInputFormatterOptions _options;

  public ProtobufInputFormatter() : this(new ProtobufFormatterOptions())
  {
  }

  public ProtobufInputFormatter(ProtobufFormatterOptions options)
  {
    _options = options.InputFormatterOptions;
    Init();
  }

  private void Init()
  {
    foreach (var mediaType in _options.SupportedMediaTypes)
      SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse(mediaType));
  }

  protected override bool CanReadType(Type type)
  {
    return type.IsAssignableTo(typeof(IMessage));
  }

  public override async Task<InputFormatterResult> ReadRequestBodyAsync(InputFormatterContext context)
  {
    try
    {
      var type = context.ModelType;
      var o = Activator.CreateInstance(type);
      var i = type.GetProperty("Parser")?.GetValue(o);

      if (i is MessageParser m)
      {
        var body = context.HttpContext.Request.Body;
        using var ms = new MemoryStream();
        await body.CopyToAsync(ms);
        var res = Parse(ms, m);
        return await InputFormatterResult.SuccessAsync(res);
      }

      return await InputFormatterResult.FailureAsync();
    }
    catch (Exception e)
    {
      throw new InputFormatterException("", e);
    }
  }
}