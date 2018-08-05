using System;
using Tangent.Employee.Core.Models;

namespace Tangent.Employee.Droid.Utils
{
    public class UserProfileSingleton
    {
        private UserProfile userProfile = null;

        private static UserProfileSingleton _instance = new UserProfileSingleton();

        public UserProfileSingleton()
        {
        }

        public static UserProfileSingleton Instance
        {
            get
            {
                return _instance;
            }
        }

        public UserProfile GetUserProfile()
        {
            return userProfile;
        }

        public void SetUserProfile(UserProfile userProfile)
        {
            this.userProfile = userProfile;
        }
    }
}
