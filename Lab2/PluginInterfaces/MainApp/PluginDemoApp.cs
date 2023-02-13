using PluginInterface;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace MainApp
{
    public partial class PluginDemoApp : Form
    {
        Dictionary<string, IPlugin> plugins = new Dictionary<string, IPlugin>();
        public PluginDemoApp()
        {
            InitializeComponent();
            GetPluginsFromConfiguration();
            CreatePluginsMenu();
            ShowPluginsInformation();
        }

        private void CreatePluginsMenu()
        {
            foreach (string p in plugins.Keys)
            {
                var menuItem = new ToolStripMenuItem(p);
                menuItem.Click += OnPluginClick;

                filtersMenuItem.DropDownItems.Add(menuItem);
            }
        }


        private void ShowPluginsInformation()
        {
            var informationForm = new InformationForm(GetPluginsInfo());
            informationForm.ShowDialog();

        }

        //Получения списка загруженных плагинов
        private List<string> GetPluginsInfo()
        {
            var pluginsInfo = new List<string>();

            foreach (var plugin in plugins.Values)
            {
                var attribute = plugin.GetType().GetCustomAttribute(typeof(VersionAttribute), false) as VersionAttribute;
                pluginsInfo.Add($"Имя = {plugin.Name}; Автор = {plugin.Author}, Версия = ({attribute.Major}, {attribute.Minor})");
            }

            return pluginsInfo;
        }

        private void OnPluginClick(object sender, EventArgs args)
        {
            IPlugin plugin = plugins[((ToolStripMenuItem)sender).Text];
            plugin.Transform((Bitmap)pictureBox.Image);
            pictureBox.Refresh();
        }

        //Получение путей из конфигурационного файла
        private void GetPluginsFromConfiguration()
        {
            try
            {
                var autoSearch = ConfigurationManager.AppSettings.Get("autoSearch");
                List<Plugin> dirs = ConfigurationManager.GetSection("pluginsPaths") as List<Plugin>;
                if (autoSearch != null && !CheckAutoSearchValue(autoSearch) && dirs != null)
                {
                    foreach (var dir in dirs)
                        LoadPlugin(dir.Path);

                }
                else FindPlugins();
            }
            catch
            {
                FindPlugins();
            }
        }
        private bool CheckAutoSearchValue(string value)
        {
            bool result;
            if (!Boolean.TryParse(value, out result)) return true;
            return result;
        }
        //Автоматический поиск плагинов
        private void FindPlugins()
        {

            string folder = System.AppDomain.CurrentDomain.BaseDirectory;

            string[] files = Directory.GetFiles(folder, "*.dll");

            foreach (string file in files)
                LoadPlugin(file);
        }

        //Загрузка плагина
        private void LoadPlugin(string path)
        {
            try
            {
                Assembly assembly = Assembly.LoadFile(path);

                foreach (Type type in assembly.GetTypes())
                {
                    Type iface = type.GetInterface("PluginInterface.IPlugin");

                    if (iface != null)
                    {
                        IPlugin plugin = (IPlugin)Activator.CreateInstance(type);
                        plugins.Add(plugin.Name, plugin);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки плагина\n" + ex.Message);
            }
        }
    }
}
