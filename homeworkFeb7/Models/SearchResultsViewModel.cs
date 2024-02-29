using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace homeworkFeb7.Models
{
    public class SearchResultsViewModel
    {
        public List<Product> products { get; set; }
        public int min { get; set; }
        public int max { get; set; }
    }
}