using System.Diagnostics;
using UqudoSDK;

namespace UqudoSampleApp;

[Register("AppDelegate")]
public class AppDelegate : UIApplicationDelegate
{
    public override UIWindow? Window { get; set; }

    private UIViewController? _rootViewController;

    public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
    {
        // Initialize the Uqudo SDK with analytics tracer
        var tracer = new Tracer();
        new UQBuilderController(tracer);

        Window = new UIWindow(UIScreen.MainScreen.Bounds);

        _rootViewController = new UIViewController();
        _rootViewController.View!.BackgroundColor = UIColor.SystemBackground;

        // Title label
        var titleLabel = new UILabel
        {
            Text = "Uqudo SDK Sample",
            TextAlignment = UITextAlignment.Center,
            Font = UIFont.BoldSystemFontOfSize(24),
            TranslatesAutoresizingMaskIntoConstraints = false
        };
        _rootViewController.View.AddSubview(titleLabel);

        // Start Enrollment button
        var enrollButton = UIButton.FromType(UIButtonType.System);
        enrollButton.SetTitle("Start Enrollment", UIControlState.Normal);
        enrollButton.TitleLabel!.Font = UIFont.SystemFontOfSize(18);
        enrollButton.BackgroundColor = UIColor.SystemBlue;
        enrollButton.SetTitleColor(UIColor.White, UIControlState.Normal);
        enrollButton.Layer.CornerRadius = 10;
        enrollButton.TranslatesAutoresizingMaskIntoConstraints = false;
        enrollButton.TouchUpInside += OnEnrollButtonTapped;
        _rootViewController.View.AddSubview(enrollButton);

        // Layout constraints
        NSLayoutConstraint.ActivateConstraints(new[]
        {
            titleLabel.CenterXAnchor.ConstraintEqualTo(_rootViewController.View.CenterXAnchor),
            titleLabel.TopAnchor.ConstraintEqualTo(_rootViewController.View.SafeAreaLayoutGuide.TopAnchor, 50),

            enrollButton.CenterXAnchor.ConstraintEqualTo(_rootViewController.View.CenterXAnchor),
            enrollButton.CenterYAnchor.ConstraintEqualTo(_rootViewController.View.CenterYAnchor),
            enrollButton.WidthAnchor.ConstraintEqualTo(200),
            enrollButton.HeightAnchor.ConstraintEqualTo(50)
        });

        Window.RootViewController = _rootViewController;
        Window.MakeKeyAndVisible();

        return true;
    }

    // Keep strong references to prevent GC of weak ObjC delegates
    private EnrollmentDelegate? _enrollmentDelegate;
    private BuilderControllerDelegate? _builderDelegate;

    private void OnEnrollButtonTapped(object? sender, EventArgs e)
    {
        Debug.WriteLine("Starting Uqudo Enrollment...");

        // TODO: Replace with your actual access token
        string accessToken = "YOUR_ACCESS_TOKEN_HERE";

        try
        {
            // Create document config (UAE ID in this example)
            var documentConfig = new UQDocumentConfig((nint)DocumentTypeID.UaeId);

            // Enable NFC reading
            var readingConfig = documentConfig.Reading;
            readingConfig.EnableReading = true;

            // Create facial recognition config
            var facialConfig = new UQFacialRecognitionConfig();
            facialConfig.MinimumMatchLevel = 3;

            // Keep delegates alive (ObjC properties are weak)
            _enrollmentDelegate = new EnrollmentDelegate();
            _builderDelegate = new BuilderControllerDelegate();

            // Create enrollment builder
            var enrollmentBuilder = new UQEnrollmentBuilder();
            enrollmentBuilder.AuthorizationToken = accessToken;
            enrollmentBuilder.AppViewController = _rootViewController!;
            enrollmentBuilder.FacialRecognitionConfig = facialConfig;
            enrollmentBuilder.Delegate = _enrollmentDelegate;

            // Add document to scan
            enrollmentBuilder.Add(documentConfig);

            // Create the builder controller and perform enrollment
            // Note: DefaultBuilder() returns null, use constructor instead
            var builderController = new UQBuilderController();
            builderController.AppViewController = _rootViewController!;
            builderController.Delegate = _builderDelegate;
            builderController.SetEnrollment(enrollmentBuilder);

            // Start the enrollment flow
            builderController.PerformEnrollment();
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error starting enrollment: {ex.Message}");
            ShowAlert("Error", ex.Message);
        }
    }

    private void ShowAlert(string title, string message)
    {
        var alert = UIAlertController.Create(title, message, UIAlertControllerStyle.Alert);
        alert.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
        _rootViewController?.PresentViewController(alert, true, null);
    }
}
