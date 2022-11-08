int[,] CreateMatrix(int rows, int columns, int minimum, int maximum)
{
    int[,] matrix = new int[rows, columns];
    Random random = new Random();
    for (int i = 0; i < matrix.GetLength(0); i++)
        for (int j = 0; j < matrix.GetLength(1); j++)
            matrix[i, j] = random.Next(minimum, maximum);
    return matrix;
}
void PrintMatrix(int[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
            Console.Write($"{matrix[i, j]} ");
        Console.WriteLine();
    }
}
int ReadIntegerNumber(string message)
{
    Console.Write(message);
    return int.Parse(Console.ReadLine() ?? "0");
}
int SumOfMainDiagonal(int[,] matrix)
{
    int sum = 0;
    for (int i = 0; i < matrix.GetLength(0); i++)
        sum += matrix[i, i];
    return sum;
}
int length = ReadIntegerNumber("Enter amount of rows: ");
int minValue = ReadIntegerNumber("Enter start of number range: ");
int maxValue = ReadIntegerNumber("Enter end of number range: ");
int[,] matrix = CreateMatrix(length, length, minValue, maxValue);
Console.WriteLine("Your matrix: ");
PrintMatrix(matrix);
if (matrix.GetLength(0) == matrix.GetLength(1))
    Console.WriteLine($"Sum of main diagonal: {SumOfMainDiagonal(matrix)}");
else
    Console.WriteLine("Matrix is not square");