using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using EricOulashin;
using System.IO;
using System.Diagnostics;

namespace Pinta_Sound
{
    class Parse_Pinta
    {
        //---------------------------------------------------------------------------------
        //Objects

        public struct Data_Lines
        {
            public List<Point> upper_line;
            public List<Point> parsed_line;
            public List<Point> lower_line;
        };

        public Data_Lines data_lines = new Data_Lines();

        public struct Double_Point
        {
            public Double X;
            public Double Y;
        };

        public struct Normalized_Lines
        {
            public List<Double_Point> upper_line;
            public List<Double_Point> parsed_line;
            public List<Double_Point> lower_line;
        };

        public Normalized_Lines normalized_lines = new Normalized_Lines();

        //---------------------------------------------------------------------------------
        //Methods

        public void Parse_Bitmap(Bitmap bitmap, Color set_pixel)
        {
            List<Point> upper_line = new List<Point>();
            List<Point> lower_line = new List<Point>();
            List<Point> parsed_line = new List<Point>();

            Point upper_pixel = new Point();
            Point lower_pixel = new Point();
            Color pixel;

            int x;
            int y;

            if (bitmap == null)
            {
                return;
            }

            for(x = 0; x < bitmap.Size.Width; ++x)
            {
                //Look for the uppest pixel
                for(y = 0; y < bitmap.Size.Height; ++y)
                {
                    pixel = bitmap.GetPixel(x, y);

                    //The current pixel is set
                    if (set_pixel.R == pixel.R
                        && set_pixel.G == pixel.G
                        && set_pixel.B == pixel.B)
                    {
                        upper_pixel = new Point(x, y);
                        upper_line.Add(upper_pixel);
                        //Stop looking for more pixels
                        break;
                    }
                }
                //If no pixel was found, add a (x, 0) dummy pixel
                if (bitmap.Size.Height == y)
                {
                    upper_pixel = new Point(x, 0);
                    upper_line.Add(upper_pixel);
                }

                //Look for the lowest pixel
                for (y = (bitmap.Size.Height - 1); y >= 0; --y)
                {
                    pixel = bitmap.GetPixel(x, y);

                    //The current pixel is set
                    if (set_pixel.R == pixel.R
                        && set_pixel.G == pixel.G
                        && set_pixel.B == pixel.B)
                    {
                        lower_pixel = new Point(x, y);
                        lower_line.Add(lower_pixel);
                        //Stop looking for more pixels
                        break;
                    }
                }
                //If no pixel was found, add a (x, (bitmap.Size.Height - 1)) dummy pixel
                if (-1 == y)
                {
                    lower_pixel = new Point(x, (bitmap.Size.Height - 1));
                    lower_line.Add(lower_pixel);
                }

                //If both points are in the same location, the resulting pixel will be unmodified
                if (upper_pixel == lower_pixel)
                {
                    parsed_line.Add(upper_pixel);
                }
                else
                {
                    //The resulting pixel must be located between the upper and the lower lines
                    int middle_y = ((lower_pixel.Y - upper_pixel.Y) / 2) + upper_pixel.Y;
                    parsed_line.Add(new Point(x, middle_y));
                }
            }

            data_lines = new Data_Lines();
            data_lines.upper_line = upper_line;
            data_lines.parsed_line = parsed_line;
            data_lines.lower_line = lower_line;

            Normalize_Data_Lines(true);
        }

        public void Normalize_Data_Lines(Boolean invert_y)
        {
            //Find the minimum
            int min = data_lines.upper_line[0].Y;

            for (int i = 1; i < data_lines.upper_line.Count; ++i)
            {
                if (data_lines.upper_line[i].Y < min)
                {
                    min = data_lines.upper_line[i].Y;
                }
            }

            for (int i = 0; i < data_lines.parsed_line.Count; ++i)
            {
                if (data_lines.parsed_line[i].Y < min)
                {
                    min = data_lines.parsed_line[i].Y;
                }
            }

            for (int i = 0; i < data_lines.lower_line.Count; ++i)
            {
                if (data_lines.lower_line[i].Y < min)
                {
                    min = data_lines.lower_line[i].Y;
                }
            }

            //Find the maximum
            int max = data_lines.upper_line[0].Y;

            for (int i = 1; i < data_lines.upper_line.Count; ++i)
            {
                if (data_lines.upper_line[i].Y > max)
                {
                    max = data_lines.upper_line[i].Y;
                }
            }

            for (int i = 0; i < data_lines.parsed_line.Count; ++i)
            {
                if (data_lines.parsed_line[i].Y > max)
                {
                    max = data_lines.parsed_line[i].Y;
                }
            }

            for (int i = 0; i < data_lines.lower_line.Count; ++i)
            {
                if (data_lines.lower_line[i].Y > max)
                {
                    max = data_lines.lower_line[i].Y;
                }
            }

            normalized_lines.upper_line = new List<Double_Point>();
            normalized_lines.parsed_line = new List<Double_Point>();
            normalized_lines.lower_line = new List<Double_Point>();

            foreach(Point p in data_lines.upper_line)
            {
                Double_Point d_point = new Double_Point();
                d_point.X = p.X;
                d_point.Y = (Double)(p.Y - min) / (Double)(max - min);
                if (invert_y)
                {
                    d_point.Y *= -1D;
                }

                normalized_lines.upper_line.Add(d_point);                        
            }

            foreach (Point p in data_lines.parsed_line)
            {
                Double_Point d_point = new Double_Point();
                d_point.X = p.X;
                d_point.Y = (Double)(p.Y - min) / (Double)(max - min);
                if (invert_y)
                {
                    d_point.Y *= -1D;
                }

                normalized_lines.parsed_line.Add(d_point);
            }

            foreach (Point p in data_lines.lower_line)
            {
                Double_Point d_point = new Double_Point();
                d_point.X = p.X;
                d_point.Y = (Double)(p.Y - min) / (Double)(max - min);
                if (invert_y)
                {
                    d_point.Y *= -1D;
                }

                normalized_lines.lower_line.Add(d_point);
            }
        }

        public static String Create_Wav_8bit(Byte[] buffer, UInt32 sample_rate)
        {
            String result = "";
            WAVFile wav = new WAVFile();

            try
            {
                wav.Create("test.wav", false, (int)sample_rate, (short)8);
            }
            catch (Exception ex)
            {
                result = ex.Message;
                return result;
            }

            try
            {
                foreach (Byte b in buffer)
                {
                    wav.AddSample_8bit(b);
                }
            }
            catch (Exception ex)
            {
                result = ex.Message;
                return result;
            }

            wav.Close();

            return result;
        }

        /// <summary>
        /// Convert a normalized list of samples into an 8bit curve
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static Byte[] Convert_Double_To_8bit(List<Double_Point> list)
        {
            Byte[] output = new Byte[list.Count];
            for (int i = 0; i < list.Count; ++i)
            {
                output[i] = (Byte)((list[i].Y * 255D) + 255);
            }
            return output;
        }

        public static String Save_Pinta(Bitmap bitmap, String filename)
        {
            String result = "";

            try
            {
                if (File.Exists(filename))
                    File.Delete(filename);

                bitmap.Save(filename);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            return result;
        }
    }
}

/* ------------------------------------------------------------------------------
 * Revision Log
 * 
 * - 05-Apr-2014 Santiago Villafuerte Rev. 1
 *   + First release
 *   
 * --------------------------------------------------------------------------- */
