using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Data.OleDb;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AuthorLocations
{
    public partial class frm_Author_Locations : Form
    {
        #region Class Level
        Hashtable hCountry = new Hashtable();
        Hashtable hCity = new Hashtable();        

        public const String DB_File = "CountryDB.mdb";     
        public const String ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + DB_File;
        public OleDbConnection Con;
        OleDbCommand CMD = new OleDbCommand();        
        const String Tilda = "~";
        const String SemiColon = ";";
        const String Comma = ",";
        const String Tab = "\t";
        public String Program_Title = "Author Locatin Finder (Shahnela Naz)";
        private ListViewSortManager sortMgr_Auth;

        public frm_Author_Locations()
        {
            InitializeComponent();
            Initialize_DB();
            Generate_Hashtable();

            // Enable Power of Sorting in the Listviews
            sortMgr_Auth = new ListViewSortManager(lvw_Authors,
            new Type[] {
            typeof(ListViewTextSort),            // first colum
            typeof(ListViewTextSort),          // second column and so on..
            typeof(ListViewTextSort),          // second column and so on..
            typeof(ListViewTextSort),          // second column and so on..            
          });


        }

        #endregion
        
        #region Initialize_DB()
        private void Initialize_DB()
        {
            try
            {
                Con = new OleDbConnection(ConnectionString);
                Con.Open();
                CMD.Connection = Con;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Program_Title, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
        }
        #endregion
        
        #region Start
        private void btn_Start_Click(object sender, EventArgs e)
        {
           tbx_Display.Text = Identify_From_HomePage_URL();
        }
        #endregion
        
        #region Populate Hashtables (Countries, Cities)
        private void Generate_Hashtable()
        {
            OleDbDataReader R; 
            CMD.CommandText = "Select * from Country";
            R = CMD.ExecuteReader();
            while (R.Read())
            {                
                 hCountry.Add(R[2].ToString().ToLower(), R[1]);
                //if (hCity.Contains(R[3]) == false)
                //    hCity.Add(R[3], R[2]);
                
            }
            R.Close();
            tbx_Display.Text = "All Hashtable Generated...";
        }
        #endregion
        
        #region Identify_From_HomePage_URL()

        private String Identify_From_HomePage_URL()
        {
            String[] Line = new String[4];
            ListViewItem L;
            String URL = String.Empty;
            String IdentifiedCountry = String.Empty;
            lvw_Authors.Items.Clear();

            StreamReader SR = File.OpenText(Application.StartupPath + "\\HomePages.txt");
            while (!SR.EndOfStream)
            {
                Line = SR.ReadLine().Split(Tab.ToCharArray());
                URL = Line[1].ToLower();                
                L = lvw_Authors.Items.Add(Line[0].ToString());
                // Identify from URL;
                Boolean ContiueRun = true;

                IDictionaryEnumerator ID = hCountry.GetEnumerator();
                while (ID.MoveNext() && (ContiueRun) )
                {
                    // Rule 1.
                    String Rule_1 = "." + ID.Key.ToString() + "/";
                    String Rule_2 = "." + ID.Key.ToString() + ":";
                    String Rule_3 = "." + ID.Key.ToString() + " ";
                    String URL_with_Space = URL + " ";

                    if ((URL.Contains(Rule_1) == true) || 
                        (URL.Contains(Rule_2) == true) ||
                        (URL_with_Space.Contains(Rule_3) == true)) 

                    {
                        ContiueRun = false;
                        IdentifiedCountry = ID.Value.ToString();                        
                           
                    }
                }


                L.SubItems.Add(IdentifiedCountry);
                L.SubItems.Add("");
                L.SubItems.Add(URL);
                IdentifiedCountry = "";                          
               
            }
            SR.Close();
            SR.Dispose();
            return lvw_Authors.Items.Count.ToString() + " Authors Identified with their Locations..";
        }

        #endregion
                
        #region Extract all Homepage Link
        private void btn_Extract_All_Homepage_Links_Click(object sender, EventArgs e)
        {
            tbx_Display.Text = Extract_All_Homepage_Links();
        }

        //   <www key="homepages/m/DavidMaier" ...>
        //   <author>David Maier</author>
        //       <title>Home Page</title>
        //       <url>http://web.cecs.pdx.edu/maier/</url>
        //   </www>

        private String Extract_All_Homepage_Links()
        {
            String HomePage = String.Empty; // "Nothing Found";
            String Author = String.Empty;
            String Line = String.Empty;
            String sPath = "D:\\web knowledge\\Xperts\\dblp.xml";
            StreamReader SR = File.OpenText(sPath);
            StreamWriter SW = File.AppendText(Application.StartupPath + "\\" + "HomePages.txt");
            while (!SR.EndOfStream)
            {
                Line = SR.ReadLine();
                if (Line.Contains("<www") == true) // found <www TAG
                {
                    Line = SR.ReadLine(); // read <author TAG
                    if (Line.Contains("<author") == true)
                    {
                        Line = Line.Replace("<author>", "");
                        Line = Line.Replace("</author>", "");
                        Author = Line;
                        Line = SR.ReadLine(); // move to <title TAG
                        if (Line.Contains("<title>Home Page</title>") == true)
                        {
                            Line = SR.ReadLine();
                            Line = Line.Replace("<url>", "");
                            Line = Line.Replace("</www>", "");
                            HomePage = Line.Replace("</url>", "");

                            HomePage = HomePage.Trim();
                            if (HomePage.Length > 2)
                            {
                                if ((HomePage.Contains("<note") == true) || (HomePage.Contains("<cite") == true))
                                { } // do nothing..
                                else
                                    SW.WriteLine(Author + Tab + HomePage);
                            }
                        }
                    }
                }
            }
            SR.Close();
            SR.Dispose();
            SW.Close();
            SW.Dispose();

            return "All Home Pages link extracted ";
        }

        #endregion

        #region Save All Records
        private void btn_Save_Click(object sender, EventArgs e)
        {
           String FilePath = Application.StartupPath + "\\" + "HomePages_with_Country.txt";
           File.Delete(FilePath);
           StreamWriter SW = File.AppendText(FilePath);
           ListViewItem L;
           String Line = String.Empty;
            int i = 0;
           for (i = 0; i < lvw_Authors.Items.Count; i++)
           {
                L = lvw_Authors.Items[i];
                Line = L.Text + Tab + L.SubItems[1].Text + Tab + L.SubItems[3].Text + Environment.NewLine;
                SW.WriteLine (Line); 
           }
           tbx_Display.Text = i.ToString() + " Authors Written..";
        }
        #endregion
       

    }
}
