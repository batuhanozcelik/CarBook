using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Dto.ReviewDto
{
    public class ResultReviewsByCarIdDto
    {
        public int ReviewId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerImage { get; set; }
        public string Comment { get; set; }
        public string RatingValue { get; set; }
        public DateTime ReviewDate { get; set; }
        public int CarId { get; set; }
    }
}
