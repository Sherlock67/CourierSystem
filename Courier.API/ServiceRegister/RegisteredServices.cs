using Courier.Business.Interface.ILogin;
using Courier.Business.Services;

namespace Courier.API.ServiceRegister
{
    public static class RegisteredServices
    {
        public static void Register(WebApplicationBuilder builder)
        {
        //    builder.Services.AddScoped<ICustomerServices, CustomerServices>();
            //builder.Services.AddScoped<ICustomerServicesOld, CustomerServicesOld>();
            builder.Services.AddScoped<ILoginService, LoginService>();

            //builder.Services.AddScoped<IModuleAndMenuServiceCommands, ModuleAndMenuServiceCommands>();
            //builder.Services.AddScoped<IModuleAndMenuServiceQueries, ModuleAndMenuServiceQueries>();

            //builder.Services.AddScoped<IRoleCommands, RoleServiceCommands>();
            //builder.Services.AddScoped<IRoleQueries, RoleServiceQueries>();
            //builder.Services.AddScoped<IChatServices, ChatsServices>();
        }
    }
}
