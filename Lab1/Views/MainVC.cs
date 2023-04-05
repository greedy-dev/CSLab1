// using Lab1.ViewModels;

using Lab1.ViewModels;
using ObjCRuntime;

namespace Lab1.Views
{
    public class MainVC : UIViewController
    {
        private PersonViewModel _viewModel;
        
        private UITextField _firstNameTextField;
        private UITextField _lastNameTextField;
        private UITextField _emailTextField;
        private UIDatePicker _datePicker;
        private UIButton _proceedButton;
        private UILabel _isAdultLabel;
        private UILabel _sunSignLabel;
        private UILabel _chineseSignLabel;
        private UILabel _isBirthdayLabel;

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            _viewModel = new PersonViewModel();
            
            // Create UI elements
            _firstNameTextField = new UITextField();
            _firstNameTextField.Placeholder = "First Name";
            _firstNameTextField.BorderStyle = UITextBorderStyle.RoundedRect;
            _firstNameTextField.AddTarget(Self, new Selector("FirstNameTextFieldEditingChanged"), UIControlEvent.EditingChanged);
            _firstNameTextField.TranslatesAutoresizingMaskIntoConstraints = false;

            _lastNameTextField = new UITextField();
            _lastNameTextField.Placeholder = "Last Name";
            _lastNameTextField.BorderStyle = UITextBorderStyle.RoundedRect;
            _lastNameTextField.AddTarget(Self, new Selector("LastNameTextFieldEditingChanged"), UIControlEvent.EditingChanged);
            _lastNameTextField.TranslatesAutoresizingMaskIntoConstraints = false;

            _emailTextField = new UITextField();
            _emailTextField.Placeholder = "Email";
            _emailTextField.BorderStyle = UITextBorderStyle.RoundedRect;
            _emailTextField.KeyboardType = UIKeyboardType.EmailAddress;
            _emailTextField.AddTarget(Self, new Selector("EmailTextFieldEditingChanged"), UIControlEvent.EditingChanged);
            _emailTextField.TranslatesAutoresizingMaskIntoConstraints = false;

            _datePicker = new UIDatePicker();
            _datePicker.Mode = UIDatePickerMode.Date;
            _datePicker.AddTarget(Self, new Selector("DatePickerValueChanged"), UIControlEvent.ValueChanged);
            _datePicker.TranslatesAutoresizingMaskIntoConstraints = false;
            _datePicker.Date = NSDate.Now;
            _viewModel.DateOfBirth = ((DateTime)_datePicker.Date).Date;

            _proceedButton = new UIButton();
            _proceedButton.Layer.CornerRadius = 8;
            _proceedButton.BackgroundColor = UIColor.SystemBlue;
            _proceedButton.SetTitle("Proceed", UIControlState.Normal);
            _proceedButton.Enabled = true;
            _proceedButton.AddTarget(Self, new Selector("ProceedButtonPressed"), UIControlEvent.TouchUpInside);
            _proceedButton.TranslatesAutoresizingMaskIntoConstraints = false;

            _isAdultLabel = new UILabel();
            _sunSignLabel = new UILabel();
            _chineseSignLabel = new UILabel();
            _isBirthdayLabel = new UILabel();

            // Add UI elements to view hierarchy
            var stackView = new UIStackView(new UIView[]
            {
                _firstNameTextField, _lastNameTextField, _emailTextField, _datePicker, _lastNameTextField,
                _emailTextField, _datePicker, _proceedButton
            });
            stackView.TranslatesAutoresizingMaskIntoConstraints = false;
            stackView.Spacing = 10;
            stackView.Axis = UILayoutConstraintAxis.Vertical;
            View.AddSubview(stackView);
            stackView.WidthAnchor.ConstraintEqualTo(200).Active = true;
            stackView.TopAnchor.ConstraintEqualTo(View.SafeAreaLayoutGuide.TopAnchor, constant: 25).Active = true;
            stackView.CenterXAnchor.ConstraintEqualTo(View.CenterXAnchor).Active = true;

