NugetPackage: uninstall EntityFrameworkCore.SQLServer -> install EntityFrameworkCore.PostgreSQL
Replace
.Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
by
.Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
has solved the problem.