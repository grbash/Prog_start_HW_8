// Допущение для всех задач: Пользователь вводит адекватные значение 
// (если в условии задачи написано "возводит число A в натуральную степень B", то мы допускаем, 
// что число B на вход мы получим натуральное, а вот А может быть любое, иначе придется использовать слишком много проверок)

// Задача 62. Напишите программу, которая заполнит спирально квадратную матрицу. 

/* Алгоритм работает через рекурсию, я решил, что раз я в задаче 54 использовал рекурсию, использую и здесь, учитывая, 
   что на лекциях она была. 

   Алгортм универсальный и работает для любой квадратной матрицы.

   Проблему с пустым центральным элементом в случае матриц с нечетным количеством строк/столбцов решил костылем перед заполнением
   массива, красивее придумать не получилось. Если будет возможность, напишите, пожалуйста, как можно было это реализовать
   по-другому. Спасибо! :-)
*/

Console.WriteLine("Task 62:");
Console.WriteLine();

int[,] CreateArray(int row)
{
    int[,] arr = new int[row, row];

    for (int i = 0; i < row; i++)
        for (int j = 0; j < row; j++)
        {
            arr[i, j] = 0;
        }

    return arr;

}

int[,] FillArray(int[,] arr, int elemValueStart, int elemValueFinish, int rowTop, int rowBottom, int colLeft, int colRight)
{
    int elemValue = elemValueStart;
    ShowArray(arr);
    for (int j = colLeft; j < colRight; j++)
    {
        arr[rowTop, j] = elemValue;
        elemValue++;
    }
    rowTop++;
    for (int i = rowTop; i < rowBottom; i++)
    {
        arr[i, colRight - 1] = elemValue;
        elemValue++;
    }
    colRight--;
    for (int j = colRight - 1; j > colLeft - 1; j--)
    {
        arr[rowBottom - 1, j] = elemValue;
        elemValue++;
    }
    rowBottom--;
    for (int i = rowBottom - 1; i > rowTop - 1; i--)
    {
        arr[i, colLeft] = elemValue;
        elemValue++;
    }
    colLeft++;
    Console.WriteLine($"rowTop - {rowTop},rowBottom - {rowBottom}, colLeft - {colLeft}, colRight - {colRight}, elemValue - {elemValue}");
    if (elemValue < elemValueFinish)
    {
        FillArray(arr, elemValue, elemValueFinish, rowTop, rowBottom, colLeft, colRight);
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

Console.Write("Enter number of rows: ");
int row = Convert.ToInt32(Console.ReadLine());

int[,] arr = new int[row, row];
arr = CreateArray(row);
if (row % 2 != 0)
    arr[row / 2, row / 2] = row * row;
arr = FillArray(arr, 1, row * row, 0, row, 0, row);

ShowArray(arr);