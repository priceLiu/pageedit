﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.17929
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

using Smark.Data.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Clay.Modules {
    
    
    /// <summary>
    /// Smark.Data Generator Copyright © FanJianHan 2010-2012
    /// website:http://www.ikende.com
    /// </summary>
    [Serializable()]
    [Table()]
    public partial class HtmlTextModule : Smark.Data.Mappings.DataObject, IHtmlTextModule {
        
        private string mControlID;
        
        /// <summary>
        /// System.String
        /// </summary>
        public static Smark.Data.FieldInfo controlID = new Smark.Data.FieldInfo("HtmlTextModule", "ControlID");
        
        private string mHtml;
        
        /// <summary>
        /// System.String
        /// </summary>
        public static Smark.Data.FieldInfo html = new Smark.Data.FieldInfo("HtmlTextModule", "Html");
        
        [ID()]
        public virtual string ControlID {
            get {
                return this.mControlID;
            }
            set {
                this.mControlID = value;
                this.EntityState.FieldChange("ControlID");
            }
        }
        
        [Column()]
        public virtual string Html {
            get {
                return this.mHtml;
            }
            set {
                this.mHtml = value;
                this.EntityState.FieldChange("Html");
            }
        }
    }
}
