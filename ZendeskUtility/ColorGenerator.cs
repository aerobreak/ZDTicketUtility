using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using Timer = System.Threading.Timer;

namespace ZendeskUtility
{
    public class ColorGenerator
    {
        private static Timer timer = new Timer(TimerCallback, null, 0, Timeout.Infinite); // Change the interval as needed;
        private static List<Form> targets = new List<Form>();
        private static Boolean enabled = false;
        public void StartTimer()
        {
            timer.Change(0, 33);
            enabled = true;
        }
        public void StopTimer()
        {
            timer.Change(0, Timeout.Infinite);
            enabled = false;
        }


        private static void TimerCallback(object state)
        {
            if (enabled)
            {

                NextColor();
                Console.WriteLine($"R: {Globals.RedColor}, G: {Globals.GreenColor}, B: {Globals.BlueColor}");
                foreach (Form target in targets)
                {
                    target.ForeColor = Color.FromArgb(255, Globals.RedColor, Globals.GreenColor, Globals.BlueColor);

                }
            }
            else
            {
                foreach(Form target in targets)
                {
                    target.ForeColor = Color.FromArgb(255, 0, 0, 0);
                }
            }
        }

        private static void NextColor()
        {
            //1: red 0-255
            //2: red 255, green 0-255
            //3: green 255, red 255-0
            //4: green 255, blue 0-255
            //5: blue 255, green 255-0
            //6: blue 255, red 0-255
            //7: red 255, blue 255-0
            //go to mode 2
            switch (Globals.ColorMode)
            {
                //0-255,0,0
                case 1:
                    if (Globals.RedColor < 255)
                    {
                        Globals.RedColor += Globals.ColorIncrement;
                        Globals.RedColor = Globals.RedColor > 255 ? 255 : Globals.RedColor;

                    }
                    else
                    {
                        Globals.ColorMode = 2;
                    }
                    break;
                //255,0-255,0
                case 2:
                    if (Globals.GreenColor < 255)
                    {
                        Globals.GreenColor += Globals.ColorIncrement;
                        Globals.GreenColor = Globals.GreenColor > 255 ? 255 : Globals.GreenColor;
                    }
                    else
                    {
                        Globals.ColorMode = 3;
                    }
                    break;
                //255-0,255,0
                case 3:
                    if (Globals.RedColor > 0)
                    {
                        Globals.RedColor -= Globals.ColorIncrement;
                        Globals.RedColor = Globals.RedColor < 0 ? 0 : Globals.RedColor;

                    }
                    else
                    {
                        Globals.ColorMode = 4;
                    }
                    break;
                //0,255,0-255
                case 4:
                    if (Globals.BlueColor < 255)
                    {
                        Globals.BlueColor += Globals.ColorIncrement;
                        Globals.BlueColor = Globals.BlueColor > 255 ? 255 : Globals.BlueColor;
                    }
                    else
                    {
                        Globals.ColorMode = 5;
                    }
                    break;
                //0,255-0,255
                case 5:
                    if (Globals.GreenColor > 0)
                    {
                        Globals.GreenColor -= Globals.ColorIncrement;
                        Globals.GreenColor = Globals.GreenColor < 0 ? 0 : Globals.GreenColor;
                    }
                    else
                    {
                        Globals.ColorMode = 6;
                    }
                    break;
                //0-255,0,255
                case 6:
                    if (Globals.RedColor < 255)
                    {
                        Globals.RedColor += Globals.ColorIncrement;
                        Globals.RedColor = Globals.RedColor > 255 ? 255 : Globals.RedColor;
                    }
                    else
                    {
                        Globals.ColorMode = 7;
                    }
                    break;
                //255,0,255-0
                case 7:
                    if (Globals.BlueColor > 0)
                    {
                        Globals.BlueColor -= Globals.ColorIncrement;
                        Globals.BlueColor = Globals.BlueColor < 0 ? 0 : Globals.BlueColor;
                    }
                    else
                    {
                        //255,0,0
                        Globals.ColorMode = 2; // Transition back to mode 2 after mode 7
                    }
                    break;
                default:
                    // Handle the default case or any additional cases
                    break;
            }
        }

        internal static void addTarget(Form f)
        {
            targets.Add(f);
        }

    }


}
