using LambdaMinimalApiNet7;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Add AWS Lambda support. When application is run in Lambda Kestrel is swapped out as the web server with Amazon.Lambda.AspNetCoreServer. This
// package will act as the webserver translating request and responses between the Lambda event source and ASP.NET Core.

//builder.Logging.AddLambdaLogger();
builder.Services
    // .Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options =>
    // {
    //     options.SerializerOptions.AddContext<LambdaFunctionJsonSerializerContext>();
    //     options.SerializerOptions.PropertyNameCaseInsensitive = false;
    //     options.SerializerOptions.PropertyNamingPolicy = null;
    //     options.SerializerOptions.WriteIndented = true;
    // })
    // .AddHttpLogging(logging =>
    // {
    // })
    .AddAWSLambdaHosting(LambdaEventSource.RestApi)
    //.AddDefaultAWSOptions(builder.Configuration.GetAWSOptions())
    ;

var app = builder.Build();


app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.MapGet("/", () => "Welcome to running ASP.NET Core Minimal API on AWS Lambda");

app.Run();