using API.Models;
using WorkFunctions;
using Microsoft.EntityFrameworkCore;
//using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;

namespace API
{
    class Program
    {
        static public Account Clone(Account inputAccount, Account editAccount)
        {
            editAccount.Name = inputAccount.Name;
            editAccount.Email = inputAccount.Email;
            editAccount.Password = inputAccount.Password;
            editAccount.DateOfBirthday = inputAccount.DateOfBirthday;
            editAccount.IdImage = inputAccount.IdImage;
            return editAccount;
        }
        static public void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<PlaceBookingContext>();

            var app = builder.Build();

            ////////////// Account functions

            app.MapGet("/accounts", async (PlaceBookingContext db) =>
            await db.Accounts.ToListAsync());
            
            /*app.MapGet("/account/{IdAccount}", async (int idAccount, PlaceBookingContext db) =>
                await db.Accounts.FirstOrDefaultAsync(acc => acc.IdAccount == idAccount)
                    is Account account ? Results.Ok(account) : Results.NotFound());*/

            app.MapGet("/account/{Email}", async (string Email, PlaceBookingContext db) =>
                await db.Accounts.FirstOrDefaultAsync(acc => acc.Email == Email)
                    is Account account ? Results.Ok(account) : Results.NotFound());

            app.MapGet("/account/{Email}/{Password}", async (string Email, string Password, PlaceBookingContext db) =>
                await db.Accounts.FirstOrDefaultAsync(acc => acc.Email == Email && acc.Password == WorkFunctionsClass.Hashing(Password))
                    is Account account ? Results.Ok(account) : Results.NotFound()) ;           

            app.MapPost("/account", async (Account inputAccount, PlaceBookingContext db) =>
            {
                Account newAcc = new();
                newAcc.Name = inputAccount.Name;
                newAcc.Email = inputAccount.Email;
                newAcc.Password = WorkFunctionsClass.Hashing(inputAccount.Password);
                newAcc.DateOfBirthday = inputAccount.DateOfBirthday;
                newAcc.Role = inputAccount.Role;
                newAcc.IdImage = inputAccount.IdImage;
                db.Accounts.Add(newAcc);
                await db.SaveChangesAsync();

                return Results.Ok(newAcc);
            });

            app.MapPut("/account/{idAccount}", async (int idAccount, Account inputAccount, PlaceBookingContext db) =>
            {
                var account = await db.Accounts.FindAsync(idAccount);
                if (account is null)
                {
                    return Results.NotFound();
                }

                account = Clone(inputAccount, account);

                await db.SaveChangesAsync();
                return Results.Ok(account);
            });

            app.MapDelete("/account/{IdAccount}", async (int idAccount, PlaceBookingContext db) =>
            {
                if (await db.Accounts.FindAsync(idAccount) is Account account)
                {
                    db.Accounts.Remove(account);
                    await db.SaveChangesAsync();
                    return Results.Ok(account);
                }
                return Results.NotFound();
            });

            ////////////// Image functions

            app.MapGet("/image/{IdImage}", async (int IdImage, PlaceBookingContext db) =>
            await db.Images.FindAsync(IdImage)
                    is Image image ? Results.Ok(image) : Results.NotFound());

            app.MapPost("/image", async (Image inputImage, PlaceBookingContext db) =>
            {
                db.Images.Add(inputImage);
                await db.SaveChangesAsync();

                return Results.Ok(inputImage);
            });

            ////////////// Cinema functions
            
            app.MapGet("/cinemas", async (PlaceBookingContext db) =>
            await db.Cinemas.ToListAsync());

            /*app.MapGet("/cinema/{IdCinema}", async (int IdCinema, PlaceBookingContext db) =>
                await db.Cinemas.FirstOrDefaultAsync(cin => cin.IdCinema == IdCinema)
                    is Cinema cinema ? Results.Ok(cinema) : Results.NotFound());*/

            app.MapGet("/cinema/{cityName}", async (string cityName, PlaceBookingContext db) =>
            {
                return await db.Cinemas.Where(cinema => cinema.CityName == cityName).ToListAsync();
            });


            app.MapGet("/cinema/{Name}/{CityName}", async (string Name, string CityName, PlaceBookingContext db) =>
                await db.Cinemas.FirstOrDefaultAsync(cin => cin.Name == Name && cin.CityName == CityName)
                    is Cinema cinema ? Results.Ok(cinema) : Results.NotFound());

            app.MapPost("/cinema", async (Cinema inputCinema, PlaceBookingContext db) =>
            {
                Cinema newCinema = new();
                newCinema.Name = inputCinema.Name;
                newCinema.Address = inputCinema.Address;
                newCinema.CityName = inputCinema.CityName;

                db.Cinemas.Add(newCinema);
                await db.SaveChangesAsync();

                return Results.Ok(newCinema);
            });

            ////////////// Cities functions

            app.MapGet("/cities", async (PlaceBookingContext db) =>
             await db.Cinemas.Select(cinema => cinema.CityName).Distinct().ToListAsync()
            );

            app.Run();
        }
    }
}