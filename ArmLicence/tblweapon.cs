//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ArmLicence
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblweapon
    {
        public string UIN { get; set; }
        public string weapon { get; set; }
        public string bore { get; set; }
        public string weaponNo { get; set; }
        public string ammunition { get; set; }
        public Nullable<System.DateTime> uploadDate { get; set; }
    
        public virtual tblweaponholder tblweaponholder { get; set; }
    }
}
