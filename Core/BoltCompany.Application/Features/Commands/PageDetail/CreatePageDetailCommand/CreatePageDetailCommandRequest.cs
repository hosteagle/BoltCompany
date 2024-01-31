using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoltCompany.Application.Features.Commands.PageDetail.CreatePageDetailCommand
{
    public class CreatePageDetailCommandRequest : IRequest<CreatePageDetailCommandResponse>
    {
       // [FromForm(Name = "pageDetailList")]
        public List<PageDetailInput> PageDetailList { get; set; }
    }

    public class PageDetailInput
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string ImageName { get; set; }
        public IFormFile File { get; set; }
        public Guid ExtraPageId { get; set; }
    }
}
