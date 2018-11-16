using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebScanner.Models.Database;
using WebScanner.Models.Services.Interfaces;
using WebScanner.Models.UnitOfWork;

namespace WebScanner.Models.Services
{
    public class ResponseService : IResponseService
    {
        private DatabaseContext DatabaseContext;
        private Models.UnitOfWork.UnitOfWork unitOfWork;

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
