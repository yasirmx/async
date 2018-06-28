namespace Asynchronous.UI
{
    using System;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    public partial class TplTask4 : Form
    {
        public TplTask4()
        {
            InitializeComponent();
        }

        /// <summary>
        /// compiler knows that the method can schedule an asynchronous operation 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnLaunch_Click(object sender, EventArgs e)
        {
            //can schedule continuation inside method's body

            var result = await Task.Run(() => { return "successful"; });

            //await = everything below executed when task is completed
            txtStatus.Text = result;
        }

        private void UpdateTextBox(string message, string response)
        {
            txtStatus.Text = message + @" Response : "+response;

        }
    }
}
