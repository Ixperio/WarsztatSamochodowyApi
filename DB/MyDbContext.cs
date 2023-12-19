using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Xml;
using DB.Entities;
using System;

public class MyDbContext : DbContext
{
    private readonly string _connectionString;

    // Dodaj konstruktor, który przyjmuje DbContextOptions<MyDbContext>
    public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

    //DbSety
    public DbSet<Person> Persons { get; set; }
    public DbSet<UserType> UserTypes { get; set; }
    public DbSet<Samochod> Car { get; set; }
    public DbSet<Marka> Brand { get; set; }
    public DbSet<ModelSamochodu> CarModels { get; set; }
    public DbSet<Paliwo> Fuel { get; set; }
    public DbSet<RodzajeUslug> ServicesTypes { get; set; }
    public DbSet<StatusyZlecen> WorksStatus { get; set; }
    public DbSet<Usluga> Services { get; set; }
    public DbSet<WersjeNadwozia> CarModelType { get; set; }
    public DbSet<Wpis> WordAdnotation { get; set; }
    public DbSet<Zlecenie> Works { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //dodanie ograniczeń na bazę

        modelBuilder.Entity<Usluga>()
       .Property(u => u.Price)
       .HasColumnType("decimal(7, 2)")
       .HasPrecision(7,2);

        //podłączenie w bazie obu tabel do siebie

        //połączenie tabeli Person do tabeli UserType 1-n
        modelBuilder.Entity<Person>()
            .HasOne(p => p.UserType)
            .WithMany(u => u.Persons)
            .HasForeignKey(p => p.rodzajUzytkownika)
            .IsRequired();

        //połączenia na kolejne tabele ModeluSamochodu

        modelBuilder.Entity<ModelSamochodu>()
           .HasOne(p => p.persons)
           .WithMany(u => u.modeleSamochodu)
           .HasForeignKey(p => p.PersonAdderId)
           .IsRequired();

        modelBuilder.Entity<ModelSamochodu>()
            .HasOne(p => p.marka)
            .WithMany(u => u.modeleSamochodu)
            .HasForeignKey(p => p.MarkaId)
            .IsRequired();

        modelBuilder.Entity<ModelSamochodu>()
            .HasOne(p => p.wersjeNadwozia)
            .WithMany(u => u.modeleSamochodu)
            .HasForeignKey(p => p.WersjaId)
            .IsRequired();

        //połączenia na kolejne tabele Samochod

        modelBuilder.Entity<Samochod>()
           .HasOne(p => p.ModelSamochodu)
           .WithMany(u => u.Samochody)
           .HasForeignKey(p => p.ModelSamochoduId)
           .IsRequired();

        modelBuilder.Entity<Samochod>()
          .HasOne(p => p.rodzajPaliwa)
          .WithMany(u => u.Samochody)
          .HasForeignKey(p => p.rodzajPaliwaId)
          .IsRequired();

        modelBuilder.Entity<Samochod>()
          .HasOne(p => p.persons)
          .WithMany(u => u.samochody)
          .HasForeignKey(p => p.WlascicielId)
          .IsRequired();

        //Rodzaje usług 

        modelBuilder.Entity<RodzajeUslug>()
          .HasOne(p => p.person)
          .WithMany(u => u.rodzajeUslug)
          .HasForeignKey(p => p.personId)
          .IsRequired();

        //Wpis

        modelBuilder.Entity<Wpis>()
          .HasOne(p => p.Person)
          .WithMany(u => u.wpisy)
          .HasForeignKey(p => p.PersonId)
          .IsRequired();

        modelBuilder.Entity<Wpis>()
         .HasOne(p => p.Zlecenie)
         .WithMany(u => u.wpisy)
         .HasForeignKey(p => p.ZlecenieId)
         .IsRequired();

        modelBuilder.Entity<Wpis>()
         .HasOne(p => p.usluga)
         .WithMany(u => u.wpisy)
         .HasForeignKey(p => p.UslugaId)
         .IsRequired();

        //zlecenie

        modelBuilder.Entity<Zlecenie>()
        .HasOne(p => p.Person)
        .WithMany(u => u.zlecenia)
        .HasForeignKey(p => p.PersonWorkerId)
        .IsRequired();

        modelBuilder.Entity<Zlecenie>()
        .HasOne(p => p.Samochod)
        .WithMany(u => u.zlecenia)
        .HasForeignKey(p => p.SamochodId)
        .IsRequired();

        modelBuilder.Entity<Zlecenie>()
        .HasOne(p => p.rodzajUslug)
        .WithMany(u => u.zlecenia)
        .HasForeignKey(p => p.rodzajUslugiId)
        .IsRequired();

        modelBuilder.Entity<Zlecenie>()
        .HasOne(p => p.statusZlecenia)
        .WithMany(u => u.zlecenia)
        .HasForeignKey(p => p.statusZleceniaId)
        .IsRequired();

        //marka

        modelBuilder.Entity<Marka>()
       .HasOne(p => p.Person)
       .WithMany(u => u.marki)
       .HasForeignKey(p => p.PersonAdderId)
       .IsRequired();

        //wersjeNadwozia

       modelBuilder.Entity<WersjeNadwozia>()
      .HasOne(p => p.Person)
      .WithMany(u => u.wersjeNadwozia)
      .HasForeignKey(p => p.PersonAdderId)
      .IsRequired();
    }


}