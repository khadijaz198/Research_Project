/* Author: Khadija Zafar
 * Date: 23rd July, 2023
 * Description: Record test class has been created which involved a test method
 * to test whether a record with id = 10 gets deleted or not from the csv file.
 */
using MVCProject.Controller;

namespace Test
{
    public class RecordTest
    {
        // the following method will check whether the sortedDictionary can help sort the records in key and value pairs.
        [Fact]
        public void TestSortingOfRecords()
        {
            // Arrange
            Record_Controller.records.Clear(); // Clear the existing records to start with a clean state

            // Create some records with unordered IDs
            MVCProject.Model.Record record1 = new(8, "2023-01-01", "Canada", "12345", "Apple", "cold", "KG", "1", "A", "2", "Vector 6", "1.2", "100", "OK", "C", "No", "9");
            MVCProject.Model.Record record2 = new(6, "2023-01-02", "USA", "67890", "Banana", "mild", "LB", "2", "B", "3", "Vector 3", "3.5", "200", "OK", "M", "Yes", "1");
            MVCProject.Model.Record record3 = new(7, "2023-01-03", "UK", "54321", "Ginger", "hot", "G", "3", "C", "4", "Vector 8", "6.5", "300", "OK", "H", "No", "4");

            // Add the records to the controller's SortedDictionary
            Record_Controller.records.Add(8, record1);
            Record_Controller.records.Add(6, record2);
            Record_Controller.records.Add(7, record3);

            // Act
            // Call the function you expect to sort the records by ID (in ascending order)
            SortedDictionary<int, MVCProject.Model.Record> sortedRecords = new SortedDictionary<int, MVCProject.Model.Record>((IDictionary<int, MVCProject.Model.Record>)Record_Controller.records);

            // Assert
            // Verify if the records are sorted by ID
            int expected_Id = 6;
            foreach (var Key_Value_Pair in sortedRecords)
            {
                Assert.Equal(expected_Id, Key_Value_Pair.Key);
                expected_Id++;
            }
        }
    }
}