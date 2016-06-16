using System;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;

public partial class Assistant_ValidationCode : System.Web.UI.Page
{
  // ******************************************************************************************************
  private string pRandomCode;
  // ******************************************************************************************************
  protected void Page_Load(object sender, EventArgs e)
  {
    Random rnd = new Random();
    pRandomCode = rnd.Next(1000,9999).ToString();
    Session["ValidationCode"] = pRandomCode;

    int iWidth = (int)(pRandomCode.Length * 11.5);
    int iHeight = 20;
    Bitmap image = new Bitmap(iWidth, iHeight);
    Graphics g = Graphics.FromImage(image);
    Font f = new Font("Georgia", 12, FontStyle.Bold|FontStyle.Italic);
    Brush b = new SolidBrush(Color.Black);
    g.Clear(Color.White);
    Pen penForeground = new Pen(Color.FromArgb(0xb5,0xc8,0xd7));
    for (int i = 0; i < 15; i++)
    {
      int randomY = rnd.Next(iHeight);
      g.DrawLine(penForeground, 0, randomY, iWidth, randomY);
    }
    g.DrawString(pRandomCode, f, b, 1, 0);
    Pen penBackground = new Pen(Color.FromArgb(0x33, 0x66, 0x99));
    for (int i = 0; i < 200; i++)
    {
      g.DrawPie(penBackground, rnd.Next(iWidth), rnd.Next(iHeight), 1, 1, 20, 1);
    }
    MemoryStream ms = new MemoryStream();
    image.Save(ms, ImageFormat.Jpeg);
    Response.ClearContent();
    Response.ContentType = "image/Jpeg";
    Response.BinaryWrite(ms.ToArray());
    g.Dispose();
    image.Dispose();
  }
  // ******************************************************************************************************
}