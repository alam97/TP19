using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Event
    {
        // this is an invoice 

            private User user;
            private Catalog item;
            private DateTimeOffset dateofEvent;
            private int eventId;

            public Event(User u, Catalog c, DateTimeOffset d)
            {
                this.user = u;
                this.item = c;
                this.dateofEvent = d;
            }

            public User EventUser { get => user; set => user = value; }
            public Catalog EventCatalog { get => item; set => item = value; }
            public DateTimeOffset EventDate { get => dateofEvent; set => dateofEvent = value; }
            public int EventID { get => eventId; set => eventId = value; }
        }
    }
