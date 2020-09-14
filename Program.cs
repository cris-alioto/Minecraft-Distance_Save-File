
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Minecraft_Distance{
    class Program{
        static void Main(string[] args){
            /* Minecraft Distance */
            char[,] matrice = new char[20, 20];
            int[,] punti = new int[2, 2];
            var rand = new Random();
            int random1, random2, count = 0;
            for (int y = 0; y < 20; y++){
                for (int x = 0; x < 20; x++){
                    matrice[x, y] = '.';
                }
            }
            matrice[rand.Next(20), rand.Next(20)] = '*';
            do{
                random1 = rand.Next(20);
                random2 = rand.Next(20);
            } while (matrice[random1, random2] == '*');
            matrice[random1, random2] = '*';
            for (int y = 0; y < 20; y++){
                for (int x = 0; x < 20; x++){
                    Console.Write(matrice[x, y]);
                    if (matrice[x, y] == '*'){
                        punti[count, 0] = x;
                        punti[count, 1] = y;
                        count++;
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine("\n" + "La distanza dei due * è: " + Convert.ToInt32(Math.Sqrt(Math.Pow(punti[0, 0] - punti[1, 0], 2) + Math.Pow(punti[0, 1] - punti[1, 1], 2))));
            /* Fase di transazione*/
            string risposta;
            Console.WriteLine("Vuoi salvare la matrice su file? si / no");
            do{
                risposta = Console.ReadLine();
            } while (risposta.Length!=2 || risposta!="si" && risposta!="no");
            Console.WriteLine();
            if (risposta == "si"){
                /* Salvare su file di testo la matrice */
                using (StreamWriter file = new StreamWriter("matrice.txt")){
                    for (int y = 0; y < 20; y++){
                        for (int x = 0; x < 20; x++){
                            file.Write(matrice[x, y]);
                        }
                        file.WriteLine();
                    }
                }
                /* Leggere la matrice dal file di testo */
                int fine = 0;
                char carattere;
                try{
                    using (StreamReader file = new StreamReader("matrice.txt")){
                        for (int y = 0; y < 20; y++){
                            for (int x = 0; x < 20; x++){
                                carattere = (char)file.Read();
                                if (carattere > 0){
                                    if (carattere != matrice[x, y]){
                                        fine = 1;
                                        break;
                                    }
                                }
                                Console.Write(matrice[x, y]);
                            }
                            if (fine == 1) break;
                            file.ReadLine();
                            Console.WriteLine();
                        }
                        Console.WriteLine();
                        if (fine == 0) Console.WriteLine("Lettura della matrice eseguita con successo.");
                        else Console.WriteLine("Lettura della matrice fallita.");
                    }
                }
                catch (Exception e){
                    Console.WriteLine("Il file non può essere letto:");
                    Console.WriteLine(e.Message);
                }
            }
            else Console.WriteLine("Bha, non sai che ti perdi.");
            Console.WriteLine("Premi un tasto per terminare il programma");
            Console.ReadKey();
        }
    }
}