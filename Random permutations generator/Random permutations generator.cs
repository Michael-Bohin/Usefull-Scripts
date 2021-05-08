using System;
using static System.Console;
using static System.Random;
using System.IO;

namespace Random_permutations_generator
{
    class Generator {
        Random rand = new Random();
        int int_Line_Count = 8;
        int int_Numbers_Per_Line = 10_000;
        int int_Digits_Per_Number = 5;

        int string_Line_Count = 8;
        int string_Words_Per_Line = 10_000;
        int string_Characters_Per_Word = 8;

        public Generator() { }

        public void generate_Integers(StreamWriter sw) {
            for(int i = 0; i < int_Line_Count; i++) {
                string resultLine = "";
                for(int j = 0; j < int_Numbers_Per_Line; j++) {
                    string number = "";
                    if(Coin_Flip())
                        number += "-"; // mix positive and negative number evenly
                    for(int k = 0; k < int_Digits_Per_Number; k++) {
                        int from = 48;
                        if(k == 0) 
                            from = 49; // exlude leading zero -> doesnt make much sense
                        char c = (char) rand.Next(from, 58); // inclusive , exlusive -> 0-9
                        number += char.ToString(c) ;
                    }
                    resultLine += $"{number} ";
                }
                resultLine = resultLine.Trim();
                sw.WriteLine(resultLine);
            }
        }

        private bool Coin_Flip() {
            if(rand.Next(0, 2) == 1)
                return true;
            return false;
        }
        
        public void generate_Strings(StreamWriter sw) {
            int from_a = 97; // use both lower and upper case letters
            int to_z = 123;
            int from_A = 65;
            int to_Z = 91;
            char c;
            string word;
            string resultLine;
            for(int i = 0; i < string_Line_Count; i++) {
                resultLine = "";
                for(int j = 0; j < string_Words_Per_Line; j++) {
                    word = "";
                    for(int k = 0; k < string_Characters_Per_Word; k++) {
                        if(Coin_Flip()) {
                            c = (char) rand.Next(from_a, to_z); // inclusive , exlusive -> a-z
                        } else {
                            c = (char) rand.Next(from_A, to_Z); // inclusive , exlusive -> A-Z
                        }
                        word += char.ToString(c) ;
                    }
                    resultLine += word + " ";
                }
                resultLine = resultLine.Trim();
                sw.WriteLine(resultLine);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("Hello");
            string path = "./rand_Integers.txt";
            Generator g = new Generator();
            using(StreamWriter sw = new StreamWriter(path)) 
                g.generate_Integers(sw);
                
            path = "./rand_Strings.txt";
            using(StreamWriter sw = new StreamWriter(path)) 
                g.generate_Strings(sw);
            
        }
    }
}
