using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Clay.Modules
{
    public class BoolToInt:Smark.Data.Mappings.PropertyCastAttribute
    {
        public override object ToColumn(object value, Type ptype, object source)
        {
            bool data = (bool)value;
            if (data)
                return 1;
            return 0;
        }
        public override object ToProperty(object value, Type ptype, object source)
        {
            Int64 data = (Int64)value;
            return data == 1;
        }
    }
}
