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

            app.MapGet("/accounts", async (PlaceBookingContext db) =>
            await db.Accounts.ToListAsync());
            /*
            app.MapGet("/account/{IdAccount}", async (int idAccount, PlaceBookingContext db) =>
                await db.Accounts.FindAsync(idAccount)
                    is Account account ? Results.Ok(account) : Results.NotFound());
            */
            app.MapGet("/account/{Email}", async (string Email, PlaceBookingContext db) =>
                await db.Accounts.FirstOrDefaultAsync(acc => acc.Email == Email)
                    is Account account ? Results.Ok(account) : Results.NotFound());

            app.MapGet("/account/{Email}/{Password}", async (string Email, string Password, PlaceBookingContext db) =>
                await db.Accounts.FirstOrDefaultAsync(acc => acc.Email == Email && acc.Password == Password)
                    is Account account ? Results.Ok(account) : Results.NotFound());           

            app.MapPost("/account", async (Account inputAccount, PlaceBookingContext db) =>
            {
                Account newAcc = new();
                newAcc.Name = inputAccount.Name;
                newAcc.Email = inputAccount.Email;
                newAcc.Password = WorkFunctionsClass.Hashing(inputAccount.Password);
                newAcc.DateOfBirthday = inputAccount.DateOfBirthday;
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

            app.MapGet("/image/{IdImage}", async (int IdImage, PlaceBookingContext db) =>
            await db.Images.FindAsync(IdImage)
                    is Image image ? Results.Ok(image) : Results.NotFound());

            app.MapPost("/image", async (Image inputImage, PlaceBookingContext db) =>
            {
                db.Images.Add(inputImage);
                await db.SaveChangesAsync();

                return Results.Ok(inputImage);
            });

            app.Run();
        }
    }
}