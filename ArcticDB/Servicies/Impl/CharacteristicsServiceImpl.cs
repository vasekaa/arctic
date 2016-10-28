using ArcticDB;
using ArcticDB.Model;
using ArcticDB.Servicies;
using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace ArcticDB.Views
{
    internal class CharacteristicsServiceImpl : ICharacteristicsService
    {
        private const string SELECT_ALL = "SELECT id,name,type FROM InputParamaters";
        private const string INSERT = "INSERT INTO InputParamaters (id, name, type) VALUES (@id,@name,@type)";
        private const string DELETE_ONE = "DELETE FROM InputParamaters WHERE id = @id";
        public Characteristic addCharacteristic(Characteristic characteristic)
        {
            SQLiteCommand insertSQL = new SQLiteCommand(INSERT, Program.conn);
            insertSQL.Parameters.Add(new SQLiteParameter("@id",null));
            insertSQL.Parameters.Add(new SQLiteParameter("@name", characteristic.name));
            insertSQL.Parameters.Add(new SQLiteParameter("@type", characteristic.type.getTypeOrdinal().ToString()));
            try
            {
                insertSQL.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            characteristic.id = SQLLiteUtil.getLastRowId();
            return characteristic;
        }

        public List<Characteristic> getAllCharacteristics()
        {
            SQLiteCommand cmd = new SQLiteCommand(Program.conn);
            List<Characteristic> characteristics = new List<Characteristic>();
            cmd.CommandText = SELECT_ALL;
            try
            {
                SQLiteDataReader r = cmd.ExecuteReader();
                Characteristic characteristic = null;
                while (r.Read())
                {
                    characteristic = new Characteristic(CharacteristicsTypes.getCharacteristicsTypesByType(Int32.Parse(r["type"].ToString())), r["name"].ToString(), Int32.Parse(r["id"].ToString()));
                    characteristics.Add(characteristic);
                    Console.WriteLine(characteristic);
                }
                r.Close();
            }
            catch (SQLiteException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return characteristics;
        }

        public Characteristic removeCharacteristic(int characteristicId)
        {
            SQLiteCommand insertSQL = new SQLiteCommand(DELETE_ONE, Program.conn);
            insertSQL.Parameters.Add(new SQLiteParameter("@id", characteristicId));
            try
            {
                insertSQL.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
            return null;
        }
    }
}