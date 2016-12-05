using System;
using System.Collections.Generic;
using ArcticDB.Model;
using System.Data.SQLite;
using System.Windows.Forms;
using NLog;
/*
CREATE TABLE SampeTypeParameters ( SampeTypeId integer, InputParameterId integer )
CREATE TABLE SampleType ( id integer PRIMARY KEY AUTOINCREMENT, name text )
CREATE TABLE `SampleImputPamameters` ( `SampleId` integer, `InputParameterId` integer NOT NULL, `value` text, FOREIGN KEY(`InputParameterId`) REFERENCES InputParamaters(id) ) 
*/
namespace ArcticDB.Servicies
{
    internal class ObjectsOfInvestServiceImpl : IObjectsOfInvestService
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private const string SELECT_ALL = "SELECT id,name FROM SampleType";
        private const string INSERT = "INSERT INTO SampleType (id, name) VALUES (@id,@name)";
        private const string INSERT_CHARACTS = "INSERT INTO SampeTypeParameters (InputParameterId, SampeTypeId) VALUES (@InputParameterId,@SampeTypeId)";
        private const string DELETE_ONE = "DELETE FROM SampleType WHERE id = @id";
        private const string UPDATE = "UPDATE SampleType SET name= @name WHERE id = @id";
        private const string SELECT_OBJECTTYPE_CHARACTS_ALL = "SELECT SampleType.id,SampleType.name,InputParamaters.id,InputParamaters.name FROM SampleType LEFT JOIN SampeTypeParameters ON SampleType.id = SampeTypeParameters.SampeTypeId LEFT JOIN InputParamaters ON SampeTypeParameters.InputParameterId = InputParamaters.id";
        private const string SELECT_OBJECTTYPE_CHARACTS_BY_ID = "SELECT InputParamaters.id AS id,InputParamaters.name AS name FROM SampeTypeParameters LEFT JOIN InputParamaters ON SampeTypeParameters.InputParameterId = InputParamaters.id WHERE SampeTypeParameters.SampeTypeId = @id";
        private const string DELETE_OBJTYPE_CHARACTS = "DELETE FROM SampeTypeParameters WHERE SampeTypeId = @id";

        public ObjectOfInvestigationPojo addObjectOfInvestigation(ObjectOfInvestigationPojo objectOfInvestigation)
        {
            SQLiteTransaction transact = Program.conn.BeginTransaction();

            SQLiteCommand addObjects = new SQLiteCommand(INSERT, Program.conn, transact);
            addObjects.Parameters.Add(new SQLiteParameter("@id", null));
            addObjects.Parameters.Add(new SQLiteParameter("@name", objectOfInvestigation.name));

            try
            {
                addObjects.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                transact.Rollback();
                if (ex.Message.Contains("FOREIGN"))
                {
                    MessageBox.Show("Данную запись нельзя удалить.\nОна используется в связанных таблицах.",
                        "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return null;
                }
                throw new Exception(ex.Message);
            }
            objectOfInvestigation.id = SQLLiteUtil.getLastRowId();

            foreach (Characteristic characteristic in objectOfInvestigation.characteristics)
            {
                SQLiteCommand addCharactsForObject = new SQLiteCommand(INSERT_CHARACTS, Program.conn, transact);
                addCharactsForObject.Parameters.Add(new SQLiteParameter("@InputParameterId", characteristic.id));
                addCharactsForObject.Parameters.Add(new SQLiteParameter("@SampeTypeId", objectOfInvestigation.id));
                try
                {
                    addCharactsForObject.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    logger.Error(ex);
                    transact.Rollback();
                    if (ex.Message.Contains("FOREIGN"))
                    {
                        MessageBox.Show("Данную запись нельзя удалить.\nОна используется в связанных таблицах.",
                            "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return null;
                    }
                    throw new Exception(ex.Message);
                }
                
            }
                       
            transact.Commit();

            return objectOfInvestigation;
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
                    logger.Debug("r.Read(): " + objectOfInvestigation);
                }
                r.Close();
            }
            catch (SQLiteException ex)
            {
                logger.Error(ex);
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
                logger.Error(ex);
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
            return new ObjectOfInvestigationPojo();
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
                    logger.Debug("r.Read(): " + characteristic);
                }
                r.Close();
            }
            catch (SQLiteException ex)
            {
                logger.Error(ex);
            }
            return characteristics;
        }
    }
}