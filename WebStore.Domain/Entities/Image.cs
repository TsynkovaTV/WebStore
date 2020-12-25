using System;
using System.Collections.Generic;
using System.Text;

namespace WebStore.Domain.Entities
{
    public class Image
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public Product Product { get; set; }
    }
}
