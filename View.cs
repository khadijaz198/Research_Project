/* Author: Khadija Zafar
 * Date: August 6th, 2023
 * Description: This is View class of the project. It is responsible for
 * representing records of the csv file. It provides different options for user to 
 * select from and represents the changes in the csv file based on user input.
 */

using MVCProject.Controller;
using MVCProject.Model;

namespace MVCProject.View
{
    public class View
    {

        public static void view()
        {
         
        Console.WriteLine("Program by Khadija Zafar");

            string filePath = @"C:\Users\User\Desktop\MVCProject\MVCProject\32100260.csv";
            string newCSV_FilePath = @"C:\Users\User\Desktop\MVCProject\MVCProject\updated_data.csv";

            Controller.Record_Controller.ReadExcelFile(filePath);
            Console.WriteLine("Please select from the following options");

            while (true)
            {
                Console.WriteLine("");
                Console.WriteLine("To reload the data from the dataset enter 1");
                Console.WriteLine("To create a new record enter 2");
                Console.WriteLine("To select and edit a record enter 3");
                Console.WriteLine("To select and delete a record enter 4");
                Console.WriteLine("To select and display record(s) enter 5");
                Console.WriteLine("To show records with specific value enter 6");
                Console.WriteLine("To see total count of values inside column(Horizontal Chart), enter 7");
                Console.WriteLine("To exit the program enter 9");


                string userInput = Console.ReadLine();

                if (userInput == "9")
                {
                    Console.WriteLine("Exiting the program...");
                    break;
                }
                else if (userInput == "1")
                {
                    Controller.Record_Controller.ReadExcelFile(filePath);
                    Controller.Record_Controller.printRecordList(Controller.Record_Controller.records);
                }
                else if (userInput == "2")
                {
                    Console.WriteLine("");
                    Console.WriteLine("Please provide the following column values: ");

                    Console.Write("REF_DATE: ");
                    string REF_DATE = Console.ReadLine();

                    Console.Write("GEO: ");
                    string GEO = Console.ReadLine();

                    Console.Write("DGUID: ");
                    string DGUID = Console.ReadLine();

                    Console.Write("TypeOfProduct: ");
                    string TypeOfProduct = Console.ReadLine();

                    Console.Write("TypeOfStorage: ");
                    string TypeOfStorage = Console.ReadLine();

                    Console.Write("UOM: ");
                    string UOM = Console.ReadLine();

                    Console.Write("UOM_ID: ");
                    string UOM_ID = Console.ReadLine();

                    Console.Write("SCALAR_FACTOR: ");
                    string SCALAR_FACTOR = Console.ReadLine();

                    Console.Write("SCALAR_ID: ");
                    string SCALAR_ID = Console.ReadLine();

                    Console.Write("VECTOR: ");
                    string VECTOR = Console.ReadLine();

                    Console.Write("COORDINATE: ");
                    string COORDINATE = Console.ReadLine();

                    Console.Write("VALUE: ");
                    string VALUE = Console.ReadLine();

                    Console.Write("STATUS: ");
                    string STATUS = Console.ReadLine();

                    Console.Write("SYMBOL: ");
                    string SYMBOL = Console.ReadLine();

                    Console.Write("TERMINATE: ");
                    string TERMINATE = Console.ReadLine();

                    Console.Write("DECIMALS: ");
                    string DECIMALS = Console.ReadLine();

                    //new record gets created.
                    // Generate a new unique identifier for the record using the ID field in Record_Controller.
                    int newRecordID = Controller.Record_Controller.ID++;

                    // New record gets created with the newRecordID as the first parameter.
                    var newRecord = Controller.Record_Controller.CreateRecord(newRecordID, REF_DATE, GEO, DGUID, TypeOfProduct, TypeOfStorage, UOM, UOM_ID, SCALAR_FACTOR, SCALAR_ID, VECTOR, COORDINATE, VALUE, STATUS, SYMBOL, TERMINATE, DECIMALS);
                    //var newRecord = Controller.Record_Controller.CreateRecord(REF_DATE, GEO, DGUID, TypeOfProduct, TypeOfStorage, UOM, UOM_ID, SCALAR_FACTOR, SCALAR_ID, VECTOR, COORDINATE, VALUE, STATUS, SYMBOL, TERMINATE, DECIMALS);

                    // Asking user whether they want to save the newly created record to the updated CSV file
                    Console.WriteLine("Do you want to save the newly created record to the new CSV file? (Y/N)");
                    string saveOption = Console.ReadLine();

                    if (saveOption.ToUpper() == "Y")
                    {
                        Controller.Record_Controller.Save_To_CSV(Controller.Record_Controller.records, newCSV_FilePath); //record will be saved to the new csv file.
                        Console.WriteLine("New record has been saved to the new CSV file.");
                    }
                    
                    Controller.Record_Controller.printRecordList(Controller.Record_Controller.records); // newly created record will still show in memory as well as console whether or not
                    //the user saves it to updated csv file or not.

                }
                else if (userInput == "3")
                {
                        Console.WriteLine("Please enter the ID of the record you would like to update: ");
                        string ID = Console.ReadLine();

                    while (true)
                    {
                        int ID_Parsed;
                        if (int.TryParse(ID, out ID_Parsed))
                        {
                            Record foundRecord;
                            if (Controller.Record_Controller.records.TryGetValue(ID_Parsed, out foundRecord))
                            {
                                Console.WriteLine("Please modify any column value as you like. If you do not like to change some column value leave it blank and press enter");

                                Console.WriteLine("Here is the current record: ");

                                Console.Write("Current REF_DATE: " + foundRecord.getREF_DATE() + " " + " "
                                    + "Current GEO: " + foundRecord.getGEO() + " " + " "
                                    + "Current DGUID: " + foundRecord.getDGUID() + " " + " "
                                    + "Current Type of product: " + foundRecord.getTypeOfProduct() + " " + " "
                                    + "Current Type of Storage:" + foundRecord.getTypeOfStorage() + " " + " "
                                    + "Current UOM: " + foundRecord.getUOM() + " " + " "
                                    + "Current UOM_ID:" + foundRecord.getUOM_ID() + " " + " "
                                    + "Current SCALAR_FACTOR:" + foundRecord.getSCALAR_FACTOR() + " " + " "
                                    + "Current SCALAR_ID: " + foundRecord.getSCALAR_ID() + " " + " "
                                    + "Current Vector: " + foundRecord.getVECTOR() + " " + " "
                                    + "Current Coordinate: " + foundRecord.getCOORDINATE() + " " + " "
                                    + "Current VALUE: " + foundRecord.getVALUE() + " " + " "
                                    + "Current STATUS: " + foundRecord.getSTATUS() + " " + " "
                                    + " Current SYMBOL: " + foundRecord.getSYMBOL() + " " + " "
                                    + "Current TERMINATE: " + foundRecord.getTERMINATE() + " " + " "
                                    + "Current DECIMALS: " + foundRecord.getDECIMALS());

                                Console.WriteLine("");

                                Console.Write("New REF_DATE: ");
                                string newREF_DATE = Console.ReadLine();

                                Console.Write("New GEO: ");
                                string newGEO = Console.ReadLine();

                                Console.Write("DGUID: ");
                                string newDGUID = Console.ReadLine();

                                Console.Write("TypeOfProduct: ");
                                string newTypeOfProduct = Console.ReadLine();

                                Console.Write("TypeOfStorage: ");
                                string newTypeOfStorage = Console.ReadLine();

                                Console.Write("UOM: ");
                                string newUOM = Console.ReadLine();

                                Console.Write("UOM_ID: ");
                                string newUOM_ID = Console.ReadLine();

                                Console.Write("SCALAR_FACTOR: ");
                                string newSCALAR_FACTOR = Console.ReadLine();

                                Console.Write("SCALAR_ID: ");
                                string newSCALAR_ID = Console.ReadLine();

                                Console.Write("VECTOR: ");
                                string newVECTOR = Console.ReadLine();

                                Console.Write("COORDINATE: ");
                                string newCOORDINATE = Console.ReadLine();

                                Console.Write("VALUE: ");
                                string newVALUE = Console.ReadLine();

                                Console.Write("STATUS: ");
                                string newSTATUS = Console.ReadLine();

                                Console.Write("SYMBOL: ");
                                string newSYMBOL = Console.ReadLine();

                                Console.Write("TERMINATE: ");
                                string newTERMINATE = Console.ReadLine();

                                Console.Write("DECIMALS: ");
                                string newDECIMALS = Console.ReadLine();

                                var useREF_DATE = String.IsNullOrEmpty(newREF_DATE) ? foundRecord.getREF_DATE() : newREF_DATE;

                                var useGEO = String.IsNullOrEmpty(newGEO) ? foundRecord.getGEO() : newGEO;

                                var useDGUID = String.IsNullOrEmpty(newDGUID) ? foundRecord.getDGUID() : newDGUID;

                                var useTypeOfProduct = String.IsNullOrEmpty(newTypeOfProduct) ? foundRecord.getTypeOfProduct() : newTypeOfProduct;

                                var useTypeOfStorage = String.IsNullOrEmpty(newTypeOfStorage) ? foundRecord.getTypeOfStorage() : newTypeOfStorage;

                                var useUOM = String.IsNullOrEmpty(newUOM) ? foundRecord.getUOM() : newUOM;

                                var useUOM_ID = String.IsNullOrEmpty(newUOM_ID) ? foundRecord.getUOM_ID() : newUOM_ID;

                                var useSCALAR_FACTOR = String.IsNullOrEmpty(newSCALAR_FACTOR) ? foundRecord.getSCALAR_FACTOR() : newSCALAR_FACTOR;

                                var useSCALAR_ID = String.IsNullOrEmpty(newSCALAR_ID) ? foundRecord.getSCALAR_ID() : newSCALAR_ID;

                                var useVECTOR = String.IsNullOrEmpty(newVECTOR) ? foundRecord.getVECTOR() : newVECTOR;

                                var useCOORDINATE = String.IsNullOrEmpty(newCOORDINATE) ? foundRecord.getCOORDINATE() : newCOORDINATE;

                                var useVALUE = String.IsNullOrEmpty(newVALUE) ? foundRecord.getVALUE() : newVALUE;

                                var useSTATUS = String.IsNullOrEmpty(newSTATUS) ? foundRecord.getSTATUS() : newSTATUS;

                                var useSYMBOL = String.IsNullOrEmpty(newSYMBOL) ? foundRecord.getSYMBOL() : newSYMBOL;

                                var useTERMINATE = String.IsNullOrEmpty(newTERMINATE) ? foundRecord.getTERMINATE() : newTERMINATE;

                                var useDECIMALS = String.IsNullOrEmpty(newDECIMALS) ? foundRecord.getDECIMALS() : newDECIMALS;

                                Controller.Record_Controller.UpdateRecord(foundRecord, useREF_DATE, useGEO, useDGUID, useTypeOfProduct, useTypeOfStorage,
                                    useUOM, useUOM_ID, useSCALAR_FACTOR, useSCALAR_ID, useVECTOR, useCOORDINATE, useVALUE, useSTATUS, useSYMBOL,
                                    useTERMINATE, useDECIMALS);

                                Console.WriteLine("Record has been modified!");
                                // Asking user whether they want to save the updated record to the updated CSV file
                                Console.WriteLine("Do you want to save the updated record to the new CSV file? (Y/N)");
                                string saveOption = Console.ReadLine();

                                if (saveOption.ToUpper() == "Y")
                                {
                                    Controller.Record_Controller.Save_To_CSV(Controller.Record_Controller.records, newCSV_FilePath); //record will be saved to the new csv file.
                                    Console.WriteLine("Updated record has been saved to the new CSV file.");
                                }

                                Controller.Record_Controller.printRecordList(Controller.Record_Controller.records); // updated record will still show in memory as well as console whether or not
                                                                                       //the user saves it to updated csv file or not.
                                break;
                            }
                            else
                            {
                                Console.Write("The ID you provided is not found. Please enter a valid ID: ");
                                ID = Console.ReadLine();
                            }
                        } else
                        {
                            Console.WriteLine("Invalid input, please try a valid ID!");
                            ID = Console.ReadLine();
                        }
                    }

                    } else if (userInput == "4")
                {
                    Console.WriteLine("Please enter the ID of the record you would like to delete: ");
                    string ID = Console.ReadLine();

                    while (true)
                    {
                        int ID_Parsed;
                        if (int.TryParse(ID, out ID_Parsed))
                        {
                            Record foundRecord;
                            if (Controller.Record_Controller.records.TryGetValue(ID_Parsed, out foundRecord))
                            {
                                Console.Write("A record with this ID has been found! ");
                                Controller.Record_Controller.DeleteRecord(ID_Parsed);

                                // Asking user whether they want to save the changes to the updated CSV file
                                Console.WriteLine("Do you want to save the changes to the new CSV file? (Y/N)");
                                string saveOption = Console.ReadLine();

                                if (saveOption.ToUpper() == "Y")
                                {
                                    Controller.Record_Controller.Save_To_CSV(Controller.Record_Controller.records, newCSV_FilePath);
                                    Console.WriteLine("Updated record has been saved to the new CSV file.");
                                }

                                Controller.Record_Controller.printRecordList(Controller.Record_Controller.records);
                                break;
                            }
                            else
                            {
                                Console.Write("The ID you provided is not found. Please enter a valid ID: ");
                                ID = Console.ReadLine();
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid input, please try a valid ID!");
                            ID = Console.ReadLine();
                        }
                    }



                }
                else if (userInput == "5")
                {
                    Console.WriteLine("Please enter the Id(s) of the records you would like to see separated by commas: ");
                    string IDs = Console.ReadLine();
                    string[] ID_Values = IDs.Split(',');
                    foreach (string ID_Value in ID_Values)
                    {
                        int ID_Parsed;
                        if (int.TryParse(ID_Value, out ID_Parsed))
                        {
                            Record foundRecord;
                            if (Controller.Record_Controller.records.TryGetValue(ID_Parsed, out foundRecord))
                            {
                                Console.Write(" REF_DATE: " + foundRecord.getREF_DATE() + " " + " "
                                    + " GEO: " + foundRecord.getGEO() + " " + " "
                                    + " DGUID: " + foundRecord.getDGUID() + " " + " "
                                    + "Type of product: " + foundRecord.getTypeOfProduct() + " " + " "
                                    + "Type of Storage:" + foundRecord.getTypeOfStorage() + " " + " "
                                    + " UOM: " + foundRecord.getUOM() + " " + " "
                                    + " UOM_ID:" + foundRecord.getUOM_ID() + " " + " "
                                    + " SCALAR_FACTOR:" + foundRecord.getSCALAR_FACTOR() + " " + " "
                                    + " SCALAR_ID: " + foundRecord.getSCALAR_ID() + " " + " "
                                    + " Vector: " + foundRecord.getVECTOR() + " " + " "
                                    + " Coordinate: " + foundRecord.getCOORDINATE() + " " + " "
                                    + "VALUE: " + foundRecord.getVALUE() + " " + " "
                                    + " STATUS: " + foundRecord.getSTATUS() + " " + " "
                                    + "  SYMBOL: " + foundRecord.getSYMBOL() + " " + " "
                                    + "TERMINATE: " + foundRecord.getTERMINATE() + " " + " "
                                    + " DECIMALS: " + foundRecord.getDECIMALS());

                                Console.WriteLine("");
                            }
                            else
                            {
                                Console.WriteLine("No record found for the id : " + ID_Value);
                            }
                        }
                    }
                } 
                else if(userInput == "6")
                {
                    Console.WriteLine("Enter the value to search:");
                    string searchValue = Console.ReadLine();

                    SortedDictionary<int, Record> matchingRecords = Record_Controller.Search_Val_Records(searchValue); //program searches the value in records.

                    if (matchingRecords.Count > 0)
                    {
                        Console.WriteLine("Records matching the search value:");
                        Record_Controller.printRecordList(matchingRecords);
                    }
                    else
                    {
                        Console.WriteLine("No records found with the given search value.");
                    }

                }
                else if(userInput == "7")
                {
                    Console.WriteLine("Enter a column name to see the total% of values in a horizontal chart:");
                    string searchValue = Console.ReadLine();

                    // Show the pie chart for the searched value
                    Record_Controller.CreateChart(searchValue);
                }

            }
        }

    }
}
