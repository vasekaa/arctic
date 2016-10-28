using ArcticDB.Model;

namespace ArcticDB
{
    public class Characteristic
    {
        public Characteristic(CharacteristicsTypes type,string name,int id)
        {
            this.type = type;
            this.name = name;
            this.id = id;
        }

        public Characteristic(object selectedValue, string text)
        {
            this.selectedValue = selectedValue;
            this.text = text;
        }

        public CharacteristicsTypes type;
        public string name;
        public int id;
        private object selectedValue;
        private string text;
    }
}