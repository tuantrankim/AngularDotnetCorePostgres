### Icon
https://www.iconfinder.com/icons/1222769/facebook_ads_facebook_marketing_marketing_icon

### Favicon convert
https://favicon.io/favicon-converter/

### Support for ASP.NET Core Identity was added to your project.

For setup and configuration information, see https://go.microsoft.com/fwlink/?linkid=2116645.

## Setup

NugetPackage: uninstall EntityFrameworkCore.SQLServer -> install EntityFrameworkCore.PostgreSQL
Replace
.Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
by
.Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
has solved the problem.


### Create new component in app module when more than one module
ng g c create-post --module app

### Enable Swagger
#### Install nuget package
 Swashbuckle.AspNetCore
 ```
 Open Startup.cs file to add swagger service to middleware. Like:
public void ConfigureServices(IServiceCollection services)
{
    services.AddMvc();
    services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new Info
        {
            Version = "v1",
            Title = "My API",
            Description = "My First ASP.NET Core Web API",
            TermsOfService = "None",
            Contact = new Contact() { Name = "Talking Dotnet", Email = "contact@talkingdotnet.com", Url = "www.talkingdotnet.com" }
        });
    });
}

And enable the Swagger UI in Configure() method.
public void Configure(IApplicationBuilder app, IHostingEnvironment env)
{
    if (env.IsDevelopment())
    {
        app.UseDeveloperExceptionPage();
    }

    app.UseMvc();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
    });
}

```
### Add migration
PM> add-migration addNewColumn

### Remove last migration
PM> remove-migration

### Entity framework code first. Update database using Package Manager Console
PM> update-database

### Rollback or update database to a migration
PM> update-database 20200524180826_add_states_cities




### Generate sql script from database
```
    # Powershell / Package manager console
    Script-Migration

    # Cli 
    dotnet ef migrations script

    upload to ec2 ~/postgres-script
    ssh to ~/postgres-script
    -login as posgres
    psql posgres
    -create database
    CREATE DATABASE raovat;
    - or drop database
    DROP DATABASE raovat;
    - exit
    \q
    - connect to database raovat
    psql raovat
    - Execute a sql script test.sql
    \i ~\PATH\TO\test.sql


```
