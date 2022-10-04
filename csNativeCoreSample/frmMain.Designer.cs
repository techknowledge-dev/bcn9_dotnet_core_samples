
namespace csNativeCoreSample
{
    partial class frmMain
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
            this.lstRoom = new System.Windows.Forms.ListBox();
            this.btnFill = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstRoom
            // 
            this.lstRoom.FormattingEnabled = true;
            this.lstRoom.ItemHeight = 15;
            this.lstRoom.Location = new System.Drawing.Point(12, 12);
            this.lstRoom.Name = "lstRoom";
            this.lstRoom.Size = new System.Drawing.Size(294, 424);
            this.lstRoom.TabIndex = 0;
            // 
            // btnFill
            // 
            this.btnFill.Location = new System.Drawing.Point(323, 23);
            this.btnFill.Name = "btnFill";
            this.btnFill.Size = new System.Drawing.Size(75, 23);
            this.btnFill.TabIndex = 1;
            this.btnFill.Text = "Fill";
            this.btnFill.UseVisualStyleBackColor = true;
            this.btnFill.Click += new System.EventHandler(this.btnFill_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(411, 450);
            this.Controls.Add(this.btnFill);
            this.Controls.Add(this.lstRoom);
            this.Name = "frmMain";
            this.Text = "Native sample (.NET core)";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstRoom;
        private System.Windows.Forms.Button btnFill;
    }
}
