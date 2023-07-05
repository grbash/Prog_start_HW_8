// Допущение для всех задач: Пользователь вводит адекватные значение 
// (если в условии задачи написано "возводит число A в натуральную степень B", то мы допускаем, 
// что число B на вход мы получим натуральное, а вот А может быть любое, иначе придется использовать слишком много проверок)

// Задача 54: Задайте двумерный массив. Напишите программу, которая упорядочит по убыванию элементы каждой строки двумерного массива.

Console.WriteLine("Task 54:");
Console.WriteLine();

int[,] CreateArray(int row, int col)
{
    int[,] arr = new int[row, col];

    for (int i = 0; i < row; i++)
        for (int j = 0; j < col; j++)
        {
            arr[i, j] = new Random().Next(-row, col + 1);
        }

    return arr;

}

void ShowArray(int[,] arr)
{
    for (int i = 0; i < arr.GetLength(0); i++)
    {
        for (int j = 0; j < arr.GetLength(1); j++)
        {
            Console.Write(arr[i,j] + " ");
        }
        Console.WriteLine();

    }
}

int[] QSortArray(int[] arr, int leftIndex, int rightIndex)
{
    int i = leftIndex;
    int j = rightIndex;
    int max = arr[leftIndex];

    while (i <= j)
    {
        while (arr[i] > max)
            i++;
        
        while (arr[j] < max)
            j--;

        if (i <= j)
        {
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
            i++;
            j--;
        }
    }
    
    if (leftIndex < j)
        QSortArray(arr, leftIndex, j);

    if (i < rightIndex)
        QSortArray(arr, i, rightIndex);

    return arr;
}

int[,] SortTwoDemArray(int [,] arr)
{
    int [] rowArr = new int[arr.GetLength(1)];
    for (int i = 0; i < arr.GetLength(0); i++)
    {
        for (int j = 0; j < arr.GetLength(1); j++)
            rowArr[j] = arr[i, j];

        QSortArray(rowArr, 0, arr.GetLength(1) - 1);

        for (int j = 0; j < arr.GetLength(1); j++)
            arr[i, j] = rowArr[j];
    }
    return arr;
}

Console.Write("Enter amount of rows: ");
int row = Convert.ToInt32(Console.ReadLine());

Console.Write("Enter amount of columns: ");
int col = Convert.ToInt32(Console.ReadLine());

int[,] arr = new int[row, col];
arr = CreateArray(row, col);

Console.WriteLine("Ur arr:");
ShowArray(arr);
Console.WriteLine();

arr = SortTwoDemArray(arr);

Console.WriteLine("Ur sorted arr:");
ShowArray(arr);

