/* Задача 56: Задайте прямоугольный двумерный массив. Напишите программу, которая будет находить строку с наименьшей суммой элементов.
Например, задан массив:
1 4 7 2
5 9 2 3
8 4 2 4
5 2 6 7
Программа считает сумму элементов в каждой строке и выдаёт номер строки с наименьшей суммой элементов: 1 строка
*/
Console.Clear();

// int[,] array = { {2, 4, 8, 1}, {4, 0, 9, 2}, {1, 5, 8, 1} , {8, 0, 7, 0}  }; // Тестовый двумерный массив
int[,] array = CreateArray(); // Создаем двумерный массив
PrintArray(array); // Выводим на консоль созданный двумерный массив

PrintSumRaw(array); // Находим номера строк массива с наименьшей суммой элементов. Вывод их на консоль.


// Ф-ция задающая двумерный массив случайным образом
int[,] CreateArray(){
    int m = new Random().Next(3, 9); // Задаем случайным образом длину строки массива (3...8)
    int n = new Random().Next(3, 9); // Задаем случайным образом длину столбца массива (3...8)

    int[,] array = new int[m, n];
    for(int i = 0; i < m; i++){
        for(int j = 0; j < n; j++){
            array[i,j] = new Random().Next(0, 10);
        }
    }

    return array;
}

// Ф-ция нахождения номеров строк массива с наименьшей суммой элементов. Вывод на консоль.
void PrintSumRaw(int[,] array){
    Console.WriteLine();
    int[] sumRawArray = new int[array.GetLength(0)];
    int sum = 0;
    int minSum = 0;

    for(int i = 0; i < array.GetLength(0); i++){
        for(int j = 0; j < array.GetLength(1); j++){
            sum += array[i,j];
        }

        sumRawArray[i] = sum;

        if(i == 0){
            minSum = sum;
        }
        else{
            if(sum < minSum) minSum = sum;
        }
        
        Console.WriteLine($"Сумма {i+1}-строки = {sumRawArray[i]}");
        sum = 0;
    }

    Console.Write("Номера строк массива с наименьшей суммой элементов:");
    for(int i = 0; i < sumRawArray.Length; i++){
        if(sumRawArray[i] == minSum){
            Console.Write($" {i+1},");
        }
    }
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