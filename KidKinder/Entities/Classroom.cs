using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KidKinder.Entities
{
    public class Classroom
    {

        public int ClassroomId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string AgeofKids  { get; set; }
        public byte TotalSeat { get; set; }
        public string ClassTime  { get; set; }
        public decimal Price  { get; set; }
        public string ImageUrl  { get; set; }
        public List<BookASeat> BookASeats { get; set; }
        public List<Student> Students { get; set; }

    }
}