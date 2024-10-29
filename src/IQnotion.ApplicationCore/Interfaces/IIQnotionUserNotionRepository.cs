using IQnotion.ApplicationCore.Models;

namespace IQnotion.ApplicationCore.Interfaces;

public interface IIQnotionUserNotionRepository
{
    public UserNotion AddUserNotion(UserNotion userNotion);
}