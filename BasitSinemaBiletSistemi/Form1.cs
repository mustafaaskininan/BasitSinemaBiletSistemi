using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BasitSinemaBiletSistemi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        LinkedList ll = new LinkedList();
        private void btnListele_Click(object sender, EventArgs e)
        {
            lblDurum.Text = "SALON AKTİF";
            btnCikar.Enabled = true;
            btnEkle.Enabled = true;
            btnKontrol.Enabled = true;
            btnListele.Enabled = false;
            int fakeValue = 101;
            for (int i = 1; i <= 60; i++)
            {
                ll.InsertLast(fakeValue);
                fakeValue++;
            }
            
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            string btnIsmi = "button" + Convert.ToString(txtKoltuk.Text);
            Form1 frm = null;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "Harry Potter ve Melez Prens")
                {
                    frm = (Form1)f;
                }
            }
            if (frm != null)
            {

                foreach (Control c in frm.Controls)
                {
                    if (c is Button)
                    {
                        if (c.Name == btnIsmi)
                        {
                            c.BackColor = Color.Red; 
                        }
                    }
                }
            }
            if (Convert.ToInt32(txtKoltuk.Text) > 60 || Convert.ToInt32(txtKoltuk.Text) < 1)
            {
                MessageBox.Show("Geçersiz Koltuk Numarası Girdiniz");
            }
            else
            {
                if (ll.GetElement(Convert.ToInt32(txtKoltuk.Text)).Data > 0 && ll.GetElement(Convert.ToInt32(txtKoltuk.Text)).Data <= 60)
                {
                    MessageBox.Show("Koltuk Daha Önceden Satılmış");
                }
                else
                {
                    if (Convert.ToInt32(txtKoltuk.Text) == 1)
                    {
                        ll.DeleteFirst();
                        ll.InsertFirst(Convert.ToInt32(txtKoltuk.Text));
                        txtListe.Clear();
                        txtListe.Text = ll.DisplayElements();
                    }
                    else if (Convert.ToInt32(txtKoltuk.Text) == 60)
                    {
                        ll.DeleteLast();
                        ll.InsertLast(Convert.ToInt32(txtKoltuk.Text));
                        txtListe.Clear();
                        txtListe.Text = ll.DisplayElements();
                    }
                    else if (Convert.ToInt32(txtKoltuk.Text) < 60 && Convert.ToInt32(txtKoltuk.Text) > 1)
                    {
                        ll.DeletePos(Convert.ToInt32(txtKoltuk.Text));
                        ll.InsertPos(Convert.ToInt32(txtKoltuk.Text), Convert.ToInt32(txtKoltuk.Text));
                        txtListe.Clear();
                        txtListe.Text = ll.DisplayElements();
                    }
                }
            }
        }

        private void txtKoltuk_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void btnCikar_Click(object sender, EventArgs e)
        {
            string btnIsmi = "button" + Convert.ToString(txtKoltuk.Text);
            Form1 frm = null;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "Form1")
                {
                    frm = (Form1)f;
                }
            }
            if (frm != null)
            {

                foreach (Control c in frm.Controls)
                {
                    if (c is Button)
                    {
                        if (c.Name == btnIsmi)
                        {
                            c.BackColor = Color.Green; ;
                        }
                    }
                }
            }
            if (Convert.ToInt32(txtKoltuk.Text) > 60 || Convert.ToInt32(txtKoltuk.Text) < 1)
            {
                MessageBox.Show("Hatalı Değer Girdiniz");
            }
            else
            {
                if (ll.GetElement(Convert.ToInt32(txtKoltuk.Text)).Data > 60)
                {
                    MessageBox.Show("Koltuk Henüz satılmamış");
                }
                else
                {
                    if (Convert.ToInt32(txtKoltuk.Text) == 1)
                    {
                        ll.DeleteFirst();
                        ll.InsertFirst(101);
                        txtListe.Clear();
                        txtListe.Text = ll.DisplayElements();
                    }
                    else if (Convert.ToInt32(txtKoltuk.Text) == 60)
                    {
                        ll.DeleteLast();
                        ll.InsertLast(160);
                        txtListe.Clear();
                        txtListe.Text = ll.DisplayElements();
                    }
                    else if (Convert.ToInt32(txtKoltuk.Text) < 60 && Convert.ToInt32(txtKoltuk.Text) > 1)
                    {
                        int i = 100 + Convert.ToInt32(txtKoltuk.Text);
                        ll.DeletePos(Convert.ToInt32(txtKoltuk.Text));
                        ll.InsertPos(Convert.ToInt32(txtKoltuk.Text), i);
                        txtListe.Clear();
                        txtListe.Text = ll.DisplayElements();
                    }
                }
            }
        }

        private void txtKontrol_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void btnKontrol_Click(object sender, EventArgs e)
        {
            try
            {
                if (ll.GetElement(Convert.ToInt32(txtKontrol.Text)).Data < 61 && ll.GetElement(Convert.ToInt32(txtKontrol.Text)).Data > 0)
                {
                    lblBiletDurumu.Text = ll.GetElement(Convert.ToInt32(txtKontrol.Text)).Data + ".Koltuk satılmıştır\nAdı:\nSoyadı:";
                }
                else
                {
                    lblBiletDurumu.Text = txtKontrol.Text + ".Koltuk satılmamıştır";
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Hatalı Koltuk Numarası Girdiniz");
            }
        }
    }
}
