using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab001
{
    class CommandLine
    {
        public static int[] Numbers;
        public static int[] GetNumbers()
        {
            return Numbers;
        }
        public static void AddNumbers(int _number, int _index)
        {
            Numbers[_index] = _number;
        }
        public static void DetectNumbers(string[] _args)
        {
            int _length = _args.Length;
            if (Numbers == null)
            {
                Numbers = new int[_length];
            }
            for (int i = 0; i < _length; i++)
            {
                Console.Write("Аргумент {1} = {0}", _args[i], i);
                Converter.Convert2Int(_args[i], out int _Number, out bool _succes);
                if (!_succes)
                {
                    Converter.Convert2Int(_args[i], out _Number);
                    AddNumbers(_Number, i);
                    Console.WriteLine("Получили число - {0}\nАргумент {1} = {0} - Это число {0}", _Number, i);    
                }
                else
                {
                    Console.Write(" - Это число {0}\n", _Number);
                    AddNumbers(_Number, i);
                } 
            }
        }
        class Converter
        {
            public static void Convert2Int(string _input, out int result, out bool _succes)
            {
                try
                {
                    result = int.Parse(_input);
                    _succes = true;
                }
                catch
                {
                    result = 0;
                    _succes = false;
                }
            }
            public static void Convert2Int(string _input, out int result)
            {
                bool IsConverted = false;
                Console.WriteLine(" - Это не число");
                do
                {
                    
                    try
                    {
                        Console.WriteLine("Введите число:");
                        result = int.Parse(Console.ReadLine());
                        IsConverted = true;
                    }
                    catch
                    {
                        Console.WriteLine("Не число, повторите ввод...");
                        result = 0;
                    }

                } while (!IsConverted);
            }
        }
        class stringArr
        {
            public string[] ArrString(string[] _args)
            {
                int count = 0;
                for (int i = 0; i < _args.Length; i++)
                {
                    bool res = int.TryParse(_args[i], out var number);
                    if (res == false)
                    {
                        count++;
                    }
                }
                if (count == 0)
                {
                    count = 1;
                }
                string[] mass = new string[count];
                mass[0] = " Аргументы командной строки содержат только числа";
                int key = 0;
                for (int i = 0; i < mass.Length; i++)
                {
                    for (int j = key; j < _args.Length; j++)
                    {
                        bool res = int.TryParse(_args[j], out var number);
                        if (res == false)
                        {
                            key = j;
                            mass[i] = _args[j];
                            key++;
                            break;
                        }
                    }
                }
                return mass;
            }
        }

        class myArray
        {
            public void Print(int[] _Arr)
            {
                Console.Write("\nМетод Print(int[] _Arr) - ");
                for (int i = 0; i < _Arr.Length; i++)
                {
                    Console.Write(_Arr[i] +  " ");
                }
                Console.WriteLine();
            }
            public void Print(string[] _Arr)
            {
                stringArr myArray = new stringArr();
                string[] ARR = myArray.ArrString(_Arr);
                Console.Write("\nМетод Print(string[] _Arr) - ");
                Console.Write(string.Join(" ", ARR));
                Console.WriteLine("");
            }
            public void Sort(int[] _Arr)
            {
                Console.Write("\nМетод Sort(int[] _Arr) - ");
                Array.Sort(_Arr);
                foreach (var item in _Arr)
                {
                    Console.Write($"{item} ");
                }
                Console.WriteLine();
            }
            public void Sort(string[] _Arr)
            {
                stringArr myArray = new stringArr();
                string[] ARR = myArray.ArrString(_Arr);
                Console.Write("\nМетод Sort(string[] _Arr) - ");
                Array.Sort(ARR);
                foreach (var item in ARR)
                {
                    Console.Write($"{item} ");
                }
                Console.WriteLine();
            }
            public void FindEven(int[] _Arr)
            {
                Console.Write("\nМетод FindEven(int[] _Arr) - ");
                for (int i = 0; i < _Arr.Length; i++)
                {
                    if (_Arr[i] % 2 == 0)
                    {
                        Console.Write(_Arr[i] + " ");
                    }
                }
                Console.WriteLine();
            }
        }
        class Program
        {
            static void Main(string[] args)
            {

                if (args.Length != 0)
                {
                    int[] _intArgs = new int[args.Length];
                    string[] _args = new string[args.Length];
                    for (int i = 0; i < args.Length; i++)
                    {
                        _args[i] = args[i];
                    }
                    DetectNumbers(_args);
                    _intArgs = CommandLine.GetNumbers();
                    myArray _array = new myArray();
                    _array.Print(_intArgs);
                    _array.Print(_args);
                    _array.Sort(_intArgs);
                    _array.Sort(_args);
                    _array.FindEven(_intArgs);
                }
                else
                {
                    Console.WriteLine("Программа требует ввода агрументов командной строки");
                }               
            }
        }
    }
}
