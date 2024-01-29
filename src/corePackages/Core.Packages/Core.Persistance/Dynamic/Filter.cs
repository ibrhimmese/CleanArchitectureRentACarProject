using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Persistance.Dynamic;

public class Filter
{
    public string Field { get; set; }   //Yakıt tipi
    public string? Value { get; set; }
    public string Operator { get; set; }
    public string? Logic { get; set; }

    public IEnumerable<Filter>? Filters { get; set; }

    public Filter()
    {
        Field = string.Empty;
        Operator=string.Empty;
    }

    public Filter(string field, string @operator)
    {
        Field =field;
        Operator =@operator;
    }
}