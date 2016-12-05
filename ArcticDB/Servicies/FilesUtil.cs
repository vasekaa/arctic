using ArcticDB.Model;
using NLog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArcticDB.Servicies
{
    class FilesUtil
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        public static string[] GetFileNames(string path, string filter)
        {
            string[] files = Directory.GetFiles(path, filter);
            for (int i = 0; i < files.Length; i++)
                files[i] = Path.GetFileName(files[i]);
            return files;
        }
        public static List<String> getVisibleFileNamesByMeta(List<MetaObject> metaObjectList)
        {
            List<String> fileList = new List<string>();
            foreach (MetaObject item in  metaObjectList)
            {
                if(item.type == 1)
                {
                    String line = getVisibleFileNameByMetaItem(item.Value);
                    if (line != null)
                        fileList.Add(line);
                }
                
            }
            return fileList;

        }
        public static List<String> getStorageFileNamesByMeta(List<MetaObject> metaObjectList)
        {
            List<String> fileList = new List<string>();
            foreach (MetaObject item in metaObjectList)
            {
                if (item.type == 1)
                {
                    String line = getStorageFileNameByMetaItem(item.Value);
                    if (line != null)
                        fileList.Add(line);
                }

            }
            return fileList;
        }
        public static String getVisibleFileNameByMetaItem(String line)
        {
            if (line == null || line.IndexOf("-->") == -1)
                return null;
            int startIndex = line.IndexOf("-->") + 3;
            int length = line.Length - startIndex;
            String visibleFileName = line.Substring(0, line.IndexOf("-->"));
            return visibleFileName;
        }
        public static String getStorageFileNameByMetaItem(String line)
        {
            if (line == null || line.IndexOf("-->") == -1)
                return null;
            int startIndex = line.IndexOf("-->") + 3;
            if (startIndex == 2)
                return null;
            int length = line.Length - startIndex;
            String storageFileName = line.Substring(startIndex, length);
            return storageFileName;
        }
    }
}
