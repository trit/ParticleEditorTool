//
// PROG56693 Games Tools and Data-Driven Design
// February 2014
// Mikhail Kutuzov, Vladyslav Dolhopolov 
//

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Collections;
using System.Xml;

namespace WinformToolWithNativeCode
{

    public partial class Form1 : Form
    {
        // list of emitters on the screen
        List<IntPtr>    m_emitters                  = new List<IntPtr>();
        // selected emitter
        IntPtr          m_activeEmitter             = IntPtr.Zero;
        // rect for selection circle
        RectangleF      m_emitterSelectionOffset    = new RectangleF(-7.5f, -7.5f, 15.0f, 15.0f);

        public Form1()
        {
            InitializeComponent();

            particleShape_cb.SelectedIndex = 0;
        }

        private void particleClock_Tick(object sender, EventArgs e)
        {
            float delta = particleClock.Interval / 1000.0f;

            // update each emitter
            for (int i = 0; i < m_emitters.Count; i++)
            {
                ParticleLib_External.Update(m_emitters[i], delta);
            }
            
            particleViewer_pb.Refresh();
        }

        private void simStart_cb_CheckedChanged(object sender, EventArgs e)
        {
            // starts/stops selected emitter
            if (simStart_cb.Checked && m_activeEmitter != IntPtr.Zero)
            {
                simStart_cb.Text = "Stop";
                ParticleLib_External.StartParticleEmitter(m_activeEmitter);
            }
            else if (m_activeEmitter != IntPtr.Zero)
            {
                simStart_cb.Text = "Start";
                ParticleLib_External.StopParticleEmitter(m_activeEmitter);
            }
        }

        private void particleViewer_pb_Paint(object sender, PaintEventArgs e)
        {
            // draw particles
            for (int i = 0; i < m_emitters.Count; i++)
            {
                if (m_emitters[i] != IntPtr.Zero)
                {
                    // amount of particles on the screen
                    int size        = ParticleLib_External.GetParticleCount(m_emitters[i]);
                    IntPtr particle = ParticleLib_External.GetFirstParticle(m_emitters[i]);

                    for (int j = 0; j < size; j++)
                    {
                        // position
                        float x         = ParticleLib_External.GetParticlePosX(particle);
                        float y         = ParticleLib_External.GetParticlePosY(particle);
                        // 8*4 bits for each color channel
                        Int32 bits      = ParticleLib_External.GetParticleColour(particle);
                        
                        using (Brush brush = new SolidBrush(ParseColorBits(bits)))
                        {
                            // choose particle shape to draw
                            switch (ParticleLib_External.GetParticleType(particle))
                            {
                                // ellipse shape
                                case 0:
                                    e.Graphics.FillEllipse(brush, x, y, 3, 6);
                                    break;

                                // circle shape
                                case 1:
                                    e.Graphics.FillEllipse(brush, x, y, 4, 4);
                                    break;

                                // star
                                case 2:
                                    // star verticies
                                    PointF[] points = new PointF[5];
                                    points[0] = new PointF(x - 3, y - 6);
                                    points[1] = new PointF(x, y + 6);
                                    points[2] = new PointF(x + 3, y - 6);
                                    points[3] = new PointF(x - 4.5f, y + 1.5f);
                                    points[4] = new PointF(x + 4.5f, y + 1.5f);

                                    e.Graphics.FillClosedCurve(brush, points);
                                    break;
                                
                                // diamond(quad?)
                                case 3:
                                    e.Graphics.FillRectangle(brush, x, y, 4, 4);
                                    break;

                                default:
                                    break;
                            }
                            
                        }
                            
                        // next particle in the list
                        particle = IntPtr.Add(particle, IntPtr.Size);
                    }

                    // draw borders around not selected emitters
                    using (Pen pen = new Pen(Color.DarkGray, 1))
                    {
                        float x = ParticleLib_External.GetEmitterPosX(m_emitters[i]);
                        float y = ParticleLib_External.GetEmitterPosY(m_emitters[i]);
                        e.Graphics.DrawEllipse(pen, x + m_emitterSelectionOffset.X,
                                                    y + m_emitterSelectionOffset.Y,
                                                        m_emitterSelectionOffset.Width,
                                                        m_emitterSelectionOffset.Height);
                    }
                }
            }

            // draw border around selected emitter
            if (m_activeEmitter != IntPtr.Zero)
            {
                using (Pen pen = new Pen(Color.GreenYellow, 1))
                {
                    float x = ParticleLib_External.GetEmitterPosX(m_activeEmitter);
                    float y = ParticleLib_External.GetEmitterPosY(m_activeEmitter);
                    e.Graphics.DrawEllipse(pen, x + m_emitterSelectionOffset.X,
                                                y + m_emitterSelectionOffset.Y,
                                                    m_emitterSelectionOffset.Width,
                                                    m_emitterSelectionOffset.Height);
                }
            }
        }

