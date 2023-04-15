using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Runtime.InteropServices;
using System.Reflection;
using C_ImageLibrary;
using Timer = System.Windows.Forms.Timer;
using System.IO;
using System.Collections.Specialized;



// Nazwa Uczelni: Politechnika Śląska
// Semestr i przedmiot: Języki Asemblerowe, sem 5
// Temat projektu: Przekrztałcanie perspektywiczne obrazów
// Opis: Celem projektu jest edycja obrazu w taki sposób aby używając wyglądał on jakby był zrzutowany perspektywicznie.
// Inaczej mówiąc, pozycja obrazu po edycji będzie wygenerowana w taki sposób jakby zmienił się punkt widzenia obserwatora.
// Autor: Szymon Czech

namespace ProjektJA
{
    public partial class MyForm : Form
    {
        [DllImport(@"F:\Projekty\ProjektJA\x64\Debug\JAAsm.dll")]
        static extern void transformation(double factor, byte[] inp, int start, int end, int width, int height, byte[] outp);
 
        // Plik wejściowy z obrazem.
        String filename;

        // Bitmapa obrazu wejściowego.
        Bitmap image;

        //Bitmapa obrazu wyjściowego - przekrztałconego.
        Bitmap transformed_image;

        //Obiekt klay projectivTransformation z biblioteki C#.
        ImageTransformation projectivTransformation = new ImageTransformation();

        // Liczba wątków
        int threads; 
        public MyForm()
        {
            InitializeComponent();
            setTrackBarThreads();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        //Funkcja do obsługi przycisku "Załaduj obraz"
        private void LoadButton_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(LoadFile);
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
            thread.Join();
        }

        //Funkcja do załadowanie wybranego obrazu
        private void LoadFile()
        {
            openFileDialog1.Title = "Wybierz obraz do edycji.";
            openFileDialog1.InitialDirectory = "F:\\Projekty\\ProjektJA\\Przykłady";
            openFileDialog1.Filter = "Image files (*.PNG;*.JPG;*BMP)|*.PNG;*.JPG;*BMP";
            openFileDialog1.RestoreDirectory = true;


            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                filename = openFileDialog1.FileName;

                Bitmap loaded = new Bitmap(filename);
                LoadPB.Image = loaded;
                image = loaded;
                transformed_image = new Bitmap(image.Width, image.Height);
                ResultPB.Image = null;
            }
        }

        //Funkcja do obsługi przycisku "Wykonaj", w niej wywoływane są metody do przekrztałcenia obrazu.
        private void MakeButton_Click(object sender, EventArgs e)
        {
            
            if(LoadPB.Image!= null)
            {

                //Przygotowanie bitmapy i tabeli bajtów obrazu
                Bitmap original = new Bitmap(image);
                BitmapData originalData = original.LockBits(new Rectangle(0, 0, image.Width, image.Height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
                IntPtr ptr = originalData.Scan0;
                int bytes = originalData.Stride * originalData.Height;
                byte[] input = new byte[bytes];
                byte[] output = new byte[bytes];

                //Wyznaczenie współczynnika do przekrztałcenia
                double factor = (double)(1.0 / image.Height);

                //Ustawienie białego tła w obrazie wyjściowym
                MakeWhiteBackground(ref output);

                Marshal.Copy(ptr, input, 0, bytes);

                //Przygotowanie wątków
                threads = trackBar1.Value;
                Thread[] threadsArray = new Thread[threads];

                //Przygotowanie fragmentu obrazu na wątek
                int blockSize = output.Length / threads;

                //Wystartowanie mierzenia czasu
                Stopwatch watch = new Stopwatch();
                watch.Start();

                for (int i = 0; i < threads; i++)
                {
                    //Wyznaczenie fragmentu tablicy którym będzie się zajmował dany wątek
                    int start = i * blockSize;
                    int end = (i + 1) * blockSize;

                    //Wywołanie biblioteki C#
                    if (CLibrary.Checked)
                    {                
                        Thread thread = new Thread(() => {
                            projectivTransformation.transformation(factor, input, start, end, original.Width, original.Height, ref output);
                        });
                        threadsArray[i] = thread;

                    }
                    //Wywołanie biblioteki ASM
                    else if (ASMLibrary.Checked)
                    {
                        Thread thread = new Thread(() => {
                            transformation(factor, input, start, end, original.Width, original.Height, output);
                        });
                        threadsArray[i] = thread;
                    }
                }

                // Rozpoczęcie wątków
                for (int i = 0; i < threads; i++)
                    threadsArray[i].Start();

                // Czekanie na zakończenie pracy wszystkich wątków
                for (int i = 0; i < threads; i++)
                    threadsArray[i].Join();

                //Zatrzymanie pomiaru czasu i wyśiwetlenie go
                watch.Stop();
                if (CLibrary.Checked)
                    CTime.Text = (watch.Elapsed.TotalMilliseconds).ToString() + "ms";
                else if (ASMLibrary.Checked)
                    ASMTime.Text = (watch.Elapsed.TotalMilliseconds).ToString() + "ms";

                //Ustawienie obrazu wyjściowego
                input = (byte[])output.Clone();
                BitmapData data = transformed_image.LockBits(new Rectangle(0, 0, image.Width, image.Height), ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);
                Marshal.Copy(output, 0, data.Scan0, output.Length);
                transformed_image.UnlockBits(data);
                ResultPB.Image = transformed_image;
   
            }
            

        }

        //Funkcja do obsługi przycisku "Zapisz"
        private void SaveButton_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(SaveFile);
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
            thread.Join();
        }

        // Funkcja zapisująca przekrztałcony obraz do wskazanej lokalizacji.
        private void SaveFile()
        {
            saveFileDialog1.InitialDirectory = "F:\\Projekty\\ProjektJA\\Wyniki";
            saveFileDialog1.Filter = "PNG Image|*.png";
            saveFileDialog1.Title = "Zapisz obraz";
            saveFileDialog1.FileName = "";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (!saveFileDialog1.FileName.Equals(""))
                {
                    transformed_image.Save(saveFileDialog1.FileName, ImageFormat.Png);
                }
            }
        }

