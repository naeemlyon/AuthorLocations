namespace AuthorLocations
{
    partial class frm_Author_Locations
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
            this.btn_Start = new System.Windows.Forms.Button();
            this.lvw_Authors = new System.Windows.Forms.ListView();
            this.columnHeader28 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader27 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.tbx_Display = new System.Windows.Forms.TextBox();
            this.btn_Extract_All_Homepage_Links = new System.Windows.Forms.Button();
            this.btn_Save = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_Start
            // 
            this.btn_Start.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Start.ForeColor = System.Drawing.Color.DeepPink;
            this.btn_Start.Location = new System.Drawing.Point(697, 461);
            this.btn_Start.Name = "btn_Start";
            this.btn_Start.Size = new System.Drawing.Size(133, 34);
            this.btn_Start.TabIndex = 0;
            this.btn_Start.Text = "Start";
            this.btn_Start.UseVisualStyleBackColor = true;
            this.btn_Start.Click += new System.EventHandler(this.btn_Start_Click);
            // 
            // lvw_Authors
            // 
            this.lvw_Authors.BackColor = System.Drawing.Color.PowderBlue;
            this.lvw_Authors.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader28,
            this.columnHeader27,
            this.columnHeader1,
            this.columnHeader2});
            this.lvw_Authors.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvw_Authors.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lvw_Authors.FullRowSelect = true;
            this.lvw_Authors.GridLines = true;
            this.lvw_Authors.HideSelection = false;
            this.lvw_Authors.Location = new System.Drawing.Point(2, 2);
            this.lvw_Authors.MultiSelect = false;
            this.lvw_Authors.Name = "lvw_Authors";
            this.lvw_Authors.Size = new System.Drawing.Size(990, 411);
            this.lvw_Authors.TabIndex = 87;
            this.lvw_Authors.UseCompatibleStateImageBehavior = false;
            this.lvw_Authors.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader28
            // 
            this.columnHeader28.Text = "Author";
            this.columnHeader28.Width = 250;
            // 
            // columnHeader27
            // 
            this.columnHeader27.Text = "Country";
            this.columnHeader27.Width = 160;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "City";
            this.columnHeader1.Width = 160;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "URL";
            this.columnHeader2.Width = 400;
            // 
            // tbx_Display
            // 
            this.tbx_Display.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbx_Display.ForeColor = System.Drawing.Color.MediumBlue;
            this.tbx_Display.Location = new System.Drawing.Point(2, 459);
            this.tbx_Display.Multiline = true;
            this.tbx_Display.Name = "tbx_Display";
            this.tbx_Display.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbx_Display.Size = new System.Drawing.Size(671, 36);
            this.tbx_Display.TabIndex = 95;
            // 
            // btn_Extract_All_Homepage_Links
            // 
            this.btn_Extract_All_Homepage_Links.Location = new System.Drawing.Point(12, 419);
            this.btn_Extract_All_Homepage_Links.Name = "btn_Extract_All_Homepage_Links";
            this.btn_Extract_All_Homepage_Links.Size = new System.Drawing.Size(170, 34);
            this.btn_Extract_All_Homepage_Links.TabIndex = 107;
            this.btn_Extract_All_Homepage_Links.Text = "Extract All Homepage Links";
            this.btn_Extract_All_Homepage_Links.UseVisualStyleBackColor = true;
            this.btn_Extract_All_Homepage_Links.Click += new System.EventHandler(this.btn_Extract_All_Homepage_Links_Click);
            // 
            // btn_Save
            // 
            this.btn_Save.Location = new System.Drawing.Point(848, 460);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(120, 35);
            this.btn_Save.TabIndex = 108;
            this.btn_Save.Text = "Save";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // frm_Author_Locations
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(996, 495);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.btn_Extract_All_Homepage_Links);
            this.Controls.Add(this.tbx_Display);
            this.Controls.Add(this.lvw_Authors);
            this.Controls.Add(this.btn_Start);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frm_Author_Locations";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DBLP Author Location (Shahnela Naz)";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Start;
        private System.Windows.Forms.ListView lvw_Authors;
        private System.Windows.Forms.ColumnHeader columnHeader28;
        private System.Windows.Forms.ColumnHeader columnHeader27;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.TextBox tbx_Display;
        private System.Windows.Forms.Button btn_Extract_All_Homepage_Links;
        private System.Windows.Forms.Button btn_Save;
    }
}

