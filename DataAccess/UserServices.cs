using Entities;

namespace DataAccess;

public class UserServices
{
    public List<User> GetUsers()
    {
        UserList userList = new UserList();
        return userList;
    }
}