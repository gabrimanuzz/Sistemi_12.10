    using System.Numerics;

    namespace CifrarioCesare;

    class Program
    {
        static void Main(string[] args)
        {
            // cesare
            
            Console.WriteLine("inserire frase: ");
            string text = Console.ReadLine();
            
            Console.WriteLine("inserire shift: ");
            int shift = int.Parse(Console.ReadLine());

            Console.WriteLine("\n -- CESARE -- ");
            string cifrata = CifraTraduciCesare(text, shift, true);
            string decifrata = CifraTraduciCesare(cifrata, shift, false);
            
            Console.WriteLine(cifrata);
            Console.WriteLine(decifrata);
            
            // rot
            // basta passare rot come shift a cesare?
            
            Console.WriteLine("\n -- ROT13 -- ");
            
            cifrata = CifraTraduciCesare(text, 13, true);
            decifrata = CifraTraduciCesare(cifrata, 13, false);
            
            Console.WriteLine(cifrata);
            Console.WriteLine(decifrata);
            
            // vegenere

            int[] sShift = [1, 4, 5, 7];
            
            Console.WriteLine("\n -- VIGENERE -- ");
            
            cifrata = cifraTraduciVegenere(text, sShift, true);
            decifrata = cifraTraduciVegenere(cifrata, sShift, false);
            
            Console.WriteLine(cifrata);
            Console.WriteLine(decifrata);
        }

        // mode = true (cifra) ! mode = false (traduci)
        static string CifraTraduciCesare(string text, int shift, bool mode)
        {
            shift = shift % 26;
            shift = mode ? shift : -shift;
            
            string result = "";
            
            for (int i = 0;i < text.Length;i++)
            {
                var c =  text[i];
                int ascii = (int)c;

                if (ascii >= 65 && ascii <= 90)
                {
                    ascii = (ascii - 65 + shift + 26) % 26 + 65;
                }
                
                if (ascii >= 97 && ascii <= 122)
                {
                    ascii = (ascii - 97 + shift + 26) % 26 + 97;
                }
        
                result += (char)ascii;
            }
            
            return result;
        }
        
        static string cifraTraduciVegenere(string text, int[] shift, bool mode) {
            
            for (int i = 0; i < shift.Length; i++) {
                shift[i] = shift[i] % 26;
                shift[i] = mode ? shift[i] : -shift[i];
            }

            string result = "";

            for (int i = 0; i < text.Length; i++) {
                
                char c = text[i];
                int ascii = (int)c;

                if (ascii >= 65 && ascii <= 90)
                {
                    ascii = (ascii - 65 + shift[i % shift.Length] + 26) % 26 + 65;
                }
                
                if (ascii >= 97 && ascii <= 122)
                {
                    ascii = (ascii - 97 + shift[i % shift.Length] + 26) % 26 + 97;
                }

                result +=  (char)ascii;
            }

            return result;
        }
        
    }