﻿using LovroLog.LovroEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LovroLog.Database
{
    public class DataAccessWrapper : IDataAccess
    {
        private bool useXMLDatabase = false;
        private LovroContext databaseAccessor;
        private DataAccessXML xmlDatabaseAccessor;

        public DataAccessWrapper(string dataAccessDetails, bool useXMLDatabase)
        {
            this.DataAccessDetails = dataAccessDetails;
            this.useXMLDatabase = useXMLDatabase;

            if (useXMLDatabase)
                this.xmlDatabaseAccessor = new DataAccessXML(DataAccessDetails);
            else
                this.databaseAccessor = new LovroContext(DataAccessDetails);
        }

        public string DataAccessDetails { get; set; }

        public DatabaseSummary GetSummary()
        {
            if (useXMLDatabase)
                return xmlDatabaseAccessor.GetSummary();
            else
                return databaseAccessor.Summaries.FirstOrDefault();
        }

        public IEnumerable<LovroBaseEvent> GetBaseEvents()
        {
            if (useXMLDatabase)
                return xmlDatabaseAccessor.GetBaseEvents();
            else
                return databaseAccessor.BaseEvents;
        }

        public IEnumerable<LovroDiaperChangedEvent> GetDiaperChangedEvents()
        {
            if (useXMLDatabase)
                return xmlDatabaseAccessor.GetDiaperChangedEvents();
            else
                return databaseAccessor.DiaperChangedEvents;
        }

        public DatabaseSummary GetDatabaseSummary()
        { 
            if (useXMLDatabase)
                return xmlDatabaseAccessor.GetSummary();
            else
                return databaseAccessor.Summaries.FirstOrDefault();
        }

        public void DeleteBaseEvent(int id)
        {
            if (useXMLDatabase)
                xmlDatabaseAccessor.DeleteBaseEvent(id);
            else
            {
                LovroBaseEvent eventToDelete = databaseAccessor.BaseEvents.FirstOrDefault(item => item.ID == id);
                if (eventToDelete != null)
                {
                    databaseAccessor.BaseEvents.Remove(eventToDelete);
                }
            }
        }

        public LovroBaseEvent AddBaseEvent(LovroBaseEvent newEvent)
        {
            if (useXMLDatabase)
                return xmlDatabaseAccessor.AddBaseEvent(newEvent);
            else
            {
                if (newEvent != null)
                {
                    return databaseAccessor.BaseEvents.Add(newEvent); // now with ID set automatically by the database
                }
            }
            return null;
        }

        public LovroBaseEvent EditBaseEvent(LovroBaseEvent editedEvent)
        {
            if (useXMLDatabase)
                xmlDatabaseAccessor.EditBaseEvent(editedEvent);
            else
            {
                if (editedEvent != null)
                {
                    LovroBaseEvent savedEvent = databaseAccessor.BaseEvents.FirstOrDefault(item => item.ID == editedEvent.ID);
                    if (savedEvent != null)
                        savedEvent.CopyProperties(editedEvent);

                    return savedEvent;
                }
            }

            return null;
        }

        public void Dispose()
        {
            if (this.databaseAccessor != null)
            {
                databaseAccessor.SaveChanges();
                this.databaseAccessor.Dispose();
            }
        }
    }
}
