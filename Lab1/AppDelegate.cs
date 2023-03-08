using Lab1.Views;

namespace Lab1;

[Register("AppDelegate")]
public class AppDelegate : UIApplicationDelegate
{
    public override UIWindow? Window { get; set; }

    public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
    {
        // create a new window instance based on the screen size
        Window = new UIWindow(UIScreen.MainScreen.Bounds);
        

        var mainVC = new MainVC();
        Window.RootViewController = mainVC;

        // make the window visible
        Window.MakeKeyAndVisible();

        return true;
    }
}