using System;
using System.Threading.Tasks;
using System.Net;
using WebDAVClient;

namespace Tests
{
	class Program
	{
		IClient c;

		#region Main
		static void Main(string[] args)
		{
			Program p = new Program();
			p.Initialize();
			Console.ReadLine();
		}
		#endregion

		private async void Initialize()
		{
			c = new Client(new NetworkCredential { UserName = "ablos", Password = "AblosStack00" });
			c.Server = "https://ablos.stackstorage.com/";
			c.BasePath = "/remote.php/webdav/";
			await fetchFiles();
		}

		private async Task fetchFiles()
		{
			var files = await c.List();

			foreach (var file in files)
			{
				Console.WriteLine(file.DisplayName);
			}
		}
	}
}
