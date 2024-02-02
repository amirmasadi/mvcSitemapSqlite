using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using mvcSitemapSqlite.Data;
using mvcSitemapSqlite.Models;

namespace mvcSitemapSqlite.Repository
{
    public class ProductRep
    {
        private readonly ProductsDbContext _tvShowContext = new ProductsDbContext();
        public List<Product> GetProducts()
        {
            return _tvShowContext.Product.ToList();
        }
    }
}