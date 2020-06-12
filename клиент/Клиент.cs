using System;
using System.IO;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace СоцСеть {
    class Клиент {
	public static void Main(string[] args)
	{
	    if (args.Length < 2) {
		Console.WriteLine("Клиент адрес <порт>");
		return;
	    }
	    int port = Convert.ToInt32(args[1]);

	    while (true)
	    {
		TcpClient client = new TcpClient(args[0], port);      				
		NetworkStream stream = client.GetStream();
		StreamReader reader = new StreamReader(stream);
		StreamWriter writer = new StreamWriter(stream) { AutoFlush = true };
		string lineToSend = Console.ReadLine();
		writer.WriteLine(lineToSend);
		string all = "";
		string line;
		while ((line = reader.ReadLine()) != null)
		    all += line + "\n";
		Console.WriteLine(all.Substring(0, all.Length - 1));
		reader.Close();
		writer.Close();
		client.Close();
	    }
	}
    }
}
