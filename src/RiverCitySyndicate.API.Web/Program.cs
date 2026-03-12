using RiverCitySyndicate.APi.Service;
using RiverCitySyndicate.API.Data.DbContexts;
using RiverCitySyndicate.API.Data.Repositories;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.MSSqlServer;
using System.Data;


var builder = WebApplication.CreateBuilder(args);

//--LOGGING--//
var logTblName = "Logs";
var connString = builder.Configuration["ConnectionStrings:sqlServerDbConnectionString"];
var appIdString = builder.Configuration["AppId"];

var columnOptions = new ColumnOptions
{
    AdditionalColumns = new List<SqlColumn>
    {
        new SqlColumn { ColumnName = "AppId", DataType = SqlDbType.UniqueIdentifier }
    }
};

var loggerConfiguration = new LoggerConfiguration().MinimumLevel.Information();

if (Guid.TryParse(appIdString, out var appIdGuid))
{
    loggerConfiguration = loggerConfiguration.Enrich.WithProperty("AppId", appIdGuid);
}
else if (!string.IsNullOrWhiteSpace(appIdString))
{
    // fallback to string if not a GUID
    loggerConfiguration = loggerConfiguration.Enrich.WithProperty("AppId", appIdString);
}

Log.Logger = loggerConfiguration
    .WriteTo.MSSqlServer
    (
        connectionString: connString,
        sinkOptions: new MSSqlServerSinkOptions
        {
            TableName = logTblName,
            SchemaName = "dbo",
            AutoCreateSqlTable = true
        },
        restrictedToMinimumLevel: LogEventLevel.Information,
        formatProvider: null,
        columnOptions: columnOptions,
        logEventFormatter: null
    )
    .WriteTo.Console()
    .WriteTo.File("logs/log.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

// Ensure the host uses the configured static Log.Logger
builder.Host.UseSerilog();


//--SERVICES--//
builder.Services.AddControllers(options =>
{
    //  media types: don't blindly return json regardless of what they asked for.
    options.ReturnHttpNotAcceptable = true;
})
.AddNewtonsoftJson()
.AddXmlDataContractSerializerFormatters();

// OpenAPI & Swagger
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen((setupAction) =>
{
    // since multiple projects will have xml documentation, we will need to loop thru all
    // the files and include all xml docs.
    DirectoryInfo baseDirectoryInfo = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);
    foreach (var fileInfo in baseDirectoryInfo.EnumerateFiles("RiverCitySyndicate.API*.xml"))
    {
        setupAction.IncludeXmlComments(fileInfo.FullName);
    };
});

// ms sql
builder.Services.AddDbContext<RiverCitySyndicateDbContext>(dbContextOptions => dbContextOptions.UseSqlServer(connString));

// postgres
//builder.Services.AddDbContext<ElleChristineDbContext>(dbContextOptions => dbContextOptions.UseNpgsql(connString));

builder.Services.AddScoped<IRiverCitySyndicateRepository, RiverCitySyndicateRepository>();
builder.Services.AddScoped<IShowProcessor, ShowProcessor>();
builder.Services.AddScoped<IPhotoProcessor, PhotoProcessor>();
builder.Services.AddScoped<IVideoProcessor, VideoProcessor>();
builder.Services.AddSingleton<FileExtensionContentTypeProvider>();

builder.Services.AddHealthChecks();

// auto-mapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFromOrigins", policy =>
    {
        policy
            .WithOrigins(
                "http://127.0.0.1:5500",
                "http://localhost:5500",
                "http://localhost:4200/",
                "https://calm-plant-0f7005e0f.4.azurestaticapps.net",
                "https://www.rivercitysyndicate.com"
            )
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    // remove if not wanted to expose in prod
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseCors("AllowFromOrigins");

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.MapHealthChecks("/api/health");

app.Run();
