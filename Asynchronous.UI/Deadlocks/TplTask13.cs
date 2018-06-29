using System.Threading;

namespace Asynchronous.UI
{
    using System;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    public partial class TplTask13 : Form
    {
        public TplTask13()
        {
            InitializeComponent();
        }

        delegate void Mydelegate();

        private void Method()
        {
            
        }

        private async void btnLaunch_Click(object sender, EventArgs e)
        {
            Mydelegate del = new Mydelegate(Method);
            try
            {
               var task= Task.Delay(1).ContinueWith(t =>
                {
                    BeginInvoke(null); //delegate does nothing. Invoke the UI. Task cannot complete until UI is complete
                });

                task.Wait(); //force wait until task is completed. 
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
