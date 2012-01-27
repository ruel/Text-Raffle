namespace Text_Raffle
{
    partial class frmWon
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbWon = new System.Windows.Forms.ListBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbWon
            // 
            this.lbWon.FormattingEnabled = true;
            this.lbWon.Location = new System.Drawing.Point(12, 12);
            this.lbWon.Name = "lbWon";
            this.lbWon.Size = new System.Drawing.Size(198, 277);
            this.lbWon.TabIndex = 0;
            // 
            // btnAdd
            // 
            this.btnAdd.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.btnAdd.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnAdd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(28, 295);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "ADD";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDel
            // 
            this.btnDel.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.btnDel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnDel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnDel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDel.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDel.Location = new System.Drawing.Point(123, 295);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(75, 23);
            this.btnDel.TabIndex = 1;
            this.btnDel.Text = "DELETE";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // frmWon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(222, 327);
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lbWon);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "frmWon";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Won Entries";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lbWon;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDel;
    }
}