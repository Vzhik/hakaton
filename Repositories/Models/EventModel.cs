using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Repositories.Models
{
    public class EventModel
    {
        public Guid Id { get; set; }
        public EventTypes EventType { get; set; }
        
        public string Target { get; set; }
        public int TimeAfterStart { get; set; }
        public Guid ErrorId { get; set; }

        public EventModel()
        {
            Id = Guid.NewGuid();

        }
    }
}