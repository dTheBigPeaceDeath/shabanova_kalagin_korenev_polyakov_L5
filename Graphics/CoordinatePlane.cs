using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace shabanova_kalagin_korenev_polyakov_L5.Graphics
{
    enum Position
    {
        Horizontal,
        Vertical
    }
    class CoordinatePlane
    {
        protected Canvas canvas;
        protected List<Point> points;
        protected Axis axis_x;
        protected Axis axis_y;
        public Vector2 NullPoint { get; private set; }

        // Var
        public Brush axis_color;
        public Brush point_color;
        public Brush text_color;
        public Brush label_color;
        public Brush proection_color;
        public double axis_thickness;
        public double label_thickness;
        public double proection_thickness;
        public double text_size;
        public double point_size;
        public int d_x;
        public int d_y;
        public bool proections;
        public CoordinatePlane(Canvas _canvas, string _axis_x_name, string _axis_y_name)
        {
            canvas = _canvas;
            NullPoint = new Vector2(canvas.Width * 0.1, canvas.Height * 0.9);
            points = new List<Point>();
            axis_x = new Axis(this, Position.Horizontal, new Vector2(0, 0), canvas.Width * 0.8, _axis_x_name);
            axis_y = new Axis(this, Position.Vertical, new Vector2(0, 0), canvas.Height * 0.8, _axis_y_name);
            points = new List<Point>();

            axis_color = Brushes.Black;
            point_color = Brushes.Red;
            text_color = Brushes.DarkBlue;
            label_color = Brushes.Green;
            proection_color = Brushes.BlueViolet;
            axis_thickness = 2.0;
            label_thickness = 3.0;
            proection_thickness = 1.0;
            text_size = 12.0;
            point_size = 6.0;
            d_x = 1;
            d_y = 1;
            proections = false;
        }
        public virtual void ShowCoordinatePlane()
        {
            axis_x.Show();
            axis_y.Show();

            foreach(Point p in points)
            {
                CreatePoint(p);
                if(proections)
                {
                    CreateProections(p);
                }
            }
        }
        public void AddPoint(double _value_x, double _value_y)
        {
            Point new_point = new Point(new Vector2(_value_x, _value_y));

            axis_x.AddValue(new_point);
            axis_y.AddValue(new_point);

            points.Add(new_point);
        }
        public void CreateLine(Vector2 _p1, Vector2 _p2, double _stroke_thickness, Brush _color)
        {
            Line line = new Line();

            line.X1 = NullPoint.x + _p1.x;
            line.Y1 = NullPoint.y - _p1.y;
            line.X2 = NullPoint.x + _p2.x;
            line.Y2 = NullPoint.y - _p2.y;
            line.Stroke = _color;
            line.StrokeThickness = _stroke_thickness;

            canvas.Children.Add(line);
        }
        public void CreatePoint(Point _p)
        {
            Ellipse el = new Ellipse();

            el.Width = point_size;
            el.Height = point_size;
            el.Fill = point_color;
            canvas.Children.Add(el);

            Canvas.SetLeft(el, NullPoint.x - (point_size / 2) + _p.label_x.axis_value);
            Canvas.SetTop(el, NullPoint.y - (point_size / 2) - _p.label_y.axis_value);
        }
        public void CreateArrow(Vector2 _p, Position _position, double _horisontal, double _vertical, double _stroke_thickness, Brush _color)
        {
            if (_position == Position.Horizontal)
            {
                CreateLine(_p, new Vector2(_p.x - _horisontal, _p.y + _vertical), _stroke_thickness, _color);
                CreateLine(_p, new Vector2(_p.x - _horisontal, _p.y - _vertical), _stroke_thickness, _color);
            }
            else
            {
                CreateLine(_p, new Vector2(_p.x + _horisontal, _p.y - _vertical), _stroke_thickness, _color);
                CreateLine(_p, new Vector2(_p.x - _horisontal, _p.y - _vertical), _stroke_thickness, _color);
            }
        }
        public void CreateText(Vector2 _p, Position _position, string _text, double _font_size, Brush _color)
        {
            TextBlock text = new TextBlock()
            {
                Text = _text,
                FontSize = _font_size,
                Foreground = _color
            };

            canvas.Children.Add(text);

            if(_position == Position.Horizontal)
            {
                Canvas.SetLeft(text, NullPoint.x + _p.x - (_font_size / 2));
                Canvas.SetTop(text, NullPoint.y - _p.y + (_font_size / 2));
            }
            else
            {
                Canvas.SetLeft(text, NullPoint.x + _p.x - (_font_size * 4));
                Canvas.SetTop(text, NullPoint.y - _p.y - (_font_size / 2));
            }
        }
        public void CreateLabel(Label _label, double _value)
        {
            if (_label.ParentAxis.AxisPosition == Position.Horizontal)
            {
                CreateLine(new Vector2(_value, -(text_size / 2)), new Vector2(_value, (text_size / 2)), label_thickness, label_color);
                CreateText(new Vector2(_value, 0), Position.Horizontal, _label.value.ToString("0.##"), text_size, text_color);
            }
            else
            {
                CreateLine(new Vector2(-(text_size / 2), _value), new Vector2((text_size / 2), _value), label_thickness, label_color);
                CreateText(new Vector2(0, _value), Position.Vertical, _label.value.ToString("0.##"), text_size, text_color);
            }

            _label.axis_value = _value;
        }
        public void CreateDashLine(Vector2 _p1, Vector2 _p2, double _stroke_thickness, Brush _color)
        {
            Line line = new Line();

            line.X1 = NullPoint.x + _p1.x;
            line.Y1 = NullPoint.y - _p1.y;
            line.X2 = NullPoint.x + _p2.x;
            line.Y2 = NullPoint.y - _p2.y;
            line.Stroke = _color;
            line.StrokeThickness = _stroke_thickness;
            line.StrokeDashArray = new DoubleCollection
            {
                4,
                2
            };

            canvas.Children.Add(line);
        }
        public void CreateProections(Point _p)
        {
            CreateDashLine(new Vector2(_p.label_x.axis_value, _p.label_y.axis_value),
                new Vector2(_p.label_x.axis_value, 0),
                proection_thickness, proection_color);
            CreateDashLine(new Vector2(_p.label_x.axis_value, _p.label_y.axis_value),
                new Vector2(0, _p.label_y.axis_value),
                proection_thickness, proection_color);
        }
    }
}
