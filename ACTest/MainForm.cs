using System;
using System.Windows.Forms;
using CSharpACLib;


namespace ACTest
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            var config = new Configuration
            {
                BaseApiUrl = "https://acs.sersoftin.xyz/",
                PublicKeyHash =
                    new byte[]
                    {
                        0x9F, 0x71, 0x41, 0x48, 0x67,
                        0x18, 0x73, 0xCE, 0x77, 0x1B,
                        0xE6, 0x14, 0x0C, 0x25, 0x22,
                        0xB1, 0x4D, 0xDA, 0xF5, 0x12
                    },
                ProductId = 1,
                HashSalt = "TestHash"
            };
            var accessControl = new AccessControl(config);
            if (accessControl.AccessAllowed()) return;
            MessageBox.Show("Вы не имеете права на использование этого продукта.", "Ошибка", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            Application.Exit();
        }
    }
}
