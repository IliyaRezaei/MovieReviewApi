using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore;
using MovieReviewApi.Data;
using MovieReviewApi.Helpers;
using MovieReviewApi.Interfaces;
using MovieReviewApi.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration["ConnectionString:MovieReview"]));

builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<IGenreRepository, GenreRepository>();
builder.Services.AddScoped<IMovieRepository, MovieRepository>();
builder.Services.AddScoped<IReviewRepository, ReviewRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IMovieCrewRepository, MovieCrewRepository>();
builder.Services.AddScoped<IPersonRepository, PersonRepository>();
builder.Services.AddScoped<IImageUploadHandler, ImageUploadHandler>();
builder.Services.AddScoped<IVideoUploadHandler, VideoUploadHandler>();

builder.Services.Configure<FormOptions>(options =>{
    options.MultipartBodyLengthLimit = 500 * 1024 * 1024;
});

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
