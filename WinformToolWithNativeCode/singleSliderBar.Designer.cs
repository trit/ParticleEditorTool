namespace WinformToolWithNativeCode
{
    partial class singleSliderBar
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.valueTrackBar_tb = new System.Windows.Forms.TrackBar();
            this.title_lbl = new System.Windows.Forms.Label();
            this.value_lbl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.valueTrackBar_tb)).BeginInit();
            this.SuspendLayout();
            // 
            // valueTrackBar_tb
            // 
            this.valueTrackBar_tb.Location = new System.Drawing.Point(3, 35);
            this.valueTrackBar_tb.Name = "valueTrackBar_tb";
            this.valueTrackBar_tb.Size = new System.Drawing.Size(194, 45);
            this.valueTrackBar_tb.TabIndex = 0;
            this.valueTrackBar_tb.TickFrequency = 1000;
            this.valueTrackBar_tb.Scroll += new System.EventHandler(this.valueTrackBar_tb_Scroll);
            // 
            // title_lbl
            // 
            this.title_lbl.AutoSize = true;
            this.title_lbl.Location = new System.Drawing.Point(23, 21);
            this.title_lbl.Name = "title_lbl";
            this.title_lbl.Size = new System.Drawing.Size(27, 13);
            this.title_lbl.TabIndex = 1;
            this.title_lbl.Text = "Title";
            // 
            // value_lbl
            // 
            this.value_lbl.AutoSize = true;
            this.value_lbl.Location = new System.Drawing.Point(144, 21);
            this.value_lbl.Name = "value_lbl";
            this.value_lbl.Size = new System.Drawing.Size(13, 13);
            this.value_lbl.TabIndex = 2;
            this.value_lbl.Text = "0";
            // 
            // singleSliderBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.value_lbl);
            this.Controls.Add(this.title_lbl);
            this.Controls.Add(this.valueTrackBar_tb);
            this.Name = "singleSliderBar";
            this.Size = new System.Drawing.Size(200, 83);
            ((System.ComponentModel.ISupportInitialize)(this.valueTrackBar_tb)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar valueTrackBar_tb;
        private System.Windows.Forms.Label title_lbl;
        private System.Windows.Forms.Label value_lbl;
    }
}
