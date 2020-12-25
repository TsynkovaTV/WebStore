using System.Collections.Generic;
using WebStore.Domain.Entities;
using WebStore.ViewModels;

namespace WebStore.Models
{
    public class AdminCatalogViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public PageViewModel PageViewModel { get; set; }
    }
}
