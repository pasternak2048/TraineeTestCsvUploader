using Application.Features.UserFeatures.GetUser;
using Application.Features.UserFeatures.UpdateUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Globalization;
using System.Threading;

namespace WebUI.Pages
{
    public class EditModel : PageModel
    {
        private readonly IMediator _mediator;

        public EditModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        public GetUserResponse UserResponse { get; set; }

        public async Task OnGetAsync(Guid pageId)
        {
            UserResponse = await _mediator.Send(new GetUserRequest()
            {
                Id = pageId
            });
            var i = UserResponse;
        }

        public async Task<ActionResult> OnPostAsync(Guid id, string name, DateTime dateOfBirth, bool married, string phone, string salary)
        {
            await _mediator.Send(new UpdateUserRequest()
            {
                Id = id,
                Name = name,
                DateOfBirth = dateOfBirth,
                Married = married,
                Phone = phone,
                Salary = decimal.Parse(salary, CultureInfo.InvariantCulture)
            });

            return RedirectToPage("Index");
        }
    }
}
