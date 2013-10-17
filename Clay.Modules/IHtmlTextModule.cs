using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Smark.Data.Mappings;
namespace Clay.Modules
{
    [Table]
    public interface IHtmlTextModule
    {
        [ID]
        string ControlID { get; set; }
        [Column]
        string Html { get; set; }

    }
}
