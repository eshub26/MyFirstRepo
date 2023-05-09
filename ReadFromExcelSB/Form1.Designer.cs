namespace ReadFromExcelSB
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.reportPanel = new TheArtOfDev.HtmlRenderer.WinForms.HtmlPanel();
            this.btnLineMenReport = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.logTextBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1417, 580);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.reportPanel);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.btnLineMenReport);
            this.tabPage1.Location = new System.Drawing.Point(4, 37);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1409, 539);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Reports";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // reportPanel
            // 
            this.reportPanel.AutoScroll = true;
            this.reportPanel.BackColor = System.Drawing.SystemColors.Window;
            this.reportPanel.BaseStylesheet = null;
            this.reportPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.reportPanel.Location = new System.Drawing.Point(21, 70);
            this.reportPanel.Name = "reportPanel";
            this.reportPanel.Size = new System.Drawing.Size(1144, 430);
            this.reportPanel.TabIndex = 2;
            this.reportPanel.Text = null;
            // 
            // btnLineMenReport
            // 
            this.btnLineMenReport.BackColor = System.Drawing.Color.LightCoral;
            this.btnLineMenReport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLineMenReport.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnLineMenReport.Location = new System.Drawing.Point(21, 18);
            this.btnLineMenReport.Name = "btnLineMenReport";
            this.btnLineMenReport.Size = new System.Drawing.Size(198, 46);
            this.btnLineMenReport.TabIndex = 1;
            this.btnLineMenReport.Text = "Line Men Report";
            this.btnLineMenReport.UseVisualStyleBackColor = false;
            this.btnLineMenReport.Click += new System.EventHandler(this.btnSubmit_Click_1);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.logTextBox);
            this.tabPage2.Location = new System.Drawing.Point(4, 37);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1409, 539);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Log";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // logTextBox
            // 
            this.logTextBox.Font = new System.Drawing.Font("Segoe UI Historic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.logTextBox.ForeColor = System.Drawing.SystemColors.Highlight;
            this.logTextBox.Location = new System.Drawing.Point(38, 17);
            this.logTextBox.Multiline = true;
            this.logTextBox.Name = "logTextBox";
            this.logTextBox.Size = new System.Drawing.Size(1026, 366);
            this.logTextBox.TabIndex = 2;
            this.logTextBox.Text = "Log Data";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.LightCoral;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.button1.Location = new System.Drawing.Point(250, 18);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(198, 46);
            this.button1.TabIndex = 1;
            this.button1.Text = "Line Men Report";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.CreateExcel_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1441, 653);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Excel Reader";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private ContextMenuStrip contextMenuStrip1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private Button btnLineMenReport;
        private TabPage tabPage2;
        private TextBox logTextBox;
        private TheArtOfDev.HtmlRenderer.WinForms.HtmlPanel reportPanel;
        private Button button1;
    }
}