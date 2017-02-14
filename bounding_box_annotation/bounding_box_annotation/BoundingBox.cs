using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace bounding_box_annotation
{
    public struct BoundingBox
    {
        private RectangleF rect;
        private string classLabel;       
        private bool isEmpty;

        public bool IsEmpty
        {
            get { return this.isEmpty; }
            set { this.isEmpty = value; }
        }

        public BoundingBox(float x, float y, float width, float height, string classLabel = ""):this(new RectangleF(x, y, width, height), classLabel)
        {            
        }

        public BoundingBox(RectangleF rect, string classLabel = "")
        {
            this.rect = rect;
            this.classLabel = classLabel;            
            isEmpty = false;
        }

        public RectangleF BB
        {
            get { return this.rect; }
            set { this.rect = value; }
        }

        public string ClassLabel
        {
            get { return this.classLabel; }
            set { this.classLabel = value; }
        }

        public BoundingBox Clip(RectangleF source)
        {
            if (rect.X < 0)
            {
                rect.Width += rect.X;
                rect.X = 0;
            }
            if (rect.Y < 0)
            {
                rect.Height+= rect.Y;
                rect.Y = 0;
            }
            if (rect.X + rect.Width  > source.Width )
            {
                rect.Width = source.Width  - rect.X ;
            }
            if (rect.Y  + rect.Height  > source.Height )
            {
                rect.Height = source.Height  - rect.Y ;
            }
            return this;
        }
        public BoundingBox Translate(float dx, float dy)
        {
            this.rect.X += dx;
            this.rect.Y += dy;
            return this;
        }

        public BoundingBox InflateLeft(float d)
        {
            this.rect.X += d;
            this.rect.Width -= d;
            return this;
        }
        public BoundingBox InflateRight(float d)
        {            
            this.rect.Width += d;
            return this;
        }
        public BoundingBox InflateUp(float d)
        {
            this.rect.Y += d;
            this.rect.Height-= d;
            return this;
        }
        public BoundingBox InflateDown(float d)
        {            
            this.rect.Height += d;
            return this;
        }

        public BoundingBox Translate(PointF d)
        {
            return this + d;
        }

        public BoundingBox Scale(float s)
        {
            return this * s;
        }

        public static explicit operator RectangleF(BoundingBox bb)
        {
            return bb.rect;
        }

        public static explicit operator Rectangle(BoundingBox bb)
        {
            return new Rectangle((int)bb.rect.X, (int)bb.rect.Y, (int)bb.rect.Width, (int)bb.rect.Height);
        }

        public static BoundingBox operator  +(BoundingBox bb, PointF dx)
        {
            BoundingBox temp = bb;
            temp.rect.X += dx.X;
            temp.rect.Y += dx.Y;
            return temp;
            
        }

        public static BoundingBox operator *(BoundingBox bb, float s)
        {
            BoundingBox temp = bb;
            temp.rect.X *= s;
            temp.rect.Y *= s;
            temp.rect.Width *= s;
            temp.rect.Height *= s;
            return temp;

        }
    }
}
