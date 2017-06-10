#include <stdio.h>
#include <stdlib.h>

typedef int (*IntegerSelectorStrategy) (int*,int,int,int, int**);

int EvenNumbersSelector(int*,int,int,int, int**);
int NumbersFormRangeSelector(int*,int,int,int, int**);
int OddNumbersSelector(int*,int,int,int, int**);

void PrintSelectedElements(int* source, int len, int segmentStart, int segmentEnd, IntegerSelectorStrategy strategy)
{
    printf("[");
    for(int i=0;i<len-1;i++)
    {
        printf("%d, ", source[i]);
    }
    printf("%i]\n", source[len-1]);

    int* resultArray;
    int lenResultArray = (*strategy)(source, len, segmentStart, segmentEnd, &resultArray);

    for(int i=0;i<lenResultArray;i++)
    {
        printf("Selected element: %d \n", resultArray[i]);
    }
}

int main()
{
    int sourceArray[17] = { 1, 2, 3, 4, 5, 6, -4, -1, -455, 2, 1, 456, 783, 12, 45, 90, 24};

    printf("Selecting even numbers");
    PrintSelectedElements(sourceArray, 17, 0, 0, EvenNumbersSelector);

    printf("Selecting odd numbers");
    PrintSelectedElements(sourceArray, 17, 0, 0, OddNumbersSelector);

    printf("Selecting numbers in range [1, 20]");
    PrintSelectedElements(sourceArray, 17, 1, 20, NumbersFormRangeSelector);

    return 0;
}


int EvenNumbersSelector(int* source, int len, int unused1, int unused2, int** resultArray)
{
    int numberOfPassed = 0;
    for(int i=0; i<len; ++i)
    {
        if(source[i] % 2 == 0)
            numberOfPassed++;
    }

    (*resultArray) = (int*)malloc(numberOfPassed * sizeof(int));
    int* resultArrayPointerCopy = (*resultArray);

    for(int i=0; i<numberOfPassed; ++source)
    {
        if((*source) % 2 == 0)
        {
            (*resultArrayPointerCopy) = (*source);
            ++resultArrayPointerCopy;
            ++i;
        }
    }

    return numberOfPassed;
}

int OddNumbersSelector(int* source, int len, int unused1, int unused2, int** resultArray)
{
    int numberOfPassed = 0;
    for(int i=0; i<len; ++i)
    {
        if(source[i] % 2 != 0)
            numberOfPassed++;
    }

    (*resultArray) = (int*)malloc(numberOfPassed * sizeof(int));
    int* resultArrayPointerCopy = (*resultArray);

    for(int i=0; i<numberOfPassed; ++source)
    {
        if((*source) % 2 != 0)
        {
            (*resultArrayPointerCopy) = (*source);
            ++resultArrayPointerCopy;
            ++i;
        }
    }

    return numberOfPassed;
}

int NumbersFormRangeSelector(int* source, int len, int segmentStart, int segmentEnd, int** resultArray)
{
    int numberOfPassed = 0;
    for(int i=0; i<len; ++i)
    {
        if(source[i] >= segmentStart && source[i] <= segmentEnd)
            numberOfPassed++;
    }

    (*resultArray) = (int*)malloc(numberOfPassed * sizeof(int));
    int* resultArrayPointerCopy = (*resultArray);

    for(int i=0; i<numberOfPassed; ++source)
    {
        if((*source) >= segmentStart && (*source) <= segmentEnd)
        {
            (*resultArrayPointerCopy) = (*source);
            ++resultArrayPointerCopy;
            ++i;
        }
    }

    return numberOfPassed;
}
