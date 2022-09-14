/* Задача 58: Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.
Например, даны 2 матрицы:
2 4 | 3 4
3 2 | 3 3
Результирующая матрица будет:
18 20
15 18
*/
Console.Clear();

/* Аргументы ф-ции CreateMatrix(row (кол-во сторк), col (кол-во столбцов), 
   min, max (диапазон максимальных и минимальных значений элементов массива)) */
int[,] matrixA = CreateMatrix(5, 4, 0, 9);
Console.WriteLine("Матрица A:");
PrintMatrix(matrixA);
Console.WriteLine();

int[,] matrixB = CreateMatrix(4, 6, 0, 9);
Console.WriteLine("Матрица B:");
PrintMatrix(matrixB);
Console.WriteLine();

int[,] matrixC = MultiTwoMatrix(matrixA, matrixB);
if( matrixC[0,0] != -1 )
{
    Console.WriteLine("Произведение двух матриц А и В:");
    PrintMatrix(matrixC);
}
Console.WriteLine();

// Ф-ция задающая двумерный массив по переданным кол-вам сторк (row) и столбцов (col), 
// и заполняющая массив элементами случайным образом в диапазоне значений min и max.
int[,] CreateMatrix(int row, int col, int min, int max){
    Random rnd = new Random();

    int[,] array = new int[row, col];
  
    for (int i = 0; i < row; i++)
    {
        for (int j = 0; j < col; j++)
        {
            array[i, j] = rnd.Next(min, max + 1);
        }
    }
    return array;
}

// Ф-ция вывода на консоль матрицы с форматированием интервала между элементами
void PrintMatrix(int[,] array){
    for(int i = 0; i < array.GetLength(0); i++){
        Console.Write("[ ");
        for(int j = 0; j < array.GetLength(1); j++){
//            Console.Write($"{array[i, j]} ");
            Console.Write( String.Format("{0,-4}", array[i, j]) );
        }
        Console.WriteLine("]");
    }
}

// Ф-ция умножения двух матриц
int[,] MultiTwoMatrix(int[,] matrixA, int[,] matrixB){
    int[,] matrixC = new int[matrixA.GetLength(0), matrixB.GetLength(1)];

    if( matrixA.GetLength(1) == matrixB.GetLength(0) ){
        for(int i = 0; i < matrixC.GetLength(0); i++ ){
            for(int j = 0; j < matrixC.GetLength(1); j++){
                matrixC[i,j] = 0;
                for (int n = 0; n < matrixA.GetLength(1); n++)
                {
                    matrixC[i, j] += matrixA[i, n] * matrixB[n, j];
                }
            }
        }
    }
    else{
        int[,] err = {{ -1 }};
        Console.Write($"Решение невозможно! Кол-во столбцов Матрицы А ({matrixA.GetLength(1)}) ");
        Console.WriteLine($"не равна кол-ву строк Матрицы В ({matrixB.GetLength(0)}).");
        return err;
    }

    return matrixC;
}