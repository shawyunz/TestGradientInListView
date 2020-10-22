using Xamarin.Forms;

namespace TestGradientInListView
{
    public class GradientLabel : Label
    {
        public static readonly BindableProperty ColorLeftProperty = BindableProperty.Create(
              propertyName: nameof(ColorLeft),
              returnType: typeof(Color),
              declaringType: typeof(Color),
              defaultValue: Color.Green);

        public static readonly BindableProperty ColorRightProperty = BindableProperty.Create(
            propertyName: nameof(ColorRight),
            returnType: typeof(Color),
            declaringType: typeof(Color),
            defaultValue: Color.Red);

        public Color ColorLeft
        {
            get => (Color)GetValue(ColorLeftProperty);
            set => SetValue(ColorLeftProperty, value);
        }

        public Color ColorRight
        {
            get => (Color)GetValue(ColorRightProperty);
            set => SetValue(ColorRightProperty, value);
        }
    }
}