using FluentAssertions;
using NUnit.Framework;
using OnlineStore.DataAccess;
using OnlineStore.DataAccess.Entities;

namespace OnlineStore.UnitTests.Repository;

[TestFixture]
[Category("Integration")]
public class UserRepositoryTest : RepositoryTestsBase
{
    [Test]
    public void GetAllUsersTest()
    {
        using var context = DbContextFactory.CreateDbContext();

        var users = new User[]
        {
            new User()
            {
                Login = "User1",
                PasswordHash = "hashhash",
                ExternalId = Guid.NewGuid()
            },
            new User()
            {
                Login = "User2",
                PasswordHash = "hashhash",
                ExternalId = Guid.NewGuid()
            }
        };
        context.Users.AddRange(users);
        context.SaveChanges();

        var repository = new Repository<User>(DbContextFactory);
        var actualUsers = repository.GetAll();

        actualUsers.Should().BeEquivalentTo(users);
    }

    [Test]
    public void UpdateUserTest()
    {
        using var context = DbContextFactory.CreateDbContext();

        var user = new User()
        {
            Login = "User1",
            PasswordHash = "hashhash",
            ExternalId = Guid.NewGuid()
        };
        context.Users.Add(user);
        context.SaveChanges();

        user.Login = "User2";
        user.PasswordHash = "hash";
        var repository = new Repository<User>(DbContextFactory);
        repository.Save(user);

        var actualUser = context.Users.SingleOrDefault();
        actualUser.Should().BeEquivalentTo(user);
    }

    [Test]
    public void DeleteUserTest()
    {
        using var context = DbContextFactory.CreateDbContext();

        var user = new User()
        {
            Login = "User1",
            PasswordHash = "hashhash",
            ExternalId = Guid.NewGuid()
        };
        context.Users.Add(user);
        context.SaveChanges();

        var repository = new Repository<User>(DbContextFactory);
        repository.Delete(user);

        context.Users.Count().Should().Be(0);
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
        context.Users.RemoveRange(context.Users);
        context.SaveChanges();
    }
}
