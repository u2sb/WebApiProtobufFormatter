using System.Collections.Generic;

namespace WebApiProtobufFormatter;

public class ProtobufFormatterOptions
{
  public ProtobufInputFormatterOptions InputFormatterOptions { get; set; } = new();
  public ProtobufOutputFormatterOptions OutputFormatterOptions { get; set; } = new();

  public class ProtobufInputFormatterOptions
  {
    public HashSet<string> SupportedMediaTypes { get; set; } = new()
      { "application/octet-stream", "application/x-protobuf", "application/protobuf", "application/x-google-protobuf" };
  }

  public class ProtobufOutputFormatterOptions
  {
    public string ContentTypeDefault { get; set; } = "application/octet-stream";
    public HashSet<string> SupportedMediaTypes { get; set; } = new()
      { "application/octet-stream", "application/x-protobuf", "application/protobuf", "application/x-google-protobuf" };
  }
}
