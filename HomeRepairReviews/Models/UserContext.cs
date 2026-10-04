using Microsoft.EntityFrameworkCore;
namespace HomeRepairReviews.Models;

public class UserContext : DbContext
{
    public DbSet<User> Users { get; set; }

    public UserContext(DbContextOptions<UserContext> options)
        : base(options)
    {
        if (Database.EnsureCreated())
        {
            Users.Add(new User
            {
                FirstName = "Адмін",
                LastName = "",
                Login = "admin",
                Password = "0AEF49652E02A3BC63E001B5E9BDB4C92C7952492A53D882088B0D810A1A9D6A",
                Salt = "adminSalt"
            });

            Users.Add(new User
            {
                FirstName = "Михайло",
                LastName = "Петров",
                Login = "mihailo",
                Password = "FB3B830C43F4632D3D45FFA913D44681E686D9FAE384320FD4DD6FDABC578500",
                Salt = "salt1"
            });

            Users.Add(new User
            {
                FirstName = "Андрій",
                LastName = "Коваль",
                Login = "andriy",
                Password = "25EC7396275DCABDFEA16DB52BA411F7A601BB3BD9D8FF1E944A7DCBD4C26B93",
                Salt = "salt2"
            });

            Users.Add(new User
            {
                FirstName = "Олена",
                LastName = "Шевченко",
                Login = "olena",
                Password = "85478DFF076A38D080B2FBFF2978A2DC022234CB01D90B55F3148E2221F3D854",
                Salt = "salt3"
            });

            Users.Add(new User
            {
                FirstName = "Іван",
                LastName = "Мельник",
                Login = "ivan",
                Password = "E8FC39773B757B66ADCBD70190A032D4D277F6DE6375C6F352B9EF2801E6C0D4",
                Salt = "salt4"
            });

            Users.Add(new User
            {
                FirstName = "Анна",
                LastName = "Бондар",
                Login = "anna",
                Password = "07FAD238459CD74854D3BF5F083FA9C663C054393F4598D2ACB79083712F784A",
                Salt = "salt5"
            });

            Users.Add(new User
            {
                FirstName = "Максим",
                LastName = "Ткаченко",
                Login = "max",
                Password = "DE0CD016F7D8A1114F8BF070E49AA1D4DCB4D3C7EB7BCEE67974736BD49384C8",
                Salt = "salt6"
            });

            Users.Add(new User
            {
                FirstName = "Софія",
                LastName = "Лисенко",
                Login = "sofia",
                Password = "C14546BB3A9F6395549F4E0E3A7593EA8D0CF1D609EDB1D53D0B49E385B763F0",
                Salt = "salt7"
            });

            Users.Add(new User
            {
                FirstName = "Дмитро",
                LastName = "Кравець",
                Login = "dmytro",
                Password = "FBBE7D0D4593F95928D3B9110397F66BD1D0FF09FDA8416A946FF32B216F59F0",
                Salt = "salt8"
            });

            Users.Add(new User
            {
                FirstName = "Катерина",
                LastName = "Романенко",
                Login = "katya",
                Password = "1DAEDFA5E58E2FA042933D8D2323572E9F2BBEAB41D1F16FAD5EE1A33E221CFA",
                Salt = "salt9"
            });

            SaveChanges();
        }
    }
}