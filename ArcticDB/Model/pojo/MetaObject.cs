using ArcticDB.Model;

namespace ArcticDB.Model
{
    public class MetaObject
    {
        public MetaObject()
        {
        }
        public MetaObject(int id, int type, string Value, int SampleId)
        {
            this.type = type;
            this.Value = Value;
            this.id = id;
            this.SampleId = SampleId;
        }
        public MetaObject(int type,string Value, int id)
        {
            this.type = type;
            this.Value = Value;
            this.id = id;
        }
        public MetaObject(int type, string Value)
        {
            this.type = type;
            this.Value = Value;
        }

        public int type;//0 - Keyword, 1 - file
        public string Value;
        public int id;
        public int SampleId;
    }
}