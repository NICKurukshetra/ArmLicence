using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;
using System.Web;
using System.Web.UI;

namespace ArmLicence
{
    public partial class CreateCaptcha : System.Web.UI.Page
    {
        private string code;
        private Random rand = new Random();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
    {
        Bitmap captchaImage = CreateCaptchaImage();
        Response.ContentType = "image/gif";
        captchaImage.Save(Response.OutputStream, ImageFormat.Gif);
        captchaImage.Dispose();
    }
        }

        /// <summary>
        /// Method for creating a captcha image
        /// </summary>
        private Bitmap CreateCaptchaImage()
        {
            code = GetRandomText();
            Bitmap bitmap = new Bitmap(200, 60, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            Graphics g = Graphics.FromImage(bitmap);
            Pen pen = new Pen(Color.Yellow);
            Rectangle rect = new Rectangle(0, 0, 200, 60);
            SolidBrush blue = new SolidBrush(Color.CornflowerBlue);
            SolidBrush black = new SolidBrush(Color.Black);
            int counter = 0;
            g.DrawRectangle(pen, rect);
            g.FillRectangle(blue, rect);

            for (int i = 0; i < code.Length; i++)
            {
                g.DrawString(code[i].ToString(), new Font("Tahoma", 10 + rand.Next(15, 20), FontStyle.Italic), black, new PointF(10 + counter, 10));
                counter += 28;
            }

            DrawRandomLines(g);

            return bitmap;
        }


        /// <summary>
        /// Method for drawing lines
        /// </summary>
        /// <param name="g"></param>
        private void DrawRandomLines(Graphics g)
        {
            SolidBrush yellow = new SolidBrush(Color.Yellow);
            for (int i = 0; i < 20; i++)
            {
                g.DrawLines(new Pen(yellow, 1), GetRandomPoints());
            }
        }

        /// <summary>
        /// Method for getting random point positions
        /// </summary>
        /// <returns></returns>
        private Point[] GetRandomPoints()
        {
            Point[] points = { new Point(rand.Next(0, 150), rand.Next(1, 150)), new Point(rand.Next(0, 200), rand.Next(1, 190)) };
            return points;
        }

        /// <summary>
        /// Method for generating random text of 5 characters as captcha code
        /// </summary>
        /// <returns></returns>
        private string GetRandomText()
        {
            StringBuilder randomText = new StringBuilder();
            string alphabets = "0123456789ACEFGHKLMNPRSWXZabcdefghijkhlmnopqrstuvwxyz";
            for (int j = 0; j < 5; j++)
            {
                randomText.Append(alphabets[rand.Next(alphabets.Length)]);
            }
            Session["CaptchaCode"] = randomText.ToString();
            return Session["CaptchaCode"] as string;
        }
    }
}