            _isAdultLabel.TranslatesAutoresizingMaskIntoConstraints = false;
            _sunSignLabel.TranslatesAutoresizingMaskIntoConstraints = false;
            _chineseSignLabel.TranslatesAutoresizingMaskIntoConstraints = false;
            _isBirthdayLabel.TranslatesAutoresizingMaskIntoConstraints = false;
            
            _isAdultLabel.Hidden = true;
            _sunSignLabel.Hidden = true;
            _chineseSignLabel.Hidden = true;
            _isBirthdayLabel.Hidden = true;

            View.AddSubview(_isAdultLabel);
            View.AddSubview(_sunSignLabel);
            View.AddSubview(_chineseSignLabel);
            View.AddSubview(_isBirthdayLabel);

            _isAdultLabel.CenterXAnchor.ConstraintEqualTo(View.CenterXAnchor).Active = true;
            _isAdultLabel.TopAnchor.ConstraintEqualTo(stackView.BottomAnchor, constant: 20).Active = true;

            _sunSignLabel.CenterXAnchor.ConstraintEqualTo(View.CenterXAnchor).Active = true;
            _sunSignLabel.TopAnchor.ConstraintEqualTo(_isAdultLabel.BottomAnchor, constant: 20).Active = true;

            _chineseSignLabel.CenterXAnchor.ConstraintEqualTo(View.CenterXAnchor).Active = true;
            _chineseSignLabel.TopAnchor.ConstraintEqualTo(_sunSignLabel.BottomAnchor, constant: 20).Active = true;

            _isBirthdayLabel.CenterXAnchor.ConstraintEqualTo(View.CenterXAnchor).Active = true;
            _isBirthdayLabel.TopAnchor.ConstraintEqualTo(_chineseSignLabel.BottomAnchor, constant: 20).Active = true;
        }

        [Export("FirstNameTextFieldEditingChanged")]
        private void FirstNameTextFieldEditingChanged()
        {
            _viewModel.FirstName = _firstNameTextField.Text;
        }
        
        [Export("LastNameTextFieldEditingChanged")]
        private void LastNameTextFieldEditingChanged()
        {
            _viewModel.LastName = _lastNameTextField.Text;
        }
        
        [Export("EmailTextFieldEditingChanged")]
        private void EmailTextFieldEditingChanged()
        {
            _viewModel.Email = _emailTextField.Text;
        }

        [Export("DatePickerValueChanged")]
        private void DatePickerValueChanged()
        {
            _viewModel.DateOfBirth = ((DateTime)_datePicker.Date).Date;
        }
        
        [Export("ProceedButtonPressed")]
        private async void ProceedButtonPressed()
        {
            // Disable UI while processing
            _proceedButton.Enabled = false;
            View.EndEditing(true);

            var result = await _viewModel.ProcessAsync();

            Console.WriteLine(_datePicker.Date);
            if (result.IsSuccess)
            {
                InvokeOnMainThread(() =>
                {
                    _isAdultLabel.Text = $"Is Adult: {_viewModel.IsAdult}";
                    _sunSignLabel.Text = $"Western Sign: {_viewModel.SunSign}";
                    _chineseSignLabel.Text = $"Chinese Sign: {_viewModel.ChineseSign}";
                    _isBirthdayLabel.Text = $"Is Birthday: {_viewModel.IsBirthday}";

                    _isAdultLabel.Hidden = false;
                    _sunSignLabel.Hidden = false;
                    _chineseSignLabel.Hidden = false;
                    _isBirthdayLabel.Hidden = false;
                });
            }
            else
            {
                var alert = UIAlertController.Create("Error", result.ErrorMessage, UIAlertControllerStyle.Alert);
                alert.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                PresentViewController(alert, true, null);
            }
            
            _proceedButton.Enabled = true;
        }

    }
}