using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BI_CM_C1_2020.Models
{
    public class Message
    {
        
        public int id { get; set; }
        public string title { get; set; }
        public string text { get; set; }
        public DateTime date { get; set; }
        public Message()
        {
            date = DateTime.Now;
        }
    }
}
