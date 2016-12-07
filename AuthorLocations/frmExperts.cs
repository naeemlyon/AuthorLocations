using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Collections;
using System.Windows.Forms;
using System.Net;

namespace AuthorLocations
{
    public partial class frmExpert : Form
    {
        #region Local Variables
        const String Tab = "\t";
        const String Tilda = "~";
        const String SemiColon = ";";
        const String Comma = ",";
        const int MaxWidth = 1350;
        const int MaxHeight = 750;
        const int itemCapcity = 41;
        String byAuthor_byTopic = String.Empty;

        Hashtable hCountry = new Hashtable();
        Hashtable hCity = new Hashtable();
        Hashtable AC = new Hashtable();
        Hashtable AU = new Hashtable();           

        public const String DB_File = "CountryDB.mdb";
        public const String ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + DB_File;
        public OleDbConnection Con;
        OleDbCommand CMD = new OleDbCommand();        
        public String Program_Title = "Author Locatin Finder (Shahnela Naz)";
        Hashtable A = new Hashtable(); // for authors on load time...

        /////////////////////////////////////////////////////////////
        String[] Clrs = new String[55];
        int Radius = 0;
        Hashtable hAuth = new Hashtable();
        Hashtable hTopic = new Hashtable();
        Hashtable Author_Topics = new Hashtable();         
        /////////////////////////////////////////////////////////////


        // Enable Power of Sorting for Listviews
        private ListViewSortManager sortMgr_Topics, sortMgr_Auth, sortMgr_Marginalized;

        public frmExpert()
        {
            InitializeComponent();
            this.Text = Program_Title;
            Initialize_DB();
            Generate_Hashtable();
            // Enable Power of Sorting in the Listviews
            sortMgr_Auth = new ListViewSortManager(lvw_Authors,
            new Type[] {
            typeof(ListViewTextSort),            // first colum
            typeof(ListViewDoubleSort),          // second column and so on..
            typeof(ListViewDoubleSort),
            typeof(ListViewDoubleSort),
            typeof(ListViewDoubleSort),
            typeof(ListViewDoubleSort),
            typeof(ListViewDoubleSort),
            typeof(ListViewDoubleSort),
            typeof(ListViewDoubleSort),
            typeof(ListViewDoubleSort),   
            typeof(ListViewTextSort),            // Country
            typeof(ListViewTextSort),            // City             
          });

            sortMgr_Topics = new ListViewSortManager(lvw_Keywords,
                        new Type[] {
            typeof(ListViewTextSort),            
            typeof(ListViewInt32Sort),
            typeof(ListViewInt32Sort),            
          });

            sortMgr_Marginalized = new ListViewSortManager(lvw_Marginalized,
            new Type[] {
            typeof(ListViewTextSort),            // first colum
            typeof(ListViewDoubleSort),          // second column and so on..
            typeof(ListViewDoubleSort),
            typeof(ListViewDoubleSort),
            typeof(ListViewDoubleSort),
            typeof(ListViewDoubleSort),
            typeof(ListViewDoubleSort),
            typeof(ListViewDoubleSort),
            typeof(ListViewDoubleSort),
            typeof(ListViewDoubleSort),            
            typeof(ListViewTextSort),            // Country
            typeof(ListViewTextSort),            // City 
            
          });

          // Populate_Authors_Topics("Authors.txt");
            Populate_Authors_Topics("Topics.txt");
            Initilize_Colors();
            Populate_Authors_with_URLs_Country();
        }
        #endregion

        #region Populate Topics
        private String Populate_Topics()
        {
            ListViewItem L;
            int Cnt = 0;
            String Topic = String.Empty;
            String Line = String.Empty;
            Hashtable H = new Hashtable();
            String Pth = String.Empty;

            if (rad_coOccuredKeywords.Checked == true)
                Pth = "D:\\web knowledge\\Xperts\\coOccuredKeywords";
            else
                Pth = "D:\\web knowledge\\Xperts\\generalTerms";

            lvw_Keywords.Items.Clear();
            lvw_Authors.Items.Clear();
            lvw_Marginalized.Items.Clear();
            DirectoryInfo D = new DirectoryInfo(Pth);
            FileInfo[] fi = D.GetFiles();
            foreach (FileInfo f in fi)
            {
                Topic = f.Name.ToString();
                L = lvw_Keywords.Items.Add(Topic);
                Cnt = 0;
                H.Clear();
                StreamReader SR = File.OpenText(f.FullName);

                while (!SR.EndOfStream)
                {
                    Line = SR.ReadLine();
                    Cnt++;
                    if (H.Contains(Line) == false)
                        H.Add(Line, "");
                }
                SR.Close();
                SR.Dispose();
                L.SubItems.Add(Cnt.ToString());
                L.SubItems.Add(H.Count.ToString());
            }
            return fi.Length.ToString() + " Topics Loaded..";
        }
       
