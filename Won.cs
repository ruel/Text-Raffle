using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Text_Raffle
{
    public partial class frmWon : Form
    {
        #region Global Variables

        List<string> won;

        #endregion

        #region Class / Custom Methods

        /// <summary>
        /// Initializes a new instance of the <see cref="frmWon"/> class.
        /// </summary>
        public frmWon()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Called from the parent form.
        /// </summary>
        /// <returns>Updated list of won entries</returns>
        public List<string> updateList()
        {
            won = new List<string>();
            foreach (string val in lbWon.Items)
            {
                won.Add(val);
            }
            return won;
        }

        /// <summary>
        /// Loads the list from the parent form to the listbox.
        /// </summary>
        /// <param name="won">Won entries in the parent form</param>
        public void loadList(List<string> won)
        {
            foreach (string entry in won)
            {
                lbWon.Items.Add(entry);
            }
        }

        #endregion

        #region Control Event Methods

        /// <summary>
        /// Handles the Click event of the btnDel control.
        /// Removes an entry from the list.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void btnDel_Click(object sender, EventArgs e)
        {
            if (lbWon.SelectedItems.Count > 0)
            {
                lbWon.Items.Remove(lbWon.SelectedItems[0]);
            }
        }

        /// <summary>
        /// Handles the Click event of the btnAdd control.
        /// Adds an entry to the list.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAddWon awFrm = new frmAddWon();
            awFrm.ShowDialog(this);
            string toAdd = awFrm.getInput();
            if (toAdd != "")
            {
                lbWon.Items.Add(toAdd);
            }
        }

        #endregion
    }
}
