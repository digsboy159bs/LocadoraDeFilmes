using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IO;
using System.Reflection;

namespace LocadoraFilmes
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services
                // Adiciona o MVC ao projeto
                .AddMvc()

                // Adiciona as op��es do json 
                

                // Define a vers�o do .NET Core
                .SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Version_3_0);

            // Documenta��o Swagger

            // https://docs.microsoft.com/pt-br/aspnet/core/tutorials/getting-started-with-swashbuckle?view=aspnetcore-2.1&tabs=visual-studio
            // Register the Swagger generator, defining 1 or more Swagger documents
            

            services
                // Define a forma de autentica��o
                .AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = "JwtBearer";
                    options.DefaultChallengeScheme = "JwtBearer";
                })

                // Define os par�metros de valida��o do token
                .AddJwtBearer("JwtBearer", options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        // Quem est� solicitando
                        ValidateIssuer = true,

                        // Quem est� validando
                        ValidateAudience = true,

                        // Definindo o tempo de expira��o
                        ValidateLifetime = true,

                        // Forma de criptografia
                        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("LocadoraFilmes-chave-autenticacao")),

                        // Tempo de expira��o do token
                        ClockSkew = TimeSpan.FromMinutes(30),

                        // Nome da issuer, de onde est� vindo
                        ValidIssuer = "LocadoraFilmes",

                        // Nome da audience, de onde est� vindo
                        ValidAudience = "LocadoraFilmes"
                    };
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            

            // Habilita o uso de autentica��o
            app.UseAuthentication();

            // Define o uso do MVC
            app.UseStaticFiles();
            app.UseRouting();
            app.UseCors();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}");
            });
        }
    }
}