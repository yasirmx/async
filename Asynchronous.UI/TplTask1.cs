namespace Asynchronous.UI
{
    using System;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    public partial class TplTask1 : Form
    {
        private delegate void UpdateControl(string message);

        public TplTask1()
        {
            InitializeComponent();
        }

        private void btnLaunch_Click(object sender, EventArgs e)
        {
            var task = Task.Run(() => MessageBox.Show(@"Async task is running"));

            task.ContinueWith(t =>
            {
                //async task completed
                //prevent cross thread exception by invoking delegate which runs on UI thread
                BeginInvoke(new UpdateControl(UpdateTextBox), "Completed");
            });
        }

        private void UpdateTextBox(string message)
        {
            txtStatus.Text = message;
        }
    }
}
