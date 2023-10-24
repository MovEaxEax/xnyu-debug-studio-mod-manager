using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml;
using System.IO;
using System.Net;
using System.Net.NetworkInformation;

namespace xnyu_debug_studio_mod_manager
{
    public partial class Form1 : Form
    {
        static public string approvedModsFileUrl = "http://raw.githubusercontent.com/MovEaxEax/xnyu-debug-approved-mods/main/available-mods.xml";
        static public string approvedModsFileContent = "";
        static public string historyDirectory = Directory.GetCurrentDirectory() + @"\config\history";
        static public string installedOnlineModsFile = Directory.GetCurrentDirectory() + @"\config\ModsOnline.xml";
        static public string installedOfflineModsFile = Directory.GetCurrentDirectory() + @"\config\ModsOffline.xml";
        static public string templatesDirectory = Directory.GetCurrentDirectory() + @"\templates";
        static public string modsDirectory = Directory.GetCurrentDirectory() + @"\mods";

        static public XMLParser availableOnlineMods = null;
        static public XMLParser installedOnlineMods = null;
        static public XMLParser installedOfflineMods = null;

        public Form1()
        {
            InitializeComponent();

        }

        async private void Form1_Load(object sender, EventArgs e)
        {
            System.Net.ServicePointManager.Expect100Continue = true;
            System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;

            if (NetworkInterface.GetIsNetworkAvailable())
            {
                approvedModsFileContent = await GetAvailableModsXML(approvedModsFileUrl);
            }

            if (!File.Exists(installedOnlineModsFile)) File.WriteAllText(installedOnlineModsFile, "<mods>\n</mods>");
            if (!File.Exists(installedOfflineModsFile)) File.WriteAllText(installedOfflineModsFile, "<mods>\n</mods>");

            availableOnlineMods = new XMLParser(approvedModsFileContent);
            installedOnlineMods = new XMLParser(File.ReadAllText(installedOnlineModsFile));
            installedOfflineMods = new XMLParser(File.ReadAllText(installedOfflineModsFile));

            ComboboxOnlineInstallFill();
            ComboboxOnlineUninstallFill();
            ComboboxOfflineUninstallFill();

            // Create directories if not existing
            if (!Directory.Exists(historyDirectory)) Directory.CreateDirectory(historyDirectory);
            if (!Directory.Exists(templatesDirectory)) Directory.CreateDirectory(templatesDirectory);
            if (!Directory.Exists(modsDirectory)) Directory.CreateDirectory(modsDirectory);
        }

        public static async Task<string> GetAvailableModsXML(string url)
        {
            using (var httpClient = new HttpClient())
            {
                //httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                using (var response = await httpClient.GetAsync(url))
                {
                    response.EnsureSuccessStatusCode();
                    var xmlContent = await response.Content.ReadAsStringAsync();
                    return xmlContent;
                }
            }
        }

        public static void DownloadZipFile(string url, string dst)
        {
            using (WebClient client = new WebClient())
            {
                client.DownloadFile(url, dst);
            }
        }

        private void button_online_install_Click(object sender, EventArgs e)
        {
            if (combobox_online_install.SelectedIndex > -1)
            {
                string name = combobox_online_install.SelectedItem.ToString();
                string link = availableOnlineMods.getLink(name);
                string version = availableOnlineMods.getVersion(name);
                if (installedOnlineMods.getVersion(name) == "")
                {
                    string zip = historyDirectory + @"\" + ModManagement.GenerateRandomNumberString(10) + ".zip";
                    DownloadZipFile(link, zip);
                    ModManagement.InstallMod(zip, name + "_" + version, historyDirectory, true);
                    installedOnlineMods.addMod(name, version, link);
                    File.WriteAllText(installedOnlineModsFile, installedOnlineMods.generateFile());

                    ComboboxOnlineUninstallFill();
                    MessageBox.Show("Mod installed!");
                }
                else
                {
                    MessageBox.Show("Mod already installed!\nIf you want to check for an update, please use the 'Update'-button.");
                }
            }
        }

        private void button_online_uninstall_Click(object sender, EventArgs e)
        {
            if (combobox_online_uninstall.SelectedIndex > -1)
            {
                string name = combobox_online_uninstall.SelectedItem.ToString();
                string link = installedOnlineMods.getLink(name);
                string version = installedOnlineMods.getVersion(name);
                if (version != "")
                {
                    ModManagement.UninstallMod(name + "_" + version, historyDirectory);
                    installedOnlineMods.deleteMod(name);
                    File.WriteAllText(installedOnlineModsFile, installedOnlineMods.generateFile());

                    ComboboxOnlineUninstallFill();
                    MessageBox.Show("Mod uninstalled!");
                }
                else
                {
                    MessageBox.Show("Mod wasn't installed properly. Couldn't end the uninstallation.");
                }
            }
        }

