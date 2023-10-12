using CustomMessageBox;
using Palacio_el_restaurante.src.Conection;
using Palacio_el_restaurante.src.GUI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Palacio_el_restaurante.src.UI
{
    public partial class FoodUI : Form
    {
        public int xClick = 0, yClick = 0;
        private int ss;
        private int countA, countS, countI;
        private int buttonCountL, buttonCountM, buttonCountC;
        private int buttonOn, buttonLe, buttonTo, buttonSp, buttonVSp;
        private int countAM, countBM;
        private int ssAnimation = 0;
        private int ssAminationFood = 0;

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
      (
          int nLeftRect,     // x-coordinate of upper-left corner
          int nTopRect,      // y-coordinate of upper-left corner
          int nRightRect,    // x-coordinate of lower-right corner
          int nBottomRect,   // y-coordinate of lower-right corner
          int nWidthEllipse, // height of ellipse
          int nHeightEllipse // width of ellipse
      );
        public FoodUI()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            loadDrink.Enabled = false;
            loadFood.Enabled = false;
            fillBoxes("Bebida","Platillo fuerte");
        }

        private async Task loadPicturesDrink()
        {
            try
            {
                InquiriesDB DB = new InquiriesDB();
                string selectedDrinkName = rjItemD.SelectedItem as string;

                if (string.IsNullOrEmpty(selectedDrinkName))
                {
                    return; 
                }

                Image image = DB.getImage(selectedDrinkName);
                if (pictureDrink.InvokeRequired)
                {
                    pictureDrink.Invoke((MethodInvoker)(() =>
                    {
                        pictureDrink.Image = image;
                    }));
                }
                else
                {
                    pictureDrink.Image = image;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        private async Task loadPicturesFood()
        {
            try
            {
                InquiriesDB DB = new InquiriesDB();
                string selectedFoodName = rjItemF.SelectedItem as string;

                if (string.IsNullOrEmpty(selectedFoodName))
                {
                    return; 
                }

                Image image = DB.getImage(selectedFoodName);
                if (pictureFood.InvokeRequired)
                {
                    pictureFood.Invoke((MethodInvoker)(() =>
                    {
                        pictureFood.Image = image;
                        labelFood.Text = selectedFoodName;
                    }));
                }
                else
                {
                    pictureFood.Image = image;
                    labelFood.Text = selectedFoodName;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void fillBoxes(String typeDrink, String typeFood)
        {
            InquiriesDB DB = new InquiriesDB();
            List<string> consumablesList = DB.getConsumable(typeDrink);
            foreach (string consumable in consumablesList)
            {
                rjItemD.Items.Add(consumable);
            }

            List<string> foodList = DB.GetFood(typeFood);
            foreach (string food in foodList)
            {
                rjItemF.Items.Add(food);
            }

        }
        private void motionFrame(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            { xClick = e.X; yClick = e.Y; }
            else
            { this.Left = this.Left + (e.X - xClick); this.Top = this.Top + (e.Y - yClick); }


        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            ss += 1;
            if (ss == 15)
            {
                resetTimer();
                LoginFrame login = new LoginFrame();
                login.Show();
                login.Visible = true;
                this.Hide();
            }
        }
        private void resetTimer()
        {
            ss = 0;
            timer1.Stop();
        }

        private void pictureLogOut_Click(object sender, EventArgs e)
        {
            LoginFrame login = new LoginFrame();
            login.Show();
            this.Hide();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FoodUI_MouseMove(object sender, MouseEventArgs e)
        {
            motionFrame(sender, e);
        }
        private void clickMore(String type)
        {
            switch (type)
            {
                case "Amount":
                    switch (countA)
                    {
                        case 0:
                            showCount1.Image = Properties.Resources.cero;
                            break;
                        case 1:
                            showCount1.Image = Properties.Resources.uno;
                            break;
                        case 2:
                            showCount1.Image = Properties.Resources.dos;
                            break;
                        case 3:
                            showCount1.Image = Properties.Resources.tres;
                            break;
                        case 4:
                            showCount1.Image = Properties.Resources.cuatro;
                            break;
                        case 5:
                            showCount1.Image = Properties.Resources.cinco;
                            break;
                        case 6:
                            showCount1.Image = Properties.Resources.seis;
                            break;
                        case 7:
                            showCount1.Image = Properties.Resources.siete;
                            break;
                        case 8:
                            showCount1.Image = Properties.Resources.ocho;
                            break;
                        case 9:
                            showCount1.Image = Properties.Resources.nueve;
                            break;
                        case 10:
                            showCount1.Image = Properties.Resources.diez;
                            break;
                        default:
                            if (countA > 9)
                            {
                                RJMessageBox.Show("Vaya parece que te gusta mucho" +
                                    "pero supera el limite de envio", "ADVERTENCIA!",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                countA = 10;
                            }
                            break;
                    }
                    break;
                case "Sugar":
                    switch (countS)
                    {
                        case 0:
                            showCount3.Image = Properties.Resources.cero;
                            break;
                        case 1:
                            showCount3.Image = Properties.Resources.uno;
                            break;
                        case 2:
                            showCount3.Image = Properties.Resources.dos;
                            break;
                        case 3:
                            showCount3.Image = Properties.Resources.tres;
                            break;
                        case 4:
                            showCount3.Image = Properties.Resources.cuatro;
                            break;
                        case 5:
                            showCount3.Image = Properties.Resources.cinco;
                            break;
                        case 6:
                            showCount3.Image = Properties.Resources.seis;
                            break;
                        case 7:
                            showCount3.Image = Properties.Resources.siete;
                            break;
                        case 8:
                            showCount3.Image = Properties.Resources.ocho;
                            break;
                        case 9:
                            showCount3.Image = Properties.Resources.nueve;
                            break;
                        case 10:
                            showCount3.Image = Properties.Resources.diez;
                            break;
                        default:
                            if (countS > 9)
                            {
                                RJMessageBox.Show("No puedes poner demaciada azúcar", "ADVERTENCIA!",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                countS = 10;
                            }
                            break;
                    }
                    break;
                case "Ice":
                    switch (countI)
                    {
                        case 0:
                            showCount4.Image = Properties.Resources.cero;
                            break;
                        case 1:
                            showCount4.Image = Properties.Resources.uno;
                            break;
                        case 2:
                            showCount4.Image = Properties.Resources.dos;
                            break;
                        case 3:
                            showCount4.Image = Properties.Resources.tres;
                            break;
                        case 4:
                            showCount4.Image = Properties.Resources.cuatro;
                            break;
                        case 5:
                            showCount4.Image = Properties.Resources.cinco;
                            break;
                        case 6:
                            showCount4.Image = Properties.Resources.seis;
                            break;
                        case 7:
                            showCount4.Image = Properties.Resources.siete;
                            break;
                        case 8:
                            showCount4.Image = Properties.Resources.ocho;
                            break;
                        case 9:
                            showCount4.Image = Properties.Resources.nueve;
                            break;
                        case 10:
                            showCount4.Image = Properties.Resources.diez;
                            break;
                        default:
                            if (countI > 9)
                            {
                                RJMessageBox.Show("No puedes poner mucho hielo", "ADVERTENCIA!",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                countI = 10;
                            }
                            break;
                    }
                    break;
            }
        }
        private void button_MoreC_Click(object sender, EventArgs e)
        {
            countA++;
            clickMore("Amount");
        }
        private void rjPictureRounded5_Click(object sender, EventArgs e)
        {
            countS++;
            clickMore("Sugar");
        }
        private void button_Onion_Click(object sender, EventArgs e)
        {
            buttonOn++;
            if (buttonOn < 2)
            {
                button_Onion.Image = Properties.Resources.cebolla;

            }
            else
            {
                button_Onion.Image = Properties.Resources.cebolla_Off;
                buttonOn = 0;
            }
        }

        private void button_Tomato_Click(object sender, EventArgs e)
        {
            buttonTo++;
            if (buttonTo < 2)
            {
                button_Tomato.Image = Properties.Resources.tomate;

            }
            else
            {
                button_Tomato.Image = Properties.Resources.tomate_Off;
                buttonTo = 0;
            }
        }

        private void button_Lettuce_Click(object sender, EventArgs e)
        {
            buttonLe++;
            if (buttonLe < 2)
            {
                button_Lettuce.Image = Properties.Resources.lechuga;

            }
            else
            {
                button_Lettuce.Image = Properties.Resources.lechuga_Off;
                buttonLe = 0;
            }
        }

        private void button_Spicy_Click(object sender, EventArgs e)
        {
            buttonSp++;
            if (buttonSp < 2)
            {
                button_Spicy.Image = Properties.Resources.chile;
                button_VerySpicy.Image = Properties.Resources.fuego_Off;
                buttonVSp = 0;
            }
            else
            {
                button_Spicy.Image = Properties.Resources.chile_Off;
                buttonSp = 0;
            }
        }

        private void button_VerySpicy_Click(object sender, EventArgs e)
        {
            buttonVSp++;
            if (buttonVSp < 2)
            {
                button_VerySpicy.Image = Properties.Resources.fuego;
                button_Spicy.Image = Properties.Resources.chile_Off;
                buttonSp = 0;

            }
            else
            {
                button_VerySpicy.Image = Properties.Resources.fuego_Off;
                buttonVSp = 0;
            }
        }

        private void more_Click(object sender, EventArgs e)
        {
            countAM++;
            clickButton("AmountM");
        }

        private void clickButton(String typeButton)
        {
            switch (typeButton)
            {
                case "AmountM":
                    switch (countAM)
                    {
                        case 0:
                            showAmount.Image = Properties.Resources.cero;
                            break;
                        case 1:
                            showAmount.Image = Properties.Resources.uno;
                            break;
                        case 2:
                            showAmount.Image = Properties.Resources.dos;
                            break;
                        case 3:
                            showAmount.Image = Properties.Resources.tres;
                            break;
                        case 4:
                            showAmount.Image = Properties.Resources.cuatro;
                            break;
                        case 5:
                            showAmount.Image = Properties.Resources.cinco;
                            break;
                        case 6:
                            showAmount.Image = Properties.Resources.seis;
                            break;
                        case 7:
                            showAmount.Image = Properties.Resources.siete;
                            break;
                        case 8:
                            showAmount.Image = Properties.Resources.ocho;
                            break;
                        case 9:
                            showAmount.Image = Properties.Resources.nueve;
                            break;
                        case 10:
                            showAmount.Image = Properties.Resources.diez;
                            break;
                        default:
                            if (countAM > 9)
                            {
                                RJMessageBox.Show("Estas ingresando mucho", "ADVERTENCIA!",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            break;
                    }
                    break;
                case "BagChips":
                    switch (countBM)
                    {
                        case 0:
                            showBag.Image = Properties.Resources.cero;
                            break;
                        case 1:
                            showBag.Image = Properties.Resources.uno;
                            break;
                        case 2:
                            showBag.Image = Properties.Resources.dos;
                            break;
                        case 3:
                            showBag.Image = Properties.Resources.tres;
                            break;
                        case 4:
                            showBag.Image = Properties.Resources.cuatro;
                            break;
                        case 5:
                            showBag.Image = Properties.Resources.cinco;
                            break;
                        case 6:
                            showBag.Image = Properties.Resources.seis;
                            break;
                        case 7:
                            showBag.Image = Properties.Resources.siete;
                            break;
                        case 8:
                            showBag.Image = Properties.Resources.ocho;
                            break;
                        case 9:
                            showBag.Image = Properties.Resources.nueve;
                            break;
                        case 10:
                            showBag.Image = Properties.Resources.diez;
                            break;
                        default:
                            if (countBM > 9)
                            {
                                RJMessageBox.Show("Estas ingresando muchas papas", "ADVERTENCIA!",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            break;
                    }
                    break;
            }
        }

        private void minus_Click(object sender, EventArgs e)
        {
            countAM--;
            clickButton("AmountM");
        }

        private void button_MoreF_Click(object sender, EventArgs e)
        {
            countBM++;
            clickButton("BagChips");
        }


        private void rjAddTea_Click(object sender, EventArgs e)
        {
            DialogResult result = RJMessageBox.Show("Are you sure to add this request to your list?", "QUESTION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    InquiriesDB DB = new InquiriesDB();
                    String[] id = { "1A", "1B", "1C", "1D", "1E", "1F" };
                    List<String> trabajador = DB.GetEmployes(id);
                    Sale venta = new Sale();
                    venta.Amount = countA;
                    if (trabajador.Count > 0)
                    {
                        Random random = new Random();
                        int indiceAleatorio = random.Next(0, id.Length);
                        venta.IdEmploy = id[indiceAleatorio];
                    }
                    String typeDrink = rjItemD.SelectedItem as String;
                    venta.IdDish = DB.GetClurp(typeDrink)[0];
                    venta.Price = float.Parse(DB.GetClurp(typeDrink)[1]);
                    SaleHistory saleHistory = new SaleHistory();
                    saleHistory.AddSale(venta);
                    venta.Date = DateTime.Now.Date;
                    if (DB.registSale(venta))
                    {
                        RJMessageBox.Show("Your order is being processed", "INFORMATION!",
                              MessageBoxButtons.OK, MessageBoxIcon.Information);
                        timer2.Start();
                    }
                    else
                    {
                        RJMessageBox.Show("Your order could not be processed", "INFORMATION!",
                              MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    RJMessageBox.Show(ex.Message, "ERROR!", System.Windows.Forms.MessageBoxButtons.OK,
                        System.Windows.Forms.MessageBoxIcon.Error);
                }
            }
        }


        private void button_AddFood_Click(object sender, EventArgs e)
        {
            DialogResult result = RJMessageBox.Show("Are you sure to add this request to your list?", "QUESTION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    InquiriesDB DB = new InquiriesDB();
                    String[] id = { "1A", "1B", "1C", "1D", "1E", "1F" };
                    List<String> trabajador = DB.GetEmployes(id);
                    Sale venta = new Sale();
                    venta.Amount = countAM;
                    if (trabajador.Count > 0)
                    {
                        Random random = new Random();
                        int indiceAleatorio = random.Next(0, id.Length);
                        venta.IdEmploy = id[indiceAleatorio];
                    }

                    String typeDrink = rjItemF.SelectedItem as String;
                    venta.IdDish = DB.GetClurp(typeDrink)[0];
                    venta.Price = float.Parse(DB.GetClurp(typeDrink)[1]);
                    SaleHistory saleHistory = new SaleHistory();
                    saleHistory.AddSale(venta);
                    venta.Date = DateTime.Now.Date;
                    if (DB.registSale(venta))
                    {
                        RJMessageBox.Show("Your order is being processed", "INFORMATION!",
                              MessageBoxButtons.OK, MessageBoxIcon.Information);
                        timer2.Start();
                    }
                    else
                    {
                        RJMessageBox.Show("Your order could not be processed", "INFORMATION!",
                              MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    RJMessageBox.Show(ex.Message, "ERROR!", System.Windows.Forms.MessageBoxButtons.OK,
                    System.Windows.Forms.MessageBoxIcon.Error);
                }
            }
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            OrdersGUI orders = new OrdersGUI();
            orders.Show();
        }

        private void panelClose_MouseEnter(object sender, EventArgs e)
        {
            Close.Enabled = true;
        }

        private void panelJuice_MouseEnter(object sender, EventArgs e)
        {
            Close.Enabled = false;
            LogOut.Enabled = false;
            Wallet.Enabled = false;
            Settings.Enabled = false;
            Orders.Enabled = false;
        }

        private void panelWallet_MouseEnter(object sender, EventArgs e)
        {
            Wallet.Enabled = true;
        }

        private void panelLogOut_MouseEnter(object sender, EventArgs e)
        {
            LogOut.Enabled = true;
        }

        private void panelSettings_MouseEnter(object sender, EventArgs e)
        {
            Settings.Enabled = true;
        }

        private void panel21_MouseEnter(object sender, EventArgs e)
        {
            Orders.Enabled = true;
        }
        private void panelJuice_MouseMove(object sender, MouseEventArgs e)
        {
            motionFrame(sender, e);
        }
        private void panelFood_MouseMove(object sender, MouseEventArgs e)
        {
            motionFrame(sender, e);
        }

        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            motionFrame(sender, e);
        }
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            motionFrame(sender, e);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            RecordGUI recordGUI = new RecordGUI();
            recordGUI.Show();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            ssAnimation += 1;
            if (ssAnimation < 45)
            {
                loadDrink.Enabled = true;
            }
            else
            {
                timer2.Stop();
                loadDrink.Enabled = false;
                RJMessageBox.Show("Your order is ready to be shipped", "INFORMATION!",
                             MessageBoxButtons.OK, MessageBoxIcon.Information);
                showCount1.Image = Properties.Resources.cero;
                showCount2.Image = Properties.Resources.letra_m_off;
                showCount3.Image = Properties.Resources.cero;
                showCount4.Image = Properties.Resources.cero;
                button_MinusS.Image = Properties.Resources.letra_l_Off;
                button_MoreS.Image = Properties.Resources.letra_c_off;
                ssAnimation = 0;
            }
        }
        private void timer3_Tick(object sender, EventArgs e)
        {
            ssAminationFood += 1;
            if (ssAminationFood < 70)
            {
                loadFood.Enabled = true;
            }
            else
            {
                timer3.Stop();
                loadFood.Enabled = false;
                RJMessageBox.Show("Your order is ready to be shipped", "INFORMATION!",
                             MessageBoxButtons.OK, MessageBoxIcon.Information);
                showAmount.Image = Properties.Resources.cero;
                showBag.Image = Properties.Resources.cero;
                button_Onion.Image = Properties.Resources.cebolla_Off;
                button_Tomato.Image = Properties.Resources.tomate_Off;
                button_Lettuce.Image = Properties.Resources.lechuga_Off;
                button_Spicy.Image = Properties.Resources.chile_Off;
                button_VerySpicy.Image = Properties.Resources.fuego_Off;
                ssAminationFood = 0;
            }
        }

        private void rjItemD_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void rjItemD_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                labelDrink.Text = rjItemD.SelectedItem as String;
                Task.Run(async () => await loadPicturesDrink());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void rjItemF_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                labelFood.Text = rjItemF.SelectedItem as String;
                Task.Run(async () => await loadPicturesFood());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private void fillBoxDrink(String type)
        {
            rjItemD.Items.Clear();
            InquiriesDB DB = new InquiriesDB();
            List<string> consumablesList = DB.getConsumable(type);
            foreach (string consumable in consumablesList)
            {
                rjItemD.Items.Add(consumable);
            }
        }
        private void fillBoxFood(String type)
        {
            rjItemF.Items.Clear();
            InquiriesDB DB = new InquiriesDB();
            List<string> foodList = DB.GetFood(type);
            foreach (string food in foodList)
            {
                rjItemF.Items.Add(food);
            }
        }

        private void button_coffe_Click(object sender, EventArgs e)
        {
            fillBoxDrink("Café");
        }

        private void rjButton2_Click(object sender, EventArgs e)
        {
            fillBoxDrink("Te");
        }

        private void rjButton3_Click(object sender, EventArgs e)
        {
            fillBoxDrink("Jugo");
        }

        private void rjButton4_Click(object sender, EventArgs e)
        {
            fillBoxFood("Platillo fuerte");
        }

        private void rjButton5_Click(object sender, EventArgs e)
        {
            fillBoxFood("Comida marina");
        }

        private void button_MinusF_Click(object sender, EventArgs e)
        {
            countBM--;
            clickButton("BagChips");
        }
        private void rjPictureRounded8_Click(object sender, EventArgs e)
        {
            countI++;
            clickMore("Ice");
        }

        private void button_MinusS_Click(object sender, EventArgs e)
        {
            buttonCountL++;
            if (buttonCountL < 2)
            {
                button_MoreS.Image = Properties.Resources.letra_c_off;
                showCount2.Image = Properties.Resources.letra_m_off;
                button_MinusS.Image = Properties.Resources.letra_l;
                buttonCountM = 0;
                buttonCountC = 0;
            }
            else
            {
                button_MinusS.Image = Properties.Resources.letra_l_Off;
                buttonCountL = 0;
            }
        }

        private void rjButton1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            { xClick = e.X; yClick = e.Y; }
            else
            { this.Left = this.Left + (e.X - xClick); this.Top = this.Top + (e.Y - yClick); }
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            { xClick = e.X; yClick = e.Y; }
            else
            { this.Left = this.Left + (e.X - xClick); this.Top = this.Top + (e.Y - yClick); }
        }

        private void showCount2_Click(object sender, EventArgs e)
        {
            buttonCountM++;
            if (buttonCountM < 2)
            {
                showCount2.Image = Properties.Resources.letra_m;
                button_MinusS.Image = Properties.Resources.letra_l_Off;
                button_MoreS.Image = Properties.Resources.letra_c_off;
                buttonCountC = 0;
                buttonCountL = 0;
            }
            else
            {
                showCount2.Image = Properties.Resources.letra_m_off;
                buttonCountM = 0;
            }
        }
        private void button_MoreS_Click(object sender, EventArgs e)
        {
            buttonCountC++;
            if (buttonCountC < 2)
            {
                button_MoreS.Image = Properties.Resources.letra_c;
                showCount2.Image = Properties.Resources.letra_m_off;
                button_MinusS.Image = Properties.Resources.letra_l_Off;
                buttonCountM = 0;
                buttonCountL = 0;
            }
            else
            {
                button_MoreS.Image = Properties.Resources.letra_c_off;
                buttonCountC = 0;
            }
        }

        private void button_MinusC_Click(object sender, EventArgs e)
        {
            countA--;
            clickMore("Amount");
        }
        private void rjPictureRounded4_Click(object sender, EventArgs e)
        {
            countS--;
            clickMore("Sugar");
        }
        private void rjPictureRounded7_Click(object sender, EventArgs e)
        {
            countA--;
            clickMore("Ice");
        }
    }
}