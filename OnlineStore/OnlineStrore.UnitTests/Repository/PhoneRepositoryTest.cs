using FluentAssertions;
using NUnit.Framework;
using OnlineStore.DataAccess;
using OnlineStore.DataAccess.Entities;

namespace OnlineStore.UnitTests.Repository;

public class PhoneRepositoryTest : RepositoryTestsBase
{
    [Test]
    public void GetAllPhonesTest()
    {
        using var context = DbContextFactory.CreateDbContext();

        var manufacturer = new Manufacturer()
        {
            CompanyName = "Test",
            ExternalId = Guid.NewGuid()
        };
        context.Manufacturers.Add(manufacturer);
        context.SaveChanges();

        var processor = new Processor()
        {
            Frequency = 100,
            NumberOfCores = 1,
            Tdp = 13,
            ExternalId = Guid.NewGuid()
        };
        context.Processors.Add(processor);
        context.SaveChanges();

        var phones = new Phone[]
        {
            new Phone()
            {
                Name = "phone",
                Description = "phone",
                Price = 100,
                PhotoUrl = "https://my.media.server/phones/1234",
                StorageSize = 100,
                RamSize = 200,
                ManufacturerId = manufacturer.Id,
                ProcessorId = processor.Id,
                ExternalId = Guid.NewGuid()
            },
            new Phone()
            {
                Name = "phone2",
                Description = "phone2",
                Price = 123,
                PhotoUrl = "https://my.media.server/phones/1235",
                StorageSize = 321,
                RamSize = 123,
                ManufacturerId = manufacturer.Id,
                ProcessorId = processor.Id,
                ExternalId = Guid.NewGuid()
            }
        };
        context.Phones.AddRange(phones);
        context.SaveChanges();

        var repository = new Repository<Phone>(DbContextFactory);
        var actualPhones = repository.GetAll();

        actualPhones.Should()
            .BeEquivalentTo(phones, options => options.Excluding(x => x.Manufacturer).Excluding(x => x.Processor));
    }

    [SetUp]
    public void SetUp()
    {
        CleanUp();
    }

    [TearDown]
    public void TearDown()
    {
        CleanUp();
    }

    private void CleanUp()
    {
        using var context = DbContextFactory.CreateDbContext();
        context.Phones.RemoveRange(context.Phones);
        context.Processors.RemoveRange(context.Processors);
        context.Manufacturers.RemoveRange(context.Manufacturers);
        context.SaveChanges();
    }
}
