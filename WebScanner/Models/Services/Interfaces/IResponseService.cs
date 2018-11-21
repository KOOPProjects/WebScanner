using System.Threading.Tasks;

namespace WebScanner.Models.Services.Interfaces
{
    public interface IResponseService
    {
        Task AddResponseToDb(Response response);
    }
}
