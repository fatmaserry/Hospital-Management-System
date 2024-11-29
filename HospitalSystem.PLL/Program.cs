using HospitalSystem.BLL.Mapping;
using HospitalSystem.BLL.Service.Impelementation;
using HospitalSystem.DAL.Repo.Abstraction;
using HospitalSystem.DAL.Repo.Impelementation;
using HospitalSystem.DAL.DB;
using Microsoft.AspNetCore.Identity;
using HospitalSystem.DAL.Entity;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using HospitalSystem.BLL.Service.Abstraction;
using HospitalSystem.DAL.Repo.Abstracion;
using HospitalSystem.DAL.Repo.Implemintation;
using Stripe;
using HospitalSystem.BLL.Service.Implemintation;
using SH.DAL.Repo.Abstracion;
using SH.DAL.Repo.Implemintation;
using SH.BLL.Services.Abstraction;
using SH.BLL.Services.implemintation;
using Microsoft.Extensions.Options;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAutoMapper(x => x.AddProfile(new Mapp()));
builder.Services.AddControllersWithViews(); // mvc



builder.Services.AddScoped<IAccountRepo, AccountRepo>();
builder.Services.AddScoped<IAccountService, HospitalSystem.BLL.Service.Impelementation.AccountService>();
builder.Services.AddScoped<IDoctorRepo, DoctorRepo>();
builder.Services.AddScoped<IDocServices, DocServices>();
builder.Services.AddScoped<IAppointmentRepo, AppointmentRepo>();
builder.Services.AddScoped<IAppointmentService, AppointmentService>();
builder.Services.AddScoped<IPaymentRepo, PaymentRepo>();
builder.Services.AddScoped<IPaymentService, PaymentService>();
builder.Services.AddScoped<IMedicalReportRepo, MedicalReportRepo>();
builder.Services.AddScoped<IMedicalReportService, MedicalReportService>();
builder.Services.AddScoped<IAMedicalReportService, AMedicalReportService>();
builder.Services.AddScoped<IAMedicalReportRepo, AMedicalReportRepo>();
builder.Services.AddScoped<IRoomRepo, RoomRepo>();
builder.Services.AddScoped<IRoomService, RoomService>();
builder.Services.AddDbContext<AppDbContext>(options =>
               options.UseSqlServer("name=DefaultConnection"));



builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
.AddCookie(CookieAuthenticationDefaults.AuthenticationScheme,
    options =>
    {
        options.LoginPath = new PathString("/Account/Login");
        options.AccessDeniedPath = new PathString("/Account/Login");
    });

builder.Services.AddIdentity<Patient, IdentityRole>()
        .AddEntityFrameworkStores<AppDbContext>()
        .AddDefaultTokenProviders();


builder.Services.AddIdentityCore<Patient>(options => { options.SignIn.RequireConfirmedAccount = false; options.SignIn.RequireConfirmedEmail = false; })
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<AppDbContext>()
                .AddTokenProvider<DataProtectorTokenProvider<Patient>>(TokenOptions.DefaultProvider);


var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
//StripeConfiguration.ApiKey = builder.Configuration.GetSection("Stripe:SecretKey").Get<string>();

app.UseAuthentication();

app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});



app.Run();