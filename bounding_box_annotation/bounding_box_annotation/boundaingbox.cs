using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Drawing.Drawing2D;

namespace bounding_box_annotation
{
    public partial class boundaingbox : UserControl
    {
        public boundaingbox()
        {
            InitializeComponent();

            list_bbs = new List<BoundingBox>();
            ptStart = ptEnd = Point.Empty;
            selected_bb_index = current_bb_index = -1;
            scale = 1;
            bmp_canvas = null;
            imageLocation = "";
            imageRect = RectangleF.Empty;
            penBB = new Pen(new SolidBrush(Color.Purple), 2);            
            penGuidLine = new Pen(new SolidBrush(Color.FromArgb(200, 127, 127, 127)), 1);
            penMouseGuid = new Pen(new SolidBrush(penBB.Color), 1);
            this.show_mouse_guid = true;
            this.showArros = true;
            listRecentLabels = new List<string>();

            drawingState = DrawingState.None;

            vScroll = new VScrollBar();
            vScroll.Dock = DockStyle.Right;
            vScroll.SmallChange = 1;
            hScroll = new HScrollBar();
            hScroll.Dock = DockStyle.Bottom;
            hScroll.SmallChange = 1;
            SplitContainer splitContainer = new SplitContainer();
            splitContainer.Dock = DockStyle.Bottom;
            splitContainer.Height = 40;

            
            vScroll.Scroll += new ScrollEventHandler(vScroll_Scroll);
            hScroll.Scroll += new ScrollEventHandler(hScroll_Scroll);
            
            this.Controls.Add(vScroll);
            this.Controls.Add(hScroll);
                       

            vScroll.Maximum = vScroll.Minimum = 0;
            hScroll.Maximum = hScroll.Minimum = 0;
        }

        void hScroll_Scroll(object sender, ScrollEventArgs e)
        {
            imageRect.X -= e.NewValue - e.OldValue;
            this.Refresh();
        }

        void vScroll_Scroll(object sender, ScrollEventArgs e)
        {
            imageRect.Y -= e.NewValue-e.OldValue;
            this.Refresh();
        }

        private enum DrawingState
        {
            DrawBoundingBox,
            InflateBoundingBoxLeft,
            InflateBoundingBoxRight,
            InflateBoundingBoxUp,
            InflateBoundingBoxDown,  
            InflateBounfingUpRight,
            InflateBounfingUpLeft,
            InflateBounfingDownRight,
            InflateBounfingDownLeft,
            MoveImage,
            MoveBoundingBox,
            None,

        };

        // Variables
        VScrollBar vScroll;
        HScrollBar hScroll;
        List<BoundingBox> list_bbs;
        PointF ptStart, ptEnd, ptMouseLocation;
        int selected_bb_index, current_bb_index;
        string imageLocation;
        Bitmap bmp_canvas;
        float scale;
        Pen penBB, penGuidLine, penMouseGuid;
        RectangleF imageRect;
        BoundingBox bb;
        DrawingState drawingState;
        bool is_ctrl_down;
        bool show_mouse_guid;
        bool showArros;
        List<string> listRecentLabels;

        public delegate void ScaleEventHandler(object sender, float scale);

        public event ScaleEventHandler ScaleChanged;

        #region Properties
        [Description("Show arrows on bounding boxes")]
        public bool ShowArrows
        {
            get
            {
                return this.showArros;
            }
            set
            {
                this.showArros = value;
                this.Refresh();
            }
        }

        [Description("Show guid in location os mouse")]
        public bool ShowMouseGuid
        {
            get
            {
                return this.show_mouse_guid;
            }
            set
            {
                this.show_mouse_guid = value;
                this.Refresh();
            }
        }

        public List<BoundingBox> Items
        {
            get
            {
                return this.list_bbs;
            }
        }
       
        public float BoundingBoxPenWidth
        {
            get
            {
                return penBB.Width;
            }
            set
            {
                
                this.penBB.Width = value;
                this.Refresh();
            }
        }

        public Color BoundingBoxPenColor
        {
            get
            {
                return this.penBB.Color;
            }
            set
            {
                this.penBB.Color = value;
                this.penMouseGuid.Color = value;
                this.Refresh();
            }
        }

        public byte BoundingBoxTransparency
        {
            get {
                return this.penBB.Color.A;
            }
            set {
                this.penBB.Color = Color.FromArgb(value, this.penBB.Color);
                this.Refresh();
            }
        }
       
