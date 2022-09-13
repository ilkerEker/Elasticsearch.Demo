using Elasticsearch.Demo;
using Nest;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var settings = new ConnectionSettings();
    //.DefaultMappingFor<User>(x=>x.IndexName("users"))   ;Bu sekilde de cal�s�yor ama sorgunun �c�ne ekled�k 2. yol olarak 
builder.Services.AddSingleton<IElasticClient>(new ElasticClient(settings));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
