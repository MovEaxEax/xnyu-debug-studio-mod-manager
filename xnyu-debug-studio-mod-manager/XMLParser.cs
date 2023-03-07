using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace xnyu_debug_studio_mod_manager
{
    public class XMLParser
    {
        public struct ModInfo
        {
            public string name;
            public string version;
            public string link;
        };

        public List<ModInfo> mods;

        public XMLParser(string text)
        {
            mods = parseText(text);
        }

        public List<ModInfo> parseText(string text)
        {
            List<ModInfo> _mods = new List<ModInfo>();

            text = text.Replace("\n", "");
            text = text.Replace("\r", "");
            text = text.Replace("\t", "");

            text = text.Replace("<mods>", "");
            text = text.Replace("</mods>", "");

            text = text.Replace("<mod>", "");
            text = text.Replace("</mod>", "");

            int index = 0;
            while (index + 45 < text.Length)
            {
                int indexName = text.IndexOf("<name>", index);
                int indexVersion = text.IndexOf("<version>", index);
                int indexLink = text.IndexOf("<link>", index);

                int indexNameClose = text.IndexOf("</name>", index);
                int indexVersionClose = text.IndexOf("</version>", index);
                int indexLinkClose = text.IndexOf("</link>", index);

                if (indexName == -1 || indexVersion == -1 || indexLink == -1 || indexNameClose == -1 || indexVersionClose == -1 || indexLinkClose == -1) break;

                ModInfo _mod = new ModInfo();

                _mod.name = text.Substring(indexName + 6, indexNameClose - (indexName + 6));
                _mod.version = text.Substring(indexVersion + 9, indexVersionClose - (indexVersion + 9));
                _mod.link = text.Substring(indexLink + 6, indexLinkClose - (indexLink + 6));

                if (_mod.name != "" && _mod.version != "" && _mod.link != "")
                {
                    _mods.Add(_mod);
                }

                if (indexName > indexVersion && indexName > indexLink) index = indexNameClose + 7;
                if (indexVersion > indexName && indexVersion > indexLink) index = indexVersionClose + 10;
                if (indexLink > indexVersion && indexLink > indexName) index = indexLinkClose + 7;
            }

            return _mods;
        }

        public void addMod(string name, string version, string link)
        {
            ModInfo mod = new ModInfo();
            mod.name = name;
            mod.version = version;
            mod.link = link;
            mods.Add(mod);
        }

        public void deleteMod(string name)
        {
            int index = mods.FindIndex((mod) => (mod.name == name));
            if (index > -1) mods.RemoveAt(index);
        }

        public void changeVersion(string name, string version)
        {
            int index = mods.FindIndex((_mod) => (_mod.name == name));
            if (index > -1)
            {
                ModInfo mod = new ModInfo();
                mod.name = mods[index].name;
                mod.version = version;
                mod.link = mods[index].link;
                mods[index] = mod;
            }
        }

        public string generateFile()
        {
            string finalFile = "<mods>\n";

            for (int i = 0; i < mods.Count; i++)
            {
                finalFile = finalFile + "\t<mod>\n";
                finalFile = finalFile + "\t\t<name>" + mods[i].name + "</name>\n";
                finalFile = finalFile + "\t\t<version>" + mods[i].version + "</version>\n";
                finalFile = finalFile + "\t\t<link>" + mods[i].link + "</link>\n";
                finalFile = finalFile + "\t</mod>\n";
            }

            finalFile = finalFile + "</mods>\n";

            return finalFile;
        }

        public string[] getNames()
        {
            string[] names = new string[mods.Count];
            for (int i = 0; i < mods.Count; i++) names[i] = mods[i].name;
            return names;
        }

        public string[] getVersions()
        {
            string[] versions = new string[mods.Count];
            for (int i = 0; i < mods.Count; i++) versions[i] = mods[i].version;
            return versions;
        }

        public string[] getLinks()
        {
            string[] links = new string[mods.Count];
            for (int i = 0; i < mods.Count; i++) links[i] = mods[i].link;
            return links;
        }

        public string getVersion(string name)
        {
            int index = mods.FindIndex((mod) => (mod.name == name));
            if (index > -1) return mods[index].version;
            return "";
        }

        public string setVersion(string name, string version)
        {
            int index = mods.FindIndex((mod) => (mod.name == name));
            if (index > -1) return mods[index].version;
            return "";
        }

        public string getLink(string name)
        {
            int index = mods.FindIndex((mod) => (mod.name == name));
            if (index > -1) return mods[index].link;
            return "";
        }

    }
}
