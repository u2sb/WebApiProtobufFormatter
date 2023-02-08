using WebApiProtobufFormatter;

namespace ProtobufFormatter.Demo;

public class Program
{
  public static void Main(string[] args)
  {
    var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.

    builder.Services.AddControllers().AddProtobufFormatters(opt =>
    {
      opt.OutputFormatterOptions.ContentTypeDefault = "application/x-protobuf";
    });

    builder.Services.AddCors(opt =>
    {
      opt.AddDefaultPolicy(p => { p.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin(); });
    });

    var app = builder.Build();

    // Configure the HTTP request pipeline.

    app.UseCors();
    app.UseAuthorization();

    app.MapControllers();

    app.Run();
  }
}