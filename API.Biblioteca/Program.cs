using API.Biblioteca.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// Add serviços de Banco de Dados
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Adiciona serviços de CORS para permitir requisições de diferentes origens

// CORS -> Cross-Origin Resource Sharing, é um mecanismo que permite que recursos restritos em uma página da web sejam solicitados a partir de outro domínio fora do domínio do qual o recurso foi servido. Neste código, estamos configurando uma política de CORS chamada "AllowAll" que permite qualquer origem, método e cabeçalho, o que é útil para desenvolvimento e testes, mas deve ser configurado com mais restrição em ambientes de produção para garantir a segurança.
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

// Add os serviços de Identidade para autenticação e autorização

// Identity é um sistema de autenticação e autorização para aplicações ASP.NET Core. Ele fornece uma maneira fácil de gerenciar usuários, senhas, funções e outras informações relacionadas à segurança. Neste código, estamos configurando o Identity para usar a classe IdentityUser como modelo de usuário e armazenar as informações de identidade no banco de dados usando Entity Framework Core com o ApplicationDbContext.
builder.Services.AddIdentityCore<IdentityUser>()
    .AddEntityFrameworkStores<ApplicationDbContext>();



// builder.Build() => É onde a aplicação é construída.
var app = builder.Build();

// Pipeline de processamento de requisições HTTP/HTTPS
if (app.Environment.IsDevelopment())
{
    // Endpoint OpenAPI
    app.MapOpenApi();

    // Interface do Scalar para testar a API
    app.MapScalarApiReference(options =>
    {
        options.Title = "Primeira API com Scalar";
        options.Theme = ScalarTheme.Default;
        options.ShowSidebar = true;
    });

    // Redireciona a pagina raiz "/" para "/scalar"
    app.MapGet("/", () => Results.Redirect("/scalar"));

}

// Redireciona todas as requisições HTTP para HTTPS
app.UseHttpsRedirection();

// Habilita o uso de CORS com a política "AllowAll" definida anteriormente
app.UseCors("AllowAll");

// Middleware de autenticação (pode ser configurado para proteger endpoints específicos)
app.UseAuthentication();

// Middleware de autorização (pode ser configurado  para proteger endpoints específicos)
app.UseAuthorization();

// Mapeia os controladores para os endpoints da API
app.MapControllers();

// Inicia a aplicação e começa a escutar as requisições
app.Run();