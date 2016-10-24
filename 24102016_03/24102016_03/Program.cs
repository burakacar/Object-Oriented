using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24102016_03
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> sepet = new Dictionary<string, int>();

            while(true)
            {
                Console.WriteLine("Ekle --> 1");
                Console.WriteLine("Çıkar --> 2");
                Console.WriteLine("Liste --> 3");
                Console.WriteLine("Çıkış --> 4");

                int choice = int.Parse(Console.ReadLine());

                switch(choice)
                {
                    case 1:
                        sepet = Ekle(sepet); //Ekle'nin üstüne tıklayıp Ctrl noktaya bastım. Fonksiyonu tanımlamak için!
                        break;
                    case 2:
                        sepet = Cikar(sepet);
                        break;
                    case 3:
                        foreach (var item in sepet)
                        {
                            Console.WriteLine("{0} --> {1}", item.Key, item.Value);
                        }
                        break;
                    case 4:
                        return;

                }
            }
        }

        private static Dictionary<string, int> Cikar(Dictionary<string, int> sepet)
        {
            Console.WriteLine("Silmek istediğiniz ürünün Adı: ");
            string productName = Console.ReadLine();

            sepet.Remove(productName);
            return sepet;
        }

        private static Dictionary<string, int> Ekle(Dictionary<string, int> sepet)
        {
            Console.WriteLine("Ürünün Adı: ");
            string productName = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(productName))
            {
                Console.WriteLine("Ürün ekleme işlemi iptal edildi.");
                return sepet;
            }
            Console.WriteLine("Ürünün Adeti: ");
            int count = int.Parse(Console.ReadLine());

            if (count == 0)
            {
                Console.WriteLine("Ürün ekleme işlemi iptal edildi.");
                return sepet;
            }
            if (sepet.Keys.Contains(productName))
            {
                Console.WriteLine("Ürün listede mevcut!");
                return sepet;
            }
            sepet.Add(productName, count);
            return sepet;

        }
    }
}
