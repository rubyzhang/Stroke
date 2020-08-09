﻿using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Stroke.Configure
{
    public partial class GestureConfigure : Form
    {
        int index = -1;
        ContextMenuStrip ContextMenuStripGesture;

        public GestureConfigure()
        {
            InitializeComponent();

            foreach (Gesture gesture in Settings.Gestures)
            {
                listViewGesture.Items.Add(gesture.Name);
            }

            ContextMenuStripGesture = new ContextMenuStrip();
            ToolStripMenuItem ToolStripMenuItemAddGesture = new ToolStripMenuItem();
            ToolStripMenuItem ToolStripMenuItemRemoveGesture = new ToolStripMenuItem();
            ToolStripMenuItemAddGesture.Text = "添加 [手势]";
            ToolStripMenuItemRemoveGesture.Text = "删除 [手势]";
            ContextMenuStripGesture.Items.Add(ToolStripMenuItemAddGesture);
            ContextMenuStripGesture.Items.Add(ToolStripMenuItemRemoveGesture);
            ToolStripMenuItemAddGesture.Click += ToolStripMenuItemAddGesture_Click;
            ToolStripMenuItemRemoveGesture.Click += ToolStripMenuItemRemoveGesture_Click;
        }

        private void DrawGesture()
        {
            if (Settings.Gestures[index].Vectors != null)
            {
                PointF[] points = new PointF[128];
                for (int i = 1; i < 128; i++)
                {
                    points[i].X += points[i - 1].X + Settings.Gestures[index].Vectors[i].X / 40f;
                    points[i].Y += points[i - 1].Y + Settings.Gestures[index].Vectors[i].Y / 40f;
                }
                float MinX = points.Min(p => p.X), MinY = points.Min(p => p.Y), MaxX = points.Max(p => p.X), MaxY = points.Max(p => p.Y);
                int thickness = 6;
                for (int i = 0; i < 128; i++)
                {
                    points[i].X = points[i].X + thickness * 3 - MinX;
                    points[i].Y = points[i].Y + thickness * 3 - MinY;
                }
                Bitmap bitmap = new Bitmap((int)(MaxX - MinX) + thickness * 6 + 1, (int)(MaxY - MinY) + thickness * 6 + 1);
                Graphics graphics = Graphics.FromImage(bitmap);
                graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                System.Drawing.Pen pen = new System.Drawing.Pen(Color.FromArgb(31, 127, 255), thickness * 2);
                pen.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
                graphics.DrawLines(pen, points);
                graphics.Dispose();
                pictureBoxGesture.BackgroundImage = bitmap;
            }
            else
            {
                Bitmap bitmap = new Bitmap(1, 1);
                pictureBoxGesture.BackgroundImage = bitmap;
            }
        }

        private void listViewGesture_MouseClick(object sender, MouseEventArgs e)
        {
            listViewGesture.HitTest(e.Location).Item.Selected = true;
            if (e.Button == MouseButtons.Right)
            {
                ContextMenuStripGesture.Show(Control.MousePosition);
            }
        }

        private void listViewGesture_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewGesture.SelectedItems.Count != 0)
            {
                index = listViewGesture.SelectedItems[0].Index;
                textBoxName.Text = Settings.Gestures[index].Name;
                DrawGesture();
            }
        }

        private void textBoxName_TextChanged(object sender, EventArgs e)
        {
            textBoxName.Text = textBoxName.Text.TrimStart('#');
            if (index != -1)
            {
                listViewGesture.Items[index].Text = textBoxName.Text;
                Settings.Gestures[index].Name = textBoxName.Text;
            }

        }

        private void pictureBoxGesture_Click(object sender, EventArgs e)
        {
            if (index != -1)
            {
                GestureCanvas GestureCanvas = new GestureCanvas(Settings.Gestures[index]);
                GestureCanvas.ShowDialog();
                DrawGesture();
            }
        }

        private void ToolStripMenuItemAddGesture_Click(object sender, EventArgs e)
        {
            index += 1;
            Settings.Gestures.Insert(index, new Gesture(""));
            listViewGesture.Items.Clear();
            foreach (Gesture gesture in Settings.Gestures)
            {
                listViewGesture.Items.Add(gesture.Name);
            }
            listViewGesture.Items[index].Selected = true;
            textBoxName.Select();
        }

        private void ToolStripMenuItemRemoveGesture_Click(object sender, EventArgs e)
        {
            Settings.Gestures.Remove(Settings.Gestures[index]);
            listViewGesture.Items.Clear();
            foreach (Gesture gesture in Settings.Gestures)
            {
                listViewGesture.Items.Add(gesture.Name);
            }
            if (index < listViewGesture.Items.Count)
            {
                listViewGesture.Items[index].Selected = true;
            }
            if (listViewGesture.Items.Count == 0)
            {
                index = -1;
                ToolStripMenuItemAddGesture_Click(null, new EventArgs());
            }

        }
    }
}
