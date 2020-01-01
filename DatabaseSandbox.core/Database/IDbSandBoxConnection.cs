using System.Threading.Tasks;

namespace DatabaseSandbox.Core.Database
{
    public interface IDbSandBoxConnection
    {
        void Open();
        Task OpenAsync();
    }
}