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
using Tourament_library.Models;

namespace TrackerUi
{
    public partial class mainApp : Form
    {
        ITourRequester callingForm;
        tourement_Model tour = new tourement_Model();
        List<int> roundNum = new List<int>();
        

        public mainApp(ITourRequester caller, tourement_Model tr)
        {

            InitializeComponent();
            callingForm = caller;
            tour = tr;
            loadTour();
            roundGetList();
            wireUpRoundList();
            round_list.SelectedIndex = 0;
            wireUpMatchupListBox(0);


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
            List<MatchupModel> matchupsList = extractAllMatchup(tour.round);
            
            foreach (MatchupModel item in matchupsList)
            {
                if (item.MatchupRound==round+1)
                {
                    matchupsListByRound.Add(item);
                }
            }

            List<string> listByround = getMatchuntriesName(matchupsListByRound);
            matchupListBox.DataSource = null;
            matchupListBox.DataSource = listByround;
        }
        private void round_list_SelectedIndexChanged(object sender, EventArgs e)
        {
            wireUpMatchupListBox(round_list.SelectedIndex);
        }
        public List<string> getMatchuntriesName(List<MatchupModel> matchupsListByRound)
        {
            List<string> list=new List<string>();
            string s = "";
            foreach (MatchupModel item in matchupsListByRound)
            {
                int count = 0;
                foreach (MatchupEntrieModel entry in item.Entries)
                {
                    count++;
                    if (item.MatchupRound == 1 && entry.teamCompreting == null)
                    {
                        s += " bye(neutral)";
                        break;
                    }
                    else if (item.MatchupRound > 1 && entry.teamCompreting == null)
                    {
                        s += " not yet define ";
                        break;
                    }
                    if (count == 1)
                    {
                        s += $"{entry.teamCompreting.teamName} Vs ";
                    }
                    else s += $"{entry.teamCompreting.teamName}";
                }
                list.Add(s);
                s = "";
            }
            return list;
            
        }
    }
}
