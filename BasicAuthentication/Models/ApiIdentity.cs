using BasicAuthentication.Models;
using System;
using System.Security.Principal;

public class ApiIdentity : IIdentity
{
    public User User
    {
        get;
        private set;
    }
    public ApiIdentity(User user)
    {
        if (user == null) throw new ArgumentNullException("user");
        this.User = user;
    }

    public string Name
    {
        get
        {
            return this.User.Username;
        }
    }

    public string AuthenticationType
    {
        get
        {
            return "Basic";
        }
    }

    public bool IsAuthenticated
    {
        get
        {
            return true;
        }
    }
}