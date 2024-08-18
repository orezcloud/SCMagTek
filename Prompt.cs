using System.Windows.Forms;

namespace SCMagTek
{
    public static class Prompt
    {
        public static bool ShowDialog(string text, string caption)
        {
            Form prompt = new Form()
            {
                Width = 500,
                Height = 150,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = caption,
                StartPosition = FormStartPosition.CenterScreen
            };
            Label textLabel = new Label() {Left = 50, Top = 20, Text = text};
            Button confirmation = new Button()
                {Text = "Ok", Left = 350, Width = 100, Top = 70, DialogResult = DialogResult.OK};
            Button cancellation = new Button()
                {Text = "Cancel", Left = 200, Width = 90};
            confirmation.Click += (sender, e) => { prompt.Close(); };
            cancellation.Click += (sender, e) => { prompt.Close(); };
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);
            prompt.Controls.Add(cancellation);
            prompt.AcceptButton = confirmation;

            return prompt.ShowDialog() == DialogResult.OK;
        }
    }
}
// bool promptValue = Prompt.ShowDialog("Test", "123");