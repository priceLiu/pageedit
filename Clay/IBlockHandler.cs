using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Clay
{
    public interface IBlockHandler
    {
        /// <summary>
        /// 编辑模板数据加载
        /// </summary>
        /// <param name="context"></param>
        /// <param name="values"></param>
        void EditorLoad(Context context, System.Collections.Specialized.NameValueCollection values);
        /// <summary>
        /// 编辑模板数据保存
        /// </summary>
        /// <param name="context"></param>
        /// <param name="values"></param>
        void EditorSave(Context context, System.Collections.Specialized.NameValueCollection values);
        /// <summary>
        /// 显示模板数据加载
        /// </summary>
        /// <param name="context"></param>
        /// <param name="values"></param>
        void ViewerLoad(Context context, System.Collections.Specialized.NameValueCollection values);
    }
}