        private Color ParseColorBits(Int32 bits)
        {
            // 4 color channels
            int[] color = new int[4];

            // magic
            for (int k = 0, m = 0, n = 0; k < 32; k++)
            {
                if ((bits & (1 << k)) != 0)
                {
                    color[n] |= (1 << m);
                }

                m = (m == 7) ? 0 : m + 1;
                n = (k == 7 || k == 15 || k == 23) ? n + 1 : n;
            }

            // create Color object from values above
            return Color.FromArgb(color[3], color[0], color[1], color[2]);
        }

        private void createEmitter_btn_Click(object sender, EventArgs e)
        {
            // create new emmiter
            IntPtr newEmitter = ParticleLib_External.CreateParticleEmitter(
                float.Parse(newEmitterXPos_tb.Text), float.Parse(newEmitterYPos_tb.Text), emissionRate_sb.SliderValue, maxParticlesNumber_sb.SliderValue, 10);
            
            // read values from the form
            ParticleLib_External.SetStartColour(newEmitter, startColor_lbl.BackColor.R, startColor_lbl.BackColor.G, startColor_lbl.BackColor.B, startColor_lbl.BackColor.A);
            ParticleLib_External.SetFinishColour(newEmitter, finishColor_lbl.BackColor.R, finishColor_lbl.BackColor.G, finishColor_lbl.BackColor.B, finishColor_lbl.BackColor.A);
            ParticleLib_External.SetParticleType(newEmitter, particleShape_cb.SelectedIndex);

            // add to list
            m_emitters.Add(newEmitter);
            // remove any selection
            m_activeEmitter = IntPtr.Zero;
            // toggle off start button
            simStart_cb.Checked = false;
        }

        private void startAll_cb_CheckedChanged(object sender, EventArgs e)
        {
            // starts/stops all emitters
            for (int i = 0; i < m_emitters.Count; i++)
            {
                if (startAll_cb.Checked)
                {
                    startAll_cb.Text = "Stop all";
                    ParticleLib_External.StartParticleEmitter(m_emitters[i]);
                    // toggle off start button
                    simStart_cb.Checked = true;
                }
                else
                {
                    startAll_cb.Text = "Start all";
                    ParticleLib_External.StopParticleEmitter(m_emitters[i]);
                    // toggle off start button
                    simStart_cb.Checked = false;
                }
            }
        }

        private void particleViewer_pb_MouseDown(object sender, MouseEventArgs e)
        {
            // compare mouse location to each emitter's one
            for (int i = 0; i < m_emitters.Count; i++) {

                float x = ParticleLib_External.GetEmitterPosX(m_emitters[i]);
                float y = ParticleLib_External.GetEmitterPosY(m_emitters[i]);

                if (e.Location.X > x + m_emitterSelectionOffset.X && e.Location.X < x + m_emitterSelectionOffset.Width &&
                    e.Location.Y > y + m_emitterSelectionOffset.Y && e.Location.Y < y + m_emitterSelectionOffset.Height)
                {
                    // make active
                    m_activeEmitter = m_emitters[i];
                    // read emitter parametrs from dll
                    getAttribValuesForActiveEmitter();
                    // check if is working and change start button text
                    if (ParticleLib_External.GetIsWorking(m_activeEmitter) == 1)
                    {
                        simStart_cb.Checked = true;
                    }
                    else
                    {
                        simStart_cb.Checked = false;
                    }
                    // break;
                    break;
                }
                else
                {
                    m_activeEmitter = IntPtr.Zero;
                }
            }
        }

