using System;
using System.IO;

class Program
{
    static void Main()
    {
        string csvFilename = "students.csv";
        string binaryFilename = "students.bin";
        string filteredBinaryFilename = "filtered_students.bin";

        // Read the contents of the CSV file
        string[] lines = File.ReadAllLines(csvFilename);

        using (BinaryWriter writer = new BinaryWriter(File.OpenWrite(binaryFilename)))
        {
            // Write the number of records
            writer.Write(lines.Length);

            // Write each record
            foreach (string line in lines)
            {
                writer.Write(line);
            }
        }

        using (BinaryReader reader = new BinaryReader(File.OpenRead(binaryFilename)))
        {
            using (BinaryWriter filteredWriter = new BinaryWriter(File.OpenWrite(filteredBinaryFilename)))
            {
                int recordCount = reader.ReadInt32();

                int filteredCount = 0;

                // Write the number of filtered records
                filteredWriter.Write(filteredCount);

                // Write the filtered records
                for (int i = 0; i < recordCount; i++)
                {
                    string record = reader.ReadString();

                    // Split the record into parts
                    string[] parts = record.Split(',');

                    // Extract the score from the record
                    int score = int.Parse(parts[2].Trim());

                    // Check if the score is greater than 95
                    if (score > 95)
                    {
                        // Increment the filtered count
                        filteredCount++;

                        // Write the filtered record
                        filteredWriter.Write(record);
                    }
                }

                // Go back to the beginning of the filtered file and write the filtered count
                filteredWriter.Seek(0, SeekOrigin.Begin);
                filteredWriter.Write(filteredCount);
            }
        }
    }
}
