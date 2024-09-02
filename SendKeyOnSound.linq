<Query Kind="Program">
  <NuGetReference>CSCore</NuGetReference>
  <Namespace>System.Threading.Tasks</Namespace>
  <Namespace>System.Windows.Forms</Namespace>
  <Namespace>CSCore.CoreAudioAPI</Namespace>
  <Namespace>System.Runtime.InteropServices</Namespace>
</Query>

const int VIRTUALKEY = 0x74; //F5
const string processName = "";
int treashold = 40;
Random rnd = new Random();
int timer = 500;
int maxRounds = 22;

async Task Main()
{
	var c = 0;
	Click();
	using (var enumerator = new MMDeviceEnumerator())
	using (var meter = AudioMeterInformation.FromDevice(enumerator.GetDefaultAudioEndpoint(DataFlow.Render, Role.Console)))
	{
		while (true)
		{
			await Task.Delay(timer);
			Util.ClearResults();
			var p = (meter.PeakValue * 1000).Dump();
			if (p > treashold)
			{
				c = 0;
				true.Dump();
				Click();
				await Task.Delay(2000);
				Click();
			}
			else
			{
				c++;
				if(c >= maxRounds*1000/timer){
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