using ServerMQTT_Lora.DBWorking;
using System;
using System.Runtime.InteropServices;

namespace ServerMQTT_Lora
{
    public class Program
    {
        internal delegate void SignalHandler(ConsoleSignal consoleSignal);

        internal enum ConsoleSignal
        {
            CtrlC = 0,
            CtrlBreak = 1,
            Close = 2,
            LogOff = 5,
            Shutdown = 6
        }

        internal static class ConsoleHelper
        {
            [DllImport("Kernel32", EntryPoint = "SetConsoleCtrlHandler")]
            public static extern bool SetSignalHandler(SignalHandler handler, bool add);
        }

        private static SignalHandler signalHandler;

        static void Main(string[] args)
        {
            ConnectMqtt connect = new ConnectMqtt();
            PublishInfo pubInfo = new PublishInfo();
            ConfigXMLReader runXml = new ConfigXMLReader();
            signalHandler += HandleConsoleSignal;
            ConsoleHelper.SetSignalHandler(signalHandler, true);

            connect.MqttConnect(runXml.XMLReader());
            //pubInfo.PublishMessage(); class for sending message on Mqtt broker server for choosen topic

            Console.ReadKey();
        }
        private static void HandleConsoleSignal(ConsoleSignal consoleSignal)
        {
            ConnectMqtt connect = new ConnectMqtt();

            connect.DisconnectMqtt(connect.client);
        }
    }
}
