using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArcticDB.Model
{
    public sealed class CharacteristicsTypes
    {

        private readonly String name;
        private readonly int value;

        public static readonly CharacteristicsTypes INTEGER = new CharacteristicsTypes(1, "Целое");
        public static readonly CharacteristicsTypes FLOAT = new CharacteristicsTypes(2, "Дробное");
        public static readonly CharacteristicsTypes TEXT = new CharacteristicsTypes(3, "Текст");
        public static readonly CharacteristicsTypes DATE = new CharacteristicsTypes(3, "Дата");
        public static readonly CharacteristicsTypes FILE = new CharacteristicsTypes(3, "Файл");

        private CharacteristicsTypes(int value, String name)
        {
            this.name = name;
            this.value = value;
        }

        public override String ToString()
        {
            return name;
        }
        public CharacteristicsTypes valueOf(string input)
        {
            switch (input)
            {
                case "Целое":
                    return INTEGER;
                    break;
                case "Дробное":
                    return FLOAT;
                    break;
                case "Текст":
                    return TEXT;
                    break;
                case "Дата":
                    return DATE;
                    break;
                case "Файл":
                    return FILE;
                    break;
                default:
                    return null;
            }
        }
    }
}