        private void emissionRate_sb_SliderValueChanged(object sender, EventArgs e)
        {
            if (m_activeEmitter != IntPtr.Zero)
            {
                ParticleLib_External.SetEmissionRate(m_activeEmitter, emissionRate_sb.SliderValue);
            }
        }

        private void maxParticlesNumber_sb_SliderValueChanged(object sender, EventArgs e)
        {
            if (m_activeEmitter != IntPtr.Zero)
            {
                ParticleLib_External.SetMaxParticles(m_activeEmitter, maxParticlesNumber_sb.SliderValue);
            }
        }

        private void startColor_lbl_Click(object sender, EventArgs e)
        {
            DialogResult dr = colorDialog.ShowDialog();
            // opens color selection dialog on label click
            if (dr == DialogResult.OK)
            {
                startColor_lbl.BackColor = colorDialog.Color;

                if (m_activeEmitter != IntPtr.Zero) {
                    ParticleLib_External.SetStartColour(m_activeEmitter, colorDialog.Color.R, colorDialog.Color.G, colorDialog.Color.B, colorDialog.Color.A);
                }
            }
        }

        private void finishColor_lbl_Click(object sender, EventArgs e)
        {
            DialogResult dr = colorDialog.ShowDialog();
            // opens color selection dialog on label click
            if (dr == DialogResult.OK)
            {
                finishColor_lbl.BackColor = colorDialog.Color;

                if (m_activeEmitter != IntPtr.Zero) {
                    ParticleLib_External.SetFinishColour(m_activeEmitter, colorDialog.Color.R, colorDialog.Color.G, colorDialog.Color.B, colorDialog.Color.A);
                }
            }
        }

        private void deleteEmitter_btn_Click(object sender, EventArgs e)
        {
            if (m_activeEmitter != IntPtr.Zero)
            {
                m_emitters.Remove(m_activeEmitter);
                m_activeEmitter = IntPtr.Zero;
                // toggle off start button
                simStart_cb.Checked = false;
            }
        }

        private void particleShape_cb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (m_activeEmitter != IntPtr.Zero)
            {
                ParticleLib_External.SetParticleType(m_activeEmitter, particleShape_cb.SelectedIndex);
            }
        }

        private void saveSettingsButton_Click(object sender, EventArgs e)
        {
            if (m_activeEmitter == IntPtr.Zero)
            {
                return;
            }

            DialogResult dr = saveFileDialog.ShowDialog();
            // saves values from form controls to xml file
            if (dr == DialogResult.OK)
            {
                XmlDocument doc = new XmlDocument();
                XmlNode decNode = doc.CreateNode(XmlNodeType.XmlDeclaration, "", "");
                doc.AppendChild(decNode);

                XmlElement rootElement = doc.CreateElement("Emitter_settings");
                doc.AppendChild(rootElement);

                XmlElement position = doc.CreateElement("Position");
                position.SetAttribute("x", newEmitterXPos_tb.Text);
                position.SetAttribute("y", newEmitterYPos_tb.Text);
                rootElement.AppendChild(position);

                XmlElement emissionRate = doc.CreateElement("Emission_rate");
                emissionRate.InnerText = emissionRate_sb.SliderValue.ToString();
                rootElement.AppendChild(emissionRate);

                XmlElement maxParticles = doc.CreateElement("Max_particles");
                maxParticles.InnerText = maxParticlesNumber_sb.SliderValue.ToString();
                rootElement.AppendChild(maxParticles);

                XmlElement startColour = doc.CreateElement("Start_colour");
                startColour.SetAttribute("r", startColor_lbl.BackColor.R.ToString());
                startColour.SetAttribute("g", startColor_lbl.BackColor.G.ToString());
                startColour.SetAttribute("b", startColor_lbl.BackColor.B.ToString());
                startColour.SetAttribute("a", startColor_lbl.BackColor.A.ToString());
                rootElement.AppendChild(startColour);

                XmlElement finishColour = doc.CreateElement("Finish_colour");
                finishColour.SetAttribute("r", finishColor_lbl.BackColor.R.ToString());
                finishColour.SetAttribute("g", finishColor_lbl.BackColor.G.ToString());
                finishColour.SetAttribute("b", finishColor_lbl.BackColor.B.ToString());
                finishColour.SetAttribute("a", finishColor_lbl.BackColor.A.ToString());
                rootElement.AppendChild(finishColour);

                XmlElement particleType = doc.CreateElement("Particle_type");
                particleType.InnerText = particleShape_cb.SelectedIndex.ToString();
                rootElement.AppendChild(particleType);

                doc.Save(saveFileDialog.FileName);
            }
        }

