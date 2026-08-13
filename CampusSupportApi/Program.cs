// Creates the builder used to configure the application.
var builder = WebApplication.CreateBuilder(args);


// Registers controller support with ASP.NET Core.
builder.Services.AddControllers();


// Allows ASP.NET Core to discover API endpoints
// for OpenAPI and Swagger documentation.
builder.Services.AddEndpointsApiExplorer();


// Registers the Swagger generator.
builder.Services.AddSwaggerGen();


// Builds the configured web application.
var app = builder.Build();


// Checks whether the application is running
// in the Development environment.
if (app.Environment.IsDevelopment())
{
    // Creates the Swagger JSON document.
    app.UseSwagger();


    // Enables the interactive Swagger web page.
    app.UseSwaggerUI();
}


// Redirects HTTP requests to HTTPS.
app.UseHttpsRedirection();


// Enables the ASP.NET Core authorization middleware.
app.UseAuthorization();


// Connects our controller routes to the application.
app.MapControllers();


// Starts the web application.
app.Run();
