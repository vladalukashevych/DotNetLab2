using ConsoleAppDemo.Extensions;
using ConsoleAppDemo.ExtendedDictionary;


string str = "last christmas I gave you my heart!";
Console.WriteLine("Original: {0}", str);
Console.WriteLine("Reversed: {0}", str.Reverse());
Console.WriteLine("'t' occurenses number: {0}", str.CountOccurenses('t'));

bool[] arrayBool = new bool[6] { true, false, false, true, true, false };
Console.WriteLine("\nBool array: {0}", string.Join(", ", arrayBool));
Console.WriteLine("'true' occurenses number: {0}", arrayBool.CountOccurenses(true));
Console.WriteLine("Unique array: {0}", string.Join(", ", arrayBool.GetUnique()));

int[] arrayInt = new int[10] { 11, 9, 3, 76, 35, 9, 15, 2, 6, 9 };
Console.WriteLine("\nInt array: {0}", string.Join(", ", arrayInt));
Console.WriteLine("'9' occurenses number: {0}", arrayInt.CountOccurenses(9));
Console.WriteLine("Unique array: {0}", string.Join(", ", arrayInt.GetUnique()));


ExtendedDictionary<int, string, string> extDic = 
    new ExtendedDictionary<int, string, string>();
ExtendedDictionaryElement<int, string, string> elem1 = 
    new ExtendedDictionaryElement<int, string, string>(1, "white", "black");
ExtendedDictionaryElement<int, string, string> elem2 = 
    new ExtendedDictionaryElement<int, string, string>(2, "light", "shadow");
ExtendedDictionaryElement<int, string, string> elem3 = 
    new ExtendedDictionaryElement<int, string, string>(3, "sun", "moon");

extDic.Add(elem1);
extDic.Add(elem2);
extDic.Add(elem3);
Console.WriteLine($"\n\n\nDictionary:\n{extDic.ToString()}");
Console.WriteLine($"Amount of elements: {extDic.Amount}\n");
extDic.Remove(2);
Console.WriteLine($"Dictionary after deleting element with key '2':\n{extDic.ToString()}");
Console.WriteLine($"Dictionary contains element with values 'sun', 'moon':\n{extDic.ContainsValues("sun", "moon")}");
extDic[1].Value2 = "grey";
Console.WriteLine($"\nChanging element value through index:\n{extDic.ToString()}");