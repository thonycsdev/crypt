var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    DotNetEnv.Env.Load("../.env.development");
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    DotNetEnv.Env.Load("../.env");
}
;

//app.UseHttpsRedirection();
app.MapControllers();
app.Run();
