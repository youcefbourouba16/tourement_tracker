using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tourament_library;
using Tourament_library.Models;
using Tourament_library.TouramentLogic;

namespace TrackerUi
{
    public partial class mainApp : Form
    {
        tourement_Model tour = new tourement_Model();
        List<int> roundNum = new List<int>();
        List<MatchupModel> matchupsListByRound = new List<MatchupModel>();


        public mainApp(tourement_Model tr)
        {

            InitializeComponent();
            tour = setWinnerFirstRounnd(tr);
            
            roundGetList();
            foreach (int  item in roundNum)
            {
                tour = tourLogic.winnerToNextMatcup(tr, item);
            }
            tour.Active = 1;
            //tour = tourLogic.winnerToNextMatcup(tr, 1); /// set next round eleminate byes if there's any 1 ===> round 1 (byes exist only round 1)

            loadTour();
            wireUpRoundList();
            round_list.SelectedIndex = 0;
            wireUpMatchupListBox(0);
            
            globalConfig.Connections.UpdateTourament(tour);


        }

        private void score_teamTWO_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }

        private void round_list_SelectedIndexChanged(object sender, EventArgs e)
        {

            wireUpMatchupListBox(round_list.SelectedIndex);
        }
        private void matchupListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            removeTextboxAndButtonInNullMatchups();
            MatchupModel m = (MatchupModel)matchupListBox.SelectedItem;
            if (m != null)
            {
                
                if (m.Entries.Count!=2)
                {
                    label4.Text = "Not Yet Set";
                    label2.Text = "Not Yet Set";
                    score_teamTWO.Text = "";
                    score_teamONE.Text = "";
                }
                else
                {
                    score_teamTWO.Text = m.Entries[1].score.ToString();
                    score_teamONE.Text = m.Entries[0].score.ToString();
                }
                

            }
            uploadCometingTeamName();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void playedOnly_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            wireUpMatchupListBox(round_list.SelectedIndex);
        }



        private void button1_Click(object sender, EventArgs e)
        {
            
            AddscoreUpdate();
            setUpnextround();
            wireUpMatchupListBox(round_list.SelectedIndex);
        }

        public void AddscoreUpdate()
        {
            MatchupModel m = (MatchupModel)matchupListBox.SelectedItem;

            if (double.TryParse(score_teamONE.Text, out double score))
            {
                m.Entries[0].score = score;
            }
            else MessageBox.Show("Team one score must be non null. !!!", "INVALID team One score.",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            if (double.TryParse(score_teamTWO.Text, out double score1))
            {
                m.Entries[1].score = score1;
            }
            else MessageBox.Show("Team two score must be non null. !!!", "INVALID team Two score.",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            if (score > score1)
            {
                m.Winner = m.Entries[0].teamCompreting;
                m.winnerID = m.Entries[0].teamCompreting.id;
            }
            else if (score < score1)
            {
                m.Winner = m.Entries[1].teamCompreting;
                m.winnerID = m.Entries[1].teamCompreting.id;
            }
            int idexMatchup = -1;
            
                foreach (MatchupModel matchup in tour.round[m.MatchupRound-1])
                {
                    if (matchup.id == m.id)
                    {

                        idexMatchup = tour.round[m.MatchupRound-1].IndexOf(matchup);
                        
                        break;
                    }

                }
                
            
            tour.round[m.MatchupRound-1][idexMatchup] = m;
            
            
            


        }
        public tourement_Model setWinnerFirstRounnd(tourement_Model tr)
        {
            foreach (MatchupModel item in tr.round[0])
            {
                if (item.Entries[1].teamCompreting==null)
                {
                    item.Winner = item.Entries[0].teamCompreting;
                }
            }
            return tr;
        }
       
        public void setUpnextround()
        {
            MatchupModel m = (MatchupModel)matchupListBox.SelectedItem;
            tour = tourLogic.winnerToNextMatcup(tour, m.MatchupRound);

            if (tour.Active == 2)
            {
                mainApp frm1 = new mainApp(tour); /// this means this exactly form that  we're in
                frm1.Close();
                tourament_Bracket frm = new tourament_Bracket(tour); /// this means this exactly form that  we're in
                frm.Show();
                
                globalConfig.Connections.touramentComplete(tour,2);
            }
            globalConfig.Connections.UpdateTourament(tour);
            if (tour.Active == 0)
            {
                globalConfig.Connections.touramentComplete(tour,0);
            }
        }
        
        public void uploadCometingTeamName()
        {
            MatchupModel m = (MatchupModel)matchupListBox.SelectedItem;
            if (m != null)
            {
                for (int i = 0; i < m.Entries.Count; i++)
                {
                    if (i == 0)
                    {
                        if (m.Entries[0].teamCompreting != null)
                        {
                            label2.Text = m.Entries[0].teamCompreting.teamName;
                            score_teamONE.Text = m.Entries[0].score.ToString();
                            
                            
                        }
                    }

                    if (i == 1)
                    {
                        if (m.Entries[1].teamCompreting != null)
                        {
                            label4.Text = m.Entries[1].teamCompreting.teamName;
                            score_teamTWO.Text = m.Entries[1].score.ToString();
                        }
                        else if (m.Entries.Count==1)
                        {
                            label4.Text = "Not Yet Set";
                            score_teamTWO.Text = "";
                        }
                        else 
                        {
                            label4.Text = "<Bye>";
                            score_teamTWO.Text = "";
                        }
                    }
                }
            }
        }
        public void removeTextboxAndButtonInNullMatchups()
        {
            MatchupModel m = (MatchupModel)matchupListBox.SelectedItem;
            if (m != null && (m.Entries.Count <2 || m.Entries[1].teamCompreting==null))
            {

                score_teamTWO.Enabled = false;
                score_teamONE.Enabled = false;
                button1.Enabled = false;
            }
            else
            {
                score_teamTWO.Enabled = true;
                score_teamONE.Enabled = true;
                button1.Enabled = true;
            }
        }
        public List<MatchupModel> extractAllMatchup(List<List<MatchupModel>> Round)
        {
            List<MatchupModel> matchupsList = new List<MatchupModel>();
            foreach (List<MatchupModel> item in Round)
            {
                foreach (MatchupModel mat in item)
                {
                    matchupsList.Add(mat);
                }
            }
            return matchupsList;
        }
        public void wireUpMatchupListBox(int round)
        {
            List<MatchupModel> matchupsListByRound = new List<MatchupModel>();
            List<MatchupModel> PlayedOnlylist = new List<MatchupModel>();

            List<MatchupModel> matchupsList = extractAllMatchup(tour.round);


            foreach (MatchupModel item in matchupsList)
            {
                if (playedOnly_checkBox.Checked && item.Winner == null)
                {
                    if (item.MatchupRound == round + 1)
                    {
                        PlayedOnlylist.Add(item);
                    }
                }
                else
                {
                    if (item.MatchupRound == round + 1)
                    {
                        matchupsListByRound.Add(item);
                    }
                }

            }
            matchupListBox.DataSource = null;
            if (playedOnly_checkBox.Checked)
            {
                matchupListBox.DataSource = PlayedOnlylist;
            }
            else
                matchupListBox.DataSource = matchupsListByRound;
            matchupListBox.DisplayMember = "fullNamesEntries";


        }

        public void wireUpRoundList()
        {
            round_list.DataSource = null;
            round_list.DataSource = roundNum;


        }

        public void loadTour()
        {
            TourName.Text = tour.TouramentName;

        }
        public void roundGetList()
        {
            roundNum.Add(1);
            int currRound = 1;
            foreach (List<MatchupModel> list in tour.round)
            {
                foreach (MatchupModel matchp in list)
                {
                    if (matchp.MatchupRound > currRound)
                    {
                        currRound++;
                        roundNum.Add(currRound);
                    }
                }
            }
        }
    }
}
