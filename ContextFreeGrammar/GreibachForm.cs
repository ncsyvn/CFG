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
    public partial class GreibachForm : Form
    {
        string s;
        public GreibachForm(string s)
        {
            InitializeComponent();
            this.s = s;
            txtGNF.Text = s;
        }
    }
}
