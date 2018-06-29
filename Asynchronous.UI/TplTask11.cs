using System.Threading;

namespace Asynchronous.UI
{
    using System;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    public partial class TplTask11 : Form
    {
        public TplTask11()
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
                txtStatus.Text = @"Login Failed from main";
            }
        }

        //Task = state machine can track the state
        private Task<string> RunTask()
        {
            try
            {
                var task1 = Task.Run(async () => //asynchronous anonymous method. Everytime we use the async keyword, we introduce a state machine
                {
                    await Task.Delay(2000); //every time we use the await keyword, we're scheduling a continuation. 
                    //Everything below will be executed on the caller thread. Caller thread may not necessarily be a UI or main thread

                    return "Login successful";
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
