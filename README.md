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

###quoc