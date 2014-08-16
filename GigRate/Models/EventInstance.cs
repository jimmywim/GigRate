//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GigRate.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class EventInstance
    {
        public EventInstance()
        {
            this.EventInstanceStages = new HashSet<EventInstanceStage>();
        }
    
        public int Id { get; set; }
        public Nullable<int> EventId { get; set; }
        public Nullable<System.DateTime> DateFrom { get; set; }
        public Nullable<System.DateTime> DateTo { get; set; }
        public string Name { get; set; }
    
        public virtual Event Event { get; set; }
        public virtual ICollection<EventInstanceStage> EventInstanceStages { get; set; }
    }
}
