using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SignalRClient
{
    public partial class WinFormsApp : Form
    {
        private HubConnection connection;

        public WinFormsApp()
        {
            InitializeComponent();
            SignalRConnection();
        }

        public async void SignalRConnection()
        {
            connection = new HubConnectionBuilder()
                  .WithUrl("http://localhost:5000/signalr/chatHub")
                  .Build();
            await connection.StartAsync();
            connection.Closed += async (error) =>
            {
                await Task.Delay(new Random().Next(0, 5) * 1000);
                await connection.StartAsync();
            };
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                await connection.InvokeAsync("WinFormsApp", "SignalRClient", this.textBox1.Text);
                connection.On<object>("ReceiveUpdate", (message) =>
                {
                    this.Invoke(new Action(() =>
                    {
                        this.textBox2.Text = message.ToString();
                    }));
                });
            }
            catch (Exception ex)
            {
                this.textBox2.Text = ex.Message;
            }
        }
    }
}