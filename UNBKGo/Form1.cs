using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using UNBKGo.Service.Net;

namespace UNBKGo
{
    public partial class Form1 : Form
    {
        private Thread _thread;
        private UnbkClient _client;

        public Form1()
        {
            InitializeComponent();

            _thread = new Thread(ConnectThread) {IsBackground = true};
            _thread.Start();
        }

        private async void ConnectThread()
        {
            var client = await UnbkClient.SearchServer();
            _client.ConfigArrived += Client_ConfigArrived;
            _client.ExambroStartRequested += Client_ExambroStartRequested;
            _client.ExambroUpdateRequested += Client_ExambroUpdateRequested;
            _client.MachineShutdown += Client_MachineShutdown;

            Invoke(new Action(() =>
            {
                lblStatus.Text = "Connected.";
                lblImgStatus.ForeColor = Color.GreenYellow;
            }));
        }

        private void Client_MachineShutdown(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Client_ExambroUpdateRequested(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Client_ExambroStartRequested(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Client_ConfigArrived(object sender, ConfigArrivedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void cmdUseAuto_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void cmdApply_Click(object sender, EventArgs e)
        {

        }
    }
}
