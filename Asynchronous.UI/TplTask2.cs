namespace Asynchronous.UI
{
    using System;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    public partial class TplTask2 : Form
    {
        private delegate void UpdateControl(string message, string response);

        public TplTask2()
        {
            InitializeComponent();
        }

        private void btnLaunch_Click(object sender, EventArgs e)
        {
            var task = Task.Run(() => "Async task is running");

            var response = task.Result; //causes a blocking here since it waits for the result from task

            task.ContinueWith(t =>
            {
                //async task completed
                //prevent cross thread exception by invoking delegate which runs on UI thread
                BeginInvoke(new UpdateControl(UpdateTextBox), "Completed",response);
            });
        }

        private void UpdateTextBox(string message, string response)
        {
            txtStatus.Text = message + @" Response : "+response;

        }
    }
}
