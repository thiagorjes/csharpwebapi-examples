# csharpwebapi-examples


Execute on your project:

- dotnet add package Microsoft.Extensions.Configuration.UserSecrets
- dotnet add package Mysql.Data.EntityFrameworkCore
- dotnet add package Microsoft.EntityFrameworkCore
- dotnet add package Microsoft.EntityFrameworkCore.Design

Migrations:

- dotnet ef migrations add InitialCreate
- dotnet ef database update

Secrets to ConnectionStrings:
- dotnet user-secrets init
- dotnet user-secrets set ConnectionStrings.DbName "server=servername;port=3306;user=username;password=passwdOfUser;database=DbName" (Use the connection string of your connection provider, in this case: Mysql)

Using secrets on scaffold:

- dotnet ef dbcontext scaffold Name=ConnectionStrings.DbName Mysql.Data.EntityFrameworkCore -o Models -c ContextName.cs


UPDATE:
 - Para usar user-secrets com migration &eacute; necess&aacute;rio uma s&eacute;rie de adapta&ccedil;&otilde;es.
 - Segue uma sequencia de modificacoes que permitem a utilizacao de "dotnet ef database update" junto com "dotnet ef scaffold ..."



crie as classes

Country, State, City e Neighborhood

(ou faça download do arquivo no GitHub  csharwebapi-examples/sistema)

//Country.cs
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace sistema.Models
{
    public partial class Country
    {
        [Key]
        public int IdCountry { get; set; }
        [StringLength(255)]
        public string Description { get; set; }
        public ICollection<State> States { get; set; }
    }
}

//State
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace sistema.Models
{
    public partial class State
    {
        [Key]
        public int IdState { get; set; }
        [StringLength(255)]
        public string Description { get; set; }
        public int IdCountry { get; set; }
        public Country IdCountryNavigation { get; set; }
        public ICollection<City> Cities { get; set; }
    }
}

//City.cs
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace sistema.Models
{
    public partial class City
    {
        [Key]
        public int IdCity { get; set; }
        [StringLength(255)]
        public string Description { get; set; }
        public int IdState { get; set; }       
        public State IdStateNavigation { get; set; }
        public ICollection<Neighborhood> Neighborhoods { get; set; }
    }
}

//Neighborhood
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace sistema.Models
{
    public partial class Neighborhood
    {
        [Key]
        public int IdNeighborhood { get; set; }
        [StringLength(255)]
        public string Description { get; set; }
        public int IdCity { get; set; }
        public City IdCityNavigation { get; set; }
        public ICollection<AccessToken> AccessToken { get; set; }
       
    }
}


Crie uma pasta CodeFirst dentro da pasta Models
dentro desta pasta crie um arquivo SistemaContext.cs que será uma "continuacao" do SistemaContext.cs criado automaticamente pelo Scaffold do banco.
Adicione neste aquivo as definicoes das novas classes que ainda nao existem no banco de dados.

using Microsoft.EntityFrameworkCore;
using sistema.Models;
namespace sistema.Models{
    public partial class SistemaContext: DbContext{
        
        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<State> State { get; set; }
        public virtual DbSet<City> City { get; set; }
        public virtual DbSet<Neighborhood> Neighborhood { get; set; }
    }
}

Adicione a seguinte linha no metodo ConfigureServices do arquivo Startup.cs
...
	public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

/* CodeFirst line-->*/  services.AddDbContext<SistemaContext>(options=>options.UseMySQL(Configuration.GetConnectionString("Sistema")));

/* Swagger line  -->*/  services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });});
            
        } 
...

Execute os comandos a seguir para adicionar as classes ao migrations e em seguid atualizar o banco de dados

dotnet ef migrations add Country /* serao criados arquivos 20181126111215_Country.cs e 20181126111215_Country.Designer.cs com as definicoes das novas classes a serem adicionadas ao DB*/

dotnet ef database update /* Adiciona as novas deficoes ao DB */
