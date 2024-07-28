using System;
using System.Collections.Generic;
using AccountManagementModels;

namespace AccountManagementData
{
    public class UserData
    {
        private List<User> users;

        public UserData()
        {
            users = new List<User>();
            UserFactory _userFactory = new UserFactory();
            users = _userFactory.GetDummyUsers();
        }

        public List<User> GetUsers()
        {
            return users;
        }

        public List<User> GetUsersByStatus(int status)
        {
            return users.FindAll(user => user.status == status);
        }

        public void AddUser(User user)
        {
            users.Add(user);
        }

        public void UpdateUser(User user)
        {
            for (int i = 0; i < users.Count; i++)
            {
                if (users[i].username == user.username)
                {
                    users[i].profile = user.profile;
                    users[i].username = user.username;
                    users[i].dateUpdated = DateTime.Now;
                    users[i].status = user.status;
                }
            }
        }
    }

    public class UserFactory
    {
        private List<User> dummyUsers = new List<User>();

        public List<User> GetDummyUsers()
        {
            dummyUsers.Add(CreateDummyUser("Admin123!", "Admin", "Admin@pup.com"));
            dummyUsers.Add(CreateDummyUser("Test123!", "Test", "Test@pup.com"));
            dummyUsers.Add(CreateDummyUser("Hello123!", "Hello", "Hello@pup.com"));
            dummyUsers.Add(CreateDummyUser("Bye123!", "Bye", "Bye@pup.com"));
            return dummyUsers;
        }

        private User CreateDummyUser(string password, string username, string emailaddress)
        {
            User user = new User
            {
                username = username,
                password = password,
                profile = new UserProfile { emailAddress = emailaddress, profileName = username },
                dateUpdated = DateTime.Now,
                dateVerified = DateTime.Now.AddDays(1),
                status = 1
            };
            return user;
        }
    }
}
