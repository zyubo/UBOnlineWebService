using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UBOnlineWebApiTest2.Models
{
    public class UBOnlineExam
    {
        [Required]
        [Key]
        public string titleId { get; set; }
        public string questionTitle { get; set; }
        public string questionContent { get; set; }
        //public bool A { get; set; }
        //public bool B { get; set; }
        //public bool C { get; set; }
        //public bool D { get; set; }
        public bool A { get; set; }
        public bool B { get; set; }
        public bool C { get; set; }
        public bool D { get; set; }
        public string comments { get; set; }
    }
}