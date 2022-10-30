using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для ColorPicker.xaml
    /// </summary>
    public partial class ColorPicker : System.Windows.Controls.UserControl 
    {
        public static DependencyProperty ColorProperty; //Свойства зависимости
        public static DependencyProperty RedProperty;
        public static DependencyProperty GreenProperty;
        public static DependencyProperty BlueProperty;

        //public static readonly RoutedEvent ColorChangedEvent;

        public ColorPicker()
        {
            InitializeComponent(); //=(
        }

 
        static ColorPicker()
        {
            // Регистрация свойств зависимости
            ColorProperty = DependencyProperty.Register("Color", typeof(Color), typeof(ColorPicker),
                new FrameworkPropertyMetadata(Colors.Black, new PropertyChangedCallback(OnColorChanged)));
            RedProperty = DependencyProperty.Register("Red", typeof(byte), typeof(ColorPicker),
                new FrameworkPropertyMetadata(new PropertyChangedCallback(OnColorRGBChanged)));
            GreenProperty = DependencyProperty.Register("Green", typeof(byte), typeof(ColorPicker),
                new FrameworkPropertyMetadata(new PropertyChangedCallback(OnColorRGBChanged)));
            BlueProperty = DependencyProperty.Register("Blue", typeof(byte), typeof(ColorPicker),
                 new FrameworkPropertyMetadata(new PropertyChangedCallback(OnColorRGBChanged)));
        }

        public Color Color
        {
            get { return (Color)GetValue(ColorProperty); }
            set { SetValue(ColorProperty, value); }
        }
        public byte Red
        {
            get { return (byte)GetValue(RedProperty); }
            set { SetValue(RedProperty, value); }
        }
        public byte Green
        {
            get { return (byte)GetValue(GreenProperty); }
            set { SetValue(GreenProperty, value); }
        }
        public byte Blue
        {
            get { return (byte)GetValue(BlueProperty); }
            set { SetValue(BlueProperty, value); }
        }



        private static void OnColorRGBChanged(DependencyObject sender,
            DependencyPropertyChangedEventArgs e)
        {
            ColorPicker colorPicker = (ColorPicker)sender;
            Color color = colorPicker.Color;
            if (e.Property == RedProperty)
                color.R = (byte)e.NewValue;
            else if (e.Property == GreenProperty)
                color.G = (byte)e.NewValue;
            else if (e.Property == BlueProperty)
                color.B = (byte)e.NewValue;

            colorPicker.Color = color;
        }



        //public static explicit operator ColorPicker(DependencyObject v)
        //{
        //    throw new NotImplementedException();
        //}


        private static void OnColorChanged(DependencyObject sender,
      DependencyPropertyChangedEventArgs e)
        {
            Color newColor = (Color)e.NewValue;
            ColorPicker colorpicker = (ColorPicker)sender;
            colorpicker.Red = newColor.R;
            colorpicker.Green = newColor.G;
            colorpicker.Blue = newColor.B;
        }

        public static readonly RoutedEvent ColorChangedEvent;

        // Регистрация маршрутизируемого события
    //    ColorChangedEvent = EventManager.RegisterRoutedEvent("ColorChanged",RoutingStrategy.Bubble,
    //typeof(RoutedPropertyChangedEventHandler<Color>), typeof(ColorPicker));



            public event RoutedPropertyChangedEventHandler<Color> ColorChanged
        {
            add { AddHandler(ColorChangedEvent, value); }
            remove { RemoveHandler(ColorChangedEvent, value); }
        }

    }
}
