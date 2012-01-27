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
    public partial class frmAddWon : Form
    {
        #region Global Variables

        public string inp = "";
        private bool but = false;

        #endregion

        #region Class / Custom Methods

        /// <summary>
        /// Initializes a new instance of the <see cref="frmAddWon"/> class.
        /// </summary>
        public frmAddWon()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Returns the input from the variable inp to the parent form.
        /// </summary>
        /// <returns>Input string</returns>
        public string getInput()
        {
            if (!but)
                return "";
            else
                return inp;
        }

        #endregion

        #region Control Event Methods

        /// <summary>
        /// Handles the Click event of the btnAdd control.
        /// Adds the input to the won entry list, and closes the form.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            inp = txtAdd.Text;
            but = true;
            this.Hide();
        }

        #endregion
    }
}