        public string ImageLocation
        {
            get { return this.imageLocation; }
            set
            {

                if (System.IO.File.Exists(value))
                {
                    this.imageLocation = value;

                    using (System.IO.FileStream fs = new System.IO.FileStream(this.imageLocation, System.IO.FileMode.Open))
                    {
                        bmp_canvas = (Bitmap)Bitmap.FromStream(fs);
                    }
                    UpdateImageAndClearCrop();
                }
            }
        }
        
        public Bitmap Bitmap
        {
            get { return this.bmp_canvas; }
            set
            {
                this.bmp_canvas = value;
                UpdateImageAndClearCrop();
            }
        }

        public float Scale
        {
            get
            {
                return this.scale;
            }
            set
            {
                this.scale = value;
                UpdateImage();
                if (ScaleChanged != null)
                {                    
                    ScaleChanged(this, this.scale);
                }
            }
        }
        #endregion

        private void UpdateRecentLabels(string label)
        {
            if (label.Trim().Length == 0)
            {
                return;
            }

            listRecentLabels.Insert(0, label);
            for (int i = 1; i < listRecentLabels.Count; i++)
            {
                if (label.Trim()  == listRecentLabels[i].Trim())
                {
                    listRecentLabels.RemoveAt(i);                                       
                    break;
                }
            }            
        }

        public void RemoveSelected()
        {
            if (selected_bb_index >= 0)
            {
                list_bbs.RemoveAt(selected_bb_index);
                selected_bb_index = -1;
                current_bb_index = -1;
                this.Refresh();
            }
        }

        public void MoveImageToCenter()
        {
            imageRect.X = (this.Width - imageRect.Width) / 2;
            imageRect.Y = (this.Height - imageRect.Height) / 2;
            this.Refresh();
        }

        public void Clear()
        {
            list_bbs.Clear();
            current_bb_index = selected_bb_index = -1;
            bb.IsEmpty = true;
            this.Refresh();
        }

        private void CorrectBoundingBoxes()
        {
            RectangleF temp_Rect = new RectangleF(imageRect.X / scale, imageRect.Y / scale, imageRect.Width / scale, imageRect.Height / scale);
            if (!bb.BB.IsEmpty)
            {
                
                bb = bb.Clip(temp_Rect);                
            }
            for(int i=0;i<list_bbs.Count;i++)
            {
                list_bbs[i] = list_bbs[i].Clip(temp_Rect);
            }
        }
        private void UpdateImageAndClearCrop()
        {
            this.list_bbs.Clear();
            UpdateImage();
        }
        private void UpdateImage()
        {
            if (bmp_canvas == null)
            {
                return;
            }
            imageRect = new RectangleF(Math.Max(0, (this.Width - bmp_canvas.Width*scale) / 2), Math.Max(0, (this.Height - bmp_canvas.Height*scale) / 2), bmp_canvas.Width*scale, bmp_canvas.Height*scale);            
            vScroll.Minimum = 0;
            vScroll.Maximum = Math.Max(0, (int)((bmp_canvas.Height*scale - this.Height)));
            hScroll.Minimum = 0;
            hScroll.Maximum = Math.Max(0, (int)((bmp_canvas.Width*scale - this.Width)));            
            this.Refresh();
        }

