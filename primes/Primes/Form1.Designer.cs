namespace Primes
{
    partial class Form1
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
            this.OkButton = new System.Windows.Forms.Button();
            this.Value = new System.Windows.Forms.NumericUpDown();
            this.TaskPanel = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.Value)).BeginInit();
            this.SuspendLayout();
            // 
            // OkButton
            // 
            this.OkButton.Location = new System.Drawing.Point(494, 170);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(138, 23);
            this.OkButton.TabIndex = 0;
            this.OkButton.Text = "OK";
            this.OkButton.UseVisualStyleBackColor = true;
            this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // Value
            // 
            this.Value.Location = new System.Drawing.Point(494, 131);
            this.Value.Maximum = new decimal(new int[] {
            1241513984,
            370409800,
            542101,
            0});
            this.Value.Name = "Value";
            this.Value.Size = new System.Drawing.Size(138, 20);
            this.Value.TabIndex = 2;
            // 
            // TaskPanel
            // 
            this.TaskPanel.AutoScroll = true;
            this.TaskPanel.Location = new System.Drawing.Point(12, 12);
            this.TaskPanel.Name = "TaskPanel";
            this.TaskPanel.Size = new System.Drawing.Size(476, 310);
            this.TaskPanel.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 334);
            this.Controls.Add(this.TaskPanel);
            this.Controls.Add(this.Value);
            this.Controls.Add(this.OkButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.Value)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button OkButton;
        private System.Windows.Forms.NumericUpDown Value;
        private System.Windows.Forms.FlowLayoutPanel TaskPanel;
    }
}

