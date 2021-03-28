using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HomeWork2
{
    public partial class Form1 : Form
    {                   
        public Form1()
        {
            InitializeComponent();

            menuSwitchIcon.Height = addPersonelMenuBtn.Height;
            menuSwitchIcon.Top = addPersonelMenuBtn.Top;

            addPersonelPagePnl.Visible = true;
            listPersonelPagePnl.Visible = false;
            removePersonelPagePnl.Visible = false;
        }
        private void removePersonelMenuBtn_Click(object sender, EventArgs e)
        {
            menuSwitchIcon.Height = removePersonelMenuBtn.Height;
            menuSwitchIcon.Top = removePersonelMenuBtn.Top;

            addPersonelPagePnl.Visible = false;
            listPersonelPagePnl.Visible = false;
            removePersonelPagePnl.Visible = true;
        }

        private void listPersonelMenuBtn_Click(object sender, EventArgs e)
        {
            menuSwitchIcon.Height = listPersonelMenuBtn.Height;
            menuSwitchIcon.Top = listPersonelMenuBtn.Top;

            addPersonelPagePnl.Visible = false;
            listPersonelPagePnl.Visible = true;
            removePersonelPagePnl.Visible = false;
        }

        private void addPersonelMenuBtn_Click(object sender, EventArgs e)
        {
            menuSwitchIcon.Height = addPersonelMenuBtn.Height;
            menuSwitchIcon.Top = addPersonelMenuBtn.Top;

            addPersonelPagePnl.Visible = true;
            listPersonelPagePnl.Visible = false;
            removePersonelPagePnl.Visible = false;
        }

        private void closeBx_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        int Move;
        int Mouse_X;
        int Mouse_Y;

        private void topPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (Move == 1)
            {
                this.SetDesktopLocation(MousePosition.X - Mouse_X, MousePosition.Y - Mouse_Y);
            }
        }

        private void topPanel_MouseDown(object sender, MouseEventArgs e)
        {
            Move = 1;
            Mouse_X = e.X;
            Mouse_Y = e.Y;
        }

        private void topPanel_MouseUp(object sender, MouseEventArgs e)
        {
            Move = 0;
        }

        private void TrIDNoTxtBx_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void personelNoTxtBx_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void webPage_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://bakircay.edu.tr");
        }

        private void universityIntagram_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.instagram.com/bakircayedu/?hl=tr");
        }

        private void universityTwitter_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://twitter.com/bakircayedu");
        }

        private void addPersonelPageSetScreen()
        {
            departmentTxtBx.Text = personelNoTxtBx.Text = NameTxtBx.Text = 
            lastNameLblTxtBx.Text = PlaceofBirthLblTxtBx.Text = 
            sexTxtBx.Text = TrIDNoTxtBx.Text = mailTxtBx.Text = "";

            NameTxtBx.Focus();
        }
        private void removePersonelPageSetScreen()
        {
            removePersonelTxtBx.Text = "";
            removePersonelTxtBx.Focus();
        }

        Factory serdarSoftware = new Factory();

        private void Form1_Load(object sender, EventArgs e)
        {
            serdarSoftware.Staff = new List<Personel>();
        }

        private void addPersonelPageBtn_Click(object sender, EventArgs e)
        {           
            try
            {
                serdarSoftware.Name = "Bakırçay University";
                serdarSoftware.Adress = "Menemen, Izmir, Turkey";

                Personel newPerson = new Personel();
                

                newPerson.Department = departmentTxtBx.Text;
                newPerson.PersonelNo = Convert.ToUInt64(personelNoTxtBx.Text);

                newPerson.IDInformation.Name = NameTxtBx.Text;
                newPerson.IDInformation.LastName = lastNameLblTxtBx.Text;
                newPerson.IDInformation.PlaceofBirth = PlaceofBirthLblTxtBx.Text;          
                newPerson.IDInformation.Sex = sexTxtBx.Text;
                newPerson.IDInformation.TrIDNo = Convert.ToUInt64(TrIDNoTxtBx.Text);
                newPerson.IDInformation.Mail = mailTxtBx.Text;

                serdarSoftware.AddStaff(newPerson);
                MessageBox.Show("The staff has been successfully created.");
                addPersonelPageSetScreen();
            }
            catch (Exception)
            {
                MessageBox.Show("Please Fill in All Information");             
            } 
        }

        private void listPersonelPageBtn_Click(object sender, EventArgs e)
        {
            listPersonelLst.Clear();
            for (int i = 0; i < serdarSoftware.Staff.Count; i++)
            {
                listPersonelLst.Items.Add(serdarSoftware.ListStaff(i));
            }                     
        }

        private void removePersonelBtn_Click(object sender, EventArgs e)
        {
            try
            {
                ulong removePersonelNo = Convert.ToUInt64(removePersonelTxtBx.Text);
                serdarSoftware.RemoveStaff(removePersonelNo);            
                removePersonelPageSetScreen();
            }
            catch (Exception)
            {
                removePersonelPageSetScreen();
            }
        }


    }
}
