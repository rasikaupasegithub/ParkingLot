using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParkingLot
{
    public partial class Cars : Form
    {
        Functions Con;
        public Cars()
        {
            InitializeComponent();
            Con = new Functions();
            ShowCars();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void ShowCars()
        {
            string Query = "select * from CarsTbl";
            CarsDGV.DataSource = Con.GetData(Query);
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            if (PNumberTb.Text == "" || DriverTb.Text == "" || CarTypeTb.Text == "" || ColourTb.Text == "")
            {
                MessageBox.Show("Missing Data!!!");

            }
            else
            {

                try
                {
                    string PNumber = PNumberTb.Text;
                    string Driver = DriverTb.Text;
                    string Gen = GenCb.SelectedItem.ToString();
                    string CType = CarTypeTb.Text;
                    string Colour = ColourTb.Text;
                    string Query = "Insert into CarsTbl values('{0}','{1}','{2}','{3}','{4}')";
                    Query = String.Format(Query, PNumber, Driver, Gen, CType, Colour);
                    Con.SetData(Query);
                    MessageBox.Show("Car Added!!!!");
                    ShowCars();

                }
                catch (Exception Ex)
                {

                    MessageBox.Show(Ex.Message);
                }
            }


        




    }
        int Key = 0;

        private void CarsDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            PNumberTb.Text = CarsDGV.SelectedRows[0].Cells[1].Value.ToString();

            DriverTb.Text = CarsDGV.SelectedRows[0].Cells[2].Value.ToString();

            GenCb.SelectedItem = CarsDGV.SelectedRows[0].Cells[3].Value.ToString();

            CarTypeTb.Text = CarsDGV.SelectedRows[0].Cells[4].Value.ToString();
            ColourTb.Text = CarsDGV.SelectedRows[0].Cells[5].Value.ToString();
            if(PNumberTb.Text == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(CarsDGV.SelectedRows[0].Cells[0].Value.ToString());
            }

        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            if (PNumberTb.Text == "" || DriverTb.Text == "" || CarTypeTb.Text == "" || ColourTb.Text == "")
            {
                MessageBox.Show("Missing Data!!!");

            }
            else
            {
                try
                {
                    string PNumber = PNumberTb.Text;
                    string Driver = DriverTb.Text;
                    string Gen = GenCb.SelectedItem.ToString();
                    string CType = CarTypeTb.Text;
                    string Colour = ColourTb.Text;
                    string Query = "Update CarsTbl set PNumber = '{0}', Driver ='{1}', Gender = '{2}', CarType='{3}', CarColour = '{4}' where CNum = {5}";
                    Query = String.Format(Query, PNumber, Driver, Gen, CType, Colour, Key);
                    Con.SetData(Query);
                    MessageBox.Show("Car Updated!!!");

                    ShowCars();
                }
                catch (Exception Ex)
                {

                    MessageBox.Show(Ex.Message);

                }
            }




        
    }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (Key == 0)
            {
                MessageBox.Show("Select a Car !!!");

            }
            else
            {
                try
                {
                   
                    string Query = "Delete from CarsTbl  where CNum = {0}";
                    Query = String.Format(Query,Key);
                    Con.SetData(Query);
                    MessageBox.Show("Car Deleted!!!");
                    ShowCars();
                }
                catch (Exception Ex)
                {

                    MessageBox.Show(Ex.Message);

                }
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Places Obj = new Places();
            Obj.Show();
            this.Hide();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            DialogResult check = MessageBox.Show("Are you sure you want to logout?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (check == DialogResult.Yes)
            {
                Places lform = new Places();
                lform.Show();
                this.Hide();
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
