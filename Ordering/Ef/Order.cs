//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Ef
{
    using System;
    using System.Collections.Generic;
    
    public partial class Order
    {
        public int Id { get; set; }
        public System.DateTime OrderDate { get; set; }
        public int ProductId { get; set; }
        public int UserId { get; set; }
        public string Status { get; set; }
        public int NumberOfProducts { get; set; }
    
        public virtual Product Product { get; set; }
        public virtual User User { get; set; }
    }
}
