using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Clay.Modules;
using Smark.Data;

namespace Clay.Logic
{
    public class ControlService
    {
        public Modules.Control Load(string id)
        {
            Modules.Control result = null;
            MControl control = DBContext.Load<MControl>(id);

            if (control != null)
            {
                result = new Modules.Control();
                control.MemberCopyTo(result);
                LoadChild(result);
            }
            return result;
        }
        
        private void LoadChild(Modules.Control control)
        {
            foreach (MControl item in (MControl.parentID == control.ID).List<MControl>(MControl.level.Asc))
            {
                Modules.Control c = new Modules.Control();
                item.MemberCopyTo(c);
                control.Controls.Add(c);
                LoadChild(c);
            }
        }

        public void AddModule(string parentid, string name)
        {
            lock (parentid)
            {
                MControl mc = DBContext.Load<MControl>(parentid);
                if (mc != null)
                {
                    MControl module = new MControl();
                    module.IsPanel = true;
                    module.ParentID = parentid;
                    module.ID = Guid.NewGuid().ToString("N");
                    module.Float = Enums.FloatType.none;
                    module.Type = Enums.ControlType.Module;
                    module.Level = (MControl.parentID == parentid).Max<int, MControl>(MControl.level.Name) + 1;
                    module.ModuleName = name;
                    module.Clear = false;
                    DBContext.Save(module);
                }
            }

        }

        public void AddControl(string parentid, int columns)
        {
            lock (parentid)
            {
                MControl mc = DBContext.Load<MControl>(parentid);
                if (mc == null)
                {
                    mc = new MControl();
                    mc.ID = parentid;
                    mc.Type = Enums.ControlType.Body;
                    mc.Clear = false;
                    mc.Float = Enums.FloatType.none;

                    DBContext.Save(mc);
                }
                MControl div = new MControl();
                div.IsPanel = true;
                div.ParentID = parentid;
                div.ID = Guid.NewGuid().ToString("N");
                div.Float = Enums.FloatType.none;
                div.Type = Enums.ControlType.Div;
                div.Level = (MControl.parentID == parentid).Max<int, MControl>(MControl.level.Name) + 1;
                div.Clear = false;
                if (columns == 1)
                {
                    div.IsViewItem = true;
                    div.Width = "100%";
                }
                DBContext.Save(div);
                string[] widths = null;

                if (columns == 2)
                {
                    widths = new string[] { "49%", "50%" };
                }
                else if (columns == 3)
                {
                    widths = new string[] { "33%", "33%", "33%" };
                }
                else if (columns == 4)
                {
                    widths = new string[] { "24%", "25%", "25%", "25%" };
                }
                else
                {
                    widths = new string[] { "20%", "20%", "19%", "20%", "19%" };
                }
                if (columns > 1)
                    for (int i = 0; i < columns; i++)
                    {
                        MControl child = new MControl();
                        child.IsPanel = false;
                        child.ParentID = div.ID;
                        child.ID = Guid.NewGuid().ToString("N");
                        child.Float = Enums.FloatType.none;
                        child.Clear = false;
                        child.Type = Enums.ControlType.Div;
                        child.IsViewItem = true;
                        child.Width = widths[i];
                        child.Level = (MControl.parentID == div.ID).Max<int, MControl>(MControl.level.Name) + 1;
                        DBContext.Save(child);

                    }
            }

        }

        public void ControlArrowup(string controlid)
        {
            MControl control = DBContext.Load<MControl>(controlid);
            if (control != null)
            {
                IList<MControl> items = (MControl.parentID == control.ParentID & MControl.level <= control.Level).List<MControl>(new Region(0, 2), MControl.level.Desc);
                if (items.Count >= 2)
                {
                    int level = items[0].Level;
                    items[0].Level = items[1].Level;
                    items[1].Level = level;
                    items[0].Save();
                    items[1].Save();
                }
            }

        }

        public void DelControl(string controlid)
        {
            foreach (MControl item in (MControl.parentID == controlid).List<MControl>())
            {
                if (item.Type == Enums.ControlType.Module)
                {
                    DelModule(item.ID);
                }
                else
                {
                    foreach (MControl mitem in (MControl.parentID == item.ID).List<MControl>())
                    {
                        DelModule(mitem.ID);
                    }
                }
            }
            (MControl.parentID == controlid).Delete<MControl>();
            (MControl.iD == controlid).Delete<MControl>();
        }

        public void DelModule(string controlid)
        {
            (ControlLinkText.controlID == controlid).Delete<ControlLinkText>();
            (HtmlTextModule.controlID == controlid).Delete<HtmlTextModule>();
            (MControl.iD == controlid).Delete<MControl>();
        }
    }
}
