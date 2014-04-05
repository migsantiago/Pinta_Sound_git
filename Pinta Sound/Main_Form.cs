using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ZedGraph;
using System.IO;
using System.Diagnostics;
using System.Runtime.InteropServices;

using Microsoft.WindowsAPICodePack.Shell;

namespace Pinta_Sound
{
    public partial class Main_Form : GlassForm
    {
        //---------------------------------------------------------------------------------
        //Objects
        private Boolean Paint_Enabled = false;
        Point Old_Mouse_Pos = new Point(0, 0);

        Color Set_Color = Color.Black;
        Color Clear_Color = Color.White;
        Color Current_Color = Color.White;

        public struct Line_Points
        {
            public Point Old_Point;
            public Point New_Point;
        };
        List<Line_Points> Point_List = new List<Line_Points>();

        Preview_Form Preview = new Preview_Form();

        Play_Sound Play = new Play_Sound();

        //---------------------------------------------------------------------------------
        //Methods

        public Main_Form()
        {
            InitializeComponent();
        }

        public void CleanPinta()
        {
            //Initialize the bmp area
            Bitmap bmp = new Bitmap(pctPinta.Width, pctPinta.Height);
            for (int x = 0; x < bmp.Size.Width; ++x)
            {
                for (int y = 0; y < bmp.Size.Height; ++y)
                {
                    bmp.SetPixel(x, y, Clear_Color);
                }
            }
            pctPinta.Image = bmp;

            Point_List.Clear();
        }

        private void pctPinta_MouseUp(object sender, MouseEventArgs e)
        {
            Paint_Enabled = false;
        }

        private void pctPinta_MouseDown(object sender, MouseEventArgs e)
        {
            Paint_Enabled = true;
            Old_Mouse_Pos = new Point(e.X, e.Y);
        }

        private void pctPinta_MouseMove(object sender, MouseEventArgs e)
        {
            if (Paint_Enabled)
            {
                Point new_mouse_pos = new Point(e.X, e.Y);

                Draw_Line(Old_Mouse_Pos, new_mouse_pos, Current_Color);

                Line_Points line_p = new Line_Points()
                {
                    Old_Point = Old_Mouse_Pos,
                    New_Point = new_mouse_pos
                };

                Point_List.Add(line_p);
                Old_Mouse_Pos = new_mouse_pos;
            }
        }

        private void Set_Pixel(int x, int y, Color color)
        {
            Bitmap bmp = (Bitmap)pctPinta.Image;
            try
            {
                bmp.SetPixel(x, y, color);
            }
            catch
            {
                //The pixel was drawn outside the picture
            }
            pctPinta.Image = bmp;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            CleanPinta();
        }

