namespace Sensors;

using System.Net;
using System.Net.Sockets;

public partial class SocketPage : ContentPage
{
	private string _ipad_str;
	private Int32 _port;
	public SocketPage()
	{
		InitializeComponent();
	}

	async void OnConnectClicked(object sender, EventArgs e)
	{
        using Socket client = new(
            SocketType.Stream,
            ProtocolType.Tcp);

		try
		{
			await client.ConnectAsync(IPAddress.Parse(_ipad_str), _port);
		}
		catch (Exception ex)
		{
            Console.WriteLine($"Processing failed: {ex.Message}");
        }
    }

    private void OnIpAdCompleted(object sender, EventArgs e)
	{
        _ipad_str = ((Entry)sender).Text;
    }

	private void OnPortCompleted(object sender, EventArgs e)
	{
		_port = Int32.Parse(((Entry)sender).Text);
	}


}