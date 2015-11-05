namespace WinformToolWithNativeCode
{
    partial class Form1
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.particleViewer_pb = new System.Windows.Forms.PictureBox();
            this.particleClock = new System.Windows.Forms.Timer(this.components);
            this.simStart_cb = new System.Windows.Forms.CheckBox();
            this.createEmitter_btn = new System.Windows.Forms.Button();
            this.newEmitterXPos_tb = new System.Windows.Forms.TextBox();
            this.newEmitterYPos_tb = new System.Windows.Forms.TextBox();
            this.newEmitterXPos_lbl = new System.Windows.Forms.Label();
            this.newEmitterYPos_lbl = new System.Windows.Forms.Label();
            this.startAll_cb = new System.Windows.Forms.CheckBox();
            this.activeEmitterControlPanel_gb = new System.Windows.Forms.GroupBox();
            this.loadSettingsButton = new System.Windows.Forms.Button();
            this.saveSettingsButton = new System.Windows.Forms.Button();
            this.particleShape_cb = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.deleteEmitter_btn = new System.Windows.Forms.Button();
            this.finishColor_lbl = new System.Windows.Forms.Label();
            this.startColor_lbl = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.maxParticlesNumber_sb = new WinformToolWithNativeCode.singleSliderBar();
            this.emissionRate_sb = new WinformToolWithNativeCode.singleSliderBar();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.particleViewer_pb)).BeginInit();
            this.activeEmitterControlPanel_gb.SuspendLayout();
            this.SuspendLayout();
            // 
            // particleViewer_pb
            // 
            this.particleViewer_pb.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.particleViewer_pb.Location = new System.Drawing.Point(12, 12);
            this.particleViewer_pb.Name = "particleViewer_pb";
            this.particleViewer_pb.Size = new System.Drawing.Size(358, 449);
            this.particleViewer_pb.TabIndex = 3;
            this.particleViewer_pb.TabStop = false;
            this.particleViewer_pb.Paint += new System.Windows.Forms.PaintEventHandler(this.particleViewer_pb_Paint);
            this.particleViewer_pb.MouseDown += new System.Windows.Forms.MouseEventHandler(this.particleViewer_pb_MouseDown);
            // 
            // particleClock
            // 
            this.particleClock.Enabled = true;
            this.particleClock.Interval = 33;
            this.particleClock.Tick += new System.EventHandler(this.particleClock_Tick);
            // 
            // simStart_cb
            // 
            this.simStart_cb.Appearance = System.Windows.Forms.Appearance.Button;
            this.simStart_cb.AutoSize = true;
            this.simStart_cb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simStart_cb.Location = new System.Drawing.Point(28, 263);
            this.simStart_cb.Name = "simStart_cb";
            this.simStart_cb.Size = new System.Drawing.Size(45, 26);
            this.simStart_cb.TabIndex = 4;
            this.simStart_cb.Text = "Start";
            this.simStart_cb.UseVisualStyleBackColor = true;
            this.simStart_cb.CheckedChanged += new System.EventHandler(this.simStart_cb_CheckedChanged);
            // 
            // createEmitter_btn
            // 
            this.createEmitter_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.createEmitter_btn.Location = new System.Drawing.Point(562, 21);
            this.createEmitter_btn.Name = "createEmitter_btn";
            this.createEmitter_btn.Size = new System.Drawing.Size(210, 23);
            this.createEmitter_btn.TabIndex = 6;
            this.createEmitter_btn.Text = "Create";
            this.createEmitter_btn.UseVisualStyleBackColor = true;
            this.createEmitter_btn.Click += new System.EventHandler(this.createEmitter_btn_Click);
            // 
            // newEmitterXPos_tb
            // 
            this.newEmitterXPos_tb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newEmitterXPos_tb.Location = new System.Drawing.Point(399, 23);
            this.newEmitterXPos_tb.Name = "newEmitterXPos_tb";
            this.newEmitterXPos_tb.Size = new System.Drawing.Size(63, 22);
            this.newEmitterXPos_tb.TabIndex = 7;
            this.newEmitterXPos_tb.Text = "0";
            // 
            // newEmitterYPos_tb
            // 
            this.newEmitterYPos_tb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newEmitterYPos_tb.Location = new System.Drawing.Point(491, 23);
            this.newEmitterYPos_tb.Name = "newEmitterYPos_tb";
            this.newEmitterYPos_tb.Size = new System.Drawing.Size(65, 22);
            this.newEmitterYPos_tb.TabIndex = 8;
            this.newEmitterYPos_tb.Text = "0";
            // 
            // newEmitterXPos_lbl
            // 
            this.newEmitterXPos_lbl.AutoSize = true;
            this.newEmitterXPos_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newEmitterXPos_lbl.Location = new System.Drawing.Point(376, 26);
            this.newEmitterXPos_lbl.Name = "newEmitterXPos_lbl";
            this.newEmitterXPos_lbl.Size = new System.Drawing.Size(19, 16);
            this.newEmitterXPos_lbl.TabIndex = 9;
            this.newEmitterXPos_lbl.Text = "X:";
            // 
            // newEmitterYPos_lbl
            // 
            this.newEmitterYPos_lbl.AutoSize = true;
            this.newEmitterYPos_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newEmitterYPos_lbl.Location = new System.Drawing.Point(468, 26);
            this.newEmitterYPos_lbl.Name = "newEmitterYPos_lbl";
            this.newEmitterYPos_lbl.Size = new System.Drawing.Size(20, 16);
            this.newEmitterYPos_lbl.TabIndex = 10;
            this.newEmitterYPos_lbl.Text = "Y:";
            // 
            // startAll_cb
            // 
            this.startAll_cb.Appearance = System.Windows.Forms.Appearance.Button;
            this.startAll_cb.AutoSize = true;
            this.startAll_cb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startAll_cb.Location = new System.Drawing.Point(160, 476);
            this.startAll_cb.Name = "startAll_cb";
            this.startAll_cb.Size = new System.Drawing.Size(62, 26);
            this.startAll_cb.TabIndex = 11;
            this.startAll_cb.Text = "Start all";
            this.startAll_cb.UseVisualStyleBackColor = true;
            this.startAll_cb.CheckedChanged += new System.EventHandler(this.startAll_cb_CheckedChanged);
            // 
            // activeEmitterControlPanel_gb
            // 
            this.activeEmitterControlPanel_gb.Controls.Add(this.loadSettingsButton);
            this.activeEmitterControlPanel_gb.Controls.Add(this.saveSettingsButton);
            this.activeEmitterControlPanel_gb.Controls.Add(this.particleShape_cb);
            this.activeEmitterControlPanel_gb.Controls.Add(this.label3);
            this.activeEmitterControlPanel_gb.Controls.Add(this.deleteEmitter_btn);
            this.activeEmitterControlPanel_gb.Controls.Add(this.finishColor_lbl);
            this.activeEmitterControlPanel_gb.Controls.Add(this.startColor_lbl);
            this.activeEmitterControlPanel_gb.Controls.Add(this.label2);
            this.activeEmitterControlPanel_gb.Controls.Add(this.label1);
            this.activeEmitterControlPanel_gb.Controls.Add(this.maxParticlesNumber_sb);
            this.activeEmitterControlPanel_gb.Controls.Add(this.emissionRate_sb);
            this.activeEmitterControlPanel_gb.Controls.Add(this.simStart_cb);
            this.activeEmitterControlPanel_gb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.activeEmitterControlPanel_gb.Location = new System.Drawing.Point(399, 61);
            this.activeEmitterControlPanel_gb.Name = "activeEmitterControlPanel_gb";
            this.activeEmitterControlPanel_gb.Size = new System.Drawing.Size(373, 441);
            this.activeEmitterControlPanel_gb.TabIndex = 12;
            this.activeEmitterControlPanel_gb.TabStop = false;
            this.activeEmitterControlPanel_gb.Text = "Active Emitter Control Panel";
            // 
            // loadSettingsButton
            // 
            this.loadSettingsButton.Location = new System.Drawing.Point(214, 412);
            this.loadSettingsButton.Name = "loadSettingsButton";
            this.loadSettingsButton.Size = new System.Drawing.Size(129, 23);
            this.loadSettingsButton.TabIndex = 18;
            this.loadSettingsButton.Text = "Load Configuration";
            this.loadSettingsButton.UseVisualStyleBackColor = true;
            this.loadSettingsButton.Click += new System.EventHandler(this.loadSettingsButton_Click);
            // 
            // saveSettingsButton
            // 
            this.saveSettingsButton.Location = new System.Drawing.Point(32, 412);
            this.saveSettingsButton.Name = "saveSettingsButton";
            this.saveSettingsButton.Size = new System.Drawing.Size(129, 23);
            this.saveSettingsButton.TabIndex = 17;
            this.saveSettingsButton.Text = "Save Configuration";
            this.saveSettingsButton.UseVisualStyleBackColor = true;
            this.saveSettingsButton.Click += new System.EventHandler(this.saveSettingsButton_Click);
            // 
            // particleShape_cb
            // 
            this.particleShape_cb.FormattingEnabled = true;
            this.particleShape_cb.Items.AddRange(new object[] {
            "Ellipse",
            "Circle",
            "Star",
            "Diamond"});
            this.particleShape_cb.Location = new System.Drawing.Point(28, 333);
            this.particleShape_cb.Name = "particleShape_cb";
            this.particleShape_cb.Size = new System.Drawing.Size(158, 24);
            this.particleShape_cb.TabIndex = 16;
            this.particleShape_cb.SelectedIndexChanged += new System.EventHandler(this.particleShape_cb_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 305);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 16);
            this.label3.TabIndex = 14;
            this.label3.Text = "Particle Shape";
            // 
            // deleteEmitter_btn
            // 
            this.deleteEmitter_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteEmitter_btn.Location = new System.Drawing.Point(111, 263);
            this.deleteEmitter_btn.Name = "deleteEmitter_btn";
            this.deleteEmitter_btn.Size = new System.Drawing.Size(75, 25);
            this.deleteEmitter_btn.TabIndex = 13;
            this.deleteEmitter_btn.Text = "Delete";
            this.deleteEmitter_btn.UseVisualStyleBackColor = true;
            this.deleteEmitter_btn.Click += new System.EventHandler(this.deleteEmitter_btn_Click);
            // 
            // finishColor_lbl
            // 
            this.finishColor_lbl.AutoSize = true;
            this.finishColor_lbl.BackColor = System.Drawing.Color.Black;
            this.finishColor_lbl.Location = new System.Drawing.Point(123, 222);
            this.finishColor_lbl.Name = "finishColor_lbl";
            this.finishColor_lbl.Size = new System.Drawing.Size(38, 16);
            this.finishColor_lbl.TabIndex = 10;
            this.finishColor_lbl.Text = "          ";
            this.finishColor_lbl.Click += new System.EventHandler(this.finishColor_lbl_Click);
            // 
            // startColor_lbl
            // 
            this.startColor_lbl.AutoSize = true;
            this.startColor_lbl.BackColor = System.Drawing.Color.White;
            this.startColor_lbl.Location = new System.Drawing.Point(123, 185);
            this.startColor_lbl.Name = "startColor_lbl";
            this.startColor_lbl.Size = new System.Drawing.Size(38, 16);
            this.startColor_lbl.TabIndex = 9;
            this.startColor_lbl.Text = "          ";
            this.startColor_lbl.Click += new System.EventHandler(this.startColor_lbl_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(25, 222);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 16);
            this.label2.TabIndex = 8;
            this.label2.Text = "Finish Color";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(25, 185);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 16);
            this.label1.TabIndex = 7;
            this.label1.Text = "Start Color";
            // 
            // maxParticlesNumber_sb
            // 
            this.maxParticlesNumber_sb.Location = new System.Drawing.Point(6, 99);
            this.maxParticlesNumber_sb.Name = "maxParticlesNumber_sb";
            this.maxParticlesNumber_sb.Size = new System.Drawing.Size(262, 83);
            this.maxParticlesNumber_sb.SliderMax = 200000;
            this.maxParticlesNumber_sb.SliderMin = 1;
            this.maxParticlesNumber_sb.SliderTitle = "Max Number of Particles";
            this.maxParticlesNumber_sb.SliderValue = 100000;
            this.maxParticlesNumber_sb.TabIndex = 6;
            this.maxParticlesNumber_sb.SliderValueChanged += new System.EventHandler(this.maxParticlesNumber_sb_SliderValueChanged);
            // 
            // emissionRate_sb
            // 
            this.emissionRate_sb.Location = new System.Drawing.Point(6, 21);
            this.emissionRate_sb.Name = "emissionRate_sb";
            this.emissionRate_sb.Size = new System.Drawing.Size(262, 72);
            this.emissionRate_sb.SliderMax = 100;
            this.emissionRate_sb.SliderMin = 1;
            this.emissionRate_sb.SliderTitle = "Emissiom Rate";
            this.emissionRate_sb.SliderValue = 50;
            this.emissionRate_sb.TabIndex = 5;
            this.emissionRate_sb.SliderValueChanged += new System.EventHandler(this.emissionRate_sb_SliderValueChanged);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.activeEmitterControlPanel_gb);
            this.Controls.Add(this.startAll_cb);
            this.Controls.Add(this.newEmitterYPos_lbl);
            this.Controls.Add(this.newEmitterXPos_lbl);
            this.Controls.Add(this.newEmitterYPos_tb);
            this.Controls.Add(this.newEmitterXPos_tb);
            this.Controls.Add(this.createEmitter_btn);
            this.Controls.Add(this.particleViewer_pb);
            this.Name = "Form1";
            this.Text = "Go Particles!";
            ((System.ComponentModel.ISupportInitialize)(this.particleViewer_pb)).EndInit();
            this.activeEmitterControlPanel_gb.ResumeLayout(false);
            this.activeEmitterControlPanel_gb.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox particleViewer_pb;
        private System.Windows.Forms.Timer particleClock;
        private System.Windows.Forms.CheckBox simStart_cb;
        private singleSliderBar emissionRate_sb;
        private System.Windows.Forms.Button createEmitter_btn;
        private System.Windows.Forms.TextBox newEmitterXPos_tb;
        private System.Windows.Forms.TextBox newEmitterYPos_tb;
        private System.Windows.Forms.Label newEmitterXPos_lbl;
        private System.Windows.Forms.Label newEmitterYPos_lbl;
        private System.Windows.Forms.CheckBox startAll_cb;
        private System.Windows.Forms.GroupBox activeEmitterControlPanel_gb;
        private singleSliderBar maxParticlesNumber_sb;
        private System.Windows.Forms.Label finishColor_lbl;
        private System.Windows.Forms.Label startColor_lbl;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.Button deleteEmitter_btn;
        private System.Windows.Forms.ComboBox particleShape_cb;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button loadSettingsButton;
        private System.Windows.Forms.Button saveSettingsButton;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
    }
}

