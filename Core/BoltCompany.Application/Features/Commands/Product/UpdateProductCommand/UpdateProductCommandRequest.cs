using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoltCompany.Application.Features.Commands.Product.UpdateProductCommand
{
    public class UpdateProductCommandRequest : IRequest<UpdateProductCommandResponse>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Specification { get; set; }
        public Guid CategoryId { get; set; }
    }
}
