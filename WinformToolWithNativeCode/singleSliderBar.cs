//
// PROG56693 Games Tools and Data-Driven Design
// February 2014
// Mikhail Kutuzov, Vladyslav Dolhopolov 
//

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WinformToolWithNativeCode
{
    public partial class singleSliderBar : UserControl
    {
        public event EventHandler SliderValueChanged;

        public String SliderTitle
        {
            get { return title_lbl.Text; }
            set { title_lbl.Text = value; }
        }

        public int SliderMin
        {
            get { return valueTrackBar_tb.Minimum; }
            set { valueTrackBar_tb.Minimum = value; }
        }

        public int SliderMax
        {
            get { return valueTrackBar_tb.Maximum; }
            set { valueTrackBar_tb.Maximum = value; }
        }

        public int SliderValue
        {
            get { return valueTrackBar_tb.Value; }
            set 
            {
                valueTrackBar_tb.Value = value;
                value_lbl.Text = value.ToString();
            }
        }

        public singleSliderBar()
        {
            InitializeComponent();
        }

        public singleSliderBar(String title, int min, int max, int startValue)
        {
            InitializeComponent();
            Init(title, min, max, startValue);
        }

        public void Init(String title, int min, int max, int startValue)
        {
            SliderTitle = title;
            SliderMin   = min;
            SliderMax   = max;
            SliderValue = startValue;
        }

        private void valueTrackBar_tb_Scroll(object sender, EventArgs e)
        {
            value_lbl.Text = valueTrackBar_tb.Value.ToString();
            if (this.SliderValueChanged != null)
            {
                this.SliderValueChanged(this, e);
            }
        }
    }
}
