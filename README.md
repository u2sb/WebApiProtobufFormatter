# WebApiProtobufFormatter

## 注意

此项目目前尚未稳定，请勿用于生产环境。

## 使用

安装 [Grpc.Tools](https://www.nuget.org/packages/Grpc.Tools/)

配置

```xml
<Project>
  <ItemGroup>
    <Protobuf Include="Models\Proto\*.proto" />
  </ItemGroup>
</Project>
```

`Startup.cs`

```cs
services.AddControllers().AddProtobufFormatters();
```

或

```cs
services.AddMvcCore().AddProtobufFormatters();
```

或

```cs
services.AddControllersWithViews().AddProtobufFormatters(new ProtobufFormatterOptions(), options => { });
```

## 打包

```sh
dotnet pack -p:PackageVersion=x.x.x --configuration Release --include-source
```
