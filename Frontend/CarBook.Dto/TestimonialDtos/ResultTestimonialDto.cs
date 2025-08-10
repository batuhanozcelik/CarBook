using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Dto.TestimonialDtos
{
    public class ResultTestimonialDto
    {

        public int TestimonialId { get; set; }
        public string name { get; set; }
        public string title { get; set; }
        public string comment { get; set; }
        public string imageURL { get; set; }
    }
}