        #endregion

        #region Click any Item to Display All Experts
        private void lvw_Keywords_Click(object sender, EventArgs e)
        {
            String Topic = lvw_Keywords.SelectedItems[0].Text;
            tbx_Display.Text = lvw_Keywords.SelectedItems[0].Index.ToString() + ": " + lvw_Keywords.SelectedItems[0].Text;

            int Cnt = 0;
            String Line = String.Empty;
            Hashtable H = new Hashtable();
            String Pth = String.Empty;
            String Author = String.Empty;
            Double WebWt = 0, NonWebWt = 0, Score = 0;
            String WebWtDetail = String.Empty;
           // int Rank = 0;

            if (rad_coOccuredKeywords.Checked == true)
                Pth = "D:\\web knowledge\\Xperts\\coOccuredKeywords\\";
            else
                Pth = "D:\\web knowledge\\Xperts\\generalTerms\\";


            StreamReader SR = File.OpenText(Pth + Topic);

            while (!SR.EndOfStream)
            {
                Line = SR.ReadLine();
                if (H.Contains(Line) == false)
                    H.Add(Line, "1");
                else
                {
                    Cnt = int.Parse(H[Line].ToString());
                    Cnt++;
                    H[Line] = Cnt;
                }
            }
            SR.Close();
            SR.Dispose();
            lvw_Authors.Items.Clear();
            ListViewItem L;
            int i = 0, j = 1;

            IDictionaryEnumerator ID = H.GetEnumerator();
            while (ID.MoveNext())
            {
                String[] Arr = ID.Key.ToString().Split(Tab.ToCharArray());
                // Author Name 
                L = lvw_Authors.Items.Add(Arr[0].ToString());

                // Pub, Citation, coAuthNet, xYearPub
                for (i = 1; i < 5; i++)
                    L.SubItems.Add(Arr[i]);
                Double PubCount = Double.Parse(Arr[1]);
                Double Citation = Double.Parse(Arr[2]);
                Double coAuthNet = Double.Parse(Arr[3]);
                Double xYearPub = Double.Parse(Arr[4]);
                
                // Arr[5] is URL...
                String Identified_Counry = Identify_From_HomePage_URL(Arr[5]);
                String Identified_City = " ";
                

                // Pub History
                L.SubItems[4].Tag = Arr[6];

                // pub this Topic only                                        
                Double PubThisTopic = Double.Parse(H[ID.Key].ToString());
                L.SubItems.Add(PubThisTopic.ToString());

                // Non-Web-Wt...by Naeem                    
                NonWebWt = 0;
                NonWebWt += Citation / PubCount;
                NonWebWt += PubCount / coAuthNet;
                NonWebWt += PubCount / xYearPub;
                NonWebWt += PubThisTopic / PubCount;
                L.SubItems.Add(NonWebWt.ToString());

                // sum up web wt..
                WebWt = 0;
                for (i = 9; i < Arr.Length - 1; i++)
                {
                    WebWt += Double.Parse(Arr[i]);
                    WebWtDetail += Arr[i] + Tab;
                }
                L.SubItems.Add(WebWt.ToString());
                L.SubItems[7].Tag = WebWtDetail; // for graphical representation

                Score = NonWebWt + WebWt;
                L.SubItems.Add(Score.ToString());
                L.SubItems.Add(Identified_Counry);
                L.SubItems[9].Tag = Arr[5]; // URL Homepage if any... 
                L.SubItems.Add(Identified_City);


                // Final Weight by Bilal


                j++;
            }
            Marginalize_All();
            lvw_Authors.Refresh();

        }
        #endregion

