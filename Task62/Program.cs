/* Задача 62. Напишите программу, которая заполнит спирально массив 4 на 4.
Например, на выходе получается вот такой массив:
01 02 03 04
12 13 14 05
11 16 15 06
10 09 08 07 */

int[,] matrix = CreateSpiralMatrix2(4, 6);

PrintMatrix2(matrix);

// Ф-ция задающая двумерный массив змейкой по переданным кол-вам сторк (row) и столбцов (col), 
int[,] CreateSpiralMatrix2(int row, int col){
    int[,] matrix = new int[row, col];

    int y = 0; // Текущее значение индекса строки (соответствует Y)
    int x = 0; // Текущее значение индекса столбца (соответствует Х)

    /* dx, dy - переменные, которые добавляют приращение к индексу матрицы 
      (задают направление выбора следующей ячейки матрицы по Х и Y)
    dx=  1, dy=  0: сверху вправо (Х - увеличивается, Y - не меняется  )
    dx=  0, dy=  1: справа вниз   (Х - не меняется,   Y - увеличивается)
    dx= -1, dy=  0: снизу влево   (Х - уменьшается,   Y - не меняется  )
    dx=  0, dy= -1: слева вверх   (Х - не меняется,   Y - уменьшается  ) */
    int dx = 1;
    int dy = 0;
    int dirChanges = 0; // Кол-во раз, когда менялось направление приращения индекса по Х и Y.
    int steps = col; // Кол-во шагов, которые остается до смены направления приращении индекса по Х и Y.
 
//Console.WriteLine($"matrix.Length= {matrix.Length}");
    for (int i = 0; i < matrix.Length; i++) {
        matrix[y, x] = i + 1;     
        if (--steps == 0){
            steps = col * (dirChanges %2) + row * ((dirChanges + 1) %2) - (dirChanges/2 - 1) - 2; 
            int temp = dx;
            dx = -dy;
            dy = temp;
            dirChanges++;  
        }
        x += dx;
        y += dy;
    }
    return matrix;
}   

// Ф-ция вывода на консоль двумерной матрицы с форматированием интервала между элементами
void PrintMatrix2(int[,] array){
    for(int i = 0; i < array.GetLength(0); i++){
        Console.Write("[ ");
        for(int j = 0; j < array.GetLength(1); j++){           
            Console.Write( String.Format("{0,-4:00}", array[i, j]) ); // Форматируемый вывод на консоль
        }
        Console.WriteLine("]");
    }
}