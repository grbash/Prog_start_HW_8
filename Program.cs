// Допущение для всех задач: Пользователь вводит адекватные значение 
// (если в условии задачи написано "возводит число A в натуральную степень B", то мы допускаем, 
// что число B на вход мы получим натуральное, а вот А может быть любое, иначе придется использовать слишком много проверок)

// Задача 58: Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.

Console.WriteLine("Task 58:");
Console.WriteLine();

int[,] CreateArray(int row, int col)
{
    int[,] arr = new int[row, col];

    for (int i = 0; i < row; i++)
        for (int j = 0; j < col; j++)
        {
            arr[i, j] = new Random().Next(1, 10);
        }

    return arr;

}

void ShowArray(int[,] arr)
{
    for (int i = 0; i < arr.GetLength(0); i++)
    {
        for (int j = 0; j < arr.GetLength(1); j++)
            Console.Write(arr[i, j] + " ");
        Console.WriteLine();
    }
}

void MultiplicationMatrix(int[,] matrixA, int[,] matrixB)
{
    if (matrixA.GetLength(1) != matrixB.GetLength(0))
        Console.WriteLine("Number of columns of matrix A must be equal to number of rows of matrix B");
    else
    {
        int[,] resultMatrix = new int[matrixA.GetLength(0), matrixB.GetLength(1)];

        for (int i = 0; i < matrixA.GetLength(0); i++)
            for (int j = 0; j < matrixB.GetLength(1); j++)
                for (int k = 0; k < matrixB.GetLength(0); k++)
                    resultMatrix[i, j] += matrixA[i, k] * matrixB[k, j];
        
        Console.WriteLine("A * B = ");
        ShowArray(resultMatrix);
    }
}

Console.Write("Enter number of rows of matrix A: ");
int rowA = Convert.ToInt32(Console.ReadLine());

Console.Write("Enter number of columns of matrix A: ");
int colA = Convert.ToInt32(Console.ReadLine());

Console.Write("Enter number of rows of matrix B: ");
int rowB = Convert.ToInt32(Console.ReadLine());

Console.Write("Enter number of columns of matrix B: ");
int colB = Convert.ToInt32(Console.ReadLine());

Console.WriteLine();
int[,] matrixA = new int[rowA, colA];
matrixA = CreateArray(rowA, colA);

Console.WriteLine("Matrix A:");
ShowArray(matrixA);

Console.WriteLine();
int[,] matrixB = new int[rowB, colB];
matrixB = CreateArray(rowB, colB);

Console.WriteLine("Matrix B:");
ShowArray(matrixB);

Console.WriteLine();
MultiplicationMatrix(matrixA, matrixB);