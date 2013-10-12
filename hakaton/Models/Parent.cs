using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace hakaton.Models
{
    public class Parent
    {
        public Guid Id { get; set; }
        public int SequenceNumber { get; set; }
        public string ElementSelector { get; set; }
    }
}