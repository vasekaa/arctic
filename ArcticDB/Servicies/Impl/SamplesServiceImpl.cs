using System;
using System.Collections.Generic;
using ArcticDB.Model;
using System.Data.SQLite;
using System.Windows.Forms;
using System.Text;
using NLog;

/*
 CREATE TABLE "Sample" ( `id` integer PRIMARY KEY AUTOINCREMENT, `Name` text, `Date` text )
 CREATE TABLE "SampeMeta" ( `id` integer PRIMARY KEY AUTOINCREMENT, `value` text, `Type` integer,`SampeId` integer, FOREIGN KEY(`SampeId`) REFERENCES Sample(id) )    

*/

namespace ArcticDB.Servicies
{
    internal class SamplesServiceImpl : ISamplesService
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private const string SELECT_ALL = "SELECT id,Name,Date FROM Sample";
        private const string SELECT_OBJECTTYPE_CHARACTS_BY_ID = "SELECT id,Type,value,SampeId FROM SampeMeta WHERE SampeId = @id";
        private const string SELECT_SAMPLE_BY_ID = "SELECT SampeMeta.id as id,SampeMeta.Type as Type,SampeMeta.value as value,Sample.id as SampeId,Sample.Date as Date,Sample.Name as Name FROM Sample LEFT JOIN SampeMeta ON SampeMeta.SampeId = Sample.id WHERE Sample.id=@SampleId";
        private const string SELECT_OBJECTTYPE_CHARACTS_BY_ID_AND_TYPE = "SELECT id,Type,value,SampeId FROM SampeMeta WHERE SampeId = @id AND Type = @Type";
        private const string INSERT = "INSERT INTO Sample (id, Name,Date) VALUES (@id,@Name,@Date)";
        private const string INSERT_META = "INSERT INTO SampeMeta (id, value,Type, SampeId) VALUES (@id, @value,@Type, @SampeId)";
        private const string DELETE_ONE = "DELETE FROM Sample WHERE id = @id";
        private const string DELETE_META_BY_SAMPLE_ID = "DELETE FROM SampeMeta WHERE SampeId = @SampeId";
        private const string UPDATE = "UPDATE Sample SET name= @name,Date= @Date  WHERE id = @id";
        private const string SELECT_ALL_META_BY_TYPE = "SELECT id, Type, value, SampeId FROM SampeMeta WHERE Type=@Type";
        private const string SELECT_SAMPLES_BY_KEYWORD = "Select DISTINCT Sample.id AS id,Sample.name AS Name ,Sample.Date AS Date FROM Sample LEFT JOIN SampeMeta ON Sample.id = SampeMeta.SampeId";


        public List<SamplePojo> getAllSamples()
        {
            SQLiteCommand cmd = new SQLiteCommand(Program.conn);
            List<SamplePojo> samplePojoList = new List<SamplePojo>();
            cmd.CommandText = SELECT_ALL;
            try
            {
                SQLiteDataReader r = cmd.ExecuteReader();
                SamplePojo samplePojo = null;
                while (r.Read())
                {
                    samplePojo = new SamplePojo(Int32.Parse(r["id"].ToString()), r["Name"].ToString(), r["Date"].ToString());
                    samplePojoList.Add(samplePojo);
                    logger.Debug("r.Read(): " + samplePojo);
                }
                r.Close();
            }
            catch (SQLiteException ex)
            {
                logger.Error(ex);
            }

            foreach(SamplePojo sample in samplePojoList)
            {
                List<MetaObject> metaList = getMetaBySampleId(sample.id, -1);
                sample.metaList = metaList;
            }
            
            return samplePojoList;
        }

        public SamplePojo addSample(SamplePojo samplePojo)
        {
            SQLiteTransaction transact = Program.conn.BeginTransaction();

            SQLiteCommand addObjects = new SQLiteCommand(INSERT, Program.conn, transact);
            addObjects.Parameters.Add(new SQLiteParameter("@id", null));
            addObjects.Parameters.Add(new SQLiteParameter("@Name", samplePojo.name));
            addObjects.Parameters.Add(new SQLiteParameter("@Date", samplePojo.Date));

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
                    MessageBox.Show("Ошибка добавления",
                        "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return null;
                }
                throw new Exception(ex.Message);
            }
            samplePojo.id = SQLLiteUtil.getLastRowId();

