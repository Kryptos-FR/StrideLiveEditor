﻿using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Stride.Core.Mathematics;
using Stride.Engine;

namespace StrideLiveEditor.Avalonia.DataTypeEditors
{
    public class Vector3Editor : BaseEditor
    {
        public TextBlock PropertyName => this.FindControl<TextBlock>("PropertyName");
        public NumericUpDown X => this.FindControl<NumericUpDown>("X");
        public NumericUpDown Y => this.FindControl<NumericUpDown>("Y");
        public NumericUpDown Z => this.FindControl<NumericUpDown>("Z");

        public Vector3Editor()
        {
            this.InitializeComponent();
        }

        public Vector3Editor(EntityComponent component, ComponentPropertyItem property)
            : base(component, property)
        {
            InitializeComponent();

            PropertyName.Text = property.Name;
            UpdateValues(false);

            AddNumericBoxEvents(OnValueChanged, X, Y, Z);
        }

        private void OnValueChanged()
        {
            var v = new Vector3(GetFloat(X.Value), GetFloat(Y.Value), GetFloat(Z.Value));

            ComponentProperty.SetValue(Component, v);
        }

        public override void UpdateValues(bool editorWindowIsActive)
        {
            var value = (Vector3)ComponentProperty.GetValue(Component);

            if ((!editorWindowIsActive || !X.IsFocused) && GetFloat(X.Value) != value.X)
                X.Value = (decimal)value.X;
            if ((!editorWindowIsActive || !Y.IsFocused) && GetFloat(Y.Value) != value.Y)
                Y.Value = (decimal)value.Y;
            if ((!editorWindowIsActive || !Z.IsFocused) && GetFloat(Z.Value) != value.Z)
                Z.Value = (decimal)value.Z;
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
