using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Smark.Data.Mappings;
namespace Clay.Modules
{

    [Table]
    public interface ITextModule
    {
        [ID]
        [UID]
        string ID { get; set; }
        [Column]
        string Title { get; set; }
        [Column]
        string Html { get; set; }
    }
    [Table]
    public interface IControlLinkText
    {
        [Column]
        string ControlID { get; set; }
        [Column]
        string TextID { get; set; }
    }
}
