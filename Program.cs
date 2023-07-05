// Допущение для всех задач: Пользователь вводит адекватные значение 
// (если в условии задачи написано "возводит число A в натуральную степень B", то мы допускаем, 
// что число B на вход мы получим натуральное, а вот А может быть любое, иначе придется использовать слишком много проверок)

// Задача 56: Задайте прямоугольный двумерный массив. Напишите программу, которая будет находить строку с наименьшей суммой элементов.

// Поскольку не указано, номер какой строки надо выводить, если таких строк несколько, 
// то решено выводить номер самой первой строки с минимально суммой.

Console.WriteLine("Task 56:");
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
            Console.Write(arr[i, j] + " ");
        }
        Console.WriteLine();

    }
}

int MinRowSum(int[,] arr)
{
    int[] sumEachRowArr = new int[arr.GetLength(0)];
    for (int i = 0; i < arr.GetLength(0); i++)
    {
        sumEachRowArr[i] = 0;
        for (int j = 0; j < arr.GetLength(1); j++)
            sumEachRowArr[i] += arr[i, j];
    }

    int minSumEachRow = sumEachRowArr[0];
    int numOfRow = 0;
    for (int i = 1; i < sumEachRowArr.GetLength(0); i++)
    {
        if (minSumEachRow > sumEachRowArr[i])
        {
            minSumEachRow = sumEachRowArr[i];
            numOfRow = i;
        }
    }

    return numOfRow;
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

int res = MinRowSum(arr);

Console.Write($"Number of row with minimum sum is {res}");
