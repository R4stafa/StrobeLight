using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StrobeLight
{
	public partial class Form1 : Form
	{
		bool rendering;

		float state = 0.5f;
		float statechange = 1;

		int BPM = 120;
		int SLEEP_TIME = 20;

		Color clearColor = Color.White;
		Color rectColor = Color.Black;
		Color polygonColor = Color.White;
		Random rand;

		List<long> mouseClicks;
		Stopwatch mouseClickTimer;

		Equalizer eq;

		bool lock_settings = false;

		public Form1()
		{
			InitializeComponent();

			eq = new Equalizer(20, 90, 0.8f);
			rand = new Random();
			mouseClicks = new List<long>();
			mouseClickTimer = new Stopwatch();

			this.KeyPreview = true;
			screen.setDoubleBuffered(true);

			tb_bpm.Text = BPM.ToString();
			tb_attack.Text = eq.Attack.ToString();
			tb_release.Text = eq.Release.ToString();
			tb_log.Text = eq.Log.ToString();


			calculateThreshold();

			eq.record();
		}

		private void screen_Paint(object sender, PaintEventArgs e)
		{
			render(e.Graphics);
		}

		private void render(Graphics g)
		{
			float amp = getAmplitude();

			g.Clear(clearColor);
			SolidBrush b = new SolidBrush(rectColor);
            g.FillRectangle(b, screen.Width/2 * (1.0f - amp), screen.Height / 2 * (1.0f - amp), screen.Width * amp, screen.Height * amp);

			float angle = (float)(Math.PI * amp);
			float r = 0.4f * screen.Height * amp;
			Point pivot = new Point(screen.Width / 2, screen.Height / 2);

			Point[] points = new Point[]
			{
				getPoint(angle, r, pivot),
				getPoint(angle + (float)(Math.PI / 3 * 2), r, pivot),
				getPoint(angle + (float)(Math.PI / 3 * 4), r, pivot)
			};

			g.FillPolygon(new SolidBrush(polygonColor), points);


			g.FillEllipse(new SolidBrush(rectColor), pivot.X - r/4, pivot.Y - r/4, r/2, r/2);
		}

		private Point getPoint(float angle, float r, Point pivot)
		{
			return new Point(pivot.X + (int)(Math.Sin(angle) * r), pivot.Y + (int)(Math.Cos(angle) * r));
		}

		private void run()
		{
			Stopwatch stopwatch = new Stopwatch();
			long epleasedTime;
			stopwatch.Start();
			rendering = true;
            while (rendering)
			{
				while ((epleasedTime = stopwatch.ElapsedMilliseconds) < SLEEP_TIME) ;
				stopwatch.Restart();
				process(epleasedTime);
                screen.Invalidate();
			}
		}

		private void process(long epleasedTime)
		{
			state += statechange * epleasedTime * BPM / 60000.0f;
			if (state >= 1.0f)
			{
				clearColor = Color.FromArgb(rand.Next(255), rand.Next(255), rand.Next(255));
				statechange = -1;
			}
			if (state <= 0.0f)
			{
				rectColor = Color.FromArgb(rand.Next(255), rand.Next(255), rand.Next(255));
				polygonColor = Color.FromArgb(rand.Next(255), rand.Next(255), rand.Next(255));
				statechange = 1;
			}
		}

		private float getAmplitude()
		{
			if (rb_bpm.Checked)
			{
				return state;
			}
			else if (rb_audio.Checked)
			{
				return (float)eq.OutputLevel;
			}
			return 0;
		}

		private void calculateThreshold()
		{
			eq.Threshold = ((float)audioThresSlider.Value / audioThresSlider.Maximum) * 0.6f;
		}

		private void calculateBPM()
		{
			int total = 0;
			foreach (long l in mouseClicks)
			{
				total += (int)l;
			}
			setBPM((int)(60000.0f / (total / mouseClicks.Count) * 2));
		}

		private void setBPM(int bpm)
		{
			BPM = bpm;
			tb_bpm.Text = BPM.ToString();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			Thread th = new Thread(run);
			th.Start();
		}

		

		private void Form1_FormClosing(object sender, FormClosingEventArgs e)
		{
			rendering = false;
			eq.close();
		}

		private void screen_MouseClick(object sender, MouseEventArgs e)
		{
			screen.Focus();
			if(mouseClickTimer.IsRunning)
			{
				mouseClicks.Add(mouseClickTimer.ElapsedMilliseconds);
				mouseClickTimer.Restart();

				if(mouseClicks.Count > 6)
				{
					mouseClicks.RemoveAt(0);
				}

				calculateBPM();
			}
			else
			{
				mouseClickTimer.Start();
			}
		}
		

		private void screen_MouseMove(object sender, MouseEventArgs e)
		{
			if(e.X < 50)
			{
				settings.Visible = true;
			}
			else if(e.X > settings.Width && !lock_settings)
			{
				settings.Visible = false;
			}
		}

		private void tb_bpm_KeyDown(object sender, KeyEventArgs e)
		{
			if(e.KeyCode == Keys.Enter)
			{
				int number;
				if (int.TryParse(tb_bpm.Text, out number) && number > 0)
				{
					BPM = number;
				}
				else
				{
					tb_bpm.Text = BPM.ToString();
				}
			}
		}

		private void cb_lock_settings_CheckedChanged(object sender, EventArgs e)
		{
			lock_settings = cb_lock_settings.Checked;
		}

		private void audioThresSlider_Scroll(object sender, EventArgs e)
		{
			calculateThreshold();
            Console.WriteLine(eq.Threshold);
		}

		private void tb_release_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				int number;
				if (int.TryParse(tb_release.Text, out number) && number > 0)
				{
					eq.Release = number;
				}
				else
				{
					tb_release.Text = eq.Release.ToString();
				}
			}
		}

		private void tb_attack_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				int number;
				if (int.TryParse(tb_attack.Text, out number) && number > 0)
				{
					eq.Attack = number;
				}
				else
				{
					tb_attack.Text = eq.Attack.ToString();
				}
			}
		}

		private void tb_log_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				float number;
				if (float.TryParse(tb_log.Text, out number) && number > 0)
				{
					eq.Log = number;
				}
				else
				{
					tb_log.Text = eq.Log.ToString();
				}
			}
		}

		private void Form1_KeyDown(object sender, KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case Keys.F11:
					toggleFullscreen();
					break;
				case Keys.Escape:
					Application.Exit();
					break;
			}
		}

		private void toggleFullscreen()
		{
			if (this.FormBorderStyle == FormBorderStyle.None)
			{
				this.FormBorderStyle = FormBorderStyle.Sizable;
				this.WindowState = FormWindowState.Normal;
			}
			else
			{
				this.FormBorderStyle = FormBorderStyle.None;
				this.WindowState = FormWindowState.Maximized;
			}
		}

		
	}
}
