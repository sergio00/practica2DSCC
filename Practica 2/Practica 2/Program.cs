using System;
using System.Collections;
using System.Threading;
using Microsoft.SPOT;
using Microsoft.SPOT.Presentation;
using Microsoft.SPOT.Presentation.Controls;
using Microsoft.SPOT.Presentation.Media;
using Microsoft.SPOT.Presentation.Shapes;
using Microsoft.SPOT.Touch;

using Gadgeteer.Networking;
using GT = Gadgeteer;
using GTM = Gadgeteer.Modules;
using Gadgeteer.Modules.GHIElectronics;

namespace Practica_2
{
    public partial class Program
    {
        String filename = "foto.bmp";
        GT.Timer timer = new GT.Timer(1500,GT.Timer.BehaviorType.RunOnce); 

        void ProgramStarted()
        {
            timer.Tick += timer_Tick;
            
            camera.CameraConnected += camera_CameraConnected;
            camera.BitmapStreamed += camera_BitmapStreamed;
            button.ButtonPressed += button_ButtonPressed;
            camera.PictureCaptured += camera_PictureCaptured;
            sdCard.Mounted += sdCard_Mounted;
           
            

            Debug.Print("Program Started");
            
        }
        bool state = false;
        void timer_Tick(GT.Timer timer)
        {
            camera.StartStreaming();
        }

        void sdCard_Mounted(SDCard sender, GT.StorageDevice device)
        {
            Debug.Print("MEMORY pERFECT");

        }

        void button_ButtonPressed(Button sender, Button.ButtonState state)
        {
            camera.StopStreaming();
            camera.TakePicture();
        }

        void camera_PictureCaptured(Camera sender, GT.Picture e)
        {
            if (e == null)
            {
                button.Mode = Button.LedMode.Off;
            }
            else
            {
                try
                {
                    button.Mode = Button.LedMode.On;
                    sdCard.StorageDevice.WriteFile(filename, e.PictureData);
                    
                }catch(Exception ex){
                    Debug.Print("Error "+ex.ToString());
                }
                
            }
            button.Mode = Button.LedMode.Off;
            timer.Start(); // Start the timer
        }

        void camera_BitmapStreamed(Camera sender, Bitmap e)
        {
            displayT35.SimpleGraphics.DisplayImage(e, 0, 0);
        }

        void camera_CameraConnected(Camera sender, EventArgs e)
        {
            Debug.Print("CAMARA CONECTADA");
            camera.StartStreaming();
        }



    }
}
