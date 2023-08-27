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

namespace TrackerUi
{
    public partial class creatTeam : Form
    {
        IteamRequester callingForm;
        List<person> availableTeamMember = globalConfig.Connections.getPersonAll();
        List<person> selectedTeamMember = new List<person>();

        public creatTeam(IteamRequester caller)
        {
            InitializeComponent();
            wireUpList();
            callingForm = caller;
        }

        private void wireUpList()
        {
            selectTeamMemberDropdown.DataSource = null;
            selectTeamMemberDropdown.DataSource = availableTeamMember;
            selectTeamMemberDropdown.DisplayMember = "fullname";

            teamMemberListBox.DataSource = null;
            teamMemberListBox.DataSource = selectedTeamMember;
            teamMemberListBox.DisplayMember = "fullname";
        }

        private void CreatNumber_Click(object sender, EventArgs e)
        {


            if (nullVerifecation())
            {

                person person1 = new person(
                    firstNameValue.Text,
                    lastNameValue.Text,
                    emailValue.Text,
                    phoneNumValue.Text);
                globalConfig.Connections.ceatePeson(person1);
                selectedTeamMember.Add(person1);
                wireUpList();


                firstNameValue.Text = "";
                lastNameValue.Text = "";
                emailValue.Text = "";
                phoneNumValue.Text = "";

            }
            else MessageBox.Show("insert information plaise !");
        }
        private bool nullVerifecation()
        {
            if (firstNameValue.Text == "" || lastNameValue.Text == "" ||
                emailValue.Text == "" || phoneNumValue.Text == "")
            {
                return false;
            }
            else return true;
        }


        private void firstNameValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            else e.Handled = false;
        }

        private void emailValue_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void phoneNumValue_KeyPress(object sender, KeyPressEventArgs e)
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

        private void addMember_Click(object sender, EventArgs e)
        {
            /// to remove selected items from the available Member list
            person p = (person)selectTeamMemberDropdown.SelectedItem;
            if (p != null)
            {
                availableTeamMember.Remove(p);
                selectedTeamMember.Add(p);
                wireUpList();
            }


        }

        private void deleteSelectedPlayer_Click(object sender, EventArgs e)
        {
            person p = (person)teamMemberListBox.SelectedItem;
            if (p != null)
            {
                selectedTeamMember.Remove(p);
                availableTeamMember.Add(p);
                wireUpList();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (tb_teamName.Text != "" && availableTeamMember != null)
            {
                teamModel team = new teamModel();
                team.teamName = tb_teamName.Text;
                team.team_member = selectedTeamMember;
                team = globalConfig.Connections.createTeam(team);
                callingForm.teamComplete(team);
                this.Close();
                //selectedTeamMember = new List<person>();
                //teamMemberListBox.DataSource = null;
                //tb_teamName.Text = "";
                //wireUpList();


            }
            else MessageBox.Show("please verfie your information !!.");


        }


    }
}