        private void loadSettingsButton_Click(object sender, EventArgs e)
        {
            if (m_activeEmitter == IntPtr.Zero)
            {
                return;
            }

            DialogResult dr = openFileDialog.ShowDialog();

            if (dr == DialogResult.OK)
            {
                // tells dll to load emitter params from file
                ParticleLib_External.InitParticleEmitterFromFile(m_activeEmitter, openFileDialog.FileName);
                // updates form controls data
                getAttribValuesForActiveEmitter();
            }
        }

        private void getAttribValuesForActiveEmitter()
        {
            // updates form controls data 
            newEmitterXPos_tb.Text = ParticleLib_External.GetEmitterPosX(m_activeEmitter).ToString();
            newEmitterYPos_tb.Text = ParticleLib_External.GetEmitterPosY(m_activeEmitter).ToString();

            emissionRate_sb.SliderValue = ParticleLib_External.GetEmissionRate(m_activeEmitter);
            maxParticlesNumber_sb.SliderValue = ParticleLib_External.GetMaxParticles(m_activeEmitter);

            startColor_lbl.BackColor = ParseColorBits(ParticleLib_External.GetStartColour(m_activeEmitter));
            finishColor_lbl.BackColor = ParseColorBits(ParticleLib_External.GetFinishColour(m_activeEmitter));

            particleShape_cb.SelectedIndex = ParticleLib_External.GetEmitterParticleType(m_activeEmitter);
        }
    }

    public class ParticleLib_External
    {
        // functions
        [DllImport("ParticleEngineLibrary.dll",
            CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr CreateDefaultParticleEmitter();

        [DllImport("ParticleEngineLibrary.dll",
            CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr CreateParticleEmitter(float locationX, float locationY, int emissionRate, int maxParticles, int seed);

        [DllImport("ParticleEngineLibrary.dll",
            CallingConvention = CallingConvention.Cdecl)]
        public static extern void DeleteParticleEmitter(IntPtr obj);

        [DllImport("ParticleEngineLibrary.dll",
            CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr GetFirstParticle(IntPtr obj);

        [DllImport("ParticleEngineLibrary.dll",
            CallingConvention = CallingConvention.Cdecl)]
        public static extern float GetParticlePosX(IntPtr obj);

        [DllImport("ParticleEngineLibrary.dll",
            CallingConvention = CallingConvention.Cdecl)]
        public static extern float GetParticlePosY(IntPtr obj);

        [DllImport("ParticleEngineLibrary.dll",
            CallingConvention = CallingConvention.Cdecl)]
        public static extern Int32 GetParticleColour(IntPtr obj);

        [DllImport("ParticleEngineLibrary.dll",
            CallingConvention = CallingConvention.Cdecl)]
        public static extern Int32 GetParticleType(IntPtr obj);

        // instance methods
        [DllImport("ParticleEngineLibrary.dll",
            CallingConvention = CallingConvention.ThisCall,
            EntryPoint = "?StartEmitting@ParticleEmitter@@QAEXXZ")]
        public static extern float StartParticleEmitter(IntPtr obj);

        [DllImport("ParticleEngineLibrary.dll",
            CallingConvention = CallingConvention.ThisCall,
            EntryPoint = "?StopEmitting@ParticleEmitter@@QAEXXZ")]
        public static extern float StopParticleEmitter(IntPtr obj);

        [DllImport("ParticleEngineLibrary.dll",
            CallingConvention = CallingConvention.ThisCall,
            EntryPoint = "?Update@ParticleEmitter@@QAEXM@Z")]
        public static extern void Update(IntPtr obj, float delta);

        [DllImport("ParticleEngineLibrary.dll",
            CallingConvention = CallingConvention.ThisCall,
            EntryPoint = "?GetParticleCount@ParticleEmitter@@QAEHXZ")]
        public static extern int GetParticleCount(IntPtr obj);

        [DllImport("ParticleEngineLibrary.dll",
            CallingConvention = CallingConvention.ThisCall,
            EntryPoint = "?GetEmitterPosX@ParticleEmitter@@QAEMXZ")]
        public static extern float GetEmitterPosX(IntPtr obj);

        [DllImport("ParticleEngineLibrary.dll",
            CallingConvention = CallingConvention.ThisCall,
            EntryPoint = "?GetEmitterPosY@ParticleEmitter@@QAEMXZ")]
        public static extern float GetEmitterPosY(IntPtr obj);

        [DllImport("ParticleEngineLibrary.dll",
            CallingConvention = CallingConvention.ThisCall,
            EntryPoint = "?SetEmissionRate@ParticleEmitter@@QAEXH@Z")]
        public static extern float SetEmissionRate(IntPtr obj, int value);

        [DllImport("ParticleEngineLibrary.dll",
            CallingConvention = CallingConvention.ThisCall,
            EntryPoint = "?SetMaxParticles@ParticleEmitter@@QAEXH@Z")]
        public static extern float SetMaxParticles(IntPtr obj, int value);

        [DllImport("ParticleEngineLibrary.dll",
            CallingConvention = CallingConvention.ThisCall,
            EntryPoint = "?SetStartColour@ParticleEmitter@@QAEXDDDD@Z")]
        public static extern float SetStartColour(IntPtr obj, byte r, byte g, byte b, byte a);

        [DllImport("ParticleEngineLibrary.dll",
            CallingConvention = CallingConvention.ThisCall,
            EntryPoint = "?SetFinishColour@ParticleEmitter@@QAEXDDDD@Z")]
        public static extern float SetFinishColour(IntPtr obj, byte r, byte g, byte b, byte a);

        [DllImport("ParticleEngineLibrary.dll",
            CallingConvention = CallingConvention.ThisCall,
            EntryPoint = "?SetParticleType@ParticleEmitter@@QAEXH@Z")]
        public static extern float SetParticleType(IntPtr obj, int type);

        [DllImport("ParticleEngineLibrary.dll",
            CallingConvention = CallingConvention.ThisCall,
            EntryPoint = "?GetEmissionRate@ParticleEmitter@@QAEHXZ")]
        public static extern int GetEmissionRate(IntPtr obj);

        [DllImport("ParticleEngineLibrary.dll",
            CallingConvention = CallingConvention.ThisCall,
            EntryPoint = "?GetMaxParticles@ParticleEmitter@@QAEHXZ")]
        public static extern int GetMaxParticles(IntPtr obj);

        [DllImport("ParticleEngineLibrary.dll",
            CallingConvention = CallingConvention.ThisCall,
            EntryPoint = "?GetParticleType@ParticleEmitter@@QAEHXZ")]
        public static extern int GetEmitterParticleType(IntPtr obj);

        [DllImport("ParticleEngineLibrary.dll",
            CallingConvention = CallingConvention.ThisCall,
            EntryPoint = "?GetStartColour@ParticleEmitter@@QAEHXZ")]
        public static extern int GetStartColour(IntPtr obj);

        [DllImport("ParticleEngineLibrary.dll",
            CallingConvention = CallingConvention.ThisCall,
            EntryPoint = "?GetFinishColour@ParticleEmitter@@QAEHXZ")]
        public static extern int GetFinishColour(IntPtr obj);

        [DllImport("ParticleEngineLibrary.dll",
            CallingConvention = CallingConvention.ThisCall,
            EntryPoint = "?InitParticleEmitterFromFile@ParticleEmitter@@QAEXPAD@Z")]
        public static extern void InitParticleEmitterFromFile(IntPtr obj, string filePath);

        [DllImport("ParticleEngineLibrary.dll",
            CallingConvention = CallingConvention.ThisCall,
            EntryPoint = "?GetIsWorking@ParticleEmitter@@QAEHXZ")]
        public static extern int GetIsWorking(IntPtr obj);
        
    }
}
