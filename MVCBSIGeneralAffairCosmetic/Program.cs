using BSIGeneralAffairBLL.Interfaces;
using BSIGeneralAffairBLL;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//register session
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(10);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

//register DI
builder.Services.AddScoped<IApprovalBLL, ApprovalBLL>();
builder.Services.AddScoped<IAssetBLL, AssetBLL>();
builder.Services.AddScoped<IBrandBLL, BrandBLL>();
builder.Services.AddScoped<ICategoryBLL, CategoryBLL>();
builder.Services.AddScoped<DashboardBLL>();
builder.Services.AddScoped<IDepartementBLL, DepartementBLL>();
builder.Services.AddScoped<IEmployeeBLL, EmployeeBLL>();
builder.Services.AddScoped<IOfficeBLL, OfficeBLL>();
builder.Services.AddScoped<IProposalBLL, ProposalBLL>();
builder.Services.AddScoped<IUserBLL, UserBLL>();
builder.Services.AddScoped<IVendorBLL, VendorBLL>();

//builder.Services.AddHttpClient<ICategoryServices, CategoryServices>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();
app.UseSession();
app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