        #region Marginalize All
        private void Marginalize_All() 
        {
            int i = 0, j = 0;
            Double MaxPub = Double.MinValue;
            Double MaxCitation = Double.MinValue;
            Double MaxXYearPub = Double.MinValue;
            Double MaxCoAuthNet = Double.MinValue;
            Double MaxThisTopic = Double.MinValue;

            ListViewItem L;
            for (i = 0; i < lvw_Authors.Items.Count; i++)
            {
                L = lvw_Authors.Items[i];
                MaxPub = Math.Max(MaxPub, Double.Parse(L.SubItems[1].Text));
                MaxCitation = Math.Max(MaxCitation, Double.Parse(L.SubItems[2].Text));
                MaxCoAuthNet = Math.Max(MaxCoAuthNet, Double.Parse(L.SubItems[3].Text));
                MaxXYearPub = Math.Max(MaxXYearPub, Double.Parse(L.SubItems[4].Text));
                MaxThisTopic = Math.Max(MaxThisTopic, Double.Parse(L.SubItems[5].Text));
            }

            lvw_Marginalized.Items.Clear();
            for (i = 0; i < lvw_Authors.Items.Count; i++)
            {
                L = lvw_Marginalized.Items.Add(lvw_Authors.Items[i].Text);
                L.SubItems.Add((Double.Parse(lvw_Authors.Items[i].SubItems[1].Text) / MaxPub).ToString());
                L.SubItems.Add((Double.Parse(lvw_Authors.Items[i].SubItems[2].Text) / MaxCitation).ToString());
                L.SubItems.Add((Double.Parse(lvw_Authors.Items[i].SubItems[3].Text) / MaxCoAuthNet).ToString());
                L.SubItems.Add((Double.Parse(lvw_Authors.Items[i].SubItems[4].Text) / MaxXYearPub).ToString());
                L.SubItems.Add((Double.Parse(lvw_Authors.Items[i].SubItems[5].Text) / MaxThisTopic).ToString());
            }
            for (i = 0; i < lvw_Marginalized.Items.Count; i++)
            {
                Double Sum = 0;
                for (j = 1; j < 6; j++)
                {
                    Sum += Double.Parse(lvw_Marginalized.Items[i].SubItems[j].Text);
                }
                Sum += Double.Parse(lvw_Marginalized.Items[i].SubItems[5].Text); // Double Time Sum Up MaxthisTopic
                lvw_Marginalized.Items[i].SubItems.Add(Sum.ToString());
                lvw_Marginalized.Items[i].SubItems.Add(lvw_Authors.Items[i].SubItems[9].Text); // Country
                lvw_Marginalized.Items[i].SubItems.Add(lvw_Authors.Items[i].SubItems[10].Text); // City
            }

            

        }

        #endregion

