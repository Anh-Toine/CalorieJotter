using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CalorieJotter
{
    public partial class MainPage : ContentPage
    {
        public Label calories;
        public int cal;

        public MainPage()
        {
            InitializeComponent();
            calories = calorieLabel;

            Type mpage = typeof(MainPage);
            topImg.Source = ImageSource.FromResource("CalorieJotter.poutine.png", mpage);
            bottomImg.Source = ImageSource.FromResource("CalorieJotter.poutine.png", mpage);
        }

        void OnStyleCheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            switch (rb.Content)
            {
                case "Lebanese(1200 cal)":
                    cal = 1200;
                    break;
                case "Mexican(1146 cal)":
                    cal = 1146;
                    break;
                case "Irish(1170 cal)":
                    cal = 1170;
                    break;
                case "Singaporean(1170 cal)":
                    cal = 1170;
                    break;
            }
            DisplayCalories(cal);
        }

        void OnExtraGravyChecked(object sender,EventArgs e)
        {
            CheckBox gravy = extraGravyChkbox;
            if (gravy.IsChecked)
            {
                cal += 50;
            }
            else
            {
                cal -= 50;
            }
            DisplayCalories(cal);
        }

        void OnExtraCheeseChecked(object sender, CheckedChangedEventArgs e)
        {
            CheckBox cheese = extraCheeseChkbox;
            if (cheese.IsChecked)
            {
                cal += 30;
            }
            else
            {
                cal -= 30;
            }
            DisplayCalories(cal);
        }

        void SpiceValueChanged(object sender, ValueChangedEventArgs e)
        {
            int newvalue = Convert.ToInt32(e.NewValue);
            int oldvalue = Convert.ToInt32(e.OldValue);
            int spice = (int)spiceSlide.Value;
            cal += newvalue - oldvalue;
            sliderLabel.Text = "Spicy level: " + spice;
            DisplayCalories(cal);
        }

        void DisplayCalories(int c)
        {
            calories.Text = "Calories: " + c;
        }
    }
}
