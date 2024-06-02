using Microsoft.OpenApi.Models;
using MLend.Api;
using MLend.Application;
using MLend.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<MongoDbSettings>(builder.Configuration.GetSection("MongoDbSettings"));

builder.Services
    .AddApplication()
    .AddInfrastructure();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(s => {
    s.SwaggerDoc("v1", new OpenApiInfo { Title = "MLend Book", Description = "Api responsável pelo emprestimo de livros", Version = "v1"}); 
});

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI(s => 
{
    s.SwaggerEndpoint("/swagger/v1/swagger.json", "Mlend Api");
});

app.MapPost("lends", async (LendRequest request, ILendService service, CancellationToken cancellationToken) =>
    await service.InsertAsync(request, cancellationToken)).AddEndpointFilter<ValidationFilter>();

app.MapPatch("lends/{id}", async (Guid id, ILendService service, CancellationToken cancellationToken) => 
    await service.UpdateAsync(id, cancellationToken));

app.MapGet("lends", async (Status status, ILendService service, CancellationToken cancellationToken) =>
    await service.GetLendsByStatus(status, cancellationToken));

app.Run();