        private void Parse_Image(Bitmap bitmap)
        {
            Bitmap bmp = (Bitmap)bitmap;

            Parse_Pinta parser = new Parse_Pinta();
            parser.Parse_Bitmap(bmp, Set_Color);

            Plot_Parsed_Lines(parser);

            //Create the byte array for the audio
            Byte[] buffer = Parse_Pinta.Convert_Double_To_8bit(parser.normalized_lines.parsed_line);

            UInt32 repeat_times;
            if (!UInt32.TryParse(txtRepeatWave.Text, out repeat_times))
            {
                MessageBox.Show("Repeat times must be a valid unsigned integer", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (0 == repeat_times)
            {
                MessageBox.Show("Repeat times was set to 0", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Byte[] output = new Byte[buffer.Length * repeat_times];
            int index = 0;
            while (repeat_times != 0)
            {
                --repeat_times;
                foreach (Byte b in buffer)
                {
                    output[index++] = b;
                }
            }

            UInt32 sample_rate;
            if (!UInt32.TryParse(cmbSampleFreq.Text, out sample_rate))
            {
                MessageBox.Show("Sample rate must be a valid unsigned integer", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (0 == sample_rate)
            {
                MessageBox.Show("Sample rate was set to 0", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            String result = Parse_Pinta.Create_Wav_8bit(output, sample_rate);
            if (result != "")
            {
                MessageBox.Show(result, "WAV Create", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
        }

        private void Plot_Parsed_Lines(Parse_Pinta parser)
        {
            PointPairList parsed_line = new PointPairList();
            PointPairList upper_line = new PointPairList();
            PointPairList lower_line = new PointPairList();

            foreach (Parse_Pinta.Double_Point p in parser.normalized_lines.parsed_line)
            {
                parsed_line.Add(p.X, p.Y);
            }

            foreach (Parse_Pinta.Double_Point p in parser.normalized_lines.upper_line)
            {
                upper_line.Add(p.X, p.Y);
            }

            foreach (Parse_Pinta.Double_Point p in parser.normalized_lines.lower_line)
            {
                lower_line.Add(p.X, p.Y);
            }

            zedParsedPlot.IsShowPointValues = true;
            // get a reference to the GraphPane
            GraphPane myPane = zedParsedPlot.GraphPane;
            myPane.CurveList.Clear();
            // Set the Titles
            myPane.Title.Text = "Parsed Audio Curves";
            myPane.XAxis.Title.Text = "Samples";
            myPane.YAxis.Title.Text = "Amplitude";

            LineItem parsed_plot = myPane.AddCurve("Parsed Plot", parsed_line, Color.Black, SymbolType.None);
            parsed_plot.Tag = 3;

            if (chkShowUpperLine.Checked)
            {
                LineItem upper_plot = myPane.AddCurve("Upper Plot", upper_line, Color.Yellow, SymbolType.None);
            }

            if (chkPlotLowerLine.Checked)
            {
                LineItem lower_plot = myPane.AddCurve("Lower Plot", lower_line, Color.Green, SymbolType.None);
            }

            myPane.YAxis.Scale.Min = -1.05D;
            myPane.YAxis.Scale.Max = 0.05D;

            zedParsedPlot.AxisChange();
            zedParsedPlot.Refresh();
        }

        private void Main_Form_Load(object sender, EventArgs e)
        {
            CleanPinta();

            //Initialize the buttons
            btnDraw.Enabled = false;
            btnErase.Enabled = true;
            Current_Color = Set_Color;

            cmbSampleFreq.SelectedIndex = 0;
        }

        //Draw a line in Black and white mode
        //Bresenham's line drawing algorithm
        //Parameters:
        //x1 -> x start
        //y1 -> y start
        //x2 -> x finish
        //y2 -> y finish
        //value -> color to draw
        private void Draw_Line(
             int x1,
             int y1,
             int x2,
             int y2,
             Color value)
        {
            int x, y, addx, addy, dx, dy;
            long P;
            int i;
            dx = Math.Abs((int)(x2 - x1));
            dy = Math.Abs((int)(y2 - y1));
            x = x1;
            y = y1;

            if (x1 > x2)
                addx = -1;
            else
                addx = 1;
            if (y1 > y2)
                addy = -1;
            else
                addy = 1;

            if (dx >= dy)
            {
                P = (2 * dy) - dx;

                for (i = 0; i <= dx; ++i)
                {
                    Set_Pixel(x, y, value);

                    if (P < 0)
                    {
                        P += (2 * dy);
                        x += addx;
                    }
                    else
                    {
                        P += (2 * dy) - (2 * dx);
                        x += addx;
                        y += addy;
                    }
                }
            }
            else
            {
                P = (2 * dx) - dy;

                for (i = 0; i <= dy; ++i)
                {
                    Set_Pixel(x, y, value);

                    if (P < 0)
                    {
                        P += (2 * dx);
                        y += addy;
                    }
                    else
                    {
                        P += (2 * dx) - (2 * dy);
                        x += addx;
                        y += addy;
                    }
                }
            }
        }

        private void Draw_Line(Point start, Point end, Color value)
        {
            Draw_Line(start.X, start.Y, end.X, end.Y, value);
        }

        private void btnDraw_Click(object sender, EventArgs e)
        {
            btnDraw.Enabled = false;
            btnErase.Enabled = true;
            Current_Color = Set_Color;
        }

        private void btnErase_Click(object sender, EventArgs e)
        {
            btnDraw.Enabled = true;
            btnErase.Enabled = false;
            Current_Color = Clear_Color;
        }

        private void btnSavePinta_Click(object sender, EventArgs e)
        {
            saveFileDialog1.AddExtension = true;
            saveFileDialog1.DefaultExt = ".bmp";
            saveFileDialog1.FileName = "*.bmp";
            saveFileDialog1.Filter = "Bitmap image (*.bmp)|*.bmp";
            DialogResult res = saveFileDialog1.ShowDialog();

            if (res != DialogResult.OK)
            {
                return;
            }

            String result = Parse_Pinta.Save_Pinta((Bitmap)pctPinta.Image, saveFileDialog1.FileName);
            if (result != "")
            {
                MessageBox.Show(result);
            }
        }

        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool GetWindowPlacement(IntPtr hWnd, ref WINDOWPLACEMENT lpwndpl);

        private struct WINDOWPLACEMENT
        {
            public int length;
            public int flags;
            public int showCmd;
            public System.Drawing.Point ptMinPosition;
            public System.Drawing.Point ptMaxPosition;
            public System.Drawing.Rectangle rcNormalPosition;
        }

        private void RestoreFromMinimized(Form form)
        {
            const int WPF_RESTORETOMAXIMIZED = 0x2;
            WINDOWPLACEMENT placement = new WINDOWPLACEMENT();
            placement.length = Marshal.SizeOf(placement);
            GetWindowPlacement(form.Handle, ref placement);

            if ((placement.flags & WPF_RESTORETOMAXIMIZED) == WPF_RESTORETOMAXIMIZED)
                form.WindowState = FormWindowState.Maximized;
            else
                form.WindowState = FormWindowState.Normal;
        }

        private void btnLoadPinta_Click(object sender, EventArgs e)
        {
            openDlgPreview.Filter = "Bitmap|*.bmp";
            openDlgPreview.Title = "Open a Pinta...";

            DialogResult res = openDlgPreview.ShowDialog();

            if (res != DialogResult.OK)
            {
                return;
            }

            if (File.Exists(openDlgPreview.FileName))
            {
                if (Image.FromFile(openDlgPreview.FileName).Size != pctPinta.Size)
                {
                    MessageBox.Show("The loaded Pinta does not match the Pinta canvas\n"
                        + " (Width " + pctPinta.Size.Width + " Height " + pctPinta.Size.Height + ")",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                pctPinta.Image = Image.FromFile(openDlgPreview.FileName);
            }
        }

        private void btnLoadImage_Click(object sender, EventArgs e)
        {
            openDlgPreview.Filter = "All files|*.*|Bitmap|*.bmp|JPEG|*.jpeg|JPG|*.jpg|PNG|*.png";
            openDlgPreview.Title = "Open an image...";

            DialogResult res = openDlgPreview.ShowDialog();

            if (res != DialogResult.OK)
            {
                return;
            }

            if (File.Exists(openDlgPreview.FileName))
            {
                if (Preview == null)
                {
                    Preview = new Preview_Form();
                }

                Preview.pctPreviewImage.Image = Image.FromFile(openDlgPreview.FileName);
                if (Preview.WindowState == FormWindowState.Minimized)
                {
                    RestoreFromMinimized(Preview);
                }
                Preview.Show();

                btnParseImage.Enabled = true;
            }
        }

        private void btnParsePinta_Click(object sender, EventArgs e)
        {
            Parse_Image((Bitmap)pctPinta.Image);
        }

        private void btnParseImage_Click(object sender, EventArgs e)
        {
            Parse_Image((Bitmap)Preview.pctPreviewImage.Image);
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            Play.Stop_Wav();
            Play = new Play_Sound();
            Play.Play_Wav("test.wav");
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
