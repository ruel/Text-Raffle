using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using Text_Raffle.Properties;
using System.Collections.Specialized;

namespace Text_Raffle
{
    public partial class frmMain : Form
    {
        #region Global Variables

        private List<string> entries, won;
        private bool pause = false, jrun = false;
        private Random randomizer = new Random();
        private object syncL = new object();

        #endregion

        #region Class / Custom Methods

        /// <summary>
        /// Initializes a new instance of the <see cref="frmMain"/> class.
        /// </summary>
        public frmMain()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Method for prompting won entries.
        /// </summary>
        private void queryMark()
        {
            if (jrun)
            {
                if (MessageBox.Show(this, "Mark entry as won?", "Winner", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    won.Add(lblWinner.Text);
                }
                jrun = false;
            }
        }

        /// <summary>
        /// Loads a file to a list.
        /// </summary>
        private void loadFile()
        {
            entries = new List<string>();
            StreamReader reader = new StreamReader(txtSource.Text);
            string line = "";
            while (!reader.EndOfStream)
            {
                line = reader.ReadLine().Trim();
                if (line == "")
                {
                    continue;
                }

                entries.Add(line);
            }

            lblNumEntries.Text = entries.Count.ToString();
        }

        /// <summary>
        /// Better random number generator
        /// </summary>
        /// <param name="min">Starting value.</param>
        /// <param name="max">Maximum value.</param>
        /// <returns>Random number</returns>
        public int randomNumber(int min, int max)
        {
            lock (syncL)
            {
                return randomizer.Next(min, max);
            }
        }

        #endregion

        #region Control Event Methods

        /// <summary>
        /// Handles the Load event of the frmMain control.
        /// Turns the window into full screen, loads the saved settings, and initializes the main lists.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void frmMain_Load(object sender, EventArgs e)
        {
            this.Bounds = Screen.PrimaryScreen.Bounds;
            won = new List<string>();
            if (!(Settings.Default["Won"] == null))
            {
                won = new List<string>(((string)Settings.Default["Won"]).Split('|'));
            }
            entries = new List<string>();
        }

        /// <summary>
        /// Handles the Click event of the btnExit control.
        /// Exits the application.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Handles the Click event of the btnStart control.
        /// Start and pause button. Triggers the two timers used.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void btnStart_Click(object sender, EventArgs e)
        {
            queryMark();
            if (entries.Count < 2)
            {
                return;
            }
            if (!pause)
            {
                tmMain.Interval = 10;
                tmMain.Enabled = true;
                btnStart.Image = Text_Raffle.Properties.Resources.pause_03;
                pause = true;
            }
            else
            {
                tmCtrl.Enabled = true;
                btnStart.Image = Text_Raffle.Properties.Resources.start_032;
                pause = false;
            }
        }

        /// <summary>
        /// Handles the Click event of the btnSource control.
        /// Triggers the Open File Dialog, and executes the loadFile method.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void btnSource_Click(object sender, EventArgs e)
        {
            ofd.ShowDialog();
            if (ofd.FileName == "")
            {
                return;
            }

            txtSource.Text = ofd.FileName;
            loadFile();
        }

        /// <summary>
        /// Handles the Tick event of the tmMain control.
        /// Main timer that randomizes the names.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void tmMain_Tick(object sender, EventArgs e)
        {
            string entry = "";
            entry = entries[randomNumber(0, entries.Count)];
            while (won.Contains(entry, StringComparer.Ordinal) && won.Count > 1)
            {
                entry = entries[randomNumber(0, entries.Count)];
            }
            lblWinner.Text = entry;
        }

        /// <summary>
        /// Handles the Tick event of the tmCtrl control.
        /// Stopping timer, gradually slows (increases interval) randomizing.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void tmCtrl_Tick(object sender, EventArgs e)
        {
            tmMain.Interval += 40;
            if (tmMain.Interval >= 400)
            {
                tmMain.Enabled = false;
                tmCtrl.Enabled = false;
                jrun = true;
            }
        }

        /// <summary>
        /// Handles the FormClosing event of the frmMain control.
        /// Saves the settings before closing.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.FormClosingEventArgs"/> instance containing the event data.</param>
        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            queryMark();
            //MessageBox.Show(String.Join("|", won.ToArray()));
            Settings.Default["Won"] = String.Join("|", won.ToArray());
            Settings.Default.Save();
        }

        /// <summary>
        /// Handles the LinkClicked event of the llView control.
        /// Opens up the won entry list.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.LinkLabelLinkClickedEventArgs"/> instance containing the event data.</param>
        private void llView_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            queryMark();
            frmWon wonFrm = new frmWon();
            wonFrm.loadList(won);
            wonFrm.ShowDialog();
            won = new List<string>();
            won = wonFrm.updateList();
        }

        #endregion
    }
}
