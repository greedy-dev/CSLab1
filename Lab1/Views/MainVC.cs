using Lab1.ViewModels;

namespace Lab1.Views
{
    public partial class MainVC : UIViewController
    {
        private UIDatePicker _datePicker;
        private UILabel _ageLabel;
        private UILabel _westernZodiacSignLabel;
        private UILabel _chineseZodiacSignLabel;
        private readonly MainPageViewModel _viewModel;

        public MainVC()
        {
            _viewModel = new MainPageViewModel();
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            // Create date picker
            _datePicker = new UIDatePicker();
            _datePicker.Mode = UIDatePickerMode.Date;
            _datePicker.ValueChanged += DatePickerValueChanged;
            View.AddSubview(_datePicker);

            // Create age label
            _ageLabel = new UILabel();
            View.AddSubview(_ageLabel);

            // Create western zodiac sign label
            _westernZodiacSignLabel = new UILabel();
            View.AddSubview(_westernZodiacSignLabel);

            // Create Chinese zodiac sign label
            _chineseZodiacSignLabel = new UILabel();
            View.AddSubview(_chineseZodiacSignLabel);
        }

        public override void ViewDidLayoutSubviews()
        {
            base.ViewDidLayoutSubviews();

            // Layout subviews
            _datePicker.Frame = new CGRect(20, 100, View.Frame.Width - 40, 50);
            _ageLabel.Frame = new CGRect(220, 60, View.Frame.Width - 40, 30);
            _westernZodiacSignLabel.Frame = new CGRect(220, 100, View.Frame.Width - 40, 30);
            _chineseZodiacSignLabel.Frame = new CGRect(220, 140, View.Frame.Width - 40, 30);
        }

        private async void DatePickerValueChanged(object sender, EventArgs e)
        {
            var selectedDate = (DateTime)_datePicker.Date;
            _viewModel.SelectedDate = selectedDate;
            _ageLabel.Text = $"Age: {_viewModel.Age}";
            _westernZodiacSignLabel.Text = $"Western Zodiac Sign: {_viewModel.WesternZodiacSign}";
            _chineseZodiacSignLabel.Text = $"Chinese Zodiac Sign: {_viewModel.ChineseZodiacSign}";
            
            if (selectedDate.Day == DateTime.Today.Day && selectedDate.Month == DateTime.Today.Month)
            {
                // Display congratulations message
                var alert = UIAlertController.Create("Happy Birthday!", null, UIAlertControllerStyle.Alert);
                await PresentViewControllerAsync(alert, true);
                
                await Task.Delay(3000);
                await alert.DismissViewControllerAsync(true);
            }
        }
    }
}
