using System;
using System.Collections.Generic;
using System.DirectoryServices.ActiveDirectory;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Graphics
{
    enum Position
    {
        Vertical,
        Horizontal
    }

    class CoordinatePlane
    {
        public Canvas canvas;
        protected Axis axis_x;
        protected Axis axis_y;
        protected List<Point> points;
        public Point NullPoint { get; private set; }

        // Variables
        public int first_multiplier_x;
        public int first_multiplier_y;
        public double label_size;
        public double point_size;
        public Brush point_color;
        public Brush label_color;
        public Brush axis_color;
        public Brush text_color;
        public CoordinatePlane(Canvas _canvas, string _axis_x_name, string _axis_y_name)
        {
            points = new List<Point>();
            canvas = _canvas;
            axis_x = new Axis(this, _axis_x_name, Position.Horizontal);
            axis_y = new Axis(this, _axis_y_name, Position.Vertical);

            first_multiplier_x = 1;
            first_multiplier_y = 1;
            label_size = 10.0;
            point_size = 10.0;
            point_color = Brushes.Red;
            label_color = Brushes.Green;
            axis_color = Brushes.Black;
            text_color = Brushes.Red;
        }
        public void AddPoint(double _x_value, double _y_value)
        {
            Point new_point = new Point(this, _x_value, _y_value);

            axis_x.AddPoint(new_point);
            axis_y.AddPoint(new_point);

            points.Add(new_point);
        }
        public void Show()
        {
            double x_O = Math.Min(canvas.ActualWidth * 0.1, canvas.ActualHeight * 0.1);
            double y_O = canvas.ActualHeight - x_O;
            double x_axis_length = canvas.ActualWidth * 0.8;
            double y_axis_length = canvas.ActualHeight * 0.8;

            canvas.Children.Clear();

            ShowPreview();

            NullPoint = new Point(this, x_O, y_O);

            axis_x.Show(x_axis_length);
            axis_y.Show(y_axis_length);

            foreach(Point point in points)
            {
                point.Show();
            }

            ShowAdditioanal();
        }
        public void CreateArrow(Position _position, Point _coords, Point _size, double _stroke_thickness, Brush _color)
        {
            Line arrow_half_1 = new Line();
            Line arrow_half_2 = new Line();

            arrow_half_1.X1 = _coords.value_x;
            arrow_half_1.Y1 = _coords.value_y;

            arrow_half_2.X1 = _coords.value_x;
            arrow_half_2.Y1 = _coords.value_y;

            if(_position == Position.Horizontal)
            {
                arrow_half_1.X2 = arrow_half_1.X1 + _size.value_x;
                arrow_half_1.Y2 = arrow_half_1.Y1 + _size.value_y;

                arrow_half_2.X2 = arrow_half_1.X1 + _size.value_x;
                arrow_half_2.Y2 = arrow_half_1.Y1 - _size.value_y;
            }
            else
            {
                arrow_half_1.X2 = arrow_half_1.X1 + _size.value_x;
                arrow_half_1.Y2 = arrow_half_1.Y1 + _size.value_y;

                arrow_half_2.X2 = arrow_half_1.X1 - _size.value_x;
                arrow_half_2.Y2 = arrow_half_1.Y1 + _size.value_y;
            }


            arrow_half_1.StrokeThickness = _stroke_thickness;
            arrow_half_1.Stroke = _color;

            arrow_half_2.StrokeThickness = _stroke_thickness;
            arrow_half_2.Stroke = _color;

            canvas.Children.Add(arrow_half_1);
            canvas.Children.Add(arrow_half_2);
        }
        public virtual void ShowPreview()
        {

        }
        public virtual void ShowAdditioanal()
        {

        }
    }
}