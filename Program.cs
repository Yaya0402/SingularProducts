using SingularProducts.Repositories;
using SingularProducts.Services;

/// Create the appliication builder


var builder = WebApplication.CreateBuilder(args);

///Register Razor Pages
builder.Services.AddRazorPages();

builder.Services.AddHttpClient<IProductRepository, ProductRepository>(client =>
{
    client.BaseAddress = new Uri("https://singularsystems-tech-assessment-sales-api2.azurewebsites.net/index.html");
});

builder.Services.AddScoped<IProductService, ProductService>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

//Redirect all HTTP requests to HTTPS
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapRazorPages();

//Start the applicaton and begin listening for requests
app.Run();

