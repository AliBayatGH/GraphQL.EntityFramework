using GraphiQl;
using GraphQL.EntityFramework;
using GraphQL;
using GraphQL.Types;
using Microsoft.EntityFrameworkCore;
using testIdentity;
using GraphQL.MicrosoftDI;
using GraphQL.Server;
using GraphQL.SystemTextJson;
using System.IO;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        EfGraphQLConventions.RegisterInContainer<SampleDbContext>(
            services,
            model: SampleDbContext.StaticModel);
        EfGraphQLConventions.RegisterConnectionTypesInContainer(services);

        //foreach (var type in GetGraphQlTypes())
        //{
        //    services.AddSingleton(type);
        //}

        //var dbContextBuilder = new DbContextBuilder();
        //services.AddSingleton<IHostedService>(dbContextBuilder);
        //services.AddSingleton<Func<SampleDbContext>>(_ => dbContextBuilder.BuildDbContext);
        //services.AddScoped(_ => dbContextBuilder.BuildDbContext());

        services.AddDbContext<SampleDbContext>(options => options.UseSqlServer("Data Source=.;Initial Catalog=GraphQLEntityFrameworkSample;User Id=sa; Password=123456;TrustServerCertificate=True"));
        services.AddSingleton<IDocumentExecuter, EfDocumentExecuter>();

        //services.AddSingleton<ISchema, Schema>();
        var mvc = services.AddMvc(option => option.EnableEndpointRouting = false);


        services.AddGraphQL(gbuilder => gbuilder
       .AddHttpMiddleware<Schema>()
       .AddSchema<Schema>(GraphQL.DI.ServiceLifetime.Scoped)
       .AddSystemTextJson()
       .AddGraphTypes(typeof(Schema).Assembly));
        mvc.AddNewtonsoftJson();
    }

    static IEnumerable<Type> GetGraphQlTypes() =>
        typeof(Startup).Assembly
            .GetTypes()
            .Where(x => !x.IsAbstract &&
                        (typeof(IObjectGraphType).IsAssignableFrom(x) ||
                         typeof(IInputObjectGraphType).IsAssignableFrom(x)));

    public void Configure(IApplicationBuilder builder)
    {
        //SeedData.EnsureSeedData(builder);
        builder.UseWebSockets();
//builder.UseGraphQLWebSockets<ISchema>();
//builder.UseGraphiQl("/graphiql", "/graphql");
        builder.UseGraphQLGraphiQL(path : "/ui/graphiql");
        builder.UseMvc();

    }
}