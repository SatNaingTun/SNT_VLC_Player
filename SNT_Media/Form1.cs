using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace SNT_Media_Player
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            directOpen();
           
        }
        private void directOpen()
        {
            try
            {
               // axVLCPlugin21.playlist.togglePause();
                axVLCPlugin21.playlist.stop();
                
               axVLCPlugin21.playlist.items.clear();

                addPlayList();
                axVLCPlugin21.playlist.play();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void addPlayList()
        {
            OpenFileDialog openfile = new OpenFileDialog();

            openfile.Filter = "(*.mp4;*.flv;*.mkv;*.avi;*.wmv)|*.mp4;*.flv;*.mkv;*.avi;*.wmv";
            if (openfile.ShowDialog() == DialogResult.OK)
            {
                string path = System.IO.Path.GetFullPath(openfile.FileName);

                axVLCPlugin21.playlist.add("file:///" + path);


            }
        }

        private void axVLCPlugin21_ClickEvent(object sender, EventArgs e)
        {
            directOpen();
        }
    }
}
