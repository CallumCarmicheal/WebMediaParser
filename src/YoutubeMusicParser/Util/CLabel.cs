using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace YoutubeMusicParser.Util {
    public class CLabel : Label {
        protected override CreateParams CreateParams { get { CreateParams parms = base.CreateParams; parms.ExStyle |= 0x20; return parms; } }

        public CLabel() {
            this.SetStyle(ControlStyles.Opaque, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, false);
        }

        protected override void OnPaintBackground(PaintEventArgs e) {
            // null
        }

        GraphicsPath GetStringPath(RectangleF rect, StringFormat format) {
            GraphicsPath Path = new GraphicsPath();

            Path.AddString(this.Text, this.Font.FontFamily, (int)Font.Style, this.Font.Size, rect, format);
            return Path;
        }

        protected override void OnPaint(PaintEventArgs e) {
            RectangleF rect = this.ClientRectangle;
            Font font = this.Font;
            StringFormat format = StringFormat.GenericDefault;

            using (GraphicsPath path = GetStringPath(rect, format)) {
                SmoothingMode sm = e.Graphics.SmoothingMode;
                e.Graphics.SmoothingMode = SmoothingMode.None;

                Brush b = new SolidBrush(Color.Black);
                e.Graphics.FillPath(b, path);
                e.Graphics.DrawPath(Pens.Black, path);

                b.Dispose();
            }
        }
    }
}
