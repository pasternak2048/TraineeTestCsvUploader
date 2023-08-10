using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Features.UserFeatures.CreateUserCSV
{
    public class CreateUserCSVRequest : IRequest<List<CreateUserCSVResponse>>
    {
        public IFormFile CSVFile { get; set; }
    }
}
