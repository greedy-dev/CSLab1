using System;

using UIKit;
using Foundation;

namespace Lab1.Views;

[Register("MainVC")]
public partial class MainVC : UIViewController
{
    private UILabel _label;
    public MainVC() : base()
    {
        
    }

    public override void LoadView()
    {
        base.LoadView();
    }

    public override void ViewDidLoad()
    {
        base.ViewDidLoad();
        // Perform any additional setup after loading the view, typically from a nib.
        _label = new UILabel
        {
            BackgroundColor = UIColor.SystemBackground,
            TextAlignment = UITextAlignment.Center,
            Text = "Hello, world!",
            AutoresizingMask = UIViewAutoresizing.All,
        };

        View = new UIView();

        _label.TranslatesAutoresizingMaskIntoConstraints = false;
        View.AddSubview(_label);
        View.AddConstraints(new[]
        {
            _label.CenterXAnchor.ConstraintEqualTo(View.CenterXAnchor),
            _label.CenterYAnchor.ConstraintEqualTo(View.CenterYAnchor)
        });
    }

    public override void DidReceiveMemoryWarning()
    {
        base.DidReceiveMemoryWarning();
        // Release any cached data, images, etc that aren't in use.
    }
}