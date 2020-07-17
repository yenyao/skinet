using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Specifications
{
    public class ProductSpecParams
    {
        // Max products to a page
        private const int MaxPageSize = 50;

        // Page index
        public int PageIndex { get; set; } = 1;

        // default products to a page
        private int _pageSize = 6;

        public int PageSize
        {
            get => _pageSize;
            // If the products to a page > max products to a page, set to max products, else set to value
            set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
        }

        public int? BrandId { get; set; }
        public int? TypeId { get; set; }
        // pageAsc or pageDesc. Switch case string
        public string Sort{ get; set; }

        private string _search;
        public string Search 
        {
            get => _search;
            set => _search = value.ToLower();
        }

    }
}
