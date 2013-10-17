using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Smark.Data.Mappings;
using Smark.Data;
using Clay.Enums;
namespace Clay.Modules
{
    [Table]
    public interface IMControl
    {
        [ID]
        string ID { get; set; }
        [Column]
        [EnumToString]
        ControlType Type { get; set; }
        [Column]
        string ParentID { get; set; }
        [Column]
        string Remark { get; set; }
        #region style
        [Column]
        string Width { get; set; }
        [Column]
        [BoolToInt]
        bool Clear { get; set; }
        [Column]
        [EnumToString]
        FloatType Float
        {
            get;
            set;
        }
        [Column]
        [BoolToInt]
        bool IsPanel { get; set; }
        [Column]
        [BoolToInt]
        bool IsViewItem { get; set; }
        [Column]
        [DefaultInt(0)]
        int Level { get; set; }

        [Column]
        string ModuleName { get; set; }
        #endregion
    }
}
