

namespace RVP.Core.Application.Interfaces.HelpersInterfaces
{
    public interface IPasswordEncyptor
    {
        string HashPassword(string password);
        bool VerifyPassword(string Inpassword, string outPassword);

    }
}
