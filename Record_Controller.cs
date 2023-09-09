/* Author: Khadija Zafar
* Date: August 6th, 2023
* Description: This is Controller class of the project. It involves methods which are called 
* in the view class to create, read, update and delete record in the CSV file.
*/

using MVCProject.Model;

namespace MVCProject.Controller
{
    public class Record_Controller
    {
        public static SortedDictionary<int, Record> records = new SortedDictionary<int, Record>();
        public Record_Controller recordController = new Record_Controller();

        public static int ID = 0;

        //this function is responsible for creating a new record to the csv file. 
        public static Record CreateRecord(int newRecordID, string REF_DATE, string GEO, string DGUID, string TypeOfProduct,
            string TypeOfStorage, string UOM, string UOM_ID, string SCALAR_FACTOR, string SCALAR_ID,
            string VECTOR, string COORDINATE, string VALUE, string STATUS, string SYMBOL, string TERMINATE, string DECIMALS)
        {
            Record newRecord = new Record(newRecordID, REF_DATE, GEO, DGUID, TypeOfProduct, TypeOfStorage, UOM, UOM_ID, SCALAR_FACTOR, SCALAR_ID, VECTOR, COORDINATE, VALUE, STATUS, SYMBOL, TERMINATE, DECIMALS);
            records[newRecordID] = newRecord;

            return newRecord;
        }

        // this function updates the record when the user inputs the id of the record. 
        public static void UpdateRecord(Record foundRecord, string REF_DATE, string GEO, string DGUID, string TypeOfProduct,
        string TypeOfStorage, string UOM, string UOM_ID, string SCALAR_FACTOR, string SCALAR_ID,
            string VECTOR, string COORDINATE, string VALUE, string STATUS, string SYMBOL, string TERMINATE, string DECIMALS)
        {
            foundRecord.setREF_DATE(REF_DATE); // when the user inputs new values for the fields, the fields are updated with the new values.
            foundRecord.setGEO(GEO);
            foundRecord.setDGUID(DGUID);
            foundRecord.setTypeOfProduct(TypeOfProduct);
            foundRecord.setTypeOfStorage(TypeOfStorage);
            foundRecord.setUOM(UOM);
            foundRecord.setUOM_ID(UOM_ID);
            foundRecord.setSCALAR_FACTOR(SCALAR_FACTOR);
            foundRecord.setSCALAR_ID(SCALAR_ID);
            foundRecord.setVECTOR(VECTOR);
            foundRecord.setCOORDINATE(COORDINATE);
            foundRecord.setVALUE(VALUE); 
            foundRecord.setSTATUS(STATUS);
            foundRecord.setSYMBOL(SYMBOL);
            foundRecord.setTERMINATE(TERMINATE);
            foundRecord.setDECIMALS(DECIMALS);

        }

