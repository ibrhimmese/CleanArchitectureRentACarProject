﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Microsoft.AspNetCore.Mvc;

namespace Core.CrossCuttingConcerns.Exceptions.HttpProblemDetails;

public class ValidationProblemDetails:ProblemDetails
{
    public IEnumerable<ValidationExceptionModel>Errors { get; init; }

    public ValidationProblemDetails(IEnumerable<ValidationExceptionModel>errors)
    {
        Title = "Validation error(s)";
        Detail = "One or more validation errors oncurred.";
        Status = StatusCodes.Status400BadRequest;
        Type = "https://example.com/probs/validation";  //uygun link yazılır
    }
}