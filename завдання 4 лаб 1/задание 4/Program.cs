using System;
using System.IO;

class Program
{
    static void Main()
    {
        string filename = "students.csv";

        // Read the contents of the CSV file
        string[] lines = File.ReadAllLines(filename);

        // Check if there are any students with scores less than 60
        bool hasStudentsBelow60 = false;

        // Process each line of the CSV file
        foreach (string line in lines)
        {
            // Split the line into first name, last name, and score
            string[] parts = line.Split(',');

            string firstName = parts[0].Trim();
            string lastName = parts[1].Trim();
            int score = int.Parse(parts[2].Trim());

            // Check if the score is less than 60
            if (score < 60)
            {
                Console.WriteLine(firstName + " " + lastName + ", Score: " + score);
                hasStudentsBelow60 = true;
            }
        }

        // If there are no students with scores less than 60, display a message
        if (!hasStudentsBelow60)
        {
            Console.WriteLine("No students with scores below 60.");
        }
    }
}
