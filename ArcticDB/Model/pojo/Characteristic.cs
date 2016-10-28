using ArcticDB.Model;

namespace ArcticDB.Model
{
    public class Characteristic
    {
        public Characteristic(CharacteristicsTypes type,string name,int id)
        {
            this.type = type;
            this.name = name;
            this.id = id;
        }
        public Characteristic(int id, string name)
        {
            this.name = name;
            this.id = id;
        }
        public Characteristic(CharacteristicsTypes type, string text)
        {
            this.type = type;
            this.name = text;
        }

        public CharacteristicsTypes type;
        public string name;
        public int id;
    }
}