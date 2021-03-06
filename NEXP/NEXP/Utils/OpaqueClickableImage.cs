﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace NEXP.Utils
{
    public class OpaqueClickableImage : Image
    {
        protected override HitTestResult HitTestCore(PointHitTestParameters hitTestParameters)
        {
            var source = (BitmapSource)Source;
            /*
            Log.getLogInstance().writeLog("source.PixelWidth:" + source.PixelWidth);
            Log.getLogInstance().writeLog("source.PixelHeight:" + source.PixelHeight);
            Log.getLogInstance().writeLog("hitTestParameters.HitPoint.X:" + hitTestParameters.HitPoint.X);
            Log.getLogInstance().writeLog("hitTestParameters.HitPoint.Y:" + hitTestParameters.HitPoint.Y);
            Log.getLogInstance().writeLog("ActualWidth:" + ActualWidth);
            Log.getLogInstance().writeLog("ActualHeight:" + ActualHeight);
             * */
            // Get the pixel of the source that was hit
            var x = (int)(hitTestParameters.HitPoint.X / ActualWidth * source.PixelWidth);
            var y = (int)(hitTestParameters.HitPoint.Y / ActualHeight * source.PixelHeight);

            // Copy the single pixel into a new byte array representing RGBA
            var pixel = new byte[4];

            try
            {
                source.CopyPixels(new Int32Rect(x, y, 1, 1), pixel, 4, 0);
            }
            catch(ArgumentException)
            {
              return null;
            }
            


            // Check the alpha (transparency) of the pixel
            // - threshold can be adjusted from 0 to 255
            if (pixel[3] < 10)
                return null;

            return new PointHitTestResult(this, hitTestParameters.HitPoint);
        }

        protected override GeometryHitTestResult HitTestCore(GeometryHitTestParameters hitTestParameters)
        {
            // Do something similar here, possibly checking every pixel within
            // the hitTestParameters.HitGeometry.Bounds rectangle
            return base.HitTestCore(hitTestParameters);
        }
    }
}
