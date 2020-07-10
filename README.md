List
-facebook Manager
-facebook Page
-facebook pixel

-https: done
-facebook login
-UI logo-nav and card items -mobile and laptop
-performance
-search and filter
-search unicode with/without vietnamese sign.
-login style and email in vietnamese

-views and like(saved)
-file upload
-details
-my posts
-webcrawler: done

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
### Add new google analytic account
https://marketingplatform.google.com/about/analytics/

### from startup file uncomment to run in https
//app.UseHttpsRedirection();

### Google authentication setting up
https://console.developers.google.com/apis/credentials?project=raovatvietmy
https://www.youtube.com/watch?v=fgzRnlB992s
https://www.youtube.com/watch?v=vkB2yaV7_LQ
https://www.youtube.com/watch?v=V4KqpIX6pdI
Nuget need Microsoft.AspNetCore.Authentication.Google

### Facebook authentication setting
https://developers.facebook.com/apps/594568731175431/fb-login/settings/

### Add background service into project

https://docs.microsoft.com/en-us/aspnet/core/fundamentals/host/hosted-services?view=aspnetcore-3.1&tabs=visual-studio

example

https://github.com/dotnet/AspNetCore.Docs/tree/master/aspnetcore/fundamentals/host/hosted-services/samples/3.x/BackgroundTasksSample

### Generate self signed certificate in Ubuntu

https://www.youtube.com/watch?v=XrZxJsKUQR8
```
(old way)
1- Generate our private key
openssl genrsa 1024 > raovat.key

2- Generate certificate signing request
openssl req -new -key ./raovat.key > raovat.csr

Fill out the questions

Country name (2 letter code): US
State or Province Name: CALIFORNIA
Locality Name: IRVINE
Organizational Name: raovat
Organizational Unit Name: <empty>
Common Name (important): raovat.com
Email Address: tuantrankim@gmail.com

3- Sign certificate with our own key
openssl x509 -in raovat.csr -out raovat.crt -req -signkey raovat.key -days 35600

(new way)
https://www.digitalocean.com/community/tutorials/how-to-create-a-self-signed-ssl-certificate-for-apache-in-ubuntu-18-04
Step 1 – Creating the SSL Certificate
sudo openssl req -x509 -sha256 -nodes -days 36500 -newkey rsa:4096 -keyout /etc/ssl/private/raovat.key -out /etc/ssl/certs/raovat.crt

Step 2 – Configuring Apache to Use SSL
sudo nano /etc/apache2/conf-available/ssl-params.conf

# Copy and paste to the file
SSLCipherSuite EECDH+AESGCM:EDH+AESGCM:AES256+EECDH:AES256+EDH
SSLProtocol All -SSLv2 -SSLv3 -TLSv1 -TLSv1.1
SSLHonorCipherOrder On
# Disable preloading HSTS for now.  You can use the commented out header line that includes
# the "preload" directive if you understand the implications.
# Header always set Strict-Transport-Security "max-age=63072000; includeSubDomains; preload"
Header always set X-Frame-Options DENY
Header always set X-Content-Type-Options nosniff
# Requires Apache >= 2.4
SSLCompression off
SSLUseStapling on
SSLStaplingCache "shmcb:logs/stapling-cache(150000)"
# Requires Apache >= 2.4.11
SSLSessionTickets Off



DO NOT USE default-ssl.conf 

Rename file default-ssl.conf
sudo cp /etc/apache2/sites-available/default-ssl.conf /etc/apache2/sites-available/default-ssl.conf.bak

https://docs.microsoft.com/en-us/aspnet/core/host-and-deploy/linux-apache?view=aspnetcore-3.1

For sharing host. We need to add ServerName and ServerAlias to each virtual host config. 
E.g: raovat.com.conf, shop.com.conf

sudo nano /etc/apache2/sites-available/raovat.com.conf 

<VirtualHost *:*>
    RequestHeader set "X-Forwarded-Proto" expr=%{REQUEST_SCHEME}
</VirtualHost>

<VirtualHost *:80>
    ServerName raovat.com
    ServerAlias *.raovat.com

    RewriteEngine On
    RewriteCond %{HTTPS} !=on
    RewriteRule ^/?(.*) https://%{SERVER_NAME}/$1 [R,L]
</VirtualHost>

<VirtualHost *:443>
    ServerName raovat.com
    ServerAlias *.raovat.com

    ProxyPreserveHost On
    ProxyPass / http://127.0.0.1:5000/
    ProxyPassReverse / http://127.0.0.1:5000/
    ErrorLog /var/log/httpd/helloapp-error.log
    CustomLog /var/log/httpd/helloapp-access.log common
    
    SSLEngine on
    SSLProtocol all -SSLv2
    SSLCipherSuite ALL:!ADH:!EXPORT:!SSLv2:!RC4+RSA:+HIGH:+MEDIUM:!LOW:!RC4
    SSLCertificateFile /etc/ssl/certs/raovat.crt
    SSLCertificateKeyFile /etc/ssl/private/raovat.key
</VirtualHost>


sudo systemctl restart apache2
```

# Google webmaster tool

https://search.google.com/search-console?resource_id=sc-domain%3Araovatvietmy.com&hl=en




#Tool
Resize image upload
https://www.npmjs.com/package/ng2-imageupload

upload image
https://primefaces.org/primeng/showcase/#/fileupload

primeng editor
https://primefaces.org/primeng/showcase/#/editor

ngx-quill editor
https://developer.aliyun.com/mirror/npm/package/ngx-quill-example

Quill ImageResize Module
https://www.npmjs.com/package/quill-image-resize-module

compare trend
https://www.npmtrends.com/@angular/material-vs-primeng-vs-@ng-bootstrap/ng-bootstrap-vs-@ngx-translate/core