/* Задача 54: Задайте двумерный массив. Напишите программу, которая упорядочит по убыванию 
              элементы каждой строки двумерного массива.
Например, задан массив:
1 4 7 2
5 9 2 3
8 4 2 4
В итоге получается вот такой массив:
7 4 2 1
9 5 3 2
8 4 4 2     */

Console.Clear();

int[,] array = CreateArray(); // Создаем двумерный массив
PrintArray(array); // Выводим на консоль созданный двумерный массив

SortColumn(array); // Сортируем по убыванию каждую строку массива
PrintArray(array); // Выводим на консоль созданный двумерный массив

// Ф-ция задающая двумерный массив случайным образом
int[,] CreateArray(){
    int m = new Random().Next(3, 5); // Задаем случайным образом длину строки массива (3...4)
    int n = new Random().Next(3, 9); // Задаем случайным образом длину столбца массива (3...8)

    int[,] array = new int[m, n];
    for(int i = 0; i < m; i++){
        for(int j = 0; j < n; j++){
            array[i,j] = new Random().Next(0, 10);
        }
    }

    return array;
}

// Ф-ция сортировки по убыванию каждой строки массива
void SortColumn(int[,] array){
    Console.WriteLine();
    int[] rawArray = new int[array.GetLength(1)];

    for(int i = 0; i < array.GetLength(0); i++){
        for(int j = 0; j < array.GetLength(1); j++){
            rawArray[j] = array[i,j];
        }

        Array.Sort(rawArray);
        Array.Reverse(rawArray);

        for(int j = 0; j < array.GetLength(1); j++){
            array[i,j] = rawArray[j];
        }
    }

    Console.WriteLine("Массив, элементы строк которой упорядочены по убыванию:");
}

// Ф-ция вывода на консоль двумерного массива
void PrintArray(int[,] array){
    for(int i = 0; i < array.GetLength(0); i++){
        Console.Write("[ ");
        for(int j = 0; j < array.GetLength(1); j++){
            Console.Write($"{array[i, j]} ");
        }
        Console.WriteLine("]");
    }
}