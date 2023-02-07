using System;
using Microsoft.Extensions.DependencyInjection;

namespace WebApiProtobufFormatter;

public static class ProtobufFormatterMvcBuilderExtensions
{
  public static IMvcBuilder AddProtobufFormatters(this IMvcBuilder builder)
  {
    if (builder == null) throw new ArgumentNullException(nameof(builder));

    return AddProtobufFormatters(builder, new ProtobufFormatterOptions(), null);
  }

  public static IMvcCoreBuilder AddProtobufFormatters(this IMvcCoreBuilder builder)
  {
    if (builder == null) throw new ArgumentNullException(nameof(builder));

    return AddProtobufFormatters(builder, new ProtobufFormatterOptions(), null);
  }

  public static IMvcBuilder AddProtobufFormatters(this IMvcBuilder builder,
    Action<ProtobufFormatterOptions>? protobufFormatterOptionsConfiguration)
  {
    if (builder == null) throw new ArgumentNullException(nameof(builder));

    return AddProtobufFormatters(builder, new ProtobufFormatterOptions(), protobufFormatterOptionsConfiguration);
  }

  public static IMvcCoreBuilder AddProtobufFormatters(this IMvcCoreBuilder builder,
    Action<ProtobufFormatterOptions>? protobufFormatterOptionsConfiguration)
  {
    if (builder == null) throw new ArgumentNullException(nameof(builder));

    return AddProtobufFormatters(builder, new ProtobufFormatterOptions(), protobufFormatterOptionsConfiguration);
  }


  public static IMvcBuilder AddProtobufFormatters(this IMvcBuilder builder,
    ProtobufFormatterOptions protobufFormatterOptions,
    Action<ProtobufFormatterOptions>? protobufFormatterOptionsConfiguration)
  {
    if (builder == null) throw new ArgumentNullException(nameof(builder));

    protobufFormatterOptionsConfiguration?.Invoke(protobufFormatterOptions);

    builder.AddMvcOptions(options => options.InputFormatters.Add(new ProtobufInputFormatter(protobufFormatterOptions)));
    builder.AddMvcOptions(
      options => options.OutputFormatters.Add(new ProtobufOutputFormatter(protobufFormatterOptions)));

    return builder;
  }

  public static IMvcCoreBuilder AddProtobufFormatters(this IMvcCoreBuilder builder,
    ProtobufFormatterOptions protobufFormatterOptions,
    Action<ProtobufFormatterOptions>? protobufFormatterOptionsConfiguration)
  {
    if (builder == null) throw new ArgumentNullException(nameof(builder));

    protobufFormatterOptionsConfiguration?.Invoke(protobufFormatterOptions);

    builder.AddMvcOptions(options => options.InputFormatters.Add(new ProtobufInputFormatter(protobufFormatterOptions)));
    builder.AddMvcOptions(
      options => options.OutputFormatters.Add(new ProtobufOutputFormatter(protobufFormatterOptions)));

    return builder;
  }
}
