using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Event
    {
        // this is an invoice of a bought item

            private User user;
            private Catalog item;
            private DateTimeOffset dateofEvent;
            private int eventId;
           

        public Event(User user, Catalog item, DateTimeOffset dateofEvent)
        {
            this.user = user;
            this.item = item;
            this.dateofEvent = dateofEvent;
        }

        public User EventUser { get => user; set => user = value; }
            public Catalog EventCatalog { get => item; set => item = value; }
            public DateTimeOffset EventDate { get => dateofEvent; set => dateofEvent = value; }
            public int EventID { get => eventId; set => eventId = value; }
        }
    }
