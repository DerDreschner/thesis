using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Glass.Mapper.Sc.Fields;

namespace SitecoreUrlShorter.Feature.Core.Repositories
{
    public interface ISettingsRepository
    {
        int GetShorthandLength();

        string GetDomain();

        Link GetFallbackUrl();

    }
}