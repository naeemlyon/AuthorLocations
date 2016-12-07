namespace AuthorLocations
{
    partial class frmExpert
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
            System.Windows.Forms.Button btn_Start;
            this.lvw_Marginalized = new System.Windows.Forms.ListView();
            this.columnHeader11 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader12 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader13 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader14 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader15 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader16 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader17 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader19 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader21 = new System.Windows.Forms.ColumnHeader();
            this.rad_generalTerms = new System.Windows.Forms.RadioButton();
            this.rad_coOccuredKeywords = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.columnHeader9 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader8 = new System.Windows.Forms.ColumnHeader();
            this.tbx_Display = new System.Windows.Forms.TextBox();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader27 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader28 = new System.Windows.Forms.ColumnHeader();
            this.lvw_Authors = new System.Windows.Forms.ListView();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader10 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader18 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader20 = new System.Windows.Forms.ColumnHeader();
            this.lvw_Keywords = new System.Windows.Forms.ListView();
            this.btn_Detect_City = new System.Windows.Forms.Button();
            this.lvw_Detail = new System.Windows.Forms.ListView();
            this.columnHeader22 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader23 = new System.Windows.Forms.ColumnHeader();
            this.btn_Visualization = new System.Windows.Forms.Button();
            this.btn_Gen_All_SVG = new System.Windows.Forms.Button();
            this.cbo_Master = new System.Windows.Forms.ComboBox();
            this.btn_Display_Item = new System.Windows.Forms.Button();
            btn_Start = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_Start
            // 
            btn_Start.BackColor = System.Drawing.Color.Gold;
            btn_Start.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            btn_Start.ForeColor = System.Drawing.Color.DarkGreen;
            btn_Start.Location = new System.Drawing.Point(1012, 635);
            btn_Start.Name = "btn_Start";
            btn_Start.Size = new System.Drawing.Size(83, 40);
            btn_Start.TabIndex = 120;
            btn_Start.Text = "Start";
            btn_Start.UseVisualStyleBackColor = false;
            btn_Start.Click += new System.EventHandler(this.btn_Start_Click);
            // 
            // lvw_Marginalized
            // 
            this.lvw_Marginalized.BackColor = System.Drawing.Color.LightPink;
            this.lvw_Marginalized.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader11,
            this.columnHeader12,
            this.columnHeader13,
            this.columnHeader14,
            this.columnHeader15,
            this.columnHeader16,
            this.columnHeader17,
            this.columnHeader19,
            this.columnHeader21});
            this.lvw_Marginalized.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvw_Marginalized.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lvw_Marginalized.FullRowSelect = true;
            this.lvw_Marginalized.GridLines = true;
            this.lvw_Marginalized.HideSelection = false;
            this.lvw_Marginalized.Location = new System.Drawing.Point(2, 205);
            this.lvw_Marginalized.MultiSelect = false;
            this.lvw_Marginalized.Name = "lvw_Marginalized";
            this.lvw_Marginalized.Size = new System.Drawing.Size(829, 226);
            this.lvw_Marginalized.TabIndex = 121;
            this.lvw_Marginalized.UseCompatibleStateImageBehavior = false;
            this.lvw_Marginalized.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "";
            this.columnHeader11.Width = 130;
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "Publications";
            this.columnHeader12.Width = 85;
            // 
            // columnHeader13
            // 
            this.columnHeader13.Text = "Citation";
            this.columnHeader13.Width = 65;
            // 
            // columnHeader14
            // 
            this.columnHeader14.Text = "coAuthNet";
            this.columnHeader14.Width = 80;
            // 
            // columnHeader15
            // 
            this.columnHeader15.Text = "5.Year.Pub";
            this.columnHeader15.Width = 90;
            // 
            // columnHeader16
            // 
            this.columnHeader16.Text = "This.Topic.Pub";
            this.columnHeader16.Width = 110;
            // 
            // columnHeader17
            // 
            this.columnHeader17.Text = "Score";
            this.columnHeader17.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader17.Width = 120;
            // 
            // columnHeader19
            // 
            this.columnHeader19.Text = "Country";
            // 
            // columnHeader21
            // 
            this.columnHeader21.Text = "City";
            // 
            // rad_generalTerms
            // 
            this.rad_generalTerms.AutoSize = true;
            this.rad_generalTerms.Checked = true;
            this.rad_generalTerms.Location = new System.Drawing.Point(6, 16);
            this.rad_generalTerms.Name = "rad_generalTerms";
            this.rad_generalTerms.Size = new System.Drawing.Size(107, 17);
            this.rad_generalTerms.TabIndex = 110;
            this.rad_generalTerms.TabStop = true;
            this.rad_generalTerms.Text = "General Terms";
            this.rad_generalTerms.UseVisualStyleBackColor = true;
            // 
            // rad_coOccuredKeywords
            // 
            this.rad_coOccuredKeywords.AutoSize = true;
            this.rad_coOccuredKeywords.Location = new System.Drawing.Point(173, 16);
            this.rad_coOccuredKeywords.Name = "rad_coOccuredKeywords";
            this.rad_coOccuredKeywords.Size = new System.Drawing.Size(149, 17);
            this.rad_coOccuredKeywords.TabIndex = 109;
            this.rad_coOccuredKeywords.Text = "co Occured Keywords";
            this.rad_coOccuredKeywords.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Green;
            this.groupBox1.Controls.Add(this.rad_generalTerms);
            this.groupBox1.Controls.Add(this.rad_coOccuredKeywords);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Gold;
            this.groupBox1.Location = new System.Drawing.Point(839, 583);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(347, 48);
            this.groupBox1.TabIndex = 117;
            this.groupBox1.TabStop = false;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Score";
            this.columnHeader9.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader9.Width = 150;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Web.Wt";
            this.columnHeader8.Width = 85;
            // 
            // tbx_Display
            // 
            this.tbx_Display.BackColor = System.Drawing.Color.LemonChiffon;
            this.tbx_Display.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbx_Display.ForeColor = System.Drawing.Color.OliveDrab;
            this.tbx_Display.Location = new System.Drawing.Point(12, 641);
            this.tbx_Display.Multiline = true;
            this.tbx_Display.Name = "tbx_Display";
            this.tbx_Display.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbx_Display.Size = new System.Drawing.Size(478, 31);
            this.tbx_Display.TabIndex = 116;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Authors";
            // 
            // columnHeader27
            // 
            this.columnHeader27.Text = "Publications";
            this.columnHeader27.Width = 80;
            // 
            // columnHeader28
            // 
            this.columnHeader28.Text = "Topic";
            this.columnHeader28.Width = 200;
            // 
            // lvw_Authors
            // 
            this.lvw_Authors.BackColor = System.Drawing.Color.LightSteelBlue;
            this.lvw_Authors.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader10,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader18,
            this.columnHeader20});
            this.lvw_Authors.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvw_Authors.ForeColor = System.Drawing.Color.Crimson;
            this.lvw_Authors.FullRowSelect = true;
            this.lvw_Authors.GridLines = true;
            this.lvw_Authors.HideSelection = false;
            this.lvw_Authors.Location = new System.Drawing.Point(2, 0);
            this.lvw_Authors.MultiSelect = false;
            this.lvw_Authors.Name = "lvw_Authors";
            this.lvw_Authors.Size = new System.Drawing.Size(1192, 199);
            this.lvw_Authors.TabIndex = 118;
            this.lvw_Authors.UseCompatibleStateImageBehavior = false;
            this.lvw_Authors.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Author";
            this.columnHeader2.Width = 130;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Publications";
            this.columnHeader3.Width = 85;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Citation";
            this.columnHeader4.Width = 65;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "coAuthNet";
            this.columnHeader5.Width = 80;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "5.Year.Pub";
            this.columnHeader10.Width = 90;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "This.Topic.Pub";
            this.columnHeader6.Width = 110;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Non.Web.Wt";
            this.columnHeader7.Width = 125;
            // 
            // columnHeader18
            // 
            this.columnHeader18.Text = "Country";
            this.columnHeader18.Width = 150;
            // 
            // columnHeader20
            // 
            this.columnHeader20.Text = "City";
            this.columnHeader20.Width = 80;
            // 
            // lvw_Keywords
            // 
            this.lvw_Keywords.BackColor = System.Drawing.Color.PowderBlue;
            this.lvw_Keywords.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader28,
            this.columnHeader27,
            this.columnHeader1});
            this.lvw_Keywords.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvw_Keywords.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lvw_Keywords.FullRowSelect = true;
            this.lvw_Keywords.GridLines = true;
            this.lvw_Keywords.HideSelection = false;
            this.lvw_Keywords.Location = new System.Drawing.Point(837, 205);
            this.lvw_Keywords.MultiSelect = false;
            this.lvw_Keywords.Name = "lvw_Keywords";
            this.lvw_Keywords.Size = new System.Drawing.Size(363, 373);
            this.lvw_Keywords.TabIndex = 115;
            this.lvw_Keywords.UseCompatibleStateImageBehavior = false;
            this.lvw_Keywords.View = System.Windows.Forms.View.Details;
            this.lvw_Keywords.Click += new System.EventHandler(this.lvw_Keywords_Click);
            // 
            // btn_Detect_City
            // 
            this.btn_Detect_City.Location = new System.Drawing.Point(1103, 635);
            this.btn_Detect_City.Name = "btn_Detect_City";
            this.btn_Detect_City.Size = new System.Drawing.Size(83, 37);
            this.btn_Detect_City.TabIndex = 122;
            this.btn_Detect_City.Text = "Detect City";
            this.btn_Detect_City.UseVisualStyleBackColor = true;
            this.btn_Detect_City.Click += new System.EventHandler(this.btn_Detect_City_Click);
            // 
            // lvw_Detail
            // 
            this.lvw_Detail.BackColor = System.Drawing.Color.Pink;
            this.lvw_Detail.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader22,
            this.columnHeader23});
            this.lvw_Detail.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvw_Detail.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lvw_Detail.FullRowSelect = true;
            this.lvw_Detail.GridLines = true;
            this.lvw_Detail.HideSelection = false;
            this.lvw_Detail.Location = new System.Drawing.Point(12, 476);
            this.lvw_Detail.MultiSelect = false;
            this.lvw_Detail.Name = "lvw_Detail";
            this.lvw_Detail.Size = new System.Drawing.Size(478, 156);
            this.lvw_Detail.TabIndex = 126;
            this.lvw_Detail.UseCompatibleStateImageBehavior = false;
            this.lvw_Detail.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader22
            // 
            this.columnHeader22.Text = "Topic";
            this.columnHeader22.Width = 340;
            // 
            // columnHeader23
            // 
            this.columnHeader23.Text = "Frequency";
            this.columnHeader23.Width = 80;
            // 
            // btn_Visualization
            // 
            this.btn_Visualization.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Visualization.Location = new System.Drawing.Point(754, 641);
            this.btn_Visualization.Name = "btn_Visualization";
            this.btn_Visualization.Size = new System.Drawing.Size(93, 34);
            this.btn_Visualization.TabIndex = 127;
            this.btn_Visualization.Text = "Visualization";
            this.btn_Visualization.UseVisualStyleBackColor = true;
            this.btn_Visualization.Click += new System.EventHandler(this.btn_Visualization_Click);
            // 
            // btn_Gen_All_SVG
            // 
            this.btn_Gen_All_SVG.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.btn_Gen_All_SVG.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Gen_All_SVG.ForeColor = System.Drawing.Color.Red;
            this.btn_Gen_All_SVG.Location = new System.Drawing.Point(853, 639);
            this.btn_Gen_All_SVG.Name = "btn_Gen_All_SVG";
            this.btn_Gen_All_SVG.Size = new System.Drawing.Size(153, 36);
            this.btn_Gen_All_SVG.TabIndex = 128;
            this.btn_Gen_All_SVG.Text = "Gen All SVG";
            this.btn_Gen_All_SVG.UseVisualStyleBackColor = false;
            this.btn_Gen_All_SVG.Click += new System.EventHandler(this.btn_Gen_All_SVG_Click);
            // 
            // cbo_Master
            // 
            this.cbo_Master.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbo_Master.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbo_Master.FormattingEnabled = true;
            this.cbo_Master.Location = new System.Drawing.Point(12, 439);
            this.cbo_Master.Name = "cbo_Master";
            this.cbo_Master.Size = new System.Drawing.Size(344, 21);
            this.cbo_Master.TabIndex = 131;
            // 
            // btn_Display_Item
            // 
            this.btn_Display_Item.Location = new System.Drawing.Point(388, 437);
            this.btn_Display_Item.Name = "btn_Display_Item";
            this.btn_Display_Item.Size = new System.Drawing.Size(92, 29);
            this.btn_Display_Item.TabIndex = 132;
            this.btn_Display_Item.Text = "Go";
            this.btn_Display_Item.UseVisualStyleBackColor = true;
            this.btn_Display_Item.Click += new System.EventHandler(this.btn_Display_Item_Click);
            // 
            // frmExpert
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1204, 680);
            this.Controls.Add(this.btn_Display_Item);
            this.Controls.Add(this.cbo_Master);
            this.Controls.Add(this.btn_Gen_All_SVG);
            this.Controls.Add(this.btn_Visualization);
            this.Controls.Add(this.lvw_Detail);
            this.Controls.Add(this.btn_Detect_City);
            this.Controls.Add(this.lvw_Marginalized);
            this.Controls.Add(btn_Start);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tbx_Display);
            this.Controls.Add(this.lvw_Authors);
            this.Controls.Add(this.lvw_Keywords);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmExpert";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmExperts";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvw_Marginalized;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.ColumnHeader columnHeader13;
        private System.Windows.Forms.ColumnHeader columnHeader14;
        private System.Windows.Forms.ColumnHeader columnHeader15;
        private System.Windows.Forms.ColumnHeader columnHeader16;
        private System.Windows.Forms.ColumnHeader columnHeader17;
        private System.Windows.Forms.RadioButton rad_generalTerms;
        private System.Windows.Forms.RadioButton rad_coOccuredKeywords;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.TextBox tbx_Display;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader27;
        private System.Windows.Forms.ColumnHeader columnHeader28;
        private System.Windows.Forms.ListView lvw_Authors;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ListView lvw_Keywords;
        private System.Windows.Forms.ColumnHeader columnHeader18;
        private System.Windows.Forms.ColumnHeader columnHeader19;
        private System.Windows.Forms.ColumnHeader columnHeader20;
        private System.Windows.Forms.ColumnHeader columnHeader21;
        private System.Windows.Forms.Button btn_Detect_City;
        private System.Windows.Forms.ListView lvw_Detail;
        private System.Windows.Forms.ColumnHeader columnHeader22;
        private System.Windows.Forms.ColumnHeader columnHeader23;
        private System.Windows.Forms.Button btn_Visualization;
        private System.Windows.Forms.Button btn_Gen_All_SVG;
        private System.Windows.Forms.ComboBox cbo_Master;
        private System.Windows.Forms.Button btn_Display_Item;
    }
}