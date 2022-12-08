<Query Kind="Program">
  <NuGetReference>CSCore</NuGetReference>
  <Namespace>System.Threading.Tasks</Namespace>
  <Namespace>System.Windows.Forms</Namespace>
  <Namespace>CSCore.CoreAudioAPI</Namespace>
  <Namespace>System.Runtime.InteropServices</Namespace>
</Query>

const int VIRTUALKEY = 0x74; //F5
const string processName = "";
Random rnd = new Random();

async Task Main()
{
	var c = 0;
	using (var enumerator = new MMDeviceEnumerator())
	using (var meter = AudioMeterInformation.FromDevice(enumerator.GetDefaultAudioEndpoint(DataFlow.Render, Role.Console)))
	{
		while (true)
		{
			await Task.Delay(500);
			Util.ClearResults();
			var p = (meter.PeakValue * 1000).Dump();
			if (p > 40)
			{
				c = 0;
				true.Dump();
				await Task.Delay(rnd.Next(10)*200);
				Click();
				await Task.Delay(rnd.Next(5)*2000);
				Click();
				await Task.Delay(2000);
			}
			else
			{
				c++;
				if(c >= 50){
					Click();
					c = 0;
				}
			}
			
		}
	}
}

public void Click()
{
	Process[] processes = Process.GetProcessesByName(processName);

	foreach (Process proc in processes)
	{
		PostMessage(proc.MainWindowHandle, WM_KEYDOWN, VIRTUALKEY, 0);
		PostMessage(proc.MainWindowHandle, WM_KEYUP, VIRTUALKEY, 0);
	}
}

const UInt32 WM_KEYDOWN = 0x0100;
const UInt32 WM_KEYUP = 0x0101;

[DllImport("user32.dll")]
static extern bool PostMessage(IntPtr hWnd, UInt32 Msg, int wParam, int lParam);
// You can define other methods, fields, classes and namespaces here