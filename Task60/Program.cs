/* Задача 60. Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. Напишите 
              программу, которая будет построчно выводить массив, добавляя индексы каждого элемента.

Массив размером 2 x 2 x 2
66(0,0,0) 25(0,1,0)
34(1,0,0) 41(1,1,0)
27(0,0,1) 90(0,1,1)
26(1,0,1) 55(1,1,1) */
Console.Clear();

int[,,] matrix3 = CreateMatrix3(2, 3, 4, 10, 99);

if( matrix3[0,0,0] != -1 ){
    PrintMatrix3(matrix3);
}


/* Ф-ция задающая трехмерный массив по переданным кол-вам сторк (x), столбцов (y) и глубины (z), 
   заполняющая массив уникальными элементами случайным образом в диапазоне значений min и max. */
int[,,] CreateMatrix3(int x, int y, int z, int min, int max){
    Random rnd = new Random();
    int[] numMinMax = new int[max - min + 1]; // Создаем массив размером под все возможные уникальныме значения [min...max]

    if( (max - min + 1) > (x * y * z) ){ // Кол-во элементов массива недолжно быть больше кол-ва уникальных значений
        // Заполняем массив numMinMax упорядоченно значениями от min до max.
        for(int i = 0; i < max - min + 1; i++){
            numMinMax[i] = min + i;
        }     
        //Перемешиваем элементы массива numMinMax между собой.
        for (int i = max - min; i >= 0; i--){
            int j = rnd.Next(0, max - min + 1);
            int temp = numMinMax[j];
            
            numMinMax[j] = numMinMax[i];
            numMinMax[i] = temp;
        }
    }
    else{
        Console.Write($"Кол-во элементов не достаточно, чтобы заполнить все ячейки 3-х мерной матрицы {x} x {y} x {z}");
        Console.WriteLine($"уникальными значениями от {min} до {max}.");
        int[,,] err = { { {-1} } };
        return  err;
    }

    /* Создаем и заполняем 3-мерный массив 'matrix3' элементами из 'numMinMax' (по порядку, начиная с нулевого индекса).
       Т.к. в 'numMinMax' лежат в случайном порядке только уникальные числа (значением от min до max), то и элементы 
       массива 'matrix3' тоже будут уникальными */
    int[,,] matrix3 = new int[x, y, z]; // Создаем 3-х мерный массив с размерами x, y, z.
    for( int xx = 0; xx < x; xx++ ){
        for( int yy = 0; yy < y; yy++ ){
            for( int zz = 0; zz < z; zz++ ){
                matrix3[xx, yy, zz] = numMinMax[y*z*xx + z*yy + zz];
            }
        }
    }
    return matrix3;
}

// Ф-ция вывода на консоль 3-х мерной матрицы
void PrintMatrix3(int[,,] matrix3){
    // Выводим массив matrix3 на консоль для проверки
    for( int xx = 0; xx < matrix3.GetLength(0); xx++ ){
        for( int yy = 0; yy < matrix3.GetLength(1); yy++ ){
            for( int zz = 0; zz < matrix3.GetLength(2); zz++ ){
                Console.Write($"{matrix3[xx, yy, zz]}({xx}, {yy}, {zz}); ");
            }
            Console.WriteLine();
        }
    }
}