        protected override void OnClick(EventArgs e)
        {            
            base.OnClick(e);
            selected_bb_index = current_bb_index;
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            is_ctrl_down = e.Control;
            
        }
        protected override void OnKeyUp(KeyEventArgs e)
        {
            base.OnKeyUp(e);
            is_ctrl_down = e.Control;
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            base.OnMouseWheel(e);
            if (is_ctrl_down)
            {
                if (e.Delta < 0)
                {
                    this.Scale *= 0.95f;                                        
                }
                else if (e.Delta > 0)
                {
                    this.Scale *= 1.05f;                    
                }
            }    
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (bmp_canvas == null)
            {
                return;
            }

            if (e.Button == System.Windows.Forms.MouseButtons.Middle)
            {
                drawingState = DrawingState.MoveImage;
                this.Cursor = Cursors.SizeAll;
                bb.BB = Rectangle.Empty;
                ptStart = e.Location;

            }
            else if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                if (selected_bb_index < 0 || (selected_bb_index >=0 && !list_bbs[selected_bb_index].Scale(scale).Translate(imageRect.Location).BB.Contains(e.Location)))
                {
                    if (imageRect.Contains(e.Location))
                    {
                        ptStart.X = e.Location.X - imageRect.X;
                        ptStart.Y = e.Location.Y - imageRect.Y;
                        drawingState = DrawingState.DrawBoundingBox;
                        this.Cursor = Cursors.Cross;
                    }
                }
                else if (drawingState == DrawingState.InflateBoundingBoxLeft ||
                         drawingState == DrawingState.InflateBoundingBoxRight ||
                         drawingState == DrawingState.InflateBoundingBoxUp ||
                         drawingState == DrawingState.InflateBoundingBoxDown ||
                         drawingState == DrawingState.InflateBounfingUpLeft ||
                         drawingState == DrawingState.InflateBounfingUpRight ||
                         drawingState ==  DrawingState.InflateBounfingDownLeft ||
                         drawingState == DrawingState.InflateBounfingDownRight)
                {
                    ptStart = e.Location;
                }
                else if (list_bbs[selected_bb_index].Scale(scale).Translate(imageRect.Location).BB.Contains(e.Location)) 
                {
                    drawingState = DrawingState.MoveBoundingBox;
                    ptStart = e.Location;
                    this.Cursor = Cursors.SizeAll;
                }
                
                
            }
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (imageRect.Contains(e.Location))
            {
                ptMouseLocation = e.Location;
                this.Refresh();
            }
            else
            {
                ptMouseLocation = PointF.Empty;
            }

