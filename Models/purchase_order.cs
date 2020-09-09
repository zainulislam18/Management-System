//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Management_System.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class purchase_order
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public purchase_order()
        {
            this.bills = new HashSet<bill>();
            this.purchase_order_line = new HashSet<purchase_order_line>();
        }
        [Display(Name = "Purchase Order Number")]
        public int po_id { get; set; }
        [Display(Name = "Name of Company")]
        public string company_name { get; set; }
        [Display(Name = "Deliver Date")]
        public Nullable<System.DateTime> delivery_dat { get; set; }
        [Display(Name = "Purchase Order Date")]
        public Nullable<System.DateTime> po_date { get; set; }
        [Display(Name = "Tax")]
        public string tax_id { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<bill> bills { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<purchase_order_line> purchase_order_line { get; set; }
        public virtual Tax Tax { get; set; }
    }
}