using System.Threading.Tasks;
using WebScanner.Models.Database;
using WebScanner.Models.Services.Interfaces;

namespace WebScanner.Models.Services
{
    public class ResponseService : IResponseService
    {
        private readonly DatabaseContext DatabaseContext;
        private UnitOfWork.UnitOfWork unitOfWork;

        public ResponseService(DatabaseContext databaseContext)
        {
            DatabaseContext = databaseContext;
            unitOfWork = new UnitOfWork.UnitOfWork(this.DatabaseContext);
        }

        public async Task AddResponseToDb(Response response)
        {
                unitOfWork.ResponseRepository.Add(response);
                await unitOfWork.Save();       
        }
    }
}
