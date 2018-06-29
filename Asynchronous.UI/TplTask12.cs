using System.Threading;

namespace Asynchronous.UI
{
    using System;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    public partial class TplTask12 : Form
    {
        public TplTask12()
        {
            InitializeComponent();
        }


        private async void btnLaunch_Click(object sender, EventArgs e)
        {
            try 
            {
                var result = await RunTask(); //validate that the async operation completed properly

                await Task.Delay(1);
                txtStatus.Text = "Task 1 done";
                await Task.Delay(1); //grab result from awaiter and then set value. check if 3rd awaiter completed according to state machine. Continuations are scheduled on 
                //the caller thread
                txtStatus.Text = "Task 2 done";
                await Task.Delay(1);
                txtStatus.Text = "Task 3 done";
                await Task.Delay(1);
                txtStatus.Text = "Task 4 done";
                await Task.Delay(1);
                txtStatus.Text = "Task 5 done";
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
