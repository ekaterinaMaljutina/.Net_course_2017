namespace Primes
{
    partial class Item
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

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.CancelButtom = new System.Windows.Forms.Button();
            this.ValueTextBox = new System.Windows.Forms.TextBox();
            this.ProgressBarItem = new System.Windows.Forms.ProgressBar();
            this.StateLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // CancelButtom
            // 
            this.CancelButtom.Location = new System.Drawing.Point(380, 3);
            this.CancelButtom.Name = "CancelButtom";
            this.CancelButtom.Size = new System.Drawing.Size(65, 25);
            this.CancelButtom.TabIndex = 0;
            this.CancelButtom.Text = "Cancel";
            this.CancelButtom.UseVisualStyleBackColor = true;
            this.CancelButtom.Click += new System.EventHandler(this.CancelButtom_Click);
            // 
            // ValueTextBox
            // 
            this.ValueTextBox.Location = new System.Drawing.Point(0, 6);
            this.ValueTextBox.Name = "ValueTextBox";
            this.ValueTextBox.Size = new System.Drawing.Size(154, 20);
            this.ValueTextBox.TabIndex = 1;
            // 
            // ProgressBarItem
            // 
            this.ProgressBarItem.Location = new System.Drawing.Point(274, 0);
            this.ProgressBarItem.Name = "ProgressBarItem";
            this.ProgressBarItem.Size = new System.Drawing.Size(100, 31);
            this.ProgressBarItem.TabIndex = 2;
            // 
            // StateLabel
            // 
            this.StateLabel.AutoSize = true;
            this.StateLabel.Location = new System.Drawing.Point(160, 10);
            this.StateLabel.Name = "StateLabel";
            this.StateLabel.Size = new System.Drawing.Size(0, 13);
            this.StateLabel.TabIndex = 3;
            // 
            // Item
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.StateLabel);
            this.Controls.Add(this.ProgressBarItem);
            this.Controls.Add(this.ValueTextBox);
            this.Controls.Add(this.CancelButtom);
            this.Name = "Item";
            this.Size = new System.Drawing.Size(445, 31);
            this.Load += new System.EventHandler(this.Item_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CancelButtom;
        private System.Windows.Forms.TextBox ValueTextBox;
        private System.Windows.Forms.ProgressBar ProgressBarItem;
        private System.Windows.Forms.Label StateLabel;
    }
}
