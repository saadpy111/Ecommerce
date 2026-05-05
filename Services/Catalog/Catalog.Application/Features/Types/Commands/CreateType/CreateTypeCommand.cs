using Catalog.Application.Dtos;
using MediatR;

namespace Catalog.Application.Features.Types.Commands.CreateType
{
    public class CreateTypeCommand : IRequest<ProductTypeDto>
    {
        public string Name { get; set; }
    }
}
