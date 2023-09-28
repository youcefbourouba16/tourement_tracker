using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tourament_library;
using Tourament_library.Models;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TrackerUi
{
    public partial class tourament_Bracket : Form
    {
        tourement_Model tour = new();
        public void Bracket_Round1(int FirstRoundMatchupNumber)
        {
            int x_axe = 50;
            int y_axe = 50;

            string entriy1 = "lb1_";
            string entriy2 = "lb2_";
            Label lb;
            Label lb1;
            int j = 0;
            do
            {

                for (int i = 0; i < FirstRoundMatchupNumber / 2; i++)
                {
                    lb = new Label();
                    lb.Text = "lb1_" + j.ToString();
                    lb.Font = new Font("Arial", 12, FontStyle.Bold);
                    lb.ForeColor = Color.GreenYellow;
                    lb.Name = entriy1.ToString();
                    lb.Location = new Point(x_axe, y_axe);


                    lb1 = new Label();
                    lb1.Font = new Font("Arial", 12, FontStyle.Bold);
                    lb1.Text = "lb2_" + j.ToString();
                    lb1.Name = entriy2.ToString();
                    lb1.Location = new Point(x_axe, y_axe + 30);
                    y_axe += 100;
                    entriy1 += 1;
                    entriy2 += 1;
                    panel1.Controls.Add(lb);
                    panel1.Controls.Add(lb1);

                    j++;

                }
                FirstRoundMatchupNumber /= 2;
                x_axe += 150;
                y_axe = 50;
                if (FirstRoundMatchupNumber == 2)
                {
                    y_axe *= 2;
                }
                if (FirstRoundMatchupNumber == 1)
                {
                    y_axe *= 2;
                    y_axe += 15;
                    lb = new Label();
                    lb.Text = "lb1_" + j.ToString();
                    lb.Font = new Font("Arial", 12, FontStyle.Bold);
                    lb.ForeColor = Color.Blue;
                    lb.Name = entriy1.ToString();
                    lb.Location = new Point(x_axe, y_axe);
                    panel1.Controls.Add(lb);
                }
            } while (FirstRoundMatchupNumber > 0);
        }

        public void addEntriesNames(Panel p, tourement_Model tr)
        {

            List<string> listEntries = new List<string>();
            string output = "";/// 1 for id,1(0 for loser) for winner,EntryName
            int j = 0;
            foreach (List<MatchupModel> item in tr.round)
            {
                foreach (MatchupModel matchup in item)
                {
                    foreach (MatchupEntrieModel entry in matchup.Entries)
                    {
                        output += $"{j},";
                        if (entry.teamCompreting == matchup.Winner)
                        {
                            output += "1,";
                        }
                        else output += "0,";
                        if (entry.teamCompreting != null)
                        {
                            output += $"{entry.teamCompreting.teamName}:({entry.score})";
                        }
                        else output += "<Bye>";
                        if (entry.matchupParent != null)
                        {
                            output += $",{entry.matchupParent.fullNamesEntries}";
                        }
                        else output += $",Matchup Parent null";
                        listEntries.Add(output);
                        output = "";
                    }
                }
            }
            j = 0;

            foreach (Label lb in panel1.Controls)
            {
                string s = listEntries[j];

                string[] parts = s.Split(',');
                if (parts[1] == "1")
                {
                    lb.ForeColor = Color.Green;
                }
                else lb.ForeColor = Color.Red;
                lb.Text = parts[2];
                System.Windows.Forms.ToolTip toolTip1 = new System.Windows.Forms.ToolTip();
                toolTip1.SetToolTip(lb, parts[3]);
                //lb.SetToll = parts[3];
                j++;

                if (j == listEntries.Count)
                {
                    break;
                }

            }

        }
        public tourament_Bracket(tourement_Model tour)
        {
            InitializeComponent();
            System.Windows.Forms.ToolTip toolTip1 = new System.Windows.Forms.ToolTip();
            toolTip1.SetToolTip(EditTour, "Edit the tourament Matchup,NOTE:in some cases it will not work.");
            this.tour = tour;
            tourName.Text = tour.TouramentName;
            int FirstRoundMatchupNumber = 0;
            foreach (MatchupModel matchup in tour.round[0])
            {
                foreach (MatchupEntrieModel item in matchup.Entries)
                {
                    FirstRoundMatchupNumber++;
                }

            }
            if (FirstRoundMatchupNumber >= 8)
            {
                this.Size = new Size(950, 600);
                EditTour.Location = new Point(240, 400);
                DeleteTour.Location = new Point(550, 400);
                panel1.Size = new Size(1200, 700);
            }


            Bracket_Round1(FirstRoundMatchupNumber);
            addEntriesNames(panel1, tour);
            int count;
            count = panel1.Controls.Count;
            panel1.Controls[count - 1].Text = "Winner :" + tour.round[tour.round.Count - 1][0].Winner.teamName;
            panel1.Controls[count - 1].ForeColor = Color.Goldenrod;
            panel1.Controls[count - 1].Size = new Size(300, 18);
            foreach (MatchupEntrieModel item in tour.round[tour.round.Count - 1][0].Entries)
            {
                if (item.id != tour.round[tour.round.Count - 1][0].winnerID)
                {
                    secondPName.Text = item.teamCompreting.teamName;

                }
                if (item.id != tour.round[tour.round.Count - 1][0].winnerID)
                {
                    firstPName.Text = item.teamCompreting.teamName;
                }
            }




        }

        private void EditTour_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void tourament_Bracket_Load(object sender, EventArgs e)
        {
        }

        private void label3_Click(object sender, EventArgs e)
        {
        }

        private void EditTour_Click_1(object sender, EventArgs e)
        {
            mainApp frm1 = new mainApp(tour); /// this means this exactly form that  we're in

            //this.Close();
            frm1.Show();
        }

        private void DeleteTour_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Are you sure to delete this Tourament ??",
                                     "Confirm Delete!!",
                                     MessageBoxButtons.YesNo,
                                     MessageBoxIcon.Warning);
            if (confirmResult == DialogResult.Yes)
            {
                
                globalConfig.Connections.touramentComplete(tour,0);

                dashBoard frm1 = new dashBoard(); /// this means this exactly form that  we're in

                this.Close();
                frm1.Show();
            }
            else
            {
                return;
            }
        }
    }
}
