using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Shapes;
using System.Windows.Media;

namespace Graphics
{
    class Axis
    {
        private string name;
        private double length;
        public List<Label> labels;
        public Position position;
        public Point NullPoint { get; private set; }
        public CoordinatePlane ParentPlane { get; private set; }
        public double SegmentSize { get; private set; }
        public double Length
        {
            get
            {
                return length;
            }
            private set
            {
                length = value;
                SegmentSize = (length * 0.9) / labels.Count;
            }
        }
        public Axis(CoordinatePlane _parent_plane, string _name, Position _position)
        {
            ParentPlane = _parent_plane;
            name = _name;
            position = _position;

            labels = new List<Label>();
        }
        public void AddPoint(Point _point)
        {
            Label temp_label;

            foreach (Label label in labels)
            {
                if(position == Position.Horizontal && label.Value == _point.value_x)
                {
                    _point.label_x = label;
                }
                else if (position == Position.Vertical && label.Value == _point.value_y)
                {
                    _point.label_y = label;
                }
            }

            if (position == Position.Horizontal && _point.label_x == null)
            {
                temp_label = new Label(this, _point.value_x);
                labels.Add(temp_label);
                _point.label_x = temp_label;
            }
            else if (position == Position.Vertical && _point.label_y == null)
            {
                temp_label = new Label(this, _point.value_y);
                labels.Add(temp_label);
                _point.label_y = temp_label;
            }
        }
        public void Show(double _lenght)
        {
            Line line = new Line();
            int label_counter;
            TextBlock name_label = new TextBlock();

            name_label.Text = name;
            name_label.Foreground = ParentPlane.text_color;
            name_label.FontSize = ParentPlane.label_size + 2;
            ParentPlane.canvas.Children.Add(name_label);

            Length = _lenght;
            NullPoint = ParentPlane.NullPoint;

            if(position == Position.Horizontal)
            {
                line.X1 = NullPoint.value_x;
                line.Y1 = NullPoint.value_y;
                line.X2 = Length + NullPoint.value_x;
                line.Y2 = NullPoint.value_y;

                ParentPlane.CreateArrow(position, new Point(line.X2, line.Y2), new Point(-10.0, -5.0), 2.0, ParentPlane.axis_color);

                Canvas.SetLeft(name_label, line.X2);
                Canvas.SetTop(name_label, line.Y2 + ParentPlane.label_size);
            }
            else
            {
                line.X1 = NullPoint.value_x;
                line.Y1 = NullPoint.value_y;
                line.X2 = NullPoint.value_x;
                line.Y2 = NullPoint.value_y - Length;

                ParentPlane.CreateArrow(position, new Point(line.X2, line.Y2), new Point(5.0, 10.0), 2.0, ParentPlane.axis_color);

                Canvas.SetLeft(name_label, line.X2 - (ParentPlane.label_size * 3));
                Canvas.SetTop(name_label, line.Y2);
            }

            line.StrokeThickness = 2.0;
            line.Stroke = ParentPlane.axis_color;

            ParentPlane.canvas.Children.Add(line);

            labels.Sort();
            if(position == Position.Horizontal)
            {
                label_counter = ParentPlane.first_multiplier_x;
            }
            else
            {
                label_counter = ParentPlane.first_multiplier_y;
            }
            foreach(Label label in labels)
            {
                label.Show(label_counter++);
            }
        }
    }
}
