using EcomAPI.Payments;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();



var paymentHandler = new PaymentHandler();


app.MapPost("/PaymentHandler", async delegate (HttpContext context)
{
    string jsonstring;
    //using (StreamReader reader = new StreamReader(context.Request.Body, Encoding.UTF8))
    //{

    //     jsonstring = await reader.ReadToEndAsync();


    //}


    return paymentHandler.HandlePaymentAsync("lol");
}).WithName("PaymentHandler")
.WithOpenApi();




app.Run();

