// Допущение для всех задач: Пользователь вводит адекватные значение 
// (если в условии задачи написано "возводит число A в натуральную степень B", то мы допускаем, 
// что число B на вход мы получим натуральное, а вот А может быть любое, иначе придется использовать слишком много проверок)

// Задача 60. Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. Напишите программу, 
// которая будет построчно выводить массив, добавляя индексы каждого элемента.

/* Было 2 варианта реализации массива с неповторяющимися элементами:
   1. Создать и заполнить массив, отсортировать его и смотреть на повторы, параллельно как-то их исправляя:
   2. То, что реализовано в программе. При добавлении новго элемента каждый раз смотреть есть такой или нет,
   если есть, генерировать новый и проверять заново, пока не получится новый элемент.

   Первый вариант показался более сложным в исполнении, но возможно он более быстрый.
   Второй вариант будет долго работать, если элементов в массиве много и заполнен он 5-6ти значными числами.

   Есть ли другие способы без использования дополнительных бибилиотек создать массив из неповторяющихся чисел?
   Заранее спасибо за ответ! :-)
*/

Console.WriteLine("Task 60:");
Console.WriteLine();

int[] CreateTempArray(int arrLenght)
{
    int[] arr = new int[arrLenght];

    for (int i = 0; i < arrLenght; i++)
    {
        arr[i] = new Random().Next(10, 100);
        for (int j = 0; j < i; j++)
        {
            if (arr[i] == arr[j])
            {
                arr[i] = new Random().Next(10, 100);
                j = 0;
            }
        }
    }

    return arr;
}

int[,,] CreateArray(int[] tempArr, int x, int y, int z)
{
    int[,,] arr = new int[x, y, z];
    int tempArrIndex = 0;

    for (int i = 0; i < x; i++)
        for (int j = 0; j < y; j++)
        {
            for (int k = 0; k < z; k++)
            {
                arr[i, j, k] = tempArr[tempArrIndex];
                tempArrIndex++;
            }
        }

    return arr;

}

void ShowArray(int[,,] arr)
{
    for (int k = 0; k < arr.GetLength(2); k++)
        for (int i = 0; i < arr.GetLength(0); i++)
        {
            for (int j = 0; j < arr.GetLength(1); j++)
            {
                Console.Write($"{arr[i, j, k]}({i},{j},{k}) ");
            }
            Console.WriteLine();
        }
}

void mainFunc(int x, int y, int z)
{
    if (x * y * z > 89)
    {
        Console.Write("x * y * z > 89");
    }
    else
    {
        int[] tempArr = new int[x * y * z];
        int[,,] arr = new int[x, y, z];

        tempArr = CreateTempArray(x * y * z);
        arr = CreateArray(tempArr, x, y, z);
        ShowArray(arr);
    }
}

Console.Write("Enter index1: ");
int index1 = Convert.ToInt32(Console.ReadLine());

Console.Write("Enter index2: ");
int index2 = Convert.ToInt32(Console.ReadLine());

Console.Write("Enter index3: ");
int index3 = Convert.ToInt32(Console.ReadLine());

mainFunc(index1, index2, index3);
