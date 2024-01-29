using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
namespace Core.CrossCuttingConcerns.Exceptions.Extensions;

public static class ProblemDetailsExceptions
{
    public static string AsJson<TProblemDetail>(this TProblemDetail details)
    where TProblemDetail:ProblemDetails=>JsonSerializer.Serialize(details);
}