using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MOBZync
{
  public partial class ShowTextForm : Form
  {
    public ShowTextForm(string s)
    {
      InitializeComponent();

      this.textBox1.Text = s;
      this.textBox1.SelectionStart = 0;
      this.textBox1.SelectionLength = 0;
    }
  }
}