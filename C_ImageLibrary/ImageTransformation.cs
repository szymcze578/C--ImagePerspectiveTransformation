using System; 

namespace C_ImageLibrary
{
    public class ImageTransformation
    {
        //Funkcja do wyznaczenia pozycji pixela.
        public static Tuple<int, int> GetPixelPosition(int index, int width)
        {
            int pixelIndex = index / 3;
            int x = pixelIndex % (width);
            int y = pixelIndex / (width);

            return new Tuple<int, int>(x, y);
        }

        public void transformation(double factor, byte[] inp, int start, int end, int width, int height, ref byte[] outp)
        {

            for (int i = start; i < end; i += 3)
            {
                //wyznaczenie pozycji pixela
                (int x, int y) = GetPixelPosition(i, width);

                //obliczenie nowych pozycji składowych pixela na podstawie macierzy transformacji
                //matrix = {
                // { 1,      0,  0},
                // { 0.5,    1,  0},
                // { factor, 0,  1}};
                //double new_x = x * matrix[0, 0] + y * matrix[0, 1] + matrix[0, 2];
                //double new_y = x * matrix[1, 0] + y * matrix[1, 1] + matrix[1, 2];
                //double new_w = x * matrix[2, 0] + y * matrix[2, 1] + matrix[2, 2];

                double new_x = x;
                double new_y = x * 0.5 + y;
                double new_w = x * factor + 1;

                //normalizacja pixela
                int dst_x = (int)(new_x / new_w);
                int dst_y = (int)(new_y / new_w);

                //sprawdzenie czy nowe współrzędne znajdują się "na" obrazie.
                if (dst_x >= 0 && dst_x < width && dst_y >= 0 && dst_y < height)
                {
                    //obliczenie indexów w tablelach wejściowej i wyjściowej.
                    int index = (y * width + x) * 3;
                    int new_index = (dst_y * width + dst_x) * 3;

                    //przypisanie wartości RGB do nowych pozycji
                    outp[new_index] = inp[index];
                    outp[new_index + 1] = inp[index + 1];
                    outp[new_index + 2] = inp[index + 2];

                }
            }

        }
    }
}
