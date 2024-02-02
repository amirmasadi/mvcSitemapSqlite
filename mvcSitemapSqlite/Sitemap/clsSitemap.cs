using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using System.Globalization;
using System.Xml;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc;
using mvcSitemapSqlite.Models;
using mvcSitemapSqlite.Repository;

namespace mvcSitemapSqlite.Sitemap
{
    public class clsSitemap
    {
        public static string SetSitemap(IUrlHelper urlHelper, string path)
        {
            string xml = GetSitemapDocument(GetNode(urlHelper));
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);
            doc.Save(path);
            return xml;
        }
        public static List<SitemapNode> GetNode(IUrlHelper urlHelper)
        {
            List<SitemapNode> nodes = new List<SitemapNode>();
            string Domain = urlHelper.ActionContext.HttpContext.Request.Scheme +  "://" + urlHelper.ActionContext.HttpContext.Request.Host;

            nodes.Add(
                new SitemapNode()
                {
                    Url = Domain + urlHelper.Action("Index", "Home"),
                    Priority = 1,
                });
            nodes.Add(
               new SitemapNode()
               {
                   Url = Domain + urlHelper.Action("Description"),
                   Priority = 0.9,
               });
            nodes.Add(
               new SitemapNode()
               {
                   Url = Domain + urlHelper.Action("Contact"),
                   Priority = 0.9,
               });
            ProductRep Rep_Posts = new ProductRep();
            foreach (var item in Rep_Posts.GetProducts())
            {
                nodes.Add(
               new SitemapNode()
               {
                   Url = Domain + urlHelper.Action("posts/", new { id = item.Title }),
                   Frequency = SitemapFrequency.Weekly,
                   Priority = 0.8,
               });

            }
            return nodes;
        }
        public static string GetSitemapDocument(List<SitemapNode> SitemapNodes)
        {
            XNamespace Xmlns = "http://www.sitemaps.org/schemas/sitemap/0.9";
            XElement root = new XElement(Xmlns + "urlset");
            foreach(SitemapNode sitemapNode in SitemapNodes)
            {
                XElement urlElement = new XElement(
                    Xmlns + "url",
                    new XElement(Xmlns + "loc", Uri.EscapeUriString(sitemapNode.Url)),
                    sitemapNode.LastModified == null ? null : new XElement(Xmlns + "lastmod",
                    sitemapNode.LastModified.Value.ToLocalTime().ToString("yyyy-mm-ddthh:mm:sszzz")),
                    sitemapNode.Frequency == null ? null : new XElement(
                        Xmlns + "changefreq",
                        sitemapNode.Frequency.Value.ToString().ToLowerInvariant()),
                    sitemapNode.Priority == null ? null : new XElement(
                        Xmlns + "priority",
                        sitemapNode.Priority.Value.ToString("F1",
                        CultureInfo.InvariantCulture)));
                root.Add(urlElement);
            }
            XDocument document = new XDocument(root);
            return document.ToString();
        }
    }
}
