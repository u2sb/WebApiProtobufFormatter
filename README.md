# WebApiProtobufFormatter

## 注意

此项目目前尚未稳定，请勿用于生产环境。

## 使用

```cs
services.AddControllers().AddProtobufFormatters();
```

```cs
services.AddMvcCore().AddProtobufFormatters();
```

```cs
services.AddControllersWithViews().AddProtobufFormatters(new ProtobufFormatterOptions(), options => { });
```

## 打包

```sh
dotnet pack --configuration Release --include-source
```
