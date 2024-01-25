﻿using BoltCompany.Application.Features.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoltCompany.Application.Features.Queries.Logo.GetLogoByIdQuery
{
    public class GetLogoByIdQueryResponse : BaseResponse
    {
        public Domain.Entities.Logo Logo { get; set; }
    }
}
