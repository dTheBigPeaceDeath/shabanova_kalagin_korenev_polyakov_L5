using System;
using System.Collections.Generic;
using System.Linq;

namespace shabanova_kalagin_korenev_polyakov_L5.Graphics
{
    class Axis
    {
        private Vector2 null_point;
        private string name;
        private List<Label> labels;
        public CoordinatePlane ParentPlane { get; private set; }
        public Position AxisPosition { get; private set; }
        public double Length { get; private set; }
        public int LabelsCount
        {
            get
            {
                return labels.Count;
            }
        }
        public Axis(CoordinatePlane _parent_plane, Position _position, Vector2 _null_point, double _length, string _name)
        {
            ParentPlane = _parent_plane;
            AxisPosition = _position;
            null_point = _null_point;
            Length = _length;
            name = _name;
            labels = new List<Label>();
        }
        public void AddValue(Point _p)
        {
            double searching_value;
            List<Label> search_list;
            Label temp_label;

            if(AxisPosition == Position.Horizontal)
            {
                searching_value = _p.value.x;
            }
            else
            {
                searching_value = _p.value.y;
            }

            search_list = (from label in labels
                           where label.value == searching_value
                          select label).ToList();

            if(search_list.Count == 0)
            {
                temp_label = new Label(this, searching_value);
                labels.Add(temp_label);
            }
            else
            {
                temp_label = search_list[0];
            }

            if(AxisPosition == Position.Horizontal)
            {
                _p.label_x = temp_label;
            }
            else
            {
                _p.label_y = temp_label;
            }
        }
        public void Show()
        {
            int c1;
            Vector2 end_point;
            double horizontal, vertical;
            int d;

            if (AxisPosition == Position.Horizontal)
            {
                end_point = new Vector2(null_point.x + Length, null_point.y);
                horizontal = 10;
                vertical = 5;
                d = ParentPlane.d_x;
            }
            else
            {
                end_point = new Vector2(null_point.x, null_point.y + Length);
                horizontal = 5;
                vertical = 10;
                d = ParentPlane.d_y;
            }

            ParentPlane.CreateLine(null_point, end_point, ParentPlane.axis_thickness, ParentPlane.axis_color);
            ParentPlane.CreateArrow(end_point, AxisPosition, horizontal, vertical, ParentPlane.axis_thickness, ParentPlane.axis_color);
            ParentPlane.CreateText(end_point, AxisPosition, name, ParentPlane.text_size + 2, ParentPlane.text_color);

            labels.Sort();
            for(c1 = 0; c1 < labels.Count; c1++)
            {
                ParentPlane.CreateLabel(labels[c1], ((Length * 0.9) / labels.Count) * (c1 + d));
            }
        }
    }
}
