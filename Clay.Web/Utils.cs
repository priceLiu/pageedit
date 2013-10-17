using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Clay.Web
{
    public class Utils
    {
        static Utils()
        {
            LoadModules();
            LoadAssemblies();
        }

        private static Dictionary<string, ModuleBuilder> mModules = new Dictionary<string, ModuleBuilder>();

        public static Dictionary<string, ModuleBuilder>.ValueCollection GetModules
        {
            get
            {
                return mModules.Values;
            }
        }
        public static Logic.ControlService ControlService = new Logic.ControlService();
        private static void LoadModules()
        {
            try
            {
                string folder = System.Web.HttpContext.Current.Request.PhysicalApplicationPath + @"modules\";
                foreach (string item in System.IO.Directory.GetDirectories(folder))
                {
                    System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(item);
                    ModuleInfo info = new ModuleInfo();
                    info.Name = dir.Name;
                    mModules[info.Name.ToLower()] = new ModuleBuilder(info);
                    info.Viewer = "~/modules/" + info.Name + "/Viewer.ascx";
                    info.Editor = "~/modules/" + info.Name + "/Editor.ascx";
                    info.Setting = new ModuleSetting();
                    info.Setting.Load(item + @"\config.xml");
                }
            }
            catch (Exception e_)
            {
                Context.GetLog_s <Utils>().Error("load modules error!", e_);
            }
        }


        private static void LoadAssemblies()
        {
            foreach (System.Reflection.Assembly item in AppDomain.CurrentDomain.GetAssemblies())
            {
                try
                {
                    foreach (Type type in item.GetTypes())
                    {
                        ModuleAttribute[] mas = (ModuleAttribute[])type.GetCustomAttributes(typeof(ModuleAttribute), false);
                        if (mas.Length > 0)
                        {
                            ModuleBuilder info = null;
                            mModules.TryGetValue(mas[0].Name.ToLower(), out info);
                            if (info != null)
                            {
                                info.Module.Handler = (IBlockHandler)Activator.CreateInstance(type);
                                
                            }

                        }
                    }
                }
                catch (Exception e_)
                {
                    Context.GetLog_s<Utils>().Error("load module assemblies error!", e_);
                }
            }
        }

        public static ModuleBuilder GetModuleBuilder(string name)
        {
            ModuleBuilder handler = null;
            mModules.TryGetValue(name.ToLower(), out handler);          
            return handler;
        }
    }
}
