using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Repositories.Models
{
    public class ErrorModel
    {
        public Guid Id { get; set; } //base
        public string Message { get; set; } //base. add index
        public string Agent { get; set; }
        public string FileUrl { get; set; } 
        public int? Line { get; set; } 
        public string PageUrl { get; set; }
        public Guid UserId { get; set; } //base
        public string Stack { get; set; }
        public DateTime Time { get; set; }
        public EventModel[] Events { get; set; }

        public void Init()
        {
            Id = Guid.NewGuid();
            for (int i = 0; i < Events.Length; i++)
            {
                Events[i].ErrorId = Id;
            }
        }
    }
}