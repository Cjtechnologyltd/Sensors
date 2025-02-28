namespace Sensors;

public partial class MainPage : ContentPage
{
    int count = 0;

    public MainPage()
    {
        InitializeComponent();
    }

    private void OnCounterClicked(object sender, EventArgs e)
    {
        count++;

        if (count == 1)
            CounterBtn.Text = $"Clicked {count} time";
        else
            CounterBtn.Text = $"Clicked {count} times";

        SemanticScreenReader.Announce(CounterBtn.Text);
    }

    private void OnAccelClicked(object sender, EventArgs e)
    {
        if (Accelerometer.Default.IsSupported)
        {
            if (!Accelerometer.Default.IsMonitoring)
            {
                // Turn on accelerometer
                Accelerometer.Default.ReadingChanged += Accelerometer_ReadingChanged;
                Accelerometer.Default.Start(SensorSpeed.UI);
            }
            else
            {
                // Turn off accelerometer
                Accelerometer.Default.Stop();
                Accelerometer.Default.ReadingChanged -= Accelerometer_ReadingChanged;
                AccelLabel.Text = $"Disabled";
            }
        }
        else
        {
            AccelLabel.Text = $"Unsupported";
        }
    }

    private void Accelerometer_ReadingChanged(object sender, AccelerometerChangedEventArgs e)
    {
        AccelLabel.Text = $"Accel: {e.Reading}";
    }

    private void ToggleGyroscope(object sender, EventArgs e)
    {
        if (Gyroscope.Default.IsSupported)
        {
            if (!Gyroscope.Default.IsMonitoring)
            {
                // Turn on gyroscope
                Gyroscope.Default.ReadingChanged += Gyroscope_ReadingChanged;
                Gyroscope.Default.Start(SensorSpeed.UI);
            }
            else
            {
                // Turn off gyroscope
                Gyroscope.Default.Stop();
                Gyroscope.Default.ReadingChanged -= Gyroscope_ReadingChanged;
            }
        }
    }
    private void Gyroscope_ReadingChanged(object sender, GyroscopeChangedEventArgs e)
    {
        // Update UI Label with gyroscope state
        GyroscopeLabel.TextColor = Colors.Green;
        GyroscopeLabel.Text = $"Gyroscope: {e.Reading}";
    }

    private void ToggleMagnetometer(object sender, EventArgs e)
    {
        if (Magnetometer.Default.IsSupported)
        {
            if (!Magnetometer.Default.IsMonitoring)
            {
                // Turn on magnetometer
                Magnetometer.Default.ReadingChanged += Magnetometer_ReadingChanged;
                Magnetometer.Default.Start(SensorSpeed.UI);
            }
            else
            {
                // Turn off magnetometer
                Magnetometer.Default.Stop();
                Magnetometer.Default.ReadingChanged -= Magnetometer_ReadingChanged;
            }
        }
    }
    private void Magnetometer_ReadingChanged(object sender, MagnetometerChangedEventArgs e)
    {
        // Update UI Label with magnetometer state
        MagnetometerLabel.TextColor = Colors.Green;
        MagnetometerLabel.Text = $"Magnetometer: {e.Reading}";
    }

    private void ToggleOrientation(object sender, EventArgs e)
    {
        if (OrientationSensor.Default.IsSupported)
        {
            if (!OrientationSensor.Default.IsMonitoring)
            {
                // Turn on orientation
                OrientationSensor.Default.ReadingChanged += Orientation_ReadingChanged;
                OrientationSensor.Default.Start(SensorSpeed.UI);
            }
            else
            {
                // Turn off orientation
                OrientationSensor.Default.Stop();
                OrientationSensor.Default.ReadingChanged -= Orientation_ReadingChanged;
            }
        }
    }

    private void Orientation_ReadingChanged(object sender, OrientationSensorChangedEventArgs e)
    {
        // Update UI Label with orientation state
        OrientationLabel.TextColor = Colors.Green;
        OrientationLabel.Text = $"Orientation: {e.Reading}";

    }

    private void OnSocketClicked(object sender, EventArgs e)
    {
        //await Navigation.PushAsync(new SocketPage());
    }
}