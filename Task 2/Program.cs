int[] CreateArray(int length, int minimum, int maximum)
{
    int[] array = new int[length];
    Random random = new Random();
    for (int i = 0; i < array.Length; i++)
        array[i] = random.Next(minimum, maximum);
    return array;
}
void PrintArray(int[] array)
{
    foreach (int element in array)
        Console.Write($"{element} ");
    Console.WriteLine();
}
int Count(int[] array, int value)
{
    int count = 0;
    foreach (int element in array)
        if (element == value)
            count++;
    return count;
}
bool Contains(int[] array, int value, int index)
{
    for (int i = 0; i < index; i++)
        if (array[i] == value)
            return true;
    return false;
}
int CountUniqueElements(int[] array)
{
    int count = 0;
    for (int i = 0; i < array.Length; i++)
        if (Contains(array, array[i], i) == false)
            count++;
    return count;
}
// { 1, 9, 9, 0, 2, 8, 0, 9 } -> {1, 9, 0, 2, 8}
int[] GetUniquesElements(int[] array)
{
    int[] uniques = new int[CountUniqueElements(array)];
    int index = 0;
    for (int i = 0; i < array.Length; i++)
        if (Contains(array, array[i], i) == false)
        {
            uniques[index] = array[i];
            index++;
        }
    return uniques;
}
void SelectionSort(int[] array)
{
    for(int i=0;i<array.Length;i++)
    {
        int index = i;
        for(int j=i;j<array.Length;j++)
            if(array[j]<array[index])
                index = j;
        int tmp = array[i];
        array[i] = array[index];
        array[index] = tmp;
    }
}
int[,] GetFrequencyDictionary(int[] array)
{
   int[,] frequencyDictionary = new int[CountUniqueElements(array), 2];
   int[] uniques = GetUniquesElements(array);
   SelectionSort(uniques);
   for(int i=0;i<uniques.Length;i++)
    {
        frequencyDictionary[i,0] = uniques[i];
        frequencyDictionary[i,1] = Count(array, uniques[i]);
    }
    return frequencyDictionary;
}
int[] array = { 1, 9, 9, 0, 2, 8, 0, 9 };
int[,] frequencyDictionary = GetFrequencyDictionary(array);
for(int i=0;i<frequencyDictionary.GetLength(0);i++)
    Console.WriteLine($"Element {frequencyDictionary[i,0]} contains "+ 
                        $"{frequencyDictionary[i,1]} times");