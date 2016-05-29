using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CSharpACLib;

namespace ACTestApplication
{
    public partial class MainForm : Form
    {
        private AccessControl _acc;
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

            _acc = new AccessControl(config);

            ProductsCombobox.DataSource = _acc.GetProducts();

            ProductsCombobox.DisplayMember = "Name";
            ProductsCombobox.ValueMember = "Id";
        }

        private void SubmitBidButton_Click(object sender, EventArgs e)
        {
            try
            {
                var bid = _acc.RequestAccess((int)ProductsCombobox.SelectedValue);
                BidIdTextBox.Text = $"Номер заявки: {bid.Id}";
            }
            catch (Exception exception)
            {
                MessageBox.Show($"Произошла ошибка при запросе доступа: {exception.Message}");
            }
        }
    }
}
