using System.Collections.Generic;
using System.Text;

namespace ArcticDB.Model
{
    public class SamplePojo
    {
        public List<MetaObject> metaList = new List<MetaObject>();
        public string Date;
        public string name;
        public int id;
        public SamplePojo(int id, string name, string Date,List<MetaObject> metaObjects)
        {
            this.id = id;
            this.name = name;
            this.metaList = metaObjects;
            this.Date = Date;
        }
        public SamplePojo()
        {
        }
        public SamplePojo(string name, string Date, List<MetaObject> metaObjects)
        {
            this.name = name;
            this.metaList = metaObjects;
            this.Date = Date;
        }
        public SamplePojo(string name)
        {
            this.name = name;
        }
        public SamplePojo(int id, string name, string Date)
        {
            this.id = id;
            this.name = name;
            this.Date = Date;
        }

        public string getKeysString()
        {
            StringBuilder keysString = new StringBuilder();
            foreach (MetaObject key in metaList)
            {
                keysString.Append(key.Value.Substring(0,key.Value.IndexOf("-->")!=-1? key.Value.IndexOf("-->") : key.Value.Length)).Append(" ");
            }
            return keysString.ToString();
        }
    }
}