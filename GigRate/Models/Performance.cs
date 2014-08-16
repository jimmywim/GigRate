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
    
    public partial class Performance
    {
        public Performance()
        {
            this.PerformanceRatings = new HashSet<PerformanceRating>();
        }
    
        public int Id { get; set; }
        public Nullable<System.DateTime> TimeOn { get; set; }
        public Nullable<System.DateTime> TimeOff { get; set; }
        public Nullable<int> ActId { get; set; }
        public Nullable<int> EventInstanceStageId { get; set; }
    
        public virtual Act Act { get; set; }
        public virtual EventInstanceStage EventInstanceStage { get; set; }
        public virtual ICollection<PerformanceRating> PerformanceRatings { get; set; }
    }
}
