using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TRex.MPS
{
    public partial class GeneratedCodesForm : Form
    {
        string[,] magnifiedNumbers = {
            { "  _ ", "   ", "  _ ", " _ ", "    ", "  _ ", "  _ ", " _ ", "  _ ", "  _ " },
            { " | |", " | ", "  _|", " _|", " |_|", " |_ ", " |_ ", "  |", " |_|", " |_|" },
            { " |_|", " | ", " |_ ", " _|", "   |", "  _|", " |_|", "  |", " |_|", "  _|" }
        };

        public GeneratedCodesForm()
        {
            InitializeComponent();
        }
    }
}
