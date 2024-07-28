using System;
using AccountManagementModels;
using AccountManagementData;

public class Program
{
    public static void Main(string[] args)
    {
        UserData userData = new UserData();

        // 1. Display all users with a status of 1 (Active)
        Console.WriteLine("Active Users:");
        var activeUsers = userData.GetUsersByStatus(1);
        foreach (var user in activeUsers)
        {
            Console.WriteLine($"Username: {user.username}, Email: {user.profile.emailAddress}, Status: {user.status}");
        }

        // 2. Create at least 2 new users
        userData.AddUser(new User
        {
            username = "NewUser1",
            password = "New1!",
            profile = new UserProfile { emailAddress = "newuser1@pup.com", profileName = "NewUser1" },
            dateUpdated = DateTime.Now,
            dateVerified = DateTime.Now.AddDays(1),
            status = 1
        });

        userData.AddUser(new User
        {
            username = "NewUser2",
            password = "New2!",
            profile = new UserProfile { emailAddress = "newuser2@pup.com", profileName = "NewUser2" },
            dateUpdated = DateTime.Now,
            dateVerified = DateTime.Now.AddDays(1),
            status = 1
        });

        // 3. Deactivate or update the initial users' status to 2 (Inactive)
        foreach (var user in activeUsers)
        {
            user.status = 2;
            userData.UpdateUser(user);
        }

        // 4. Display all users with a status of 2 (Inactive)
        Console.WriteLine("Inactive Users:");
        var inactiveUsers = userData.GetUsersByStatus(2);
        foreach (var user in inactiveUsers)
        {
            Console.WriteLine($"Username: {user.username}, Email: {user.profile.emailAddress}, Status: {user.status}");
        }
    }
}

