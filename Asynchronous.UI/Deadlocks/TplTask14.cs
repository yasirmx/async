using System.Threading;

namespace Asynchronous.UI
{
    using System;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    public partial class TplTask14 : Form
    {
        public TplTask14()
        {
            InitializeComponent();
        }

        private void Method()
        {
            
        }

        private async void btnLaunch_Click(object sender, EventArgs e)
        {
            //async void will swallow exceptions. Better to wrap between try/catch
            try
            {
                var result = Task.Run(() => RunTask()).Result; //Runtask is run on UI Thread.
                //wait for RunTask to complete. if RunTask() is deadlocked, will keep waiting for result forever
                //.Result is root of evils
                //deadlock is caused by forcing a block on applications
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
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
