//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BookWorm.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Publisher_Table
    {
        public int Publisher_ID { get; set; }
        public string PublisherName { get; set; }
        public Nullable<int> Book_ID { get; set; }
    
        public virtual Book_Table Book_Table { get; set; }
    }
}