        // the following function is responsible for reading records of the file. 
        public static void ReadExcelFile(string filePath)
        {
            // [1] “SortedDictionary Class in C#,” GeeksforGeeks,
            // Feb. 11, 2019.
            // https://www.geeksforgeeks.org/sorteddictionary-class-in-c-sharp/
            // (accessed Jul. 23, 2023).
            records = new SortedDictionary<int, Record>(); 

            try
            {
                List<string[]> rows = new List<string[]>();

                using (StreamReader FileReader = new StreamReader(filePath))
                {
                    string line;
                    FileReader.ReadLine(); // Read headers

                    int i = 1;
                    while ((line = FileReader.ReadLine()) != null && i <= 100) // Only hundred records are read each time the program runs.
                    {
                        i++;
                        string[] columns = line.Split(',');
                        rows.Add(columns);
                    }
                }

                ID = 1;
                foreach (string[] row in rows)
                {
                    Record FileRecord = new Record(ID, row[0], row[1], row[2], row[3], row[4], row[5], row[6], row[7], row[8], row[9], row[10], row[11], row[12], row[13], row[14], row[15]);
                    records[ID] = FileRecord; // ID as the key is used for the SortedDictionary
                    ID++;
                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("File not found: " + e.Message);
                throw new Exception(e.Message);
            }
            catch (IOException e)
            {
                Console.WriteLine("Error reading file: " + e.Message);
                throw new Exception(e.Message);
            }
        }

        //the function is responsible for deleting records based on record id provided by the user.
        public static void DeleteRecord(int Id)
        {
            // [2] “C# | Check if SortedDictionary contains the specified key or not,”
            // GeeksforGeeks, Jan. 15, 2019.
            // https://www.geeksforgeeks.org/c-sharp-check-if-sorteddictionary-contains-the-specified-key-or-not/?ref=ml_lbp
            // (accessed Jul. 23, 2023).
            if (records.ContainsKey(Id)) //[2]
            {
                // [3] “C# | SortedDictionary.Remove() Method,” GeeksforGeeks,
                // Jan. 14, 2019. https://www.geeksforgeeks.org/c-sharp-sorteddictionary-remove-method/?ref=ml_lbp
                // (accessed Jul. 23, 2023).
                records.Remove(Id); //[3]
                Console.WriteLine("Record has been deleted!");
            }
            else
            {
                Console.WriteLine("Record with ID " + Id + " does not exist!");
            }
        }

        //the function is responsible for saving changes including creating, updating and deleting records to the new CSV file
        public static void Save_To_CSV(SortedDictionary<int, Record> updatedRecords, string newCSV_FilePath)
        {
            // [4]“How to output a sorted dictionary to CSV?,” Stack Overflow.
            // https://stackoverflow.com/questions/26423962/how-to-output-a-sorted-dictionary-to-csv
            // (accessed Jul. 23, 2023).
            using (StreamWriter writeRecords = new StreamWriter(newCSV_FilePath)) 
            {
                // including the header row
                string headers = "REF_DATE,GEO,DGUID,TypeOfProduct,TypeOfStorage,UOM,UOM_ID,SCALAR_FACTOR,SCALAR_ID,VECTOR,COORDINATE,VALUE,STATUS,SYMBOL,TERMINATE,DECIMALS";
                writeRecords.WriteLine(headers);

                // adding the updated records from the SortedDictionary
                foreach (var Key_Value_Pair in updatedRecords)
                {
                    Record record = Key_Value_Pair.Value;
                    string line = $"{record.getREF_DATE()},{record.getGEO()},{record.getDGUID()},{record.getTypeOfProduct()},{record.getTypeOfStorage()},{record.getUOM()},{record.getUOM_ID()},{record.getSCALAR_FACTOR()},{record.getSCALAR_ID()},{record.getVECTOR()},{record.getCOORDINATE()},{record.getVALUE()},{record.getSTATUS()},{record.getSYMBOL()},{record.getTERMINATE()},{record.getDECIMALS()}";
                    writeRecords.WriteLine(line);
                }
            }

            Console.WriteLine("Changes have been saved to the new CSV file: " + newCSV_FilePath);
        }


        //the function is responsible for displaying list of records including all the fields in the CSV
        public static void printRecordList(SortedDictionary<int, Record> records)
        {
            Console.WriteLine("Program by Khadija Zafar");
            // [5] D. Beniwal, “How to read Sorted Dictionary items with C#,” www.c-sharpcorner.com.
            // https://www.c-sharpcorner.com/UploadFile/dbeniwal321/how-to-read-sorted-dictionary-items-with-C-Sharp/
            // (accessed Jul. 23, 2023).
            foreach (var Key_Value_Pair in records)
            {
                Record record = Key_Value_Pair.Value;
                Console.WriteLine(record);
                Console.WriteLine();
            }
            Console.WriteLine("Program by Khadija Zafar");
            Console.WriteLine();
        }

        // the following function is responsible for searching a word/value in the records entered by user.
        public static SortedDictionary<int, Record> Search_Val_Records(string searchValue)
        {
            // [1] “SortedDictionary Class in C#,” GeeksforGeeks,
            // Feb. 11, 2019.
            // https://www.geeksforgeeks.org/sorteddictionary-class-in-c-sharp/
            // (accessed Jul. 23, 2023).
            SortedDictionary<int, Record> matchingRecords = new SortedDictionary<int, Record>(); 

            foreach (var Key_Value_Pair in records)
            {
                int recordId = Key_Value_Pair.Key;
                Record record = Key_Value_Pair.Value;

                // Check if any field contains the search value (case-insensitive)
               //[6] “C# | Check if SortedDictionary contains the specified key or not,”
               //GeeksforGeeks, Jan. 15, 2019.
               //https://www.geeksforgeeks.org/c-sharp-check-if-sorteddictionary-contains-the-specified-key-or-not/?ref=ml_lbp
                if (ContainsValue(record, searchValue, StringComparison.OrdinalIgnoreCase))
                {
                    matchingRecords[recordId] = record;
                }
            }

            return matchingRecords;
        }

        // this function is used to check whether the searched value exists in any of the records
        private static bool ContainsValue(Record record, string searchedValue, StringComparison compareType)
        {
            // Check if the searchValue exists in any of the records (case-insensitive)
            // [7] “C# | String.IndexOf( ) Method | Set - 1,” GeeksforGeeks, Jul. 10, 2018.
            //https://www.geeksforgeeks.org/c-sharp-string-indexof-method-set-1/ (accessed Jul. 23, 2023).

            if (record.getREF_DATE().IndexOf(searchedValue, compareType) >= 0   //[1]
                || record.getGEO().IndexOf(searchedValue, compareType) >= 0
                || record.getDGUID().IndexOf(searchedValue, compareType) >= 0
                || record.getTypeOfProduct().IndexOf(searchedValue, compareType) >= 0
                || record.getTypeOfStorage().IndexOf(searchedValue, compareType) >= 0
                || record.getUOM().IndexOf(searchedValue, compareType) >= 0
                || record.getUOM_ID().IndexOf(searchedValue, compareType) >= 0
                || record.getSCALAR_FACTOR().IndexOf(searchedValue, compareType) >= 0
                || record.getSCALAR_ID().IndexOf(searchedValue, compareType) >= 0
                || record.getVECTOR().IndexOf(searchedValue, compareType) >= 0
                || record.getCOORDINATE().IndexOf(searchedValue, compareType) >= 0
                || record.getVALUE().IndexOf(searchedValue, compareType) >= 0
                || record.getSTATUS().IndexOf(searchedValue, compareType) >= 0
                || record.getSYMBOL().IndexOf(searchedValue, compareType) >= 0
                || record.getTERMINATE().IndexOf(searchedValue, compareType) >= 0
                || record.getDECIMALS().IndexOf(searchedValue, compareType) >= 0
            )
            {
                return true;
            }

            return false;
        }

        //this function is responsible for creating a horizontal chart for values present in the searched column name
        public static void CreateChart(string col_Name)
        {
            // Preprocess columnName: remove spaces and underscores
            col_Name = col_Name.Replace(" ", "").Replace("_", "");

            // [1] “SortedDictionary Class in C#,” GeeksforGeeks,
            // Feb. 11, 2019.
            // https://www.geeksforgeeks.org/sorteddictionary-class-in-c-sharp/
            // (accessed Jul. 23, 2023).
            SortedDictionary<string, int> valueCounts = new SortedDictionary<string, int>();

            // column values for the specific columnName
            foreach (var record in records.Values)
            {
                string col_Value = null;
                // column names without case sensitivity
                switch (col_Name.ToLower())
                {
                    case "refdate":
                        col_Value = record.getREF_DATE();
                        break;
                    case "geo":
                        col_Value = record.getGEO();
                        break;
                    case "dguid":
                        col_Value = record.getDGUID();
                        break;
                    case "typeofproduct":
                        col_Value = record.getTypeOfProduct();
                        break;
                    case "typeofstorage":
                        col_Value = record.getTypeOfStorage();
                        break;
                    case "uom":
                        col_Value = record.getUOM();
                        break;
                    case "uom_id":
                        col_Value = record.getUOM_ID();
                        break;
                    case "scalarfactor":
                        col_Value = record.getSCALAR_FACTOR();
                        break;
                    case "scalar_id":
                        col_Value = record.getSCALAR_ID();
                        break;
                    case "vector":
                        col_Value = record.getVECTOR();
                        break;
                    case "coordinate":
                        col_Value = record.getCOORDINATE();
                        break;
                    case "value":
                        col_Value = record.getVALUE();
                        break;
                    case "status":
                        col_Value = record.getSTATUS();
                        break;
                    case "symbol":
                        col_Value = record.getSYMBOL();
                        break;
                    case "terminate":
                        col_Value = record.getTERMINATE();
                        break;
                    case "decimals":
                        col_Value = record.getDECIMALS();
                        break;
                    default:
                        // line will display if unknown column name is searched
                        Console.WriteLine("Unknown column name.");
                        return;
                }

                if (string.IsNullOrEmpty(col_Value))
                {
                    // Skip records with empty column values
                    continue;
                }

                // Count the occurrences of each column value
                // [2] “C# | Check if SortedDictionary contains the specified key or not,”
                // GeeksforGeeks, Jan. 15, 2019.
                // https://www.geeksforgeeks.org/c-sharp-check-if-sorteddictionary-contains-the-specified-key-or-not/?ref=ml_lbp
                // (accessed Jul. 23, 2023).
                if (valueCounts.ContainsKey(col_Value))
                {
                    valueCounts[col_Value]++;
                }
                else
                {
                    valueCounts[col_Value] = 1;
                }
            }

            // to create the chart
            foreach (var pair in valueCounts)
            {
                int Horiz_bar_Length = (int)Math.Round(30.0 * pair.Value / valueCounts.Max(pair => pair.Value));
                Console.WriteLine($"{pair.Key,-20} {new string('=', Horiz_bar_Length)} {pair.Value}");
            }
        }
    }
}
