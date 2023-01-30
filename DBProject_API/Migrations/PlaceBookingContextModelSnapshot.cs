﻿// <auto-generated />
using System;
using API;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DBProjectAPI.Migrations
{
    [DbContext(typeof(PlaceBookingContext))]
    partial class PlaceBookingContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("API.Models.Account", b =>
                {
                    b.Property<int>("IdAccount")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id_account");

                    NpgsqlPropertyBuilderExtensions.UseIdentityAlwaysColumn(b.Property<int>("IdAccount"));

                    b.Property<string>("DateOfBirthday")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("date_of_birthday");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("character varying(80)")
                        .HasColumnName("email");

                    b.Property<int?>("IdImage")
                        .HasColumnType("integer")
                        .HasColumnName("id_image");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("name");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("character varying(70)")
                        .HasColumnName("password");

                    b.Property<short>("Role")
                        .HasColumnType("smallint")
                        .HasColumnName("role");

                    b.HasKey("IdAccount")
                        .HasName("user_pkey");

                    b.HasIndex("IdImage");

                    b.ToTable("account", (string)null);
                });

            modelBuilder.Entity("API.Models.Actor", b =>
                {
                    b.Property<int>("IdActor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id_actor");

                    NpgsqlPropertyBuilderExtensions.UseIdentityAlwaysColumn(b.Property<int>("IdActor"));

                    b.Property<int?>("IdImage")
                        .HasColumnType("integer")
                        .HasColumnName("id_image");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("name");

                    b.HasKey("IdActor")
                        .HasName("actor_pkey");

                    b.HasIndex("IdImage");

                    b.ToTable("actor", (string)null);
                });

            modelBuilder.Entity("API.Models.Booking", b =>
                {
                    b.Property<int>("IdBooking")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id_booking");

                    NpgsqlPropertyBuilderExtensions.UseIdentityAlwaysColumn(b.Property<int>("IdBooking"));

                    b.Property<int>("BookingCode")
                        .HasColumnType("integer")
                        .HasColumnName("booking_code");

                    b.Property<string>("DateTime")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("date_time");

                    b.Property<int>("IdAccount")
                        .HasColumnType("integer")
                        .HasColumnName("id_account");

                    b.Property<int>("IdPlace")
                        .HasColumnType("integer")
                        .HasColumnName("id_place");

                    b.Property<int>("IdSession")
                        .HasColumnType("integer")
                        .HasColumnName("id_session");

                    b.HasKey("IdBooking")
                        .HasName("booking_pkey");

                    b.HasIndex("IdAccount");

                    b.HasIndex("IdPlace");

                    b.HasIndex("IdSession");

                    b.ToTable("booking", (string)null);
                });

            modelBuilder.Entity("API.Models.Cinema", b =>
                {
                    b.Property<int>("IdCinema")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id_cinema");

                    NpgsqlPropertyBuilderExtensions.UseIdentityAlwaysColumn(b.Property<int>("IdCinema"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("character varying(80)")
                        .HasColumnName("address");

                    b.Property<string>("CityName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("city_name");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(44)
                        .HasColumnType("character varying(44)")
                        .HasColumnName("name");

                    b.HasKey("IdCinema")
                        .HasName("Cinema_pkey");

                    b.ToTable("cinema", (string)null);
                });

            modelBuilder.Entity("API.Models.Film", b =>
                {
                    b.Property<int>("IdFilm")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id_film");

                    NpgsqlPropertyBuilderExtensions.UseIdentityAlwaysColumn(b.Property<int>("IdFilm"));

                    b.Property<short>("AgeRating")
                        .HasColumnType("smallint")
                        .HasColumnName("age_rating");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1600)
                        .HasColumnType("character varying(1600)")
                        .HasColumnName("description");

                    b.Property<string>("Duration")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("duration");

                    b.Property<int?>("IdImage")
                        .HasColumnType("integer")
                        .HasColumnName("id_image");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(113)
                        .HasColumnType("character varying(113)")
                        .HasColumnName("name");

                    b.HasKey("IdFilm")
                        .HasName("film_pkey");

                    b.ToTable("film", (string)null);
                });

            modelBuilder.Entity("API.Models.Hall", b =>
                {
                    b.Property<int>("IdHall")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id_hall");

                    NpgsqlPropertyBuilderExtensions.UseIdentityAlwaysColumn(b.Property<int>("IdHall"));

                    b.Property<short>("Capacity")
                        .HasColumnType("smallint")
                        .HasColumnName("capacity");

                    b.Property<int>("IdCinema")
                        .HasColumnType("integer")
                        .HasColumnName("id_cinema");

                    b.Property<short>("Number")
                        .HasColumnType("smallint")
                        .HasColumnName("number");

                    b.Property<short>("Type")
                        .HasColumnType("smallint")
                        .HasColumnName("type");

                    b.HasKey("IdHall")
                        .HasName("hall_pkey");

                    b.HasIndex("IdCinema");

                    b.ToTable("hall", (string)null);
                });

            modelBuilder.Entity("API.Models.Image", b =>
                {
                    b.Property<int>("IdImage")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id_image");

                    NpgsqlPropertyBuilderExtensions.UseIdentityAlwaysColumn(b.Property<int>("IdImage"));

                    b.Property<int>("IdEntity")
                        .HasColumnType("integer")
                        .HasColumnName("id_entity");

                    b.Property<short>("Type")
                        .HasColumnType("smallint")
                        .HasColumnName("type");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasMaxLength(5000)
                        .HasColumnType("character varying(5000)")
                        .HasColumnName("url");

                    b.HasKey("IdImage")
                        .HasName("image_pkey");

                    b.ToTable("image", (string)null);
                });

            modelBuilder.Entity("API.Models.Place", b =>
                {
                    b.Property<int>("IdPlace")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id_place");

                    NpgsqlPropertyBuilderExtensions.UseIdentityAlwaysColumn(b.Property<int>("IdPlace"));

                    b.Property<int>("IdHall")
                        .HasColumnType("integer")
                        .HasColumnName("id_hall");

                    b.Property<short>("Place1")
                        .HasColumnType("smallint")
                        .HasColumnName("place");

                    b.Property<short>("Row")
                        .HasColumnType("smallint")
                        .HasColumnName("row");

                    b.HasKey("IdPlace")
                        .HasName("place_pkey");

                    b.HasIndex("IdHall");

                    b.ToTable("place", (string)null);
                });

            modelBuilder.Entity("API.Models.Role", b =>
                {
                    b.Property<int>("IdRole")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id_role");

                    NpgsqlPropertyBuilderExtensions.UseIdentityAlwaysColumn(b.Property<int>("IdRole"));

                    b.Property<int>("IdActor")
                        .HasColumnType("integer")
                        .HasColumnName("id_actor");

                    b.Property<int>("IdFilm")
                        .HasColumnType("integer")
                        .HasColumnName("id_film");

                    b.Property<string>("NamePersonage")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("character varying(80)")
                        .HasColumnName("name_personage");

                    b.HasKey("IdRole")
                        .HasName("role_pkey");

                    b.HasIndex("IdActor");

                    b.HasIndex("IdFilm");

                    b.ToTable("role", (string)null);
                });

            modelBuilder.Entity("API.Models.Session", b =>
                {
                    b.Property<int>("IdSession")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id_session");

                    NpgsqlPropertyBuilderExtensions.UseIdentityAlwaysColumn(b.Property<int>("IdSession"));

                    b.Property<DateTimeOffset>("DateTime")
                        .HasColumnType("time with time zone")
                        .HasColumnName("date_time");

                    b.Property<int>("IdFilm")
                        .HasColumnType("integer")
                        .HasColumnName("id_film");

                    b.Property<int>("IdHall")
                        .HasColumnType("integer")
                        .HasColumnName("id_hall");

                    b.HasKey("IdSession")
                        .HasName("session_pkey");

                    b.HasIndex("IdFilm");

                    b.HasIndex("IdHall");

                    b.ToTable("session", (string)null);
                });

            modelBuilder.Entity("API.Models.Account", b =>
                {
                    b.HasOne("API.Models.Image", "IdImageNavigation")
                        .WithMany("Accounts")
                        .HasForeignKey("IdImage")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("account_id_image_fkey");

                    b.Navigation("IdImageNavigation");
                });

            modelBuilder.Entity("API.Models.Actor", b =>
                {
                    b.HasOne("API.Models.Image", "IdImageNavigation")
                        .WithMany("Actors")
                        .HasForeignKey("IdImage")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("actor_id_image_fkey");

                    b.Navigation("IdImageNavigation");
                });

            modelBuilder.Entity("API.Models.Booking", b =>
                {
                    b.HasOne("API.Models.Account", "IdAccountNavigation")
                        .WithMany("Bookings")
                        .HasForeignKey("IdAccount")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("booking_id_account_fkey");

                    b.HasOne("API.Models.Place", "IdPlaceNavigation")
                        .WithMany("Bookings")
                        .HasForeignKey("IdPlace")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("booking_id_place_fkey");

                    b.HasOne("API.Models.Session", "IdSessionNavigation")
                        .WithMany("Bookings")
                        .HasForeignKey("IdSession")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("booking_id_session_fkey");

                    b.Navigation("IdAccountNavigation");

                    b.Navigation("IdPlaceNavigation");

                    b.Navigation("IdSessionNavigation");
                });

            modelBuilder.Entity("API.Models.Hall", b =>
                {
                    b.HasOne("API.Models.Cinema", "IdCinemaNavigation")
                        .WithMany("Halls")
                        .HasForeignKey("IdCinema")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("hall_id_cinema_fkey");

                    b.Navigation("IdCinemaNavigation");
                });

            modelBuilder.Entity("API.Models.Place", b =>
                {
                    b.HasOne("API.Models.Hall", "IdHallNavigation")
                        .WithMany("Places")
                        .HasForeignKey("IdHall")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("place_id_hall_fkey");

                    b.Navigation("IdHallNavigation");
                });

            modelBuilder.Entity("API.Models.Role", b =>
                {
                    b.HasOne("API.Models.Actor", "IdActorNavigation")
                        .WithMany("Roles")
                        .HasForeignKey("IdActor")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("role_id_actor_fkey");

                    b.HasOne("API.Models.Film", "IdFilmNavigation")
                        .WithMany("Roles")
                        .HasForeignKey("IdFilm")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("role_id_film_fkey");

                    b.Navigation("IdActorNavigation");

                    b.Navigation("IdFilmNavigation");
                });

            modelBuilder.Entity("API.Models.Session", b =>
                {
                    b.HasOne("API.Models.Film", "IdFilmNavigation")
                        .WithMany("Sessions")
                        .HasForeignKey("IdFilm")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("session_id_film_fkey");

                    b.HasOne("API.Models.Hall", "IdHallNavigation")
                        .WithMany("Sessions")
                        .HasForeignKey("IdHall")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("session_id_hall_fkey");

                    b.Navigation("IdFilmNavigation");

                    b.Navigation("IdHallNavigation");
                });

            modelBuilder.Entity("API.Models.Account", b =>
                {
                    b.Navigation("Bookings");
                });

            modelBuilder.Entity("API.Models.Actor", b =>
                {
                    b.Navigation("Roles");
                });

            modelBuilder.Entity("API.Models.Cinema", b =>
                {
                    b.Navigation("Halls");
                });

            modelBuilder.Entity("API.Models.Film", b =>
                {
                    b.Navigation("Roles");

                    b.Navigation("Sessions");
                });

            modelBuilder.Entity("API.Models.Hall", b =>
                {
                    b.Navigation("Places");

                    b.Navigation("Sessions");
                });

            modelBuilder.Entity("API.Models.Image", b =>
                {
                    b.Navigation("Accounts");

                    b.Navigation("Actors");
                });

            modelBuilder.Entity("API.Models.Place", b =>
                {
                    b.Navigation("Bookings");
                });

            modelBuilder.Entity("API.Models.Session", b =>
                {
                    b.Navigation("Bookings");
                });
#pragma warning restore 612, 618
        }
    }
}
