//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ShopBridge.Api.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class Product
    {
        public int iProductID { get; set; }
        public string vchProductName { get; set; }
        public string vchDescription { get; set; }
        public decimal dPrice { get; set; }
        public bool bIsAvailable { get; set; }
        public int iProductCategoryID { get; set; }
        public string vchBrand { get; set; }
    }
}
