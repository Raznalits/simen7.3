//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Турагенство.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Service
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Service()
        {
            this.ServiceByTour = new HashSet<ServiceByTour>();
        }
    
        public int ID { get; set; }
        public string Name { get; set; }
        public Nullable<int> PartnerID { get; set; }
        public Nullable<int> HotelID { get; set; }
        public Nullable<decimal> Price { get; set; }
    
        public virtual HotelPhoto HotelPhoto { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ServiceByTour> ServiceByTour { get; set; }
    }
}
