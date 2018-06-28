﻿namespace Asynchronous.UI
{
    using System;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    public partial class TplTask6 : Form
    {
        public TplTask6()
        {
            InitializeComponent();
        }


        private async void btnLaunch_Click(object sender, EventArgs e)
        {
            try
            {
                var result = await RunTask().ConfigureAwait(false);//statements below will no longer execute on UI thread, i.e cross thread exception

                //execute continuation in UI thread
                txtStatus.Text = result;
            }
            catch (Exception)
            {
                txtStatus.Text = "Login Failed";
            }
        }

        //Task = state machine can track the state
        private async Task<string> RunTask()
        {
            //async: state machine catches exception and sets the state somewhere
                var result = await Task.Run(() => {
                    
                    return "Login";
                });

                return result;
                //await = everything below executed when task is completed

        }
    }
}
