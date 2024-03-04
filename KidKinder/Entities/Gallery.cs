using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KidKinder.Entities
{
    public class Gallery
    {
        public int GalleryId { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public Boolean Status { get; set; }
    }
}