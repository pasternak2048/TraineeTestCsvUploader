using Application.Common.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.UserFeatures.CreateUserCSV
{
    public class CreateUserCSVHandler : IRequestHandler<CreateUserCSVRequest, List<CreateUserCSVResponse>>
    {
        private readonly IApplicationDbContext _context;
        private readonly ICSVService _csvService;
        private readonly IMapper _mapper;

        public CreateUserCSVHandler(IApplicationDbContext context, ICSVService csvService, IMapper mapper)
        {
            _context = context;
            _csvService = csvService;
            _mapper = mapper;
        }

        public async Task<List<CreateUserCSVResponse>> Handle(CreateUserCSVRequest request, CancellationToken cancellationToken)
        {
            var items = _csvService.ReadCSV<User>(request.CSVFile.OpenReadStream()).ToList();

            _context.Users.AddRange(items);

            await _context.SaveChangesAsync(cancellationToken);

            return _mapper.Map<List<CreateUserCSVResponse>>(items);
        }
    }
}
