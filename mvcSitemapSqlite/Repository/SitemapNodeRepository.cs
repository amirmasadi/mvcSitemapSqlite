using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using mvcSitemapSqlite.Sitemap;

namespace mvcSitemapSqlite.Repository
{
    public class SitemapNodeRepository : ISitemapNodeRepository
    { 
        public string SetSitemapNodes(IUrlHelper urlHelper, string path)
        {
            return clsSitemap.SetSitemap(urlHelper, path);
        }
    }
}