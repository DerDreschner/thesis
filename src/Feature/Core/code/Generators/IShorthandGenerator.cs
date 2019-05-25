using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitecoreUrlShorter.Feature.Core.Generators
{
    public interface IShorthandGenerator
    {
        string GenerateShorthand(int length, string pattern);
    }
}