        private void button_local_install_Click(object sender, EventArgs e)
        {
            string zip = textbox_local_install.Text;
            if (File.Exists(zip))
            {
                string stem = zip.Split('\\')[zip.Split('\\').Length - 1].Split('.')[0];
                string name = "";
                string version = "";
                string link = "local";
                if (stem.Contains("_"))
                {
                    name = stem.Split('_')[0];
                    version = stem.Split('_')[1];
                    if (name.Length == 0) if (stem.Length > 0) name = stem; else name = "UnknownMod" + ModManagement.GenerateRandomNumberString(10);
                    if (version.Length == 0) version = "1.0.0";
                }
                else
                {
                    if (stem.Length > 0) name = stem; else name = "UnknownMod" + ModManagement.GenerateRandomNumberString(10);
                    version = "1.0.0";
                }

                if (installedOfflineMods.getVersion(name) == "")
                {
                    ModManagement.InstallMod(zip, name + "_" + version, historyDirectory, false);
                    installedOfflineMods.addMod(name, version, link);
                    File.WriteAllText(installedOfflineModsFile, installedOfflineMods.generateFile());

                    ComboboxOfflineUninstallFill();
                    MessageBox.Show("Mod installed!");
                }
                else
                {
                    MessageBox.Show("Mod already installed!\nIf you want to check for an update, please use the 'Update'-button.");
                }
            }
        }

        private void button_local_uninstall_Click(object sender, EventArgs e)
        {
            if (combobox_local_uninstall.SelectedIndex > -1)
            {
                string name = combobox_local_uninstall.SelectedItem.ToString();
                string version = installedOfflineMods.getVersion(name);
                if (version != "")
                {
                    ModManagement.UninstallMod(name + "_" + version, historyDirectory);
                    installedOfflineMods.deleteMod(name);
                    File.WriteAllText(installedOfflineModsFile, installedOfflineMods.generateFile());

                    ComboboxOfflineUninstallFill();
                    MessageBox.Show("Mod uninstalled!");
                }
                else
                {
                    MessageBox.Show("Mod wasn't installed properly. Couldn't end the uninstallation.");
                }
            }
        }

        private void button_offline_select_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Select the mods ZIP file";
            openFileDialog.Filter = "ZIP files (*.zip)|*.zip";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                textbox_local_install.Text = openFileDialog.FileName;
            }
        }

        public void ComboboxOnlineInstallFill()
        {
            combobox_online_install.SelectedIndex = -1;
            combobox_online_install.Items.Clear();

            string[] names = availableOnlineMods.getNames();
            for (int i = 0; i < names.Length; i++)
            {
                combobox_online_install.Items.Add(names[i]);
            }
        }

        public void ComboboxOnlineUninstallFill()
        {
            combobox_online_uninstall.SelectedIndex = -1;
            combobox_online_uninstall.Items.Clear();

            string[] names = installedOnlineMods.getNames();
            for (int i = 0; i < names.Length; i++)
            {
                combobox_online_uninstall.Items.Add(names[i]);
            }
        }

        public void ComboboxOfflineUninstallFill()
        {
            combobox_local_uninstall.SelectedIndex = -1;
            combobox_local_uninstall.Items.Clear();

            string[] names = installedOfflineMods.getNames();
            for (int i = 0; i < names.Length; i++)
            {
                combobox_local_uninstall.Items.Add(names[i]);
            }
        }

        private void button_online_updates_Click(object sender, EventArgs e)
        {
            List<string> modsToUpdate = new List<string>();
            for (int i = 0; i < installedOnlineMods.mods.Count; i++)
            {
                for (int k = 0; k < availableOnlineMods.mods.Count; k++)
                {
                    if (installedOnlineMods.mods[i].name == availableOnlineMods.mods[k].name)
                    {
                        if (installedOnlineMods.mods[i].version != availableOnlineMods.mods[k].version)
                        {
                            DialogResult result = MessageBox.Show("There is a new version of the mod '" + installedOnlineMods.mods[i].name + "' available. Do you wish to update?\n\n!!!WARNING!!! Make a backup of your old mods scripts and settings, as they get deleted if you proceed.\n\nOld version: " + installedOnlineMods.mods[i].version + "\nNew version: " + availableOnlineMods.mods[k].version, "Update mod",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1,
                            MessageBoxOptions.DefaultDesktopOnly);

                            if (result == DialogResult.Yes)
                            {
                                ModManagement.UninstallMod(installedOnlineMods.mods[i].name + "_" + installedOnlineMods.mods[i].version, historyDirectory);
                                string zip = historyDirectory + @"\" + ModManagement.GenerateRandomNumberString(10) + ".zip";
                                DownloadZipFile(availableOnlineMods.mods[k].link, zip);
                                ModManagement.InstallMod(zip, availableOnlineMods.mods[k].name + "_" + availableOnlineMods.mods[k].version, historyDirectory, true);
                                installedOnlineMods.changeVersion(installedOnlineMods.mods[i].name, availableOnlineMods.mods[k].version);
                                File.WriteAllText(installedOnlineModsFile, installedOnlineMods.generateFile());
                                ComboboxOfflineUninstallFill();
                            }
                        }
                        break;
                    }
                }
            }
            MessageBox.Show("No updates for mods found!");
        }
    }
}