        #region btn_Start_Click
        private void btn_Start_Click(object sender, EventArgs e)
        {
            //String Lnk = "http://webstaff.itn.liu.se/~sarjo/"; 
            //String Lnk = "http://www.infsec.cs.uni-saarland.de/~duermuth/"; 
           // tbx_Display.Text = Fetch_WebPage_Data(Lnk);
            tbx_Display.Text = Populate_Topics();
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
                        
        #region Populate Hashtables (Countries, Cities)
        private void Generate_Hashtable()
        {
            OleDbDataReader R;
            // Hash Bucket of Country Names with their internet code (Pakistan, pk)
            CMD.CommandText = "Select * from Country";
            R = CMD.ExecuteReader();
            while (R.Read())
            {
                hCountry.Add(R[2].ToString().ToLower(), R[1]);
            }
            R.Close();  
        }
        #endregion
        
        #region Identify_From_HomePage_URL()

        private String Identify_From_HomePage_URL(String URL)
        {
            String[] Line = new String[4];
            String IdentifiedCountry = " "; 
                URL = URL.ToLower();
                Boolean ContiueRun = true;

                IDictionaryEnumerator ID = hCountry.GetEnumerator();
                while (ID.MoveNext() && (ContiueRun))
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
            return IdentifiedCountry; 
        }

        #endregion
        
        #region Fetch WebPage Data
        private String Fetch_WebPage_Data(String URL)
        {
            String Result = String.Empty;

            if (URL.Trim().Length < 2) return Result;

            if (Uri.IsWellFormedUriString(URL, UriKind.Absolute) == false) return Result;

            // cv found
            //if (URL.ToLower().Contains(".pdf") == true)
             //   return Read_PDF(URL);

            try
            {
                WebResponse objResponse;
                WebRequest objRequest = System.Net.HttpWebRequest.Create(URL);
                objResponse = objRequest.GetResponse();

                using (StreamReader sr = new StreamReader(objResponse.GetResponseStream()))
                {
                    Result = sr.ReadToEnd();
                    // Close and clean up the StreamReader
                    sr.Close();
                }

                // meta http-equiv=\"Refresh\" page is being refreshed. grab the new link from it..    
                Result = Result.ToLower();
                if ((Result.Contains("meta") == true) && (Result.Contains("http-equiv") == true) && (Result.Contains("refresh") == true))
                {
                    Result = Result.Substring(Result.LastIndexOf("url=") + 4);
                    Result = Result.Replace("\">", "");
                    Result += Fetch_WebPage_Data(Result.Trim());
                }

            }
            catch
            {
                return Result;
            }




            return Result;
        }
        #endregion

        #region Detect_City(WebPage, CountryName)

        private void btn_Detect_City_Click(object sender, EventArgs e)
        {
            int i = 0;
            String WebPage = String.Empty;
            String CountryName = String.Empty;
            String Lnk = String.Empty;
            for (i = 0; i < lvw_Authors.Items.Count; i++)
            {
                Lnk = lvw_Authors.Items[i].SubItems[9].Tag.ToString(); // URL from Tag if any...
                if (Lnk.Trim().Length > 2)
                {
                    WebPage = Fetch_WebPage_Data(Lnk);
                    CountryName = lvw_Authors.Items[i].SubItems[9].Text; // Country whose URL eXist...
                    /// Extract its city by matching from the hashtable of cities from mdb file...
                    lvw_Authors.Items[i].SubItems[10].Text = Detect_City(WebPage, CountryName );
                }
            }
        }

        
        private String Detect_City(String WebPage, String CountryName)
        {
             String Ret = "Not Found";
            // come to population of the city hash bucket...
             OleDbDataReader R;
             CMD.CommandText = "Select Ci.CityName from Country as Cn inner join City as Ci on Cn.ID = Ci.CountryID where Cn.CountryName='" + CountryName + "'";
              R = CMD.ExecuteReader();
              while (R.Read())
              {
                  String CityName = R[0].ToString();
                  CityName = CityName.ToLower();
                  if (WebPage.Contains(CityName.ToString()) == true)
                  {
                      Ret = R[0].ToString();
                      R.Close();
                      return Ret;
                  }
              }
              R.Close();  
            return Ret; 
        }
        #endregion
                
        ////////////////////////////////////////////////////////////////////

        #region Initilize_Colors
        private void Initilize_Colors()
        {
            Clrs[0] = "firebrick";
            Clrs[1] = "springgreen";
            Clrs[2] = "aqua";
            Clrs[3] = "greenyellow";
            Clrs[4] = "blue";
            Clrs[5] = "fuchsia";
            Clrs[6] = "gray";
            Clrs[7] = "green";
            Clrs[8] = "lime";
            Clrs[9] = "maroon";
            Clrs[10] = "navy";
            Clrs[11] = "olive";
            Clrs[12] = "darkmagenta";
            Clrs[13] = "darkgray";
            Clrs[14] = "coral";
            Clrs[15] = "burlywood";
            Clrs[16] = "darkred";
            Clrs[17] = "darkslategray";
            Clrs[18] = "deeppink";
            Clrs[19] = "dodgerblue";
            Clrs[20] = "fuchsia";
            Clrs[21] = "goldenrod";
            Clrs[22] = "indigo";
            Clrs[23] = "lightcoral";
            Clrs[24] = "lightgreen";
            Clrs[25] = "lightseagreen";
            Clrs[26] = "lightsteelblue";
            Clrs[27] = "mediumblue";
            Clrs[28] = "mediumslateblue";
            Clrs[29] = "olivedrab";
            Clrs[30] = "plum";
            Clrs[31] = "rosybrown";
            Clrs[32] = "sandybrown";
            Clrs[33] = "slategrey";
            Clrs[34] = "cornflowerblue";
            Clrs[35] = "cadetblue";
            Clrs[36] = "darksalmon";
            Clrs[37] = "deepskyblue";
            Clrs[38] = "lawngreen";
            Clrs[39] = "mediumspringgreen";
            Clrs[40] = "mediumorchid";
            Clrs[41] = "maroon";
            Clrs[42] = "lime";
            Clrs[43] = "salmon";
            Clrs[44] = "tomato";
            Clrs[45] = "limegreen";
            Clrs[46] = "orangered";
            Clrs[47] = "blueviolet";
            Clrs[48] = "chocolate";
            Clrs[49] = "crimson";
            Clrs[50] = "chartreuse";
            Clrs[52] = "hotpink";
            Clrs[53] = "violet";
            Clrs[54] = "slateblue";

        }
        #endregion

        #region Visualization
        private void btn_Visualization_Click(object sender, EventArgs e)
        {
            String Pth = Application.StartupPath + "\\Out.svg";

            tbx_Display.Text = Build_SVG(Pth);
        }

        #region Tranform from String to Hashtable for retrieiving font-size...
        private Hashtable Transform_2_Hashatable(String S)
        {
            Hashtable B = new Hashtable();
            String[] Ar = S.Split("\t".ToCharArray());
            int i = 0,j=0;
            for (i = 0; i < Ar.Length; i++)
            {
                if (B.Contains(Ar[i]) == false)
                {
                    B.Add(Ar[i], 0);
                }
                else
                {
                    j= int.Parse(B[Ar[i]].ToString());
                    j++;
                    B[Ar[i]] = j;
                }
            }
            return B;
        }
        #endregion

        private String Build_SVG(String Pth)
        {
            #region Local Variables            
            File.Delete(Pth); // first delete any existing....
            StreamWriter SW = File.AppendText(Pth);
            Double[] X = new Double[itemCapcity];
            Double[] Y = new Double[itemCapcity];
            Detail_out_Nodes(ref X, ref Y);
            int i = 1;
            Hashtable C = Random_Colors(lvw_Detail.Items.Count);
            String Clr = String.Empty;
            String Line = String.Empty;
            Double Stroke_Width = 0, R = 0;
            String S = String.Empty;
            String[] arrFont = new String[6];
            arrFont[0] = "116";
            arrFont[1] = "167";
            arrFont[2] = "200";
            arrFont[4] = "240";
            arrFont[5] = "270";
            int offsetY = 20;
            int pX = 20;
            int pY = 30;
            int j = 0;
            Hashtable B = new Hashtable();
            Hashtable D = new Hashtable();
            #endregion

            #region Header
            SW.WriteLine("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
            SW.WriteLine("<!DOCTYPE svg PUBLIC \"-//W3C//DTD SVG 1.1//EN\"");
            SW.WriteLine("\"http://www.w3.org/Graphics/SVG/1.1/DTD/svg11.dtd\" >");
            SW.WriteLine("<svg contentScriptType=\"text/ecmascript\" width=\"" + MaxWidth.ToString () + "px\"");
            SW.WriteLine("xmlns:xlink=\"http://www.w3.org/1999/xlink\" zoomAndPan=\"magnify\"");
            SW.WriteLine("contentStyleType=\"text/css\" viewBox=\"0 0 " + MaxWidth.ToString() + " " + MaxHeight.ToString() + "\" height=\"800px\"");
            SW.WriteLine(" preserveAspectRatio=\"xMidYMid meet\" xmlns=\"http://www.w3.org/2000/svg\"");
            SW.WriteLine(" version=\"1.1\">\""); // end of opening header..
            #endregion
            
            #region EmacScript
            SW.WriteLine (" <script type=\"text/ecmascript\">");
            SW.WriteLine("<![CDATA[");

            for (i = 0; i < lvw_Detail.Items.Count; i++)
            {
                B = Transform_2_Hashatable(A[lvw_Detail.Items[i].Text].ToString());
            
                SW.WriteLine("  function Show_on_MouseOver" + i.ToString() + "() { ");
                // wash out all previous links.              
                for (int k = 0; k < lvw_Detail.Items.Count; k++)
                {
                    D = Transform_2_Hashatable(A[lvw_Detail.Items[k].Text].ToString());
                    IDictionaryEnumerator ID_3 = D.GetEnumerator();
                    j = 0;
                    while (ID_3.MoveNext())
                    {
                        SW.WriteLine("    T = document.getElementById(\"T" + k.ToString() + j.ToString() + "\");");
                        SW.WriteLine(" T.firstChild.nodeValue = \"\";");
                        j++;
                    }
                } 
                // draw links of this object
                IDictionaryEnumerator ID_2 = B.GetEnumerator();
                j = 0;
                while (ID_2.MoveNext())                
                {
                    SW.WriteLine("    T = document.getElementById(\"T" + i.ToString() + j.ToString() + "\");");
                    SW.WriteLine("  T.firstChild.nodeValue = \"" + ID_2.Key.ToString() + "\";");
                    j++;                   
                }             
                
                // insert author url and country
                
                if (byAuthor_byTopic == "Topics")
                {
                    // Wash out all of the possible stamps of country with url etc..
                    for (int w = 0; w < lvw_Detail.Items.Count; w++)
                    {
                        SW.WriteLine("    T = document.getElementById(\"C" + w.ToString() + "\");");
                        SW.WriteLine(" T.firstChild.nodeValue = \"\";");
                    }

                    SW.WriteLine("    T = document.getElementById(\"C" + i.ToString() + "\");");
                    if (AC.Contains(lvw_Detail.Items[i].Text) == true)
                        SW.WriteLine(" T.firstChild.nodeValue = \"" + AC[lvw_Detail.Items[i].Text].ToString() + "\";");
                    else
                        SW.WriteLine(" T.firstChild.nodeValue = \"Not Found\";");
                    
                }
                
                ////////////////////////////////

                SW.WriteLine("  }");
            }                                           

            //////////////////////////////////////////////////////////////
            // Function for Center only...            
            if (byAuthor_byTopic == "Authors")
            {
                SW.WriteLine("");
                SW.WriteLine("  function Show_on_MouseOver_4_Center() { ");
                SW.WriteLine("    T = document.getElementById(\"T_C\");");
                SW.WriteLine(" T.firstChild.nodeValue = \"\";");

                SW.WriteLine("    T = document.getElementById(\"T_C\");");
                if (AC.Contains(cbo_Master.Text) == true)
                    SW.WriteLine(" T.firstChild.nodeValue = \"" + AC[cbo_Master.Text].ToString() + "\";");
                else
                    SW.WriteLine(" T.firstChild.nodeValue = \"Not Found\";");
                SW.WriteLine("  }");
            }
            /////////////////////////////////////////////////////////////



            SW.WriteLine("  ]]>");                                  
            SW.WriteLine(" </script>");

            #endregion
            
            #region Edges

            SW.WriteLine(" <g id=\"edges\">");
            for (i = 1; i <= lvw_Detail.Items.Count; i++)
            {
                Clr = Clrs[int.Parse(C[i].ToString())];
                Line = " <line x1=\"" + X[0].ToString() + "\" y1=\"" + Y[0].ToString() + "\"";
                Line += " x2=\"" + X[i].ToString() + "\" y2=\"" + Y[i].ToString() + "\"";
                SW.Write(Line);
                Stroke_Width = Double.Parse(lvw_Detail.Items[i - 1].SubItems[1].Text) * 2;
                SW.WriteLine(" style=\"stroke: " + Clr + "; stroke-width: " + Stroke_Width.ToString() + ";\"/>");
            }
            SW.WriteLine("</g>");
            #endregion

            #region Nodes... 
          
            SW.WriteLine(" <g id=\"nodes\"");
           
            SW.WriteLine(" > ");

            String Author = cbo_Master.Text; 
            Clr = Clrs[int.Parse(C[0].ToString())];
            SW.WriteLine(" <circle fill-opacity=\"1.0\" fill=\"" + Clr + "\" r=\"" + Radius.ToString() + "\" cx=\"" + X[0].ToString() + "\"");
            SW.WriteLine(" class=\"" + Author + "\" cy=\"" + Y[0].ToString() + "\" stroke=\"#000000\"");
            if (byAuthor_byTopic == "Authors")
                SW.WriteLine(" onmouseover=\"Show_on_MouseOver_4_Center()\" ");
            SW.WriteLine(" stroke-opacity=\"1.0\" stroke-width=\"1.0\"/>");

            for (i = 0; i < lvw_Detail.Items.Count; i++)
            {
                R = 12 * Double.Parse(lvw_Detail.Items[i].SubItems[1].Text);
                Clr = Clrs[int.Parse(C[i + 1].ToString())];
                SW.WriteLine(" <circle fill-opacity=\"1.0\" fill=\"" + Clr + "\" r=\"" + R.ToString() + "\" cx=\"" + X[i + 1].ToString() + "\"");
                SW.WriteLine(" class=\"" + lvw_Detail.Items[i].Text + "\" cy=\"" + Y[i + 1].ToString() + "\" stroke=\"#000000\"");
                SW.WriteLine(" onmouseover=\"Show_on_MouseOver" + i.ToString() + "()\" ");
                SW.WriteLine(" stroke-opacity=\"1.0\" stroke-width=\"1.0\"/>");
            }
            SW.WriteLine("</g>");
            #endregion

            #region Text

            SW.WriteLine(" <g id=\"node-labels\">");
            SW.WriteLine(" <text font-size=\"28\" x=\"" + X[0].ToString() + "\" y=\"" + Y[0].ToString() + "\" fill=\"#000000\"");
            SW.WriteLine(" style=\"text-anchor: middle; dominant-baseline: central;\"");
            SW.WriteLine(" font-family=\"Arial\" class=\"" + Author + "\">");
            SW.WriteLine(Author);
            SW.WriteLine("</text>");

            for (i = 0; i < lvw_Detail.Items.Count; i++)
            {
                SW.WriteLine(" <text font-size=\"18\" x=\"" + X[i + 1].ToString() + "\" y=\"" + Y[i + 1].ToString() + "\" fill=\"#000000\"");
                SW.WriteLine(" style=\"text-anchor: middle; dominant-baseline: central;\"");
                SW.WriteLine(" font-family=\"Arial\" class=\"Data-Mining\">");
                SW.WriteLine(lvw_Detail.Items[i].Text);
                SW.WriteLine("</text>");
            }
            SW.WriteLine("</g>");

            #endregion

            #region Text Obj to be Displayed           
            int fntSize = 0;
            for (i = 0; i < lvw_Detail.Items.Count; i++)
            {
                pY = 30;
                j = 0;
                B = Transform_2_Hashatable(A[lvw_Detail.Items[i].Text].ToString());
                IDictionaryEnumerator ID = B.GetEnumerator();                
                while (ID.MoveNext())                                
                {
                    fntSize = int.Parse(ID.Value.ToString());
                    SW.WriteLine("<a xlink:href=\"" + ID.Key.ToString() + ".svg\">");
                    SW.WriteLine(" <g style=\'font-size: " + arrFont[fntSize] + "%;  padding: 1px; margin: 1px;\'>");
                    pY += offsetY;
                    SW.WriteLine("   <text x=\"" + pX.ToString() + "\" y=\"" + pY.ToString() + "\" id=\"T" + i.ToString() + j.ToString() + "\" fill=\"" + Clrs[j % Clrs.Length] + "\" > </text> ");
                    SW.WriteLine(" </g> </a> ");
                    j++;
                }                
            }
 
            // Text Object to display Country and URL
            // position and fontsize of author url and country name..
            fntSize = 1; 
            pX = 600; pY = 710;
            if (byAuthor_byTopic == "Authors")
            {                
                if (AU.Contains(cbo_Master.Text) == true)
                    SW.WriteLine("<a xlink:href=\"" + AU[cbo_Master.Text].ToString() + "\">");
                else
                    SW.WriteLine("<a xlink:href=\"http://www.google.com\">");
                SW.WriteLine(" <g style=\'font-size: " + arrFont[fntSize] + "%;  padding: 1px; margin: 1px;\'>");                
                SW.WriteLine("   <text x=\"" + pX.ToString() + "\" y=\"" + pY.ToString() + "\" id=\"T_C" + "\" fill=\"" + Clrs[5] + "\" > </text> ");
                SW.WriteLine(" </g> </a> ");
            }

            else if (byAuthor_byTopic == "Topics")
            {
                for (i = 0; i < lvw_Detail.Items.Count; i++)
                {
                    if (AU.Contains(lvw_Detail.Items[i].Text) == true)
                        SW.WriteLine("<a xlink:href=\"" + AU[lvw_Detail.Items[i].Text].ToString() + "\">");
                    else
                        SW.WriteLine("<a xlink:href=\"http://www.google.com\">");
                    SW.WriteLine(" <g style=\'font-size: " + arrFont[fntSize] + "%;  padding: 1px; margin: 1px;\'>");
                    SW.WriteLine("   <text x=\"" + pX.ToString() + "\" y=\"" + pY.ToString() + "\" id=\"C" + i.ToString() + "\" fill=\"" + Clrs[4] + "\" > </text> ");
                    SW.WriteLine(" </g> </a> ");
                }
            }

            #endregion
                       
            #region Write Close SVG
            SW.WriteLine("</svg>"); // Close SVG
            SW.Close();
            SW.Dispose();
            #endregion

            return Pth + " created...";
        }
        
        #endregion

        #region Detail Out the Nodes
        private void Detail_out_Nodes(ref  Double[] X, ref Double[] Y)
        {
            Double cX = MaxWidth/2; // double.Parse(cbo_Width.Text) / 2;
            Double cY = MaxHeight/3; // double.Parse(cbo_Height.Text) / 3;

            X[0] = cX;
            Y[0] = cY;

            X[1] = cX - 300;
            Y[1] = cY;

            X[2] = cX + 300;
            Y[2] = cY;

            X[3] = cX;
            Y[3] = cY - 250;

            X[4] = cX;
            Y[4] = cY + 250;

            X[5] = cX - 300;
            Y[5] = cY - 250;

            X[6] = cX + 300;
            Y[6] = cY + 250;

            X[7] = cX - 300;
            Y[7] = cY + 100;

            X[8] = cX + 300;
            Y[8] = cY + 100;

            X[9] = cX - 200;
            Y[9] = cY - 150;

            X[10] = cX + 200;
            Y[10] = cY + 150;

            X[11] = cX - 200;
            Y[11] = cY + 150;

            X[12] = cX + 200;
            Y[12] = cY - 150;

            X[13] = cX - 150;
            Y[13] = cY - 100;

            X[14] = cX + 150;
            Y[14] = cY + 100;

            X[15] = cX - 150;
            Y[15] = cY + 100;

            X[16] = cX + 150;
            Y[16] = cY - 100;

            X[17] = cX - 100;
            Y[17] = cY - 50;

            X[18] = cX + 100;
            Y[18] = cY + 50;

            X[19] = cX - 100;
            Y[19] = cY + 50;

            X[20] = cX + 100;
            Y[20] = cY - 50;

            X[21] = cX - 50;
            Y[21] = cY - 100;

            X[22] = cX + 50;
            Y[22] = cY + 100;

            X[23] = cX - 50;
            Y[23] = cY + 100;

            X[24] = cX + 50;
            Y[24] = cY - 100;

            X[25] = cX - 310;
            Y[25] = cY - 70;

            X[26] = cX + 310;
            Y[26] = cY + 70;

            X[27] = cX + 310;
            Y[27] = cY - 70;

            X[28] = cX - 310;
            Y[28] = cY + 70;

            X[29] = cX + 130;
            Y[29] = cY + 120;

            X[30] = cX - 130;
            Y[30] = cY - 120;

            X[31] = cX + 130;
            Y[31] = cY - 120;

            X[32] = cX - 130;
            Y[32] = cY + 120;

            X[33] = cX + 430;
            Y[33] = cY - 30;

            X[34] = cX + 450;
            Y[34] = cY - 65;

            X[35] = cX + 410;
            Y[35] = cY - 95;

            X[36] = cX + 500;
            Y[36] = cY + 35;

            X[37] = cX + 520;
            Y[37] = cY + 65;

            X[38] = cX + 490;
            Y[38] = cY + 30;


            X[39] = cX + 520;
            Y[39] = cY + 95;

            X[40] = cX + 470;
            Y[40] = cY + 150;
        }

        #endregion
        
        #region Random_Colors
        private Hashtable Random_Colors(int Max_No)
        {
            int U = Clrs.Length;
            int i = 0, randomNumber = 0;
            Hashtable H = new Hashtable();
            Random random = new Random();
            while (H.Count <= Max_No)
            {
                randomNumber = random.Next(0, Clrs.Length - 1);
                if (H.Contains(randomNumber) == false)
                    H.Add(i++, randomNumber);
            }
            return H;

        }
        #endregion

        #region Populate with Authors & Topics
        private void Populate_Authors_Topics(String Pth)
        {
            String Line = String.Empty;            
            String topicS = String.Empty;
            String authorS = String.Empty;
            String Author = String.Empty;
            String Topic = String.Empty;
            String[] Arr = new String[2];
            byAuthor_byTopic = Pth.Replace(".txt", "");

            Pth = Application.StartupPath + "\\" + Pth;
            StreamReader SR = File.OpenText(Pth);
            while (!SR.EndOfStream)
            {
                Line = SR.ReadLine();
                Arr = Line.Split("\t".ToCharArray());
                Author = Arr[0].Trim();
                Topic = Arr[1].Trim();
                // authors
                if (Author_Topics.Contains(Author) == false)
                {
                   Author_Topics.Add(Author, Topic);
                }
                else
                {
                    topicS = Author_Topics[Author].ToString();
                    topicS += "\t" + Topic;
                    Author_Topics[Author] = topicS;
                }
                // topics..
                if (A.Contains(Topic) == false)
                {
                    A.Add(Topic, Author);
                }
                else
                {
                    authorS = A[Topic].ToString();
                    authorS += "\t" + Author;                    
                    A[Topic] = authorS;
                }

            }
            SR.Close();
            SR.Dispose();

            lvw_Detail.Items.Clear();
            cbo_Master.Items.Clear();            
            IDictionaryEnumerator ID = Author_Topics.GetEnumerator();
            while (ID.MoveNext())
            {   
                cbo_Master.Items.Add(ID.Key.ToString());
            }

            tbx_Display.Text = cbo_Master.Items.Count.ToString() + " Authors Populated..";
        }
        

       private void btn_Display_Item_Click(object sender, EventArgs e)
        {
            if (cbo_Master.SelectedIndex < 0)
            {
                lvw_Detail.Items.Clear();
                tbx_Display.Text = cbo_Master.Text + " is Invalid entry";
                return; // no valid item selected..
            }

            String strTopic = Author_Topics[cbo_Master.Text].ToString();  
            tbx_Display.Text = cbo_Master.SelectedIndex.ToString() + ": " + cbo_Master.Text;
            String[] Arr = strTopic.Split("\t".ToCharArray());
            int i = 0, Cnt = 0;
            Hashtable H = new Hashtable();
            for (i = 0; i < Arr.Length; i++)
            {
                if (H.Contains(Arr[i]) == false)
                {
                    H.Add(Arr[i], 1);
                }
                else
                {
                    Cnt = int.Parse(H[Arr[i]].ToString());
                    Cnt++;
                    H[Arr[i]] = Cnt.ToString();
                }
            }

            ListViewItem L;
            lvw_Detail.Items.Clear();
            Radius = 0;
            IDictionaryEnumerator ID = H.GetEnumerator();
            while (ID.MoveNext())
            {
                L = lvw_Detail.Items.Add(ID.Key.ToString());
                L.SubItems.Add(ID.Value.ToString());
                Radius += int.Parse(ID.Value.ToString());
            }
            Radius *= 3;
        }
        #endregion

        #region all svg
        private void btn_Gen_All_SVG_Click(object sender, EventArgs e)
        {
            int i = 0;
            String Pth = String.Empty; 
            for (i = 0; i < cbo_Master.Items.Count; i++)
            {
                cbo_Master.SelectedIndex = i; 
                Pth = Application.StartupPath + "\\Results\\" + cbo_Master.Text + ".svg";
                // change it to new...one...
                btn_Display_Item_Click(null, null);
               
                // refresh list controls
                cbo_Master.Refresh();                 
                lvw_Detail.Refresh();

                if (lvw_Detail.Items.Count <= itemCapcity )
                {
                    try
                    {
                        Build_SVG(Pth);
                    }
                    catch
                    { }
                }

               // if (i > 278) return;
            }
            tbx_Display.Text = cbo_Master.Items.Count.ToString() + " svg generated";
        }
        #endregion


        #region Populate_Authors_with_URLs_Country()
        private void Populate_Authors_with_URLs_Country()
        {            
            StreamReader SR = File.OpenText(Application.StartupPath + "\\HomePages_with_Country.txt");
            
            while (!SR.EndOfStream)
            {
                String[] Arr = SR.ReadLine().Split(Tab.ToCharArray());
                if (Arr.Length > 2)
                {
                    if (AC.Contains(Arr[0]) == false)
                        AC.Add(Arr[0], Arr[1]);
                    if (AU.Contains(Arr[0]) == false)                    
                        AU.Add(Arr[0], Arr[2]);
                }
            }
            SR.Close();
            SR.Dispose();
        }
        #endregion


    }
}