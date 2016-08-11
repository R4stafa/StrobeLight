namespace StrobeLight
{
	partial class Form1
	{
		/// <summary>
		/// Erforderliche Designervariable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Verwendete Ressourcen bereinigen.
		/// </summary>
		/// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Vom Windows Form-Designer generierter Code

		/// <summary>
		/// Erforderliche Methode für die Designerunterstützung.
		/// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
		/// </summary>
		private void InitializeComponent()
		{
			this.screen = new StrobeLight.CustomPanel();
			this.settings = new StrobeLight.CustomPanel();
			this.label3 = new System.Windows.Forms.Label();
			this.tb_log = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.tb_release = new System.Windows.Forms.TextBox();
			this.tb_attack = new System.Windows.Forms.TextBox();
			this.audioThresSlider = new System.Windows.Forms.TrackBar();
			this.rb_audio = new System.Windows.Forms.RadioButton();
			this.rb_bpm = new System.Windows.Forms.RadioButton();
			this.cb_lock_settings = new System.Windows.Forms.CheckBox();
			this.tb_bpm = new System.Windows.Forms.TextBox();
			this.screen.SuspendLayout();
			this.settings.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.audioThresSlider)).BeginInit();
			this.SuspendLayout();
			// 
			// screen
			// 
			this.screen.Controls.Add(this.settings);
			this.screen.Dock = System.Windows.Forms.DockStyle.Fill;
			this.screen.Location = new System.Drawing.Point(0, 0);
			this.screen.Name = "screen";
			this.screen.Size = new System.Drawing.Size(1244, 696);
			this.screen.TabIndex = 0;
			this.screen.Paint += new System.Windows.Forms.PaintEventHandler(this.screen_Paint);
			this.screen.MouseClick += new System.Windows.Forms.MouseEventHandler(this.screen_MouseClick);
			this.screen.MouseMove += new System.Windows.Forms.MouseEventHandler(this.screen_MouseMove);
			// 
			// settings
			// 
			this.settings.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.settings.Controls.Add(this.label3);
			this.settings.Controls.Add(this.tb_log);
			this.settings.Controls.Add(this.label2);
			this.settings.Controls.Add(this.label1);
			this.settings.Controls.Add(this.tb_release);
			this.settings.Controls.Add(this.tb_attack);
			this.settings.Controls.Add(this.audioThresSlider);
			this.settings.Controls.Add(this.rb_audio);
			this.settings.Controls.Add(this.rb_bpm);
			this.settings.Controls.Add(this.cb_lock_settings);
			this.settings.Controls.Add(this.tb_bpm);
			this.settings.Dock = System.Windows.Forms.DockStyle.Left;
			this.settings.Location = new System.Drawing.Point(0, 0);
			this.settings.Name = "settings";
			this.settings.Size = new System.Drawing.Size(200, 696);
			this.settings.TabIndex = 0;
			this.settings.Visible = false;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(27, 310);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(25, 13);
			this.label3.TabIndex = 10;
			this.label3.Text = "Log";
			// 
			// tb_log
			// 
			this.tb_log.Cursor = System.Windows.Forms.Cursors.Default;
			this.tb_log.Location = new System.Drawing.Point(83, 307);
			this.tb_log.Name = "tb_log";
			this.tb_log.Size = new System.Drawing.Size(48, 20);
			this.tb_log.TabIndex = 9;
			this.tb_log.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tb_log_KeyDown);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(27, 262);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(46, 13);
			this.label2.TabIndex = 8;
			this.label2.Text = "Release";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(27, 217);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(38, 13);
			this.label1.TabIndex = 8;
			this.label1.Text = "Attack";
			// 
			// tb_release
			// 
			this.tb_release.Cursor = System.Windows.Forms.Cursors.Default;
			this.tb_release.Location = new System.Drawing.Point(83, 259);
			this.tb_release.Name = "tb_release";
			this.tb_release.Size = new System.Drawing.Size(48, 20);
			this.tb_release.TabIndex = 7;
			this.tb_release.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tb_release_KeyDown);
			// 
			// tb_attack
			// 
			this.tb_attack.Location = new System.Drawing.Point(83, 214);
			this.tb_attack.Name = "tb_attack";
			this.tb_attack.Size = new System.Drawing.Size(48, 20);
			this.tb_attack.TabIndex = 6;
			this.tb_attack.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tb_attack_KeyDown);
			// 
			// audioThresSlider
			// 
			this.audioThresSlider.Location = new System.Drawing.Point(27, 177);
			this.audioThresSlider.Maximum = 100;
			this.audioThresSlider.Minimum = 1;
			this.audioThresSlider.Name = "audioThresSlider";
			this.audioThresSlider.Size = new System.Drawing.Size(104, 45);
			this.audioThresSlider.TabIndex = 5;
			this.audioThresSlider.Value = 1;
			this.audioThresSlider.Scroll += new System.EventHandler(this.audioThresSlider_Scroll);
			// 
			// rb_audio
			// 
			this.rb_audio.AutoSize = true;
			this.rb_audio.Location = new System.Drawing.Point(27, 145);
			this.rb_audio.Name = "rb_audio";
			this.rb_audio.Size = new System.Drawing.Size(51, 17);
			this.rb_audio.TabIndex = 4;
			this.rb_audio.Text = "audio";
			this.rb_audio.UseVisualStyleBackColor = true;
			// 
			// rb_bpm
			// 
			this.rb_bpm.AutoSize = true;
			this.rb_bpm.Checked = true;
			this.rb_bpm.Location = new System.Drawing.Point(27, 87);
			this.rb_bpm.Name = "rb_bpm";
			this.rb_bpm.Size = new System.Drawing.Size(48, 17);
			this.rb_bpm.TabIndex = 3;
			this.rb_bpm.TabStop = true;
			this.rb_bpm.Text = "BPM";
			this.rb_bpm.UseVisualStyleBackColor = true;
			// 
			// cb_lock_settings
			// 
			this.cb_lock_settings.AutoSize = true;
			this.cb_lock_settings.Location = new System.Drawing.Point(27, 24);
			this.cb_lock_settings.Name = "cb_lock_settings";
			this.cb_lock_settings.Size = new System.Drawing.Size(104, 17);
			this.cb_lock_settings.TabIndex = 2;
			this.cb_lock_settings.Text = "lock this window";
			this.cb_lock_settings.UseVisualStyleBackColor = true;
			this.cb_lock_settings.CheckedChanged += new System.EventHandler(this.cb_lock_settings_CheckedChanged);
			// 
			// tb_bpm
			// 
			this.tb_bpm.Location = new System.Drawing.Point(103, 86);
			this.tb_bpm.Name = "tb_bpm";
			this.tb_bpm.Size = new System.Drawing.Size(50, 20);
			this.tb_bpm.TabIndex = 0;
			this.tb_bpm.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tb_bpm_KeyDown);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1244, 696);
			this.Controls.Add(this.screen);
			this.Name = "Form1";
			this.Text = "Form1";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
			this.Load += new System.EventHandler(this.Form1_Load);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
			this.screen.ResumeLayout(false);
			this.settings.ResumeLayout(false);
			this.settings.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.audioThresSlider)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private CustomPanel screen;
		private CustomPanel settings;
		private System.Windows.Forms.TextBox tb_bpm;
		private System.Windows.Forms.CheckBox cb_lock_settings;
		private System.Windows.Forms.RadioButton rb_audio;
		private System.Windows.Forms.RadioButton rb_bpm;
		private System.Windows.Forms.TrackBar audioThresSlider;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox tb_release;
		private System.Windows.Forms.TextBox tb_attack;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox tb_log;
	}
}

