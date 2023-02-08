using Microsoft.AspNetCore.Mvc;
using ProtobufFormatter.Demo.Models;
using WebApiProtobufFormatter;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProtobufFormatter.Demo.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DemoController : ControllerBase
{
  [HttpGet("demo1/{id}/{name}")]
  public ProtobufResult<Pd> Demo1(int id, string name)
  {
    return new ProtobufResult<Pd>(new Pd
    {
      Id = id,
      Name = name
    });
  }

  [HttpGet("demo2/{id}/{name}")]
  public Pd Demo2(int id, string name)
  {
    return new Pd
    {
      Id = id,
      Name = name
    };

  }

  [HttpPost("demo3")]
  public Pd Demo3(Pd pd)
  {
    return pd;
  }
}