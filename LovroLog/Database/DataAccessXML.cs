using LovroLog.LovroEvents;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace LovroLog.Database
{
    public class DataAccessXML : IDataAccess
    {
        /// <summary>
        /// Struktura:
        /// 
        /// 1. varijanta: 
        /// - jednostavno trpati podatke za svaki dan u odvojeni file s filenameom=taj datum
        /// 
        /// 2. varijanta:
        /// - folder na lokalnoj mašini s xml fileovima
        /// - u folderu "glavni" file u kojem je upisan raspored podataka po fileovima (npr. za datum taj i taj podaci su u fileu tom i tom
        /// - svaki file ima neko random ime, može držati podatke za nekoliko (ili možda čak nekoliko stotina dana--provj. eksperimentalno!), bitno da u svakom fileu nema previše podataka
        /// 
        /// 3. varijanta---PRIVREMENA!!!:
        /// - jednostavno utrpat sve podatke u jedan file zasad, možda ni neće biti sporo, s obzirom na oskudnost informacija. možda json bolje nego xml za smanjit prostor i ubrzat čitanje/parsanje.
        /// </summary>

        public static string _ERR_ITEM_NOT_FOUND = "The specified item could not be found";
        public static string _ERR_FETCHING_DATA = "Failed to retrieve data from the XML database";

        private XmlSerializer serializer;

        public DataAccessXML()
        {
            this.serializer = new XmlSerializer(typeof(LovroEventList), new Type[] { typeof(LovroBaseEvent), typeof(LovroDiaperChangedEvent), typeof(LovroWeighInEvent) });
        }

        public DataAccessXML(string dataAccessDetails)
            : this()
        {
            this.DataAccessDetails = dataAccessDetails;
        }

        public string DataAccessDetails { get; set; } 

        public IEnumerable<LovroBaseEvent> GetBaseEvents()
        {
            if (!File.Exists(DataAccessDetails))
                return new LovroEventList();

            LovroEventList result;

            using (var fileStream = new FileStream(DataAccessDetails, FileMode.Open))
            {
                result = serializer.Deserialize(fileStream) as LovroEventList;
            }

            return result;
        }

        public IEnumerable<LovroDiaperChangedEvent> GetDiaperChangedEvents()
        {
            var result = GetBaseEvents().Where(item => item.Type == Enums.LovroEventType.DiaperChanged) as List<LovroDiaperChangedEvent>; // OHHH BOY
            if (result == null)
                return new List<LovroDiaperChangedEvent>();
            else
                return result;
        }

        public IEnumerable<DatabaseSummary> GetSummaries()
        {
            List<DatabaseSummary> result = new List<DatabaseSummary>();

            if (!File.Exists(DataAccessDetails))
                result.Add(new DatabaseSummary() { ID = 1, LastModified = DateTime.MinValue });
            else
                result.Add(new DatabaseSummary() { ID = 1, LastModified = File.GetLastWriteTime(DataAccessDetails) });

            return result;
        }

        public LovroBaseEvent AddBaseEvent(LovroBaseEvent newEvent)
        {
            newEvent.ID = GetNewID();

            List<LovroBaseEvent> currentList = GetBaseEvents() as List<LovroBaseEvent>;
            if (currentList == null)
                currentList = new List<LovroBaseEvent>();

            currentList.Add(newEvent);
            SaveToFile(currentList);

            return newEvent;
        }

        public LovroBaseEvent EditBaseEvent(LovroBaseEvent editedEvent)
        {
            List<LovroBaseEvent> currentList = GetBaseEvents() as List<LovroBaseEvent>;
            if (currentList == null)
                throw new InvalidOperationException(_ERR_FETCHING_DATA);

            LovroBaseEvent eventToEdit = currentList.Where(item => item.ID == editedEvent.ID).FirstOrDefault();
            if (eventToEdit == null)
                throw new InvalidOperationException(_ERR_ITEM_NOT_FOUND);

            eventToEdit.CopyProperties(editedEvent);
            SaveToFile(currentList);

            return eventToEdit;
        }

        public void DeleteBaseEvent(int id)
        {
            List<LovroBaseEvent> currentList = GetBaseEvents() as List<LovroBaseEvent>;
            if (currentList == null)
                throw new InvalidOperationException(_ERR_FETCHING_DATA);

            LovroBaseEvent eventToDelete = currentList.Where(item => item.ID == id).FirstOrDefault();
            if (eventToDelete == null)
                throw new InvalidOperationException(_ERR_ITEM_NOT_FOUND);

            currentList.Remove(eventToDelete);
            SaveToFile(currentList);
        }

        public void LoadBaseEvents(List<LovroBaseEvent> items)
        {
            if (items == null || !items.Any())
                return;
            
            SaveToFile(items);
        }

        public DatabaseSummary GetSummary()
        {
            return GetSummaries().FirstOrDefault();
        }

        public void Dispose()
        {
            // throw new NotImplementedException();
        }

        private int GetNewID() // užasno
        {
            int currentMax = 1;

            if (GetBaseEvents().Any())
                currentMax = GetBaseEvents().Select(item => item.ID).Max();

            return currentMax + 1;
        }

        private void SaveToFile(List<LovroBaseEvent> currentList)
        {
            using (var fileStream = new FileStream(DataAccessDetails, FileMode.Create))
            {
                serializer.Serialize(fileStream, currentList);
            }
        }
    }
}
