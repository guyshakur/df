﻿using System.IO;
using System.Xml.Serialization;

namespace BasicFacebookFeatures
{
    public sealed class FileUtils
    {
        private static readonly FileUtils r_FileUtilsInstance = new FileUtils();

        static FileUtils()
        {
        }

        private FileUtils()
        {
        }

        public static FileUtils FileUtilsInstance
        {
            get
            {
                return r_FileUtilsInstance;
            }
        }

        public static void SaveToFile(string i_FileName, object i_SerializeInstance)
        {
            string startupPath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, i_FileName);

            using (Stream stream = new FileStream(@startupPath, FileMode.Truncate, FileAccess.ReadWrite))
            {
                XmlSerializer serlizer = new XmlSerializer(i_SerializeInstance.GetType());
                serlizer.Serialize(stream, i_SerializeInstance);
            }
        }

        public static object LoadFile(string i_FileName, object i_SerializeInstance)
        {
            object obj = null;
            string startupPath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, i_FileName);

            using (Stream stream = new FileStream(@startupPath, FileMode.Open, FileAccess.ReadWrite))
            {
                XmlSerializer serlizer = new XmlSerializer(i_SerializeInstance.GetType());
                obj = serlizer.Deserialize(stream);
            }

            return obj;
        }
    }
}