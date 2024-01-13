namespace Interfata_Procesor_Cache
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tracesSelector = new ListBox();
            startButton = new Button();
            SuspendLayout();
            // 
            // tracesSelector
            // 
            tracesSelector.FormattingEnabled = true;
            tracesSelector.Location = new Point(12, 12);
            tracesSelector.Name = "tracesSelector";
            tracesSelector.SelectionMode = SelectionMode.MultiExtended;
            tracesSelector.Size = new Size(243, 144);
            tracesSelector.TabIndex = 0;
            // 
            // startButton
            // 
            startButton.BackColor = Color.Green;
            startButton.FlatAppearance.BorderSize = 0;
            startButton.FlatStyle = FlatStyle.Popup;
            startButton.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            startButton.ForeColor = SystemColors.InfoText;
            startButton.Location = new Point(12, 162);
            startButton.Name = "startButton";
            startButton.Size = new Size(130, 40);
            startButton.TabIndex = 1;
            startButton.Text = "Start";
            startButton.UseVisualStyleBackColor = false;
            startButton.Click += this.startButton_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1224, 583);
            Controls.Add(startButton);
            Controls.Add(tracesSelector);
            Name = "MainForm";
            Text = "Interfata Procesor Cache";
            Load += MainForm_Load;
            ResumeLayout(false);
        }

        #endregion

        private ListBox tracesSelector;
        private Button startButton;
    }
}
