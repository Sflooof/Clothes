//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Clothes.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class Cloth
    {
        public int Id_cloth { get; set; }
        public string name { get; set; }
        public int color { get; set; }
        public int composition { get; set; }
        public int size { get; set; }
        public int supplier { get; set; }
        public int manufacturer { get; set; }
        public decimal price { get; set; }
        public System.DateTime delivery_date { get; set; }
        public System.DateTime purchase_date { get; set; }
        public byte[] photo { get; set; }
    
        public string Correct_Color
        {
            get
            {
                return Color1.name;
            }
        }

        public string Correct_Manufacturer
        {
            get
            {
                return Manufacturer1.name;
            }
        }
        public string Correct_Size
        {
            get
            {
                return Size1.name;
            }
        }

        public virtual Color Color1 { get; set; }
        public virtual Composition Composition1 { get; set; }
        public virtual Manufacturer Manufacturer1 { get; set; }
        public virtual Size Size1 { get; set; }
        public virtual Supplier Supplier1 { get; set; }
    }
}
