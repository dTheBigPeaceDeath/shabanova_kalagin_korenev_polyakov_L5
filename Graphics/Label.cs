using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Graphics
{
    class Label : IComparable<Label>
    {
        private string text;
        public double CoordValue { get; private set; }
        public Axis ParentAxis { get; private set; }
        public double Value
        {
            get
            {
                return Convert.ToDouble(text);
            }
            private set
            {
                text = value.ToString("0.##");
            }
        }
        public Label(Axis _parent_axis, double _value)
        {
            ParentAxis = _parent_axis;
            Value = _value;
        }
        public int CompareTo(Label _label)
        {
            return Value.CompareTo(_label.Value);
        }
        public void Show(int _multiplier)
        {
            Line label_line = new Line();
            TextBlock label_text = new TextBlock();
            double label_size = ParentAxis.ParentPlane.label_size;
            Point null_point = ParentAxis.NullPoint;

            label_text.Text = text;
            label_text.Foreground = ParentAxis.ParentPlane.text_color;
            label_text.FontSize = ParentAxis.ParentPlane.label_size;
            ParentAxis.ParentPlane.canvas.Children.Add(label_text);

            if(ParentAxis.position == Position.Horizontal)
            {
                CoordValue = (ParentAxis.SegmentSize * _multiplier) + ParentAxis.NullPoint.value_x;

                label_line.X1 = CoordValue;
                label_line.Y1 = null_point.value_y - (label_size / 2);
                label_line.X2 = CoordValue;
                label_line.Y2 = null_point.value_y + (label_size / 2);

                Canvas.SetLeft(label_text, CoordValue - (label_size / 2));
                Canvas.SetTop(label_text, null_point.value_y + (label_size / 2));
            }
            else
            {
                CoordValue = null_point.value_y - (ParentAxis.SegmentSize * _multiplier);

                label_line.X1 = null_point.value_x - (label_size / 2);
                label_line.Y1 = CoordValue;
                label_line.X2 = null_point.value_x + (label_size / 2);
                label_line.Y2 = CoordValue;

                Canvas.SetLeft(label_text, null_point.value_x - (label_size * 3));
                Canvas.SetTop(label_text, CoordValue - (label_size / 2));
            }

            label_line.StrokeThickness = 2.0;
            label_line.Stroke = ParentAxis.ParentPlane.label_color;

            ParentAxis.ParentPlane.canvas.Children.Add(label_line);
        }
    }
}
