using Microsoft.Extensions.Options;
using Proman.DataAccessLayer.Abstract;
using Proman.DataAccessLayer.Concrete;
using Proman.DataAccessLayer.Settings.Abstract;
using Proman.DataAccessLayer.Settings.Concrete;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection("DatabaseSettings"));

builder.Services.AddSingleton<IDatabaseSettings>(sp =>
{
    return sp.GetRequiredService<IOptions<DatabaseSettings>>().Value;
});

builder.Services.AddScoped<IContactDAL, ContactDAL>();
builder.Services.AddScoped<IEducationDAL, EducationDAL>();
builder.Services.AddScoped<IExperienceDAL, ExperienceDAL>();
builder.Services.AddScoped<IMapDAL, MapDAL>();
builder.Services.AddScoped<IMessageDAL, MessageDAL>();
builder.Services.AddScoped<IMyProfileDAL, MyProfileDAL>();
builder.Services.AddScoped<IProjectDAL, ProjectDAL>();
builder.Services.AddScoped<IProjectTypeDAL, ProjectTypeDAL>();
builder.Services.AddScoped<IServiceDAL, ServiceDAL>();
builder.Services.AddScoped<ISkillDAL, SkillDAL>();
builder.Services.AddScoped<ISocialMediaDAL, SocialMediaDAL>();
builder.Services.AddScoped<ITeamDAL, TeamDAL>();
builder.Services.AddScoped<ITestimonialDAL, TestimonialDAL>();

builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

app.UseCors("AllowAllOrigins");

app.Run();
