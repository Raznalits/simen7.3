//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Благодать.model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Employee
    {
        public string Employee_s_code { get; set; }
        public Nullable<int> Post { get; set; }
        public string Full_name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Nullable<System.DateTime> Last_entry { get; set; }
        public Nullable<int> Type_entry { get; set; }
        public string photo { get; set; }
    
        public virtual ID_Post ID_Post { get; set; }
        public virtual Type_entryID Type_entryID { get; set; }
    }
}
