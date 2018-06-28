namespace Asynchronous.UI
{
    using System;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    public partial class TplTask8 : Form
    {
        public TplTask8()
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
                txtStatus.Text = @"Login Failed";
            }
        }

        //Task = state machine can track the state
        private async Task<string> RunTask()
        {
            var task1 = Task.Run(() => {
                    
                    return "Login";
                });

            //scheduled 3 async tasks simultaneously

            //UI thread
            var task2 =  Task.Delay(2000); //simulate login

            //UI thread
            var task3 = Task.Delay(2000); //fetch other tasks

            await Task.WhenAll(task1, task2, task3);

            return task1.Result; //return result when all tasks complete or schedule continuation when all tasks complete.. no need to block
        }
    }
}
