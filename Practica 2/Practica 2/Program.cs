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

        void ProgramStarted()
        {
            
            camera.CameraConnected += camera_CameraConnected;
            camera.BitmapStreamed += camera_BitmapStreamed;


            // Use Debug.Print to show messages in Visual Studio's "Output" window during debugging.
            Debug.Print("Program Started");
            
        }

        void camera_BitmapStreamed(Camera sender, Bitmap e)
        {
            displayT35.SimpleGraphics.DisplayImage(e, 0, 0);
        }

        void camera_CameraConnected(Camera sender, EventArgs e)
        {
            camera.StartStreaming();
        }


        void button_press(Button sender, Button.ButtonState state){
            camera.TakePicture();

        }
    }
}
