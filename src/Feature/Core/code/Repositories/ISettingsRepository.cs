using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Glass.Mapper.Sc.Fields;
using SitecoreUrlShorter.Feature.Core.Models;

namespace SitecoreUrlShorter.Feature.Core.Repositories
{
    public interface ISettingsRepository
    {
        int GetShorthandLength();

        string GetShorthandPattern();

        string GetDomain();

        Link GetFallbackUrl();

        IUrlShorteningServiceEntriesFolder GetEntriesFolder();

    }
}