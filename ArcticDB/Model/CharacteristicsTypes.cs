using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArcticDB.Model
{
    public sealed class CharacteristicsTypes
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private readonly String name;
        private readonly int value;

        public static readonly CharacteristicsTypes INTEGER = new CharacteristicsTypes(1, "Целое");
        public static readonly CharacteristicsTypes FLOAT = new CharacteristicsTypes(2, "Дробное");
        public static readonly CharacteristicsTypes TEXT = new CharacteristicsTypes(3, "Текст");
        public static readonly CharacteristicsTypes DATE = new CharacteristicsTypes(4, "Дата");
        public static readonly CharacteristicsTypes FILE = new CharacteristicsTypes(5, "Файл");

        public int getTypeOrdinal()
        {
            return value;
        }

        public static CharacteristicsTypes getCharacteristicsTypesByType(int value)
        {
            switch (value)
            {
                case 1:
                    return INTEGER;
                case 2:
                    return FLOAT;
                case 3:
                    return TEXT;
                case 4:
                    return DATE;
                case 5:
                    return FILE;
                default:
                    return null;
            }
        }

        private CharacteristicsTypes(int value, String name)
        {
            this.name = name;
            this.value = value;
        }

        public override String ToString()
        {
            return name;
        }
        public static CharacteristicsTypes valueOf(string input)
        {
            switch (input)
            {
                case "Целое":
                    return INTEGER;
                case "Дробное":
                    return FLOAT;
                case "Текст":
                    return TEXT;
                case "Дата":
                    return DATE;
                case "Файл":
                    return FILE;
                default:
                    return null;
            }
        }
    }
}
