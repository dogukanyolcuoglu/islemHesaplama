using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1islemOdevi
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }
        static int[] rndNums = new int[7]; //Random Sayilarimizin dizisini oluşturduk.
        static int[] newNums = new int[7]; //Textbox'a girilen sayıların dizini oluşturduk.
        static int ucBas = 0;               
        static int enBuyuk = 0;              
        static Random random = new Random();
            
        public void DegerAtama() //Textbox'a girilen sayıları dizinin içine atayan metod.
        {
            //to do
        }

        private void RandomOlustur() //Rabdom sayıları oluşturduğumuz metod.
        {
            for (int i = 0; i < 6; i++)
            {
                rndNums[i] = random.Next(1, 10); 
            }
            rndNums[5] *= 10; //10 un katı haline getiriyoruz.
            rndNums[6] = random.Next(100, 1000); 
            ucBas = rndNums[6]; 
            
            textBox1.Text = rndNums[0].ToString();
            textBox2.Text = rndNums[1].ToString();
            textBox3.Text = rndNums[2].ToString();
            textBox4.Text = rndNums[3].ToString();
            textBox5.Text = rndNums[4].ToString();
            textBox6.Text = rndNums[5].ToString();
            textBox7.Text = rndNums[6].ToString();


        }
        private void hesapla(Label label) //Hesaplama işlemini yaptığımız metod ve içinde algoritmamız var.
        {
                //Bu kısımda textBox'taki değerleri dizide tutuyoruz...
                newNums[0] = Convert.ToInt32(textBox1.Text);
                newNums[1] = Convert.ToInt32(textBox2.Text);
                newNums[2] = Convert.ToInt32(textBox3.Text);
                newNums[3] = Convert.ToInt32(textBox4.Text);
                newNums[4] = Convert.ToInt32(textBox5.Text);
                newNums[5] = Convert.ToInt32(textBox6.Text);
                newNums[6] = Convert.ToInt32(textBox7.Text);
                ucBas = newNums[6];

                int count = 0; //Döngüyü devam ettirmek için sayac oluşturduk.
                while (true)
                {
                    count++;

                    int swap = random.Next(6); //Rastgele sayı oluşturuyoruz.Bu dizi içinde sayıları rastgele seçmeye yarayacak değişken.
                    int temp = newNums[swap];  //Swap edip  deniyecek döngü her döndüğünde...
                    newNums[swap] = newNums[0];
                    newNums[0] = temp;  //Ve dizinin ilk indisine atacak rastgele gelen sayiyi...

                    int sonuc = newNums[0];

                    string cozum = newNums[0].ToString(); //Çözümü string ifade olarak labela yazdıracağımız değişken tanımladık.

                    int islemSayisi = random.Next(3, 6);  //İşleme girilecek sayi adedini random olarak atadığımız değişken.

                    for (int i = 1; i < islemSayisi; i++) //Döngü İşlem adedi kadar dönüyor.
                    {
                        int islem = random.Next(4);  //Yapılacak işlemi random olarak seçtiriyoruz.Böylece sürekli deneyecek.
                        switch (islem)
                        {
                            case 0:
                                sonuc += newNums[i];
                                cozum = "(" + cozum + " + " + newNums[i].ToString() + ")";
                                break;
                            case 1:
                                sonuc -= newNums[i];
                                cozum = "(" + cozum + " - " + newNums[i].ToString() + ")";
                                break;
                            case 2:
                                sonuc *= newNums[i];
                                cozum = "(" + cozum + " * " + newNums[i].ToString() + ")";
                                break;
                            case 3:
                                if (sonuc % newNums[i] != 0) continue;
                                sonuc /= newNums[i];
                                cozum = "(" + cozum + " / " + newNums[i].ToString() + ")";
                                break;
                        }
                    }
                    cozum += " = " + sonuc.ToString(); //Çözümü label'a yazdırıyoruz...

                    if (Math.Abs(ucBas - sonuc) < Math.Abs(ucBas - enBuyuk)) //Sonucu kontrol ettiriyoruz.Yakın bir sonuç var mı diye bakıyoruz...
                    {
                        enBuyuk = sonuc;
                        label.Text = cozum;
                    }

                    if (sonuc == ucBas || sonuc - 9 == ucBas || sonuc + 9 == ucBas) //Sonucu kontrol ettiriyoruz yine...
                    {
                        break;
                    }

                    if (count > 150000) break; //Program sürekli deniyor 
                    else continue;  //Ve sonlandırıyor kendisini.
                }
        }
        private void btnRandom_Click(object sender, EventArgs e)
        {
            RandomOlustur();
        }
 
        private void btnHesapla_Click(object sender, EventArgs e)
        {
               //Bu kısımda önce sorgulama yaptırıyoruz...
               if(
                    textBox1.Text == " " || textBox2.Text == " " || textBox3.Text == " " ||
                    textBox1.Text == String.Empty || textBox2.Text == String.Empty || textBox3.Text == String.Empty
                )
                {

                    MessageBox.Show("Boş Alan Hatası ! ", "Hata", MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
                else if( textBox4.Text == " " || textBox5.Text == " " || textBox6.Text ==" " ||
                        textBox4.Text == String.Empty || textBox5.Text == String.Empty || textBox6.Text == String.Empty )
                {
                    MessageBox.Show("Boş Alan Hatası ! ", "Hata");
                }
               else if (Convert.ToInt32(textBox1.Text) > 9 || Convert.ToInt32(textBox2.Text) > 9 || Convert.ToInt32(textBox3.Text) > 9 ||
                        Convert.ToInt32(textBox4.Text) > 9 || Convert.ToInt32(textBox5.Text) > 9 )
               {
                   MessageBox.Show("9' dan büyük sayi girdiniz!( Aşağıdaki Bilgiyi Okuyunuz! )", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
               }
               else if (Convert.ToInt32(textBox1.Text) < 0 || Convert.ToInt32(textBox2.Text) < 0 || Convert.ToInt32(textBox3.Text) < 0 ||
                        Convert.ToInt32(textBox4.Text) < 0 || Convert.ToInt32(textBox5.Text) < 0 )
               {
                   MessageBox.Show("0' dan küçük sayi girdiniz!( Aşağıdaki Bilgiyi Okuyunuz! )", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
               }
               else if (Convert.ToInt32(textBox6.Text) % 10 != 0 || Convert.ToInt32(textBox6.Text) > 90 )
               {
                   MessageBox.Show("6.kutuya 10'un katı bir sayi giriniz!( Aşağıdaki Bilgiyi Okuyunuz! )", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
               }
               else if (Convert.ToInt32(textBox7.Text) < 100 || Convert.ToInt32(textBox7.Text) > 999 )
               {
                   MessageBox.Show("7.kutu hatalı giriş!( Aşağıdaki Bilgiyi Okuyunuz! )", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
   
               }
               else
               {
                   hesapla(lblCevap); 
               }    
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            lblCevap.Text = " ";
            textBox1.Text = " ";
            textBox2.Text = " ";
            textBox3.Text = " ";
            textBox4.Text = " ";
            textBox5.Text = " ";
            textBox6.Text = " ";
            textBox7.Text = " ";

        }

        private void lblCevap_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        bool move;
        int mouse_x,mouse_y;

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (move)
	        {
                this.SetDesktopLocation(MousePosition.X - mouse_x, MousePosition.Y - mouse_y);
	        }
            
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            move = true;
            mouse_x = e.X;
            mouse_y = e.Y;
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            move = false;

        }
    }
}
