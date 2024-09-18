using System;
using System.Data;
using Microsoft.Maui.Controls;


namespace CalculadoraBasica
{
    public partial class MainPage : ContentPage
    {
        private string _input = string.Empty;

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnButtonClicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            if (button != null)
            {
                _input += button.Text;
                Display.Text = _input;
            }
        }

        private void OnClearButtonClicked(object sender, EventArgs e)
        {
            _input = string.Empty;
            Display.Text = _input;
        }

        private void OnEqualsButtonClicked(object sender, EventArgs e)
        {
            try
            {
                var result = new DataTable().Compute(_input, null);
                Display.Text = result.ToString();
                _input = string.Empty; // Reset input after calculation
            }
            catch (Exception)
            {
                Display.Text = "Error";
                _input = string.Empty; // Reset on error
            }
        }
    }
}
