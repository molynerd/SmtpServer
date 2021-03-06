﻿using System.Threading;
using SmtpServer;

namespace SampleApp.Examples
{
    public static class SimpleExample
    {
        public static void Run()
        {
            var cancellationTokenSource = new CancellationTokenSource();

            var options = new OptionsBuilder()
                .ServerName("SmtpServer SampleApp")
                .Port(9025)
                .AuthenticationRequired()
                .Build();

            var server = new SmtpServer.SmtpServer(options);
            var serverTask = server.StartAsync(cancellationTokenSource.Token);

            SampleMailClient.Send(); 

            cancellationTokenSource.Cancel();
            serverTask.WaitWithoutException();
        }
    }
}