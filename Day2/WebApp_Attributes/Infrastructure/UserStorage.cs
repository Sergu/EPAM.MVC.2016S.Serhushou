using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApp_Attributes.Models;

namespace WebApp_Attributes.Infrastructure
{
    public class UserStorage
    {
        private static UserStorage instance;
        private static object syncRoot = new object();

        private UserStorage() { }

        private List<UserView> users = new List<UserView>();

        public static IEnumerable<UserView> GetUsers()
        {
            InstanceCreationCheck();
            return instance.users;
        }
        public static void AddUser(UserView user)
        {
            InstanceCreationCheck();
            instance.users.Add(user);
        }

        public static bool RemoveUser(string surname)
        {
            InstanceCreationCheck();
            var user = instance.users.FirstOrDefault(u => u.Surname == surname);
            if (!ReferenceEquals(user, null))
            {
                return instance.users.Remove(user);
            }
            return false;
        }

        private static void InstanceCreationCheck()
        {
            if (instance == null)
            {
                lock (syncRoot)
                {
                    if (instance == null)
                        instance = new UserStorage();
                }
            }
        }

    }
}