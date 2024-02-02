using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mvcSitemapSqlite.Repository
{
    interface ISitemapNodeRepository
    {
        string SetSitemapNodes(IUrlHelper urlHelper, string path);
    }
}