using System;
using System.Collections.Generic;
using System.Numerics;
using System.Windows.Controls;
using System.Windows.Media;

namespace shabanova_kalagin_korenev_polyakov_L5.Graphics
{
    class Label : IComparable<Label>
    {
        public double value;
        public double axis_value;
        public Axis ParentAxis { get; private set; }
        public int CompareTo(Label _label)
        {
            return value.CompareTo(_label.value);
        }
        public Label(Axis _parent_axis, double _value)
        {
            ParentAxis = _parent_axis;
            value = _value;
        }
    }
}
