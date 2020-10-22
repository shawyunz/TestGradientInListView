using CoreGraphics;
using System;
using System.ComponentModel;
using System.Drawing;
using TestGradientInListView;
using TestGradientInListView.iOS;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(GradientLabel), typeof(GradientLabelRenderer))]

namespace TestGradientInListView.iOS
{
    public class GradientLabelRenderer : LabelRenderer
    {
        public override void Draw(CGRect rect)
        {
            base.Draw(rect);

            if (Control != null)
            {
                SetTextColor();
            }
        }
        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);
            SetTextColor();
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            SetTextColor();
        }

        private UIImage GetGradientImage(CGSize size)
        {
            UIGraphics.BeginImageContextWithOptions(size, false, 0);

            var context = UIGraphics.GetCurrentContext();
            if (context == null)
            {
                return null;
            }

            context.SetFillColor(UIColor.Blue.CGColor);
            context.FillRect(new RectangleF(new PointF(0, 0), new SizeF((float)size.Width, (float)size.Height)));

            var c1 = (Element as GradientLabel).ColorLeft.ToCGColor();
            var c2 = (Element as GradientLabel).ColorRight.ToCGColor();
            var colorspace = CGColorSpace.CreateDeviceRGB();
            var gradient = new CGGradient(colorspace, new CGColor[] { c1, c2 }, new nfloat[] { 0f, 1f });

            var left = new CGPoint(0, 0);
            var right = new CGPoint(size.Width, 0);
            context.DrawLinearGradient(gradient, left, right, CGGradientDrawingOptions.DrawsAfterEndLocation);

            var img = UIGraphics.GetImageFromCurrentImageContext();
            UIGraphics.EndImageContext();
            return img;
        }

        private void SetTextColor()
        {
            var image = GetGradientImage(Control.Frame.Size);
            if (image != null)
            {
                Control.TextColor = UIColor.FromPatternImage(image);
            }
        }
    }
}