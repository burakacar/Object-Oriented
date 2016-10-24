using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24102016_02
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] original = ArrayInitializer();
            double[] doubleArray = new double[original.GetLength(0)];

            for (int i = 0; i < original.GetLength(0); i++) //doubleArray.Length de yazabilirdik.
                doubleArray[i] = original[1, 0] + ((double)original[i, 1]) * 0.1; //Math.Pow(0.1, original[i,1].ToString().Length()); 2-3basamaklı olanlar için

            while (true)
            {
                Console.WriteLine("Choise: ");
                int result = int.Parse(Console.ReadLine());

                Dictionary<double, int> dictionary = new Dictionary<double, int>(); //<> içine istediğimiz herhangi bir sınıfı yazabiliriz.
                //double anahtarımız, int de kaç defa gördüğümüz olacak!

                for (int i = 0; i < doubleArray.Length; i++)
                {
                    if (dictionary.Keys.Contains(doubleArray[i]))
                    {
                        int count = dictionary.Where(e => e.Key == doubleArray[i]).First().Value;
                        //Dictionary içerisinde anahtarı benim double'ımla eşleşen ilk satırı aldım. Value'yi counta gönderdim.
                        dictionary.Remove(doubleArray[i]);
                        dictionary.Add(doubleArray[i], ++count); //Silip tekrar ekliyoruz! "++"nın yeri önemli!

                    }
                    else
                    {
                        dictionary.Add(doubleArray[i], 1);
                    }
                }

                switch (result)
                {
                    case 1:
                        doubleArray = doubleArray.OrderByDescending(i => i).ToArray();
                        foreach (var item in doubleArray)
                            Console.WriteLine(item);
                        break;
                    case 2:
                        doubleArray = doubleArray.OrderBy(i => i).ToArray();
                        foreach (var item in doubleArray)
                            Console.WriteLine(item);
                        break;
                    case 3:
                        //En sık rastlanması, value'nin en büyük olması demek.
                        dictionary = dictionary.OrderByDescending(i => i.Value).ToDictionary(x => x.Key, x => x.Value);
                        foreach (var item in dictionary)
                        {
                            Console.WriteLine("{0} --> {1}", item.Key, item.Value);
                        }
                        break;
                    case 4:
                        dictionary = dictionary.OrderBy(i => i.Value).ToDictionary(x => x.Key, x => x.Value);

                        foreach (var item in dictionary)
                        {
                            Console.WriteLine("{0} --> {1}", item.Key, item.Value);
                        }
                        break;
                    case 5:
                        return;

                }
            }
        }
        private static int[,] ArrayInitializer()
        {
            return new int[,] {
 { 5, 6 }, { 1, 2 }, { 1, 3 }, { 2, 2 }, {11, 7 }, { 5, 3 }, { 4, 11},
 {15, 8 }, {14, 2 }, { 3, 9 }, { 7, 4 }, { 6, 8 }, { 8, 6 }, { 9, 5 },
 {11, 3 }, {15, 5 }, {13, 15}, {18, 14}, { 5, 19}, {15, 16}, {15, 11},
 {13, 12}, {14, 5 }, { 1, 13}, { 8, 5 }, { 9, 7 }
 };
        }

    }
}
