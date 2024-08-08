using Domain;
using Microsoft.AspNetCore.Identity;

namespace Persistence
{
  public class Seed
  {
    public static async Task SeedData(DataContext context, UserManager<AppUser> userManager)
    {
      if (!userManager.Users.Any())
      {
        var users = new  List<AppUser>
        {
          new AppUser{DisplayName = "BOB", UserName = "bob", Email = "bob@test.com"},
          new AppUser{DisplayName = "TOM", UserName = "tom", Email = "tom@test.com"},
          new AppUser{DisplayName = "JON", UserName = "jon", Email = "jon@test.com"},
        };

        foreach (var user in users)
        {
          await userManager.CreateAsync(user, "Pa$$w0rd");
        }
      }


      if (context.Activities.Any()) return;

      var activities = new List<Activity>
      {
        new Activity
        {
          Name = "Past Activity 1",
          Date = DateTime.UtcNow.AddMonths(2),
          Description = "Activity 2 months in the future",
          Category = "film",
          City = "London",
        },
        new Activity
        {
          Name = "Past Activity 2",
          Date = DateTime.UtcNow.AddMonths(3),
          Description = "Activity 3 months in the future",
          Category = "film",
          City = "Singapore",
        },
        new Activity
        {
          Name = "Past Activity 3",
          Date = DateTime.UtcNow.AddMonths(4),
          Description = "Activity 4 months in the future",
          Category = "Orchestra",
          City = "Manchester",
        }
      };

      await context.Activities.AddRangeAsync(activities);
      await context.SaveChangesAsync();
      
    }
  }
}
