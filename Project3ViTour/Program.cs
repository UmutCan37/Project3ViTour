using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Options;
using Project3ViTour.Services.BookingService;
using Project3ViTour.Services.CategoryService;
using Project3ViTour.Services.GalleryImageService;
using Project3ViTour.Services.LocationService;
using Project3ViTour.Services.ReviewService;
using Project3ViTour.Services.TourPlanningService;
using Project3ViTour.Services.TourService;
using Project3ViTour.Settings;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Servisler
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ITourService, TourService>();
builder.Services.AddScoped<IReviewService, ReviewService>();
builder.Services.AddScoped<ILocationService, LocationService>();
builder.Services.AddScoped<IGalleryImageService, GalleryImageService>();
builder.Services.AddScoped<ITourPlanningService, TourPlanningService>();
builder.Services.AddScoped<IBookingService, BookingService>();

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection("DatabaseSettingKey"));
builder.Services.AddScoped<IDatabaseSettings>(sp =>
{
    return sp.GetRequiredService<IOptions<DatabaseSettings>>().Value;
});

// Localization
builder.Services.AddLocalization(options => options.ResourcesPath = "");

builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    var supportedCultures = new[] { "tr", "en", "fr" };
    options.SetDefaultCulture("tr")
        .AddSupportedCultures(supportedCultures)
        .AddSupportedUICultures(supportedCultures);
    options.RequestCultureProviders.Insert(0, new CookieRequestCultureProvider());
});

builder.Services.AddControllersWithViews()
    .AddViewLocalization()
    .AddDataAnnotationsLocalization();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRequestLocalization();
app.UseRouting();
app.UseAuthorization();
app.MapStaticAssets();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();