            if (e.Button == System.Windows.Forms.MouseButtons.Middle)
            {
                ptEnd = e.Location;
                imageRect.X += ptEnd.X - ptStart.X;
                imageRect.Y += ptEnd.Y - ptStart.Y;
                ptStart = ptEnd;
                this.Refresh();
            }
            else if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                if (drawingState == DrawingState.DrawBoundingBox)
                {
                    ptEnd.X = e.Location.X - imageRect.X;
                    ptEnd.Y = e.Location.Y - imageRect.Y;
                    bb = new BoundingBox(new RectangleF(Math.Min(ptStart.X / scale, ptEnd.X / scale),
                                                        Math.Min(ptStart.Y / scale, ptEnd.Y / scale),
                                                        Math.Abs(ptEnd.X / scale - ptStart.X / scale),
                                                        Math.Abs(ptEnd.Y / scale - ptStart.Y / scale)), "");                    
                    this.Refresh();
                }
                else if (drawingState == DrawingState.MoveBoundingBox)
                {
                    ptEnd = e.Location;
                    float dx = ptEnd.X - ptStart.X;
                    float dy = ptEnd.Y - ptStart.Y;
                    list_bbs[selected_bb_index] = list_bbs[selected_bb_index].Translate(dx / scale, dy / scale);
                    ptStart = ptEnd;
                    this.Refresh();
                }
                else if (drawingState == DrawingState.InflateBoundingBoxLeft)
                {
                    ptEnd = e.Location;
                    float d = ptEnd.X - ptStart.X;
                    list_bbs[selected_bb_index] = list_bbs[selected_bb_index].InflateLeft(d/scale);
                    ptStart = ptEnd;
                    this.Refresh();
                }
                else if (drawingState == DrawingState.InflateBoundingBoxRight)
                {
                    ptEnd = e.Location;
                    float d = ptEnd.X - ptStart.X;
                    list_bbs[selected_bb_index] = list_bbs[selected_bb_index].InflateRight(d / scale);
                    ptStart = ptEnd;
                    this.Refresh();
                }
                else if (drawingState == DrawingState.InflateBoundingBoxUp)
                {
                    ptEnd = e.Location;
                    float d = ptEnd.Y - ptStart.Y;
                    list_bbs[selected_bb_index] = list_bbs[selected_bb_index].InflateUp(d / scale);
                    ptStart = ptEnd;
                    this.Refresh();
                }
                else if (drawingState == DrawingState.InflateBoundingBoxDown)
                {
                    ptEnd = e.Location;
                    float d = ptEnd.Y - ptStart.Y;
                    list_bbs[selected_bb_index] = list_bbs[selected_bb_index].InflateDown(d / scale);
                    ptStart = ptEnd;
                    this.Refresh();
                }
                else if (drawingState == DrawingState.InflateBounfingUpLeft)
                {
                    ptEnd = e.Location;
                    float d = ptEnd.Y - ptStart.Y;
                    list_bbs[selected_bb_index] = list_bbs[selected_bb_index].InflateUp(d / scale);
                    d = ptEnd.X - ptStart.X;
                    list_bbs[selected_bb_index] = list_bbs[selected_bb_index].InflateLeft(d / scale);
                    ptStart = ptEnd;
                    this.Refresh();
                }
                else if (drawingState == DrawingState.InflateBounfingUpRight)
                {
                    ptEnd = e.Location;
                    float d = ptEnd.Y - ptStart.Y;
                    list_bbs[selected_bb_index] = list_bbs[selected_bb_index].InflateUp(d / scale);
                    d = ptEnd.X - ptStart.X;
                    list_bbs[selected_bb_index] = list_bbs[selected_bb_index].InflateRight(d / scale);
                    ptStart = ptEnd;
                    this.Refresh();
                }
                else if (drawingState == DrawingState.InflateBounfingDownLeft)
                {
                    ptEnd = e.Location;
                    float d = ptEnd.Y - ptStart.Y;
                    list_bbs[selected_bb_index] = list_bbs[selected_bb_index].InflateDown(d / scale);
                    d = ptEnd.X - ptStart.X;
                    list_bbs[selected_bb_index] = list_bbs[selected_bb_index].InflateLeft(d / scale);
                    ptStart = ptEnd;
                    this.Refresh();
                }
                else if (drawingState == DrawingState.InflateBounfingDownRight)
                {
                    ptEnd = e.Location;
                    float d = ptEnd.Y - ptStart.Y;
                    list_bbs[selected_bb_index] = list_bbs[selected_bb_index].InflateDown(d / scale);
                    d = ptEnd.X - ptStart.X;
                    list_bbs[selected_bb_index] = list_bbs[selected_bb_index].InflateRight(d / scale);
                    ptStart = ptEnd;
                    this.Refresh();
                }
            }
            else
            {
                current_bb_index = -1;
                for (int i = 0; i < list_bbs.Count; i++)
                {
                    if (list_bbs[i].Scale(scale).Translate(imageRect.Location).BB.Contains(e.Location))
                    {
                        current_bb_index = i;
                        break;
                    }
                }
                drawingState = DrawingState.None;
                this.Cursor = Cursors.Cross;
                if (selected_bb_index >= 0)
                {
                    RectangleF temp_rect = list_bbs[selected_bb_index].Scale(scale).Translate(imageRect.Location).BB;
                    if (temp_rect.Contains(e.Location))
                    {
                        if ((e.Location.X - temp_rect.X) < temp_rect.Width * 0.1 &&
                            (e.Location.Y - temp_rect.Y) > temp_rect.Height * 0.1 && 
                            (e.Location.Y - temp_rect.Y) < temp_rect.Height * 0.9)
                        {
                            drawingState = DrawingState.InflateBoundingBoxLeft;
                            this.Cursor = Cursors.PanWest;
                        }
                        else if ((e.Location.X - temp_rect.X) > temp_rect.Width * 0.9 &&
                            (e.Location.Y - temp_rect.Y) > temp_rect.Height * 0.1 &&
                            (e.Location.Y - temp_rect.Y) < temp_rect.Height * 0.9)
                        {
                            drawingState = DrawingState.InflateBoundingBoxRight;
                            this.Cursor = Cursors.PanEast;
                        }
                        else if ((e.Location.Y - temp_rect.Y) < temp_rect.Height * 0.1 &&
                            (e.Location.X - temp_rect.X) > temp_rect.Width * 0.1 &&
                            (e.Location.X - temp_rect.X) < temp_rect.Width * 0.9)
                        {
                            drawingState = DrawingState.InflateBoundingBoxUp;
                            this.Cursor = Cursors.PanNorth;
                        }
                        else if ((e.Location.Y - temp_rect.Y) > temp_rect.Height * 0.9 &&
                            (e.Location.X - temp_rect.X) > temp_rect.Width * 0.1 &&
                            (e.Location.X - temp_rect.X) < temp_rect.Width * 0.9)
                        {
                            drawingState = DrawingState.InflateBoundingBoxDown;
                            this.Cursor = Cursors.PanSouth;
                        }
                        else if ((e.Location.Y - temp_rect.Y) < temp_rect.Height * 0.1 &&
                                  (e.Location.X - temp_rect.X) < temp_rect.Width * 0.1)
                        {
                            drawingState = DrawingState.InflateBounfingUpLeft;
                            this.Cursor = Cursors.PanNW;
                        }
                        else if ((e.Location.Y - temp_rect.Y) < temp_rect.Height * 0.1 &&
                                  (e.Location.X - temp_rect.X) > temp_rect.Width * 0.9)
                        {
                            drawingState = DrawingState.InflateBounfingUpRight;
                            this.Cursor = Cursors.PanNE;
                        }
                        else if ((e.Location.Y - temp_rect.Y) > temp_rect.Height * 0.9 &&
                                  (e.Location.X - temp_rect.X) < temp_rect.Width * 0.1)
                        {
                            drawingState = DrawingState.InflateBounfingDownLeft;
                            this.Cursor = Cursors.PanSW;
                        }
                        else if ((e.Location.Y - temp_rect.Y) > temp_rect.Height * 0.9 &&
                                  (e.Location.X - temp_rect.X) > temp_rect.Width * 0.9)
                        {
                            drawingState = DrawingState.InflateBounfingDownRight;
                            this.Cursor = Cursors.PanSE;
                        }
                    }
                }
                this.Refresh();
            }
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            if (e.Button == System.Windows.Forms.MouseButtons.Middle)
            {
                drawingState = DrawingState.None;
                this.Cursor = Cursors.Cross;
                this.Refresh();
            }
            else if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                if (drawingState == DrawingState.DrawBoundingBox)
                {
                    if (!bb.BB.IsEmpty && bb.BB.Width > 2 && bb.BB.Height>2)
                    {
                        FrmClasses frm = new FrmClasses();
                        frm.SetRecentLabel(listRecentLabels);
                        frm.StartPosition = FormStartPosition.Manual;
                        frm.Left = e.X;
                        frm.Top = e.Y;
                        if (frm.ShowDialog() == DialogResult.Yes)
                        {
                            bb.ClassLabel = frm.SelectedLabel;                            
                        }
                        UpdateRecentLabels(bb.ClassLabel);
                        list_bbs.Add(bb);
                        bb.BB = Rectangle.Empty;
                        drawingState = DrawingState.None;
                        this.Refresh();
                    }
                    
                }
                CorrectBoundingBoxes();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            if (bmp_canvas != null)
            {
                e.Graphics.DrawImage(bmp_canvas, imageRect);
            }
            if (drawingState == DrawingState.DrawBoundingBox)
            {
                Rectangle temp_rect = (Rectangle)bb.Scale(scale).Translate(imageRect.Location);
                e.Graphics.DrawRectangle(penBB, temp_rect);
            }

