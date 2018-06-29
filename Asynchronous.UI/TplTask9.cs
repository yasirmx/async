using System.Threading;

namespace Asynchronous.UI
{
    using System;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    public partial class TplTask9 : Form
    {
        public TplTask9()
        {
            InitializeComponent();
        }


        private async void btnLaunch_Click(object sender, EventArgs e)
        {
            try
            {
                var result = await RunTask(); //validate that the async operation completed properly

                //execute continuation in UI thread
                txtStatus.Text = result;
            }
            catch (Exception)
            {
                txtStatus.Text = @"Login Failed";
            }
        }

        //Task = state machine can track the state
        private Task<string> RunTask()
        {
            try
            {
                var task1 = Task.Run(() =>
                {
                    Thread.Sleep(2000);
                    return "Login";
                });

                return  task1; //we use await keyword to validate the task, grab result and return to the caller
            }
            catch (Exception)
            {

                return Task.FromResult("Login Failed");
            }
        }
    }
}
