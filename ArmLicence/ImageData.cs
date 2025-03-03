
using OpenCvSharp;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace ArmLicence
{
    public class ImageData
    {

        public byte[] RemoveBackground(byte[] imageBytes)
        {
            using (MemoryStream ms = new MemoryStream(imageBytes))
            {
                // Load the image from the byte array
                Bitmap bitmap = new Bitmap(ms);

                // Convert Bitmap to Mat
                Mat src = BitmapToMat(bitmap);

                // Create initial mask
                Mat mask = new Mat(src.Size(), MatType.CV_8UC1, Scalar.All((byte)GrabCutClasses.PR_BGD));

                // Define a rectangle containing the foreground object
                Rect rect = new Rect(10, 10, src.Width - 20, src.Height - 20);

                // Background and foreground models (empty)
                Mat bgdModel = new Mat();
                Mat fgdModel = new Mat();

                // Apply GrabCut algorithm
                Cv2.GrabCut(src, mask, rect, bgdModel, fgdModel, 5, GrabCutModes.InitWithRect);

                // Create a mask where definite and probable foreground are set to 1, and background is set to 0
                Mat fgMask = new Mat();
                Cv2.Compare(mask, new Scalar((byte)GrabCutClasses.FGD), fgMask, CmpType.EQ);
                Mat prFgMask = new Mat();
                Cv2.Compare(mask, new Scalar((byte)GrabCutClasses.PR_FGD), prFgMask, CmpType.EQ);
                Cv2.BitwiseOr(fgMask, prFgMask, mask);

                // Create a 4-channel image for the result (RGBA)
                Mat result = new Mat(src.Size(), MatType.CV_8UC4);

                // Copy source image to result image, setting alpha channel based on the mask
                for (int y = 0; y < src.Rows; y++)
                {
                    for (int x = 0; x < src.Cols; x++)
                    {
                        Vec3b color = src.At<Vec3b>(y, x);
                        byte alpha = (mask.At<byte>(y, x) == 0) ? (byte)0 : (byte)255;
                        result.Set(y, x, new Vec4b(color.Item0, color.Item1, color.Item2, alpha));
                    }
                }

                // Convert Mat back to Bitmap
                Bitmap resultBitmap = MatToBitmap(result);

                // Convert the result Bitmap to a byte array
                using (MemoryStream resultStream = new MemoryStream())
                {
                    resultBitmap.Save(resultStream, ImageFormat.Png);
                    return resultStream.ToArray();
                }
            }
        }

        private Mat BitmapToMat(Bitmap bitmap)
        {
            Mat mat = new Mat(bitmap.Height, bitmap.Width, MatType.CV_8UC3);
            for (int y = 0; y < bitmap.Height; y++)
            {
                for (int x = 0; x < bitmap.Width; x++)
                {
                    System.Drawing.Color color = bitmap.GetPixel(x, y);
                    mat.Set(y, x, new Vec3b(color.B, color.G, color.R));
                }
            }
            return mat;
        }

        private Bitmap MatToBitmap(Mat mat)
        {
            Bitmap bitmap = new Bitmap(mat.Width, mat.Height, PixelFormat.Format32bppArgb);
            for (int y = 0; y < mat.Height; y++)
            {
                for (int x = 0; x < mat.Width; x++)
                {
                    Vec4b color = mat.Get<Vec4b>(y, x);
                    bitmap.SetPixel(x, y, Color.FromArgb(color.Item3, color.Item2, color.Item1, color.Item0));
                }
            }
            return bitmap;
        }
    }
}