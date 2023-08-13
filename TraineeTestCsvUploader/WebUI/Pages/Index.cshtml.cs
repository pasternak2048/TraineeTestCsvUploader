using Application.Common.Models;
using Application.Features.UserFeatures.DeleteUser;
using Application.Features.UserFeatures.GetUsers;
using Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebUI.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IMediator _mediator;

        public IndexModel(ILogger<IndexModel> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        public PaginatedList<GetUsersResponse> Users { get; set; }

        public async Task OnGet(int pageNumber = 1)
        {
            Users = await _mediator.Send(new GetUsersRequest()
            {
                PageNumber = pageNumber,
            });
        }



        public async Task<IActionResult> OnPostDelete(Guid id, int pageNumber = 1)
        {
            await _mediator.Send(new DeleteUserRequest()
            {
                Id = id
            });

            return RedirectToPage("./Index", new { pageNumber = pageNumber });
        }
    }
}