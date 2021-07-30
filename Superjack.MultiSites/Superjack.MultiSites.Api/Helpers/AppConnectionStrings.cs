using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Superjack.MultiSites.Api.Helpers
{
    public class AppConnectionStrings
    {
        public string DefaultConnection { get; set; }
        public string MergedRecordsConnection { get; set; }
        public string SyncConnection { get; set; }
    }
}
