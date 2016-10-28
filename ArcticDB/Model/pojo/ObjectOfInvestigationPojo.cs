using System.Collections.Generic;

namespace ArcticDB.Model
{
    public class ObjectOfInvestigationPojo
    {
        public List<Characteristic> characteristics;
        public string name;
        public int id;
        public ObjectOfInvestigationPojo(int id, string name, List<Characteristic> characteristics)
        {
            this.id = id;
            this.name = name;
            this.characteristics = characteristics;
        }
        public ObjectOfInvestigationPojo()
        {
        }
        public ObjectOfInvestigationPojo(string name, List<Characteristic> characteristics)
        {
            this.name = name;
            this.characteristics = characteristics;
        }
        public ObjectOfInvestigationPojo(string name)
        {
            this.name = name;
        }
        public ObjectOfInvestigationPojo(int id, string name)
        {
            this.id = id;
            this.name = name;
        }
    }
}