namespace ACTestApplication
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.BidIdTextBox = new System.Windows.Forms.TextBox();
            this.SubmitBidButton = new System.Windows.Forms.Button();
            this.ProductsCombobox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // BidIdTextBox
            // 
            this.BidIdTextBox.Location = new System.Drawing.Point(123, 12);
            this.BidIdTextBox.Name = "BidIdTextBox";
            this.BidIdTextBox.ReadOnly = true;
            this.BidIdTextBox.Size = new System.Drawing.Size(169, 20);
            this.BidIdTextBox.TabIndex = 0;
            // 
            // SubmitBidButton
            // 
            this.SubmitBidButton.Location = new System.Drawing.Point(298, 10);
            this.SubmitBidButton.Name = "SubmitBidButton";
            this.SubmitBidButton.Size = new System.Drawing.Size(112, 23);
            this.SubmitBidButton.TabIndex = 1;
            this.SubmitBidButton.Text = "Отправить заявку";
            this.SubmitBidButton.UseVisualStyleBackColor = true;
            this.SubmitBidButton.Click += new System.EventHandler(this.SubmitBidButton_Click);
            // 
            // ProductsCombobox
            // 
            this.ProductsCombobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ProductsCombobox.FormattingEnabled = true;
            this.ProductsCombobox.Location = new System.Drawing.Point(12, 12);
            this.ProductsCombobox.Name = "ProductsCombobox";
            this.ProductsCombobox.Size = new System.Drawing.Size(105, 21);
            this.ProductsCombobox.TabIndex = 2;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 45);
            this.Controls.Add(this.ProductsCombobox);
            this.Controls.Add(this.SubmitBidButton);
            this.Controls.Add(this.BidIdTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SubmitApp";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox BidIdTextBox;
        private System.Windows.Forms.Button SubmitBidButton;
        private System.Windows.Forms.ComboBox ProductsCombobox;
    }
}

