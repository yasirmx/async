namespace Asynchronous.UI
{
    using System;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    public partial class TplTask3 : Form
    {
        public TplTask3()
        {
            InitializeComponent();
        }

        private void btnLaunch_Click(object sender, EventArgs e)
        {
            var task = Task.Run(() => "Async task is running");

            //configure await:configure where to try and execute the continuation
            //run continuation on UI thread
            task.ConfigureAwait(true)
                .GetAwaiter()
                .OnCompleted( //schedule a continuation
                    ()=>UpdateTextBox("Running from GetAwaiter",task.Result)
                );
        }

        private void UpdateTextBox(string message, string response)
        {
            txtStatus.Text = message + @" Response : "+response;

        }
    }
}
