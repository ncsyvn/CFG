using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ContextFreeGrammar
{
    public partial class DrawLineInt : Form
    {
        private List<Road> road = new List<Road>();
        public DrawLineInt(List<Road> road)
        {
            this.road = road;
            InitializeComponent();
            DrawLine(1, 1,1 ,1);
        }

        private void DrawLine(int x1, int y1, int x2, int y2)
        {
            Color m = Color.AliceBlue;
            Graphics dohoa = this.CreateGraphics();
            x1 = 200;
            y1 = 50;
            x2 = 400;
            y2 = 100;
            dohoa.DrawLine(new Pen(m, 5), x1, y1, x2, y2);
        }
    }
}
