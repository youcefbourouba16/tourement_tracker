using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tourament_library.Models;

namespace TrackerUi
{
    public partial class tourament_Bracket : Form
    {

        public void Bracket_Round1(int FirstRoundMatchupNumber)
        {
            int x_axe = 250;
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
                    lb.Font = new Font("Arial", 9, FontStyle.Bold);
                    lb.ForeColor = Color.Blue;
                    lb.Name = entriy1.ToString();
                    lb.Location = new Point(x_axe, y_axe);


                    lb1 = new Label();
                    lb1.Font = new Font("Arial", 12, FontStyle.Bold);
                    lb1.Text = "lb2_" + j.ToString();
                    lb1.Name = entriy1.ToString();
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
                            output += $"{entry.teamCompreting.teamName} :({entry.score}) ";
                        }
                        else output += "<Bye>";
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

            label1.Text = tour.TouramentName;
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
                this.Size = new Size(1280, 800);
            }


            Bracket_Round1(FirstRoundMatchupNumber);
            addEntriesNames(panel1, tour);
        }
    }
}
