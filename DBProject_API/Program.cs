using API.Models;
using WorkFunctions;
using Microsoft.EntityFrameworkCore;
//using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;

namespace API
{
    class Program
    {
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
                var editAccount = await db.Accounts.FindAsync(idAccount);
                if (editAccount is null)
                {
                    return Results.NotFound();
                }

                editAccount.Name = inputAccount.Name;
                editAccount.Email = inputAccount.Email;
                editAccount.Password = inputAccount.Password;
                editAccount.DateOfBirthday = inputAccount.DateOfBirthday;
                editAccount.IdImage = inputAccount.IdImage;

                await db.SaveChangesAsync();
                return Results.Ok(editAccount);
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

            app.MapPut("/editCinema", async (Cinema inputCinema, PlaceBookingContext db) =>
            {
                var editCinema = await db.Cinemas.FindAsync(inputCinema.IdCinema);
                if (editCinema is null)
                {
                    return Results.NotFound();
                }
                editCinema.Name = inputCinema.Name;
                editCinema.CityName = inputCinema.CityName;
                editCinema.Address = inputCinema.Address;

                await db.SaveChangesAsync();
                return Results.Ok(editCinema);
            });

            app.MapDelete("/cinema/{idCinema}", async (int idCinema, PlaceBookingContext db) =>
            {
                if (await db.Cinemas.FindAsync(idCinema) is Cinema cinema)
                {
                    db.Cinemas.Remove(cinema);
                    await db.SaveChangesAsync();
                    return Results.Ok(cinema);
                }
                return Results.NotFound();
            });

            ////////////// Cities functions

            app.MapGet("/cities", async (PlaceBookingContext db) =>
             await db.Cinemas.Select(cinema => cinema.CityName).Distinct().ToListAsync()
            );

            ////////////// Actors functions

            app.MapGet("/actors", async (PlaceBookingContext db) =>
             await db.Actors.ToListAsync());

            app.MapPost("/actor", async (Actor inputActor, PlaceBookingContext db) =>
            {
                Actor newAct = new();
                newAct.Name = inputActor.Name;
                
                db.Actors.Add(newAct);
                await db.SaveChangesAsync();

                return Results.Ok(newAct);
            });

            ////////////// Role functions

            app.MapGet("/roles", async (PlaceBookingContext db) =>
             await db.Roles.ToListAsync());

            app.MapPost("/role", async (Role inputRole, PlaceBookingContext db) =>
            {
                Role newRole = new();
                newRole.IdActor = inputRole.IdActor;
                newRole.IdFilm = inputRole.IdFilm;
                newRole.NamePersonage = inputRole.NamePersonage;

                db.Roles.Add(newRole);
                await db.SaveChangesAsync();

                return Results.Ok(newRole);
            });

            ////////////// Film functions

            app.MapGet("/films", async (PlaceBookingContext db) =>
             await db.Films.ToListAsync());

            app.MapPost("/film", async (Film inputFilm, PlaceBookingContext db) =>
            {
                Film newFilm = new();
                newFilm.Duration = inputFilm.Duration;
                newFilm.Name = inputFilm.Name;
                newFilm.AgeRating = inputFilm.AgeRating;
                newFilm.Description = inputFilm.Description;

                db.Films.Add(newFilm);
                await db.SaveChangesAsync();

                return Results.Ok(newFilm);
            });

            app.Run();
        }
    }
}