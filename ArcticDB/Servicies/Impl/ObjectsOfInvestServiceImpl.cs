using System;
using System.Collections.Generic;
using ArcticDB.Model;
using System.Data.SQLite;
using System.Windows.Forms;

namespace ArcticDB.Servicies
{
    internal class ObjectsOfInvestServiceImpl : IObjectsOfInvestService
    {
        private const string SELECT_ALL = "SELECT id,name FROM SampleType";
        private const string INSERT = "INSERT INTO SampleType (id, name) VALUES (@id,@name)";
        private const string DELETE_ONE = "DELETE FROM SampleType WHERE id = @id";
        private const string UPDATE = "UPDATE SampleType SET name= @name WHERE id = @id";
        private const string SELECT_OBJECTTYPE_CHARACTS_ALL = "SELECT SampleType.id,SampleType.name,InputParamaters.id,InputParamaters.name FROM SampleType LEFT JOIN SampeTypeParameters ON SampleType.id = SampeTypeParameters.SampeTypeId LEFT JOIN InputParamaters ON SampeTypeParameters.InputParameterId = InputParamaters.id";
        private const string SELECT_OBJECTTYPE_CHARACTS_BY_ID = "SELECT InputParamaters.id AS id,InputParamaters.name AS name FROM SampeTypeParameters LEFT JOIN InputParamaters ON SampeTypeParameters.InputParameterId = InputParamaters.id WHERE SampeTypeParameters.SampeTypeId = @id";
        private const string DELETE_OBJTYPE_CHARACTS = "DELETE FROM SampeTypeParameters WHERE SampleType.id = @id";
        public ObjectOfInvestigationPojo addObjectOfInvestigation(ObjectOfInvestigationPojo objectOfInvestigation)
        {
            throw new NotImplementedException();
        }

        public List<ObjectOfInvestigationPojo> getAllObjectOfInvestigations()
        {
            SQLiteCommand cmd = new SQLiteCommand(Program.conn);
            List<ObjectOfInvestigationPojo> objectOfInvestigations = new List<ObjectOfInvestigationPojo>();
            cmd.CommandText = SELECT_ALL;
            try
            {
                SQLiteDataReader r = cmd.ExecuteReader();
                ObjectOfInvestigationPojo objectOfInvestigation = null;
                while (r.Read())
                {
                    objectOfInvestigation = new ObjectOfInvestigationPojo(Int32.Parse(r["id"].ToString()), r["name"].ToString());
                    objectOfInvestigations.Add(objectOfInvestigation);
                    Console.WriteLine(objectOfInvestigation);
                }
                r.Close();
            }
            catch (SQLiteException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return objectOfInvestigations;
        }

        public ObjectOfInvestigationPojo removeObjectOfInvestigation(int objectOfInvestigationId)
        {
            SQLiteTransaction transact = Program.conn.BeginTransaction();
            SQLiteCommand removeObjects = new SQLiteCommand(DELETE_ONE, Program.conn, transact);
            removeObjects.Parameters.Add(new SQLiteParameter("@id", objectOfInvestigationId));
            SQLiteCommand removeCharactsForObject = new SQLiteCommand(DELETE_OBJTYPE_CHARACTS, Program.conn, transact);
            removeCharactsForObject.Parameters.Add(new SQLiteParameter("@id", objectOfInvestigationId));
            try
            {
                removeObjects.ExecuteNonQuery();
                removeCharactsForObject.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                transact.Rollback();
                if (ex.Message.Contains("FOREIGN"))
                {
                    MessageBox.Show("Данную запись нельзя удалить.\nОна используется в связанных таблицах.",
                        "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return null;
                }
                throw new Exception(ex.Message);
            }
            transact.Commit();
            return null;
        }

        public void updateObjectOfInvestigation(ObjectOfInvestigationPojo objectOfInvestigation)
        {
            throw new NotImplementedException();
        }

        public List<Characteristic> getObjectCharactsByObjctId(int objectOfInvestigationId)
        {
            SQLiteCommand cmd = new SQLiteCommand(Program.conn);
            List<Characteristic> characteristics = new List<Characteristic>();
            cmd.CommandText = SELECT_OBJECTTYPE_CHARACTS_BY_ID;
            try
            {
                SQLiteDataReader r = cmd.ExecuteReader();
                Characteristic characteristic = null;
                while (r.Read())
                {
                    characteristic = new Characteristic(Int32.Parse(r["id"].ToString()), r["name"].ToString());
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
    }
}