        private void setTrackBarThreads()
        {
            int procesors = Environment.ProcessorCount;
            trackBar1.Value = procesors;
            TNumberValue.Text = procesors.ToString();
        }

        private void Threads_number_trackbar_Scroll(object sender, EventArgs e)
        {
            int value = trackBar1.Value;
            TNumberValue.Text = value.ToString();
        }
        private void label1_Click(object sender, EventArgs e)
        {

            
        }

        //Funkcja do ustawienia białego tła w obrazie.
        private void MakeWhiteBackground(ref byte[] table)
        {
            for(int i = 0; i < table.Length; i += 3)
            {
                table[i] = 255;
                table[i+1] = 255;
                table[i+2] = 255;
            }

        }
        //Funkcja do obsługi przycisku "Raport", w niej przekrztałcanie obrazu jest wykonywane 10 razy a uśredniony wynik zapisywany do pliku tekstowego.
        private void button1_Click(object sender, EventArgs e)
        {
            
            StreamWriter file = new StreamWriter("F:\\Projekty\\ProjektJA\\Wyniki\\measures.txt", append:true);

            //Wyznaczenie tablicy na pomiary czasu
            const int NUMBER_OF_MEASURMENTS = 10;
            List<double> TABLE_OF_MEASURES = new List<double>(NUMBER_OF_MEASURMENTS);

            if (LoadPB.Image != null)
            {
                for(int m =0; m< NUMBER_OF_MEASURMENTS; m++) {

                    //Przygotowanie bitmapy i tabeli bajtów obrazu
                    Bitmap original = new Bitmap(image);
                    BitmapData originalData = original.LockBits(new Rectangle(0, 0, image.Width, image.Height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
                    IntPtr ptr = originalData.Scan0;
                    int bytes = originalData.Stride * originalData.Height;
                    byte[] input = new byte[bytes];
                    byte[] output = new byte[bytes];

                    //Wyznaczenie współczynnika do przekrztałcenia
                    double factor = (double)(1.0 / image.Height);

                    //Ustawienie białego tła w obrazie wyjściowym
                    MakeWhiteBackground(ref output);

                    Marshal.Copy(ptr, input, 0, bytes);

                    //Przygotowanie wątków
                    threads = trackBar1.Value;
                    Thread[] threadsArray = new Thread[threads];

                    //Przygotowanie fragmentu obrazu na wątek
                    int blockSize = output.Length / threads;

                    //Wystartowanie mierzenia czasu
                    Stopwatch watch = new Stopwatch();
                    watch.Start();

                    for (int i = 0; i < threads; i++)
                    {

                        int start = i * blockSize;
                        int end = (i + 1) * blockSize;
                        //Wywołanie biblioteki C#
                        if (CLibrary.Checked)
                        {

                            Thread thread = new Thread(() => {
                                projectivTransformation.transformation(factor, input, start, end, original.Width, original.Height, ref output);
                            });
                            threadsArray[i] = thread;

                        }
                        //Wywołanie biblioteki ASM
                        else if (ASMLibrary.Checked)
                        {
                            Thread thread = new Thread(() => {
                                transformation(factor, input, start, end, original.Width, original.Height, output);
                            });
                            threadsArray[i] = thread;
                        }
                    }

                    // start all threads
                    for (int i = 0; i < threads; i++)
                        threadsArray[i].Start();

                    // Czekanie na zakończenie pracy wszystkich wątków
                    for (int i = 0; i < threads; i++)
                    threadsArray[i].Join();

                    //Zatrzymanie pomiaru czasu i wyśiwetlenie go
                        watch.Stop();
                    if (CLibrary.Checked)
                        CTime.Text = (watch.Elapsed.TotalMilliseconds).ToString() + "ms";
                    else if (ASMLibrary.Checked)
                        ASMTime.Text = (watch.Elapsed.TotalMilliseconds).ToString() + "ms";

                    double time = watch.Elapsed.TotalMilliseconds;

                    TABLE_OF_MEASURES.Add(time);

                        
                    //Ustawienie obrazu wyjściowego
                    input = (byte[])output.Clone();
                    BitmapData data = transformed_image.LockBits(new Rectangle(0, 0, image.Width, image.Height), ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);
                    Marshal.Copy(output, 0, data.Scan0, output.Length);
                    transformed_image.UnlockBits(data);
                    ResultPB.Image = transformed_image;
                }
            }

            double sum = TABLE_OF_MEASURES.Sum();

            double mean = sum / TABLE_OF_MEASURES.Count;

            file.WriteLine(mean);
            file.Close();

        }
    }
}
