using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Xml;
using System.Xml.Serialization;

namespace LauncherLesAuDacieuX
{
    [Serializable]
    public class Config
    {
        /// <summary>
        /// Le nom du serveur à afficher
        /// </summary>
        public string ServerName;
        /// <summary>
        /// Le port du serveur de jeu
        /// </summary>
        public int ServerPort;
        /// <summary>
        /// L'ip du serveur de jeu
        /// </summary>
        public string ServerIp;
        /// <summary>
        /// Liste des Mods
        /// </summary>
        public List<Mod> Mods = new List<Mod>();
        /// <summary>
        /// AppData pour tous les utilisateurs
        /// </summary>
        public static string CommonAppData = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);

        public const string AppName = "ADX";

        public static string CommonAppFolderPath => Path.Combine(CommonAppData,AppName);

        internal static string FilePath = Path.Combine(CommonAppFolderPath, "test.cfg");

        /// <summary>
        /// Sauvegarde de l'objet courant au format XML
        /// </summary>
        /// <param name="path"></param>
        public void Save()
        {
            if (!Directory.Exists(CommonAppFolderPath))
                Directory.CreateDirectory(CommonAppFolderPath);
            XmlSerializer serializer = new XmlSerializer(typeof(Config));
            serializer.Serialize(File.OpenWrite(FilePath), this);
        }

        /// <summary>
        /// Chargement d'un objet config
        /// </summary>
        /// <returns></returns>
        public static Config LoadLocal()
        {
            if(!File.Exists(FilePath))
                return new Config();
            return DeserializeInternal(File.OpenRead(FilePath));
        }

        /// <summary>
        /// Chargement d'un objet config en TCP
        /// </summary>
        /// <param name="hostname"></param>
        /// <param name="port"></param>
        /// <returns></returns>
        public static Config LoadRemote(string uri)
        {
            var request = WebRequest.Create(uri);
            var stream = request.GetResponse().GetResponseStream();
            return DeserializeInternal(stream);
        }

        /// <summary>
        /// Fonction de deserialisation interne
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        internal static Config DeserializeInternal(Stream stream)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Config));
            return (Config)serializer.Deserialize(stream);
        }

        /// <summary>
        /// Recupère la liste de mod a mettre a jour
        /// </summary>
        /// <param name="oldConfig"></param>
        /// <param name="newConfig"></param>
        /// <returns></returns>
        public static List<Mod> ModsDifferencies(Config oldConfig, Config newConfig)
        {
            var modsToUpdate = new List<Mod>(newConfig.Mods);
            foreach (var oldMod in oldConfig.Mods)
            {
                foreach (var newMod in newConfig.Mods)
                {
                    if (oldMod.Version == newMod.Version)
                        modsToUpdate.Remove(newMod);
                }
            }
            return modsToUpdate;
        }
    }
}