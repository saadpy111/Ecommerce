using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.Features.Types.Queries.GetAllTypes
{
    public class GetAllTypesQueryRequest: IRequest<GetAllTypesQueryResponse>
    {
    }
}
