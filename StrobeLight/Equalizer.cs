using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StrobeLight
{
	class Equalizer
	{
		private byte[] buffer;
		private int bytesRecorded;
		private WasapiLoopbackCapture waveIn;



		private bool running;

		private double currentLevel = 0;
		private double maxLevel = 0;
		private double minLevel = 0;

		private int attack;
		private int release;
		private float log;
		private float threshold;

		private double outputLevel = 0;

		public double OutputLevel
		{
			get
			{
                return Math.Max(Math.Log(outputLevel/Threshold, Log), 0);
			}
		}

		public int Attack
		{
			get
			{
				return attack;
			}

			set
			{
				attack = value;
			}
		}

		public int Release
		{
			get
			{
				return release;
			}

			set
			{
				release = value;
			}
		}

		public float Log
		{
			get
			{
				return log;
			}

			set
			{
				log = value;
			}
		}

		public float Threshold
		{
			get
			{
				return threshold;
			}

			set
			{
				threshold = value;
			}
		}

		public Equalizer(int attack, int release, float threshold)
		{
			Attack = attack;
			Release = release;
			Threshold = threshold;
			Log = 1.0f;
        }
		

		public void record()
		{
			waveIn = new WasapiLoopbackCapture();
			BufferedWaveProvider bufferedWaveProvider = new BufferedWaveProvider(waveIn.WaveFormat);


			Console.WriteLine(waveIn.WaveFormat.BitsPerSample);
			Console.WriteLine(waveIn.WaveFormat.AverageBytesPerSecond);
			Console.WriteLine(waveIn.WaveFormat.Channels);
			Console.WriteLine(waveIn.WaveFormat.SampleRate);
			Console.WriteLine(waveIn.WaveFormat.Encoding);
			

			waveIn.DataAvailable += new EventHandler<WaveInEventArgs>(waveInStream_DataAvailable);
			waveIn.StartRecording();

			Thread analyze = new Thread(analyzeAudio);
			analyze.Start();

			Thread ar = new Thread(AttackRelease);
			ar.Start();
		}

		private void waveInStream_DataAvailable(object sender, WaveInEventArgs e)
		{
			buffer = e.Buffer;
			bytesRecorded = e.BytesRecorded;
			//Console.WriteLine(e.BytesRecorded);
			//short sample16Bit = BitConverter.ToInt16(buffer, 0);
			//double volume = Math.Abs(sample16Bit / 32768.0);
			//double decibels = Math.Log10(volume);
			//Console.WriteLine("Average Volume: " + decibels);
		}

		private void trashbag()
		{
			byte[] cBuffer = buffer;
			int cBytesRecorded = bytesRecorded;

			double level = 0;
			int n = 0;
			for (int i = 0; i < buffer.Length; i += 2)
			{
				short sample16Bit = BitConverter.ToInt16(buffer, 0);
				double volume = Math.Abs(sample16Bit / 32768.0);
				double decibels = 20 * Math.Log10(volume);
				level += decibels;
				n++;
			}
			double avg_level = level / n;
			currentLevel = avg_level;
		}

		private void AttackRelease()
		{
			running = true;
			long epleasedTime;
            Stopwatch timer = new Stopwatch();
			timer.Start();
			while (running)
			{
				if((epleasedTime = timer.ElapsedMilliseconds) < 10) continue;
				timer.Restart();

				double level = currentLevel;
				if(level > outputLevel)
				{
					float p = Math.Min((Attack > 0)? (float)epleasedTime / Attack : 1.0f, 1.0f);
					outputLevel += (level - outputLevel) * p; ;
                }
				else
				{
					float p = Math.Min((Release > 0) ? (float)epleasedTime / Release : 1.0f, 1.0f);
					outputLevel += (level - outputLevel) * p; ;
				}
			}
		}

		private void analyzeAudio()
		{
			running = true;
			while (running)
			{
				if(buffer != null && bytesRecorded > 0)
				{
					byte[] cBuffer = buffer;
					int cBytesRecorded = bytesRecorded;

					Int32 sample_count = cBytesRecorded / (waveIn.WaveFormat.BitsPerSample / 8);
					Single[] data = new Single[sample_count];

					for (int i = 0; i < sample_count; ++i)
					{
						data[i] = BitConverter.ToSingle(cBuffer, i * 4);
					}

					int j = 0;
					Double[] Audio_Samples = new Double[sample_count / 2];
					double audioLevel = 0;
					for (int sample = 0; sample < data.Length; sample += 2)
					{
						Audio_Samples[j] = (Double)data[sample];
						Audio_Samples[j] += (Double)data[sample + 1];
						audioLevel += Math.Abs(Audio_Samples[j]);
						++j;
					}
					currentLevel = audioLevel / data.Length;

					//currentLevel = Audio_Samples.Average();
					if(currentLevel > maxLevel)
					{
						maxLevel = currentLevel;
						//Console.WriteLine("max: "+maxLevel);
					}

					if (currentLevel < minLevel)
					{
						minLevel = currentLevel;
						//Console.WriteLine("min: " + minLevel);
					}
				}
			}
        }

		public void close()
		{
			waveIn.StopRecording();
			running = false;
        }
	}
}
