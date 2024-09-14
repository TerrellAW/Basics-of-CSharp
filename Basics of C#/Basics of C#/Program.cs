using System;
using System.Diagnostics.Contracts;
using System.Security.Cryptography.X509Certificates;

public class Numbers
{
    // Initialize variables
    private int lowNum = 0;
    private int highNum = 0;
    private int diff = 0;
    private int[] numbers = new int[10];
    private string filePath = "";
    private int[] newNumbers = new int[20];
    private int sum = 0;

    // Fields and properties
    int LowNum
    {
        get
        {
            return lowNum;
        }
        set
        {
            lowNum = value;
        }
    }
    int HighNum
    {
        get
        {
            return highNum;
        }
        set
        {
            highNum = value;
        }
    }
    int Diff
    {
        get
        {
            return diff;
        }
        set
        {
            diff = value;
        }
    }

    // Program start
    public static void Main(string[] args)
    {
        // Numbers class object
        Numbers obj = new Numbers();

        // Method calls
        obj.TakeInput();

        obj.GetDifference(obj.LowNum, obj.HighNum);

        obj.MakeArray(obj.LowNum, obj.Diff);

        obj.WriteFile();

        obj.ReadFile();

        obj.Sum();

        obj.PrimeNums(obj.LowNum, obj.HighNum);
    }

    // User input method
    private void TakeInput()
    {
        // User inputs low number
        Console.WriteLine("Enter a low number: ");

        // Low number stored as integer
        LowNum = Int32.Parse(Console.ReadLine());

        // Low number validation loop
        while (LowNum < 0)
        {
            // User inputs low number
            Console.WriteLine("Enter a low number: ");

            // Low number stored as integer
            LowNum = Int32.Parse(Console.ReadLine());
        }

        // Ensures loop triggers
        HighNum = LowNum - 1;

        // High number validation loop
        while (HighNum < LowNum)
        {
            // User inputs high number
            Console.WriteLine("Enter a high number: ");

            // High number stored as integer
            HighNum = Int32.Parse(Console.ReadLine());
        }
    }

    // Calculate difference method
    private int GetDifference(int lowNum, int highNum)
    {
        // Calculation
        diff = highNum - lowNum;

        // Output
        Console.WriteLine($"The difference between {lowNum} and {highNum} is {diff}.\n");
        return diff;
    }

    // Fills initialized array
    private void MakeArray(int lowNum, int diff)
    {
        // Array
        numbers = new int[diff + 1];
        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = lowNum + i;
        }

        // Reversing the array
        Array.Reverse(numbers);
    }

    // Creates and/or writes to numbers.txt file
    private void WriteFile()
    {
        // Current working directory
        string CWD = Directory.GetCurrentDirectory();

        // Creating text file
        string fileName = "numbers.txt";

        // Filepath for the text file
        filePath = Path.Combine(CWD, fileName);

        // Writing to the file
        string[] lines = Array.ConvertAll(numbers, num => num.ToString());

        File.WriteAllLines(filePath, lines);
        Console.WriteLine($"numbers.txt created in {filePath}\n");
    }

    // Reads from numbers.txt file and stores in a new array
    private void ReadFile()
    {
        // Read from numbers.txt
        StreamReader reader = new StreamReader(filePath);

        // Initialize line variable with built-in ReadLine() function
        string line = reader.ReadLine();

        // Initialize variable for index
        int idx = 0;

        Console.WriteLine("File contents: ");

        // Loop to iterate through and read each line
        while (line != null)
        {
            Console.WriteLine(line);

            // Add line to integer array
            newNumbers[idx] = Int32.Parse(line);

            // Index variable increases each iteration
            idx++;

            // Ensures next line is read
            line = reader.ReadLine();
        }

        // Close the reader to prevent memory leaks
        reader.Close();
    }

    // Find the sum of the numbers from the new array
    private void Sum()
    {
        for (int i = 0 ; i < newNumbers.Length ; i++)
        {
            sum += newNumbers[i];
        }

        Console.WriteLine($"\nThe sum is: {sum}.");
    }

    // Prime numbers method
    private void PrimeNums(int start, int end)
    {
        Numbers prime = new Numbers();

        Console.WriteLine("\nThe prime numbers are: ");

        for (int i = start; i <= end; i++)
        {
            bool yesno = prime.IsPrime(i);

            if (yesno == true)
            {
                Console.WriteLine(i);
            }
        }
    }

    // Prime numbers checker
    private bool IsPrime(int target)
    {
        if (target == 1)
            return false;
        for (int i = 2; i < target; i++)
        {
            // Should be divisible with every number from 2 to itself minus 1
            if (target % i == 0)
            {
                return false;
            }
        }

        return true;
    }
}