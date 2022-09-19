using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Booking
    {
        public Booking()
        {
            Status = StatusEnum.Created;
        }
        public int Id { get; set; }
        public DateTime PlaceAt { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        private StatusEnum Status { get; set; }
        public Room Room { get; set; }
        public Guest Guest { get; set; }
        public StatusEnum CurrentStatus { get { return Status; } }

        public void ChangeState(ActionEnum action)
        {
            this.Status = (Status, action) switch
            {
                (StatusEnum.Created, ActionEnum.Pay)=> StatusEnum.Paid,
                (StatusEnum.Created, ActionEnum.Cancel) => StatusEnum.Canceled,
                (StatusEnum.Paid, ActionEnum.Finish) => StatusEnum.Finished,
                (StatusEnum.Paid, ActionEnum.Refound) => StatusEnum.Refounded,
                (StatusEnum.Canceled, ActionEnum.Reopen) => StatusEnum.Created,
                  _  =>  Status
            };
        }
    }
}