            //Drawing all bounding boxes
            foreach (BoundingBox temp_bb in list_bbs)
            {
                Rectangle temp_rect = (Rectangle)temp_bb.Scale(scale).Translate(imageRect.Location);
                e.Graphics.DrawRectangle(penBB, temp_rect);
            }

            //Drawing the hovered bounding box
            if (current_bb_index >= 0)
            {
                Rectangle temp_rect = (Rectangle)list_bbs[current_bb_index].Scale(scale).Translate(imageRect.Location);
                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(127, penBB.Color)), temp_rect);
                e.Graphics.DrawRectangle(penBB, temp_rect);                
            }

            //Drawing the selected bounding box
            if (selected_bb_index >= 0)
            {
                Rectangle temp_rect = (Rectangle)list_bbs[selected_bb_index].Scale(scale).Translate(imageRect.Location);
                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(127, penBB.Color)), temp_rect);
                e.Graphics.DrawRectangle(penBB, temp_rect);
                #region Draw arrows
                if (showArros)
                {
                    using (GraphicsPath gPath = new GraphicsPath())
                    {
                        using (Pen penArrow = new Pen(Color.FromArgb(180, Color.White), 1))
                        {
                            gPath.AddLine(0, 0, 1.5f, 1);
                            gPath.AddLine(0, 0, 1.5f, -1);
                            float s = Math.Max(5, Math.Min(temp_rect.Width, temp_rect.Height) * 0.05f);
                            s = 4;
                            
                            //Corners
                            e.Graphics.TranslateTransform(temp_rect.X, temp_rect.Y);
                            e.Graphics.ScaleTransform(s, s);
                            e.Graphics.RotateTransform((float)(45));
                            e.Graphics.DrawPath(penArrow, gPath);
                            e.Graphics.ResetTransform();

                            e.Graphics.TranslateTransform(temp_rect.X, temp_rect.Y + temp_rect.Height);
                            e.Graphics.ScaleTransform(s, s);
                            e.Graphics.RotateTransform((float)(-45));
                            e.Graphics.DrawPath(penArrow, gPath);
                            e.Graphics.ResetTransform();

                            e.Graphics.TranslateTransform(temp_rect.X + temp_rect.Width, temp_rect.Y);
                            e.Graphics.ScaleTransform(s, s);
                            e.Graphics.RotateTransform((float)(135));
                            e.Graphics.DrawPath(penArrow, gPath);
                            e.Graphics.ResetTransform();

                            e.Graphics.TranslateTransform(temp_rect.X + temp_rect.Width, temp_rect.Y + temp_rect.Height);
                            e.Graphics.ScaleTransform(s, s);
                            e.Graphics.RotateTransform((float)(-135));
                            e.Graphics.DrawPath(penArrow, gPath);
                            e.Graphics.ResetTransform();

                            //Sides
                            e.Graphics.TranslateTransform(temp_rect.X + temp_rect.Width / 2, temp_rect.Y);
                            e.Graphics.ScaleTransform(s, s);
                            e.Graphics.RotateTransform((float)(90));
                            e.Graphics.DrawPath(penArrow, gPath);
                            e.Graphics.ResetTransform();

                            e.Graphics.TranslateTransform(temp_rect.X + temp_rect.Width / 2, temp_rect.Y + temp_rect.Height);
                            e.Graphics.ScaleTransform(s, s);
                            e.Graphics.RotateTransform((float)(-90));
                            e.Graphics.DrawPath(penArrow, gPath);
                            e.Graphics.ResetTransform();

                            e.Graphics.TranslateTransform(temp_rect.X, temp_rect.Y + temp_rect.Height / 2);
                            e.Graphics.ScaleTransform(s, s);
                            e.Graphics.RotateTransform((float)(0));
                            e.Graphics.DrawPath(penArrow, gPath);
                            e.Graphics.ResetTransform();

                            e.Graphics.TranslateTransform(temp_rect.X + temp_rect.Width, temp_rect.Y + temp_rect.Height / 2);
                            e.Graphics.ScaleTransform(s, s);
                            e.Graphics.RotateTransform((float)(180));
                            e.Graphics.DrawPath(penArrow, gPath);
                            e.Graphics.ResetTransform();
                        }
                    }
                }
                #endregion

            }

            //Draw guid lines
            e.Graphics.DrawLine(penGuidLine, x1: imageRect.X, x2: imageRect.X, y1: 0, y2: this.Height);
            e.Graphics.DrawLine(penGuidLine, x1: imageRect.X + imageRect.Width, x2: imageRect.X + imageRect.Width, y1: 0, y2: this.Height);
            e.Graphics.DrawLine(penGuidLine, y1: imageRect.Y, y2: imageRect.Y, x1: 0, x2: this.Width);
            e.Graphics.DrawLine(penGuidLine, y1: imageRect.Y + imageRect.Height, y2: imageRect.Y + imageRect.Height, x1: 0, x2: this.Width);

            //Draw mouse guids
            if (!ptMouseLocation.IsEmpty && this.show_mouse_guid)
            {
                e.Graphics.DrawLine(penMouseGuid, x1: ptMouseLocation.X, x2: ptMouseLocation.X, y1: 0, y2: this.Height);
                e.Graphics.DrawLine(penMouseGuid, y1: ptMouseLocation.Y, y2: ptMouseLocation.Y, x1: 0, x2: this.Width);
            }
            
        }

        private void mnuDeleteSelected_Click(object sender, EventArgs e)
        {
            RemoveSelected();
        }

        private void mnuChangeLabel_Click(object sender, EventArgs e)
        {
            if (selected_bb_index >= 0)
            {
                FrmClasses frm = new FrmClasses();
                frm.StartPosition = FormStartPosition.Manual;
                frm.SetRecentLabel(listRecentLabels);
                frm.Left = (int)list_bbs[selected_bb_index].BB.Right;
                frm.Top = (int)list_bbs[selected_bb_index].BB.Bottom;
                frm.SelectedLabel = list_bbs[selected_bb_index].ClassLabel;
                if (frm.ShowDialog() == DialogResult.Yes)
                {
                    BoundingBox bb = list_bbs[selected_bb_index];
                    bb.ClassLabel = frm.SelectedLabel;
                    UpdateRecentLabels(bb.ClassLabel);
                    list_bbs[selected_bb_index] = bb;
                }
            }
        }
    }
}
