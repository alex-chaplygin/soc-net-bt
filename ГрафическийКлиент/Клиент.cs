using System;
using System.IO;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ГрафическийКлиент
{
    class Клиент
    {
        static string ip;
        static int port;
        public Клиент(string n, int p)
        {
            ip = n;
            port = p;
        }

        public string ОтправитьПолучить(string запрос)
        {
            TcpClient client = new TcpClient(ip, port);
            NetworkStream stream = client.GetStream();
            StreamReader reader = new StreamReader(stream);
            StreamWriter writer = new StreamWriter(stream) { AutoFlush = true };
            writer.WriteLine(запрос);
            string all = "";
            string line;
            while ((line = reader.ReadLine()) != null)
                all += line + "\n";
            reader.Close();
            writer.Close();
            client.Close();
            return all.Substring(0, all.Length - 1);
        }
    }
}