            foreach (MetaObject metaItem in samplePojo.metaList)
            {
                metaItem.SampleId = samplePojo.id;
                SQLiteCommand addMetaForObject = new SQLiteCommand(INSERT_META, Program.conn, transact);
                addMetaForObject.Parameters.Add(new SQLiteParameter("@id", null));
                addMetaForObject.Parameters.Add(new SQLiteParameter("@value", metaItem.Value));
                addMetaForObject.Parameters.Add(new SQLiteParameter("@Type", metaItem.type));
                addMetaForObject.Parameters.Add(new SQLiteParameter("@SampeId", metaItem.SampleId));
                try
                {
                    addMetaForObject.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    logger.Error(ex);
                    transact.Rollback();
                    if (ex.Message.Contains("FOREIGN"))
                    {
                        MessageBox.Show("Данную запись нельзя добавить.",
                            "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return null;
                    }
                    throw new Exception(ex.Message);
                }

            }

            transact.Commit();

            return samplePojo;
        }

        public SamplePojo removeSample(int samplePojoId)
        {
            SQLiteTransaction transact = Program.conn.BeginTransaction();
            SQLiteCommand removeObjects = new SQLiteCommand(DELETE_ONE, Program.conn, transact);
            removeObjects.Parameters.Add(new SQLiteParameter("@id", samplePojoId));
            SQLiteCommand removeMetaForObject = new SQLiteCommand(DELETE_META_BY_SAMPLE_ID, Program.conn, transact);
            removeMetaForObject.Parameters.Add(new SQLiteParameter("@SampeId", samplePojoId));
            try
            {
                removeMetaForObject.ExecuteNonQuery();
                removeObjects.ExecuteNonQuery();
                
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
            return new SamplePojo();
        }

        public void updateSample(SamplePojo samplePojo)
        {
            SQLiteCommand insertSQL = new SQLiteCommand(UPDATE, Program.conn);
            insertSQL.Parameters.Add(new SQLiteParameter("@Name", samplePojo.name));
            insertSQL.Parameters.Add(new SQLiteParameter("@Date", samplePojo.Date));
            insertSQL.Parameters.Add(new SQLiteParameter("@id", samplePojo.id));
            try
            {
                insertSQL.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                throw new Exception(ex.Message);
            }
        }

        public List<MetaObject> getMetaBySampleId(int samplePojoId, int Type)
        {
            List<MetaObject> metaObjectList = new List<MetaObject>();
            SQLiteCommand fetchMeta = new SQLiteCommand(Program.conn);
            if (Type == -1)
            {
                fetchMeta.CommandText = SELECT_OBJECTTYPE_CHARACTS_BY_ID;
                fetchMeta.Parameters.Add(new SQLiteParameter("@id", samplePojoId));
            }
            else
            {
                fetchMeta.CommandText = SELECT_OBJECTTYPE_CHARACTS_BY_ID_AND_TYPE;
                fetchMeta.Parameters.Add(new SQLiteParameter("@id", samplePojoId));
                fetchMeta.Parameters.Add(new SQLiteParameter("@Type", Type));
            }

            try
            {
                SQLiteDataReader r = fetchMeta.ExecuteReader();
                MetaObject metaObject = null;
                while (r.Read())
                {
                    metaObject = new MetaObject(Int32.Parse(r["id"].ToString()), Int32.Parse(r["Type"].ToString()), r["value"].ToString(), Int32.Parse(r["SampeId"].ToString()));
                    metaObjectList.Add(metaObject);
                    logger.Debug("r.Read(): " + metaObject);
                }
                r.Close();
            }
            catch (SQLiteException ex)
            {
                logger.Error(ex);
            }
            return metaObjectList;
        }

        public List<SamplePojo> getSamplesByKeywords(string[] keywords)
        {
            if (keywords == null)
                return null;
            SQLiteCommand cmd = new SQLiteCommand(Program.conn);
            List<SamplePojo> samplePojoList = new List<SamplePojo>();
            StringBuilder query = new StringBuilder(SELECT_SAMPLES_BY_KEYWORD);
            if (keywords != null && keywords.Length>0 && !(keywords.Length == 1 && keywords[0].Equals(""))) {
                query.Append(" WHERE SampeMeta.value like");
                for (int i = 0; i < keywords.Length; i++)
                {
                    String word = keywords[i];
                    query.Append(" \"%" + word + "%\"");
                    if (i != keywords.Length - 1)
                        query.Append(" OR SampeMeta.value like");
                }
            }
            cmd.CommandText = query.ToString();
            try
            {
                SQLiteDataReader r = cmd.ExecuteReader();
                SamplePojo samplePojo = null;
                while (r.Read())
                {
                    samplePojo = new SamplePojo(Int32.Parse(r["id"].ToString()), r["Name"].ToString(), r["Date"].ToString());
                    samplePojoList.Add(samplePojo);
                    logger.Debug("r.Read(): " + samplePojo);
                }
                r.Close();
            }
            catch (SQLiteException ex)
            {
                logger.Error(ex);
            }

            foreach (SamplePojo sample in samplePojoList)
            {
                List<MetaObject> metaList = getMetaBySampleId(sample.id, -1);
                sample.metaList = metaList;
            }

            return samplePojoList;
        }

        public List<string> getFilelistBySample(int samplePojoId)
        {
            List<string> fileList = new List<string>();
            List<MetaObject> metaList = getMetaBySampleId(samplePojoId, 1);
            return FilesUtil.getStorageFileNamesByMeta(metaList);
        }

        public SamplePojo getSampleBySampleId(int samplePojoId)
        {
            SQLiteCommand cmd = new SQLiteCommand(Program.conn);
            List<SamplePojo> samplePojoList = new List<SamplePojo>();
            List<MetaObject> metaList = new List<MetaObject>();
            SamplePojo samplePojo = null;
            cmd.CommandText = SELECT_SAMPLE_BY_ID;
            cmd.Parameters.Add(new SQLiteParameter("@SampleId", samplePojoId));
            try
            {
                SQLiteDataReader r = cmd.ExecuteReader();
                while (r.Read())
                {
                    if (samplePojo == null)
                    {
                        samplePojo = new SamplePojo(Int32.Parse(r["SampeId"].ToString()), r["Name"].ToString(), r["Date"].ToString());
                        samplePojo.metaList = metaList;
                        logger.Debug("r.Read(): " + samplePojo);
                    }
                    //Check if there is MetaData
                    String MetaItemId = r["id"].ToString();
                    if (!MetaItemId.Equals(""))
                    {
                        MetaObject metaObj = new MetaObject(Int32.Parse(MetaItemId), Int32.Parse(r["Type"].ToString()), r["value"].ToString(), samplePojo.id);
                        metaObj.SampleId = samplePojo.id;
                        metaList.Add(metaObj);
                    }
                }
                r.Close();
            }
            catch (SQLiteException ex)
            {
                logger.Error(ex);
                MessageBox.Show("Не получилось достать образец из Базы данных - " + ex.Message,
                       "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }

            return samplePojo;
        }

        public void removeMetaBySample(int samplePojoId)
        {
            SQLiteTransaction transact = Program.conn.BeginTransaction();
            SQLiteCommand removeMetaForObject = new SQLiteCommand(DELETE_META_BY_SAMPLE_ID, Program.conn, transact);
            removeMetaForObject.Parameters.Add(new SQLiteParameter("@SampeId", samplePojoId));
            try
            {
                removeMetaForObject.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                transact.Rollback();
                if (ex.Message.Contains("FOREIGN"))
                {
                    MessageBox.Show("Данную запись нельзя удалить.\nОна используется в связанных таблицах.",
                        "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                throw new Exception(ex.Message);
            }
            transact.Commit();
        }

        public void addMetaBySample(SamplePojo samplePojo)
        {
            foreach (MetaObject metaItem in samplePojo.metaList)
            {
                metaItem.SampleId = samplePojo.id;
                SQLiteCommand addMetaForObject = new SQLiteCommand(INSERT_META, Program.conn);
                addMetaForObject.Parameters.Add(new SQLiteParameter("@id", null));
                addMetaForObject.Parameters.Add(new SQLiteParameter("@value", metaItem.Value));
                addMetaForObject.Parameters.Add(new SQLiteParameter("@Type", metaItem.type));
                addMetaForObject.Parameters.Add(new SQLiteParameter("@SampeId", metaItem.SampleId));
                try
                {
                    addMetaForObject.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    logger.Error(ex);
                    if (ex.Message.Contains("FOREIGN"))
                    {
                        MessageBox.Show("Данную запись нельзя добавить.",
                            "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    throw new Exception(ex.Message);
                }

            }
        }

        public List<MetaObject> getAllMetaByType(int type)
        {
            SQLiteCommand cmd = new SQLiteCommand(Program.conn);
            List<MetaObject> metaObjectList = new List<MetaObject>();
            cmd.CommandText = SELECT_ALL_META_BY_TYPE;
            cmd.Parameters.Add(new SQLiteParameter("@Type", type));
            MetaObject metaObject = null;
            try
            {
                SQLiteDataReader r = cmd.ExecuteReader();    
                while (r.Read())
                {
                    metaObject = new MetaObject(Int32.Parse(r["id"].ToString()), Int32.Parse(r["Type"].ToString()), r["value"].ToString(), Int32.Parse(r["SampeId"].ToString()));
                    metaObjectList.Add(metaObject);
                    logger.Debug("r.Read(): " + metaObject);
                }
                r.Close();
            }
            catch (SQLiteException ex)
            {
                logger.Error(ex);
            }
            return metaObjectList;
        }
    }
}