using System;
using System.Windows.Forms;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;

//おじさんを大量に生成しなければいけない
//生成したらdisposeしなきゃいけない
class wheelchair_race :Form
{
	//変数設定
	Label point = new Label();
	private System.Windows.Forms.Timer tm = new System.Windows.Forms.Timer ();
	private Button GameStart = new Button();
	//
	PictureBox [] Pict = new PictureBox[5];
	PictureBox [] PictUra = new PictureBox[5];
	PictureBox [] Pict3 = new PictureBox[5];
	PictureBox [] Pictt = new PictureBox[5];
	PictureBox [] Pictd = new PictureBox[5];
	PictureBox wheelchair = new PictureBox();
    PictureBox emblem = new PictureBox();
	string OnOff;
	int NowTime = 0;
	int speed = 2;
	int tmp =0;
    int points = 120;


	//Thread thread1 = new Thread( new ThreadStart( up) );
	//演歌雲とイベント
	public static void Main()
	{
		Application.Run(new wheelchair_race());
	}
	
	public wheelchair_race()
	{
        //学校
        emblem.Image = Image.FromFile(@"Z:\パソコン部\文化祭発表用フォルダ\exes\kurumaisuImages\ddd.jpg");
        point.Font = new Font("SansSerif", 50);
        //フォームを真ん中に設定
        this.StartPosition = FormStartPosition.Manual;
		this.Location = new Point(0,(Screen.PrimaryScreen.Bounds.Height - this.Height)/2 );
		
		this.Width =  Screen.PrimaryScreen.Bounds.Width; //フォームの幅をパソコン画面と同じに設定
		this.Height = 300;
		
		this.Text = "wheelchair_race";
		
		//ポイント部分
		point.Left = this.Right - point.Width - 300;
        point.Height = 100;
        point.Width = 600;
		point.Text = "血圧: " + points;
		
		//ボタン部分、ゲーム開始後はボタンが消える
		GameStart.Text = "はじめる";
		GameStart.Left = (this.Width - GameStart.Width) /2;	//真ん中に配置
		GameStart.Top = 10;
		GameStart.Click += delegate 
		{
			tm.Start();
		};
		
		//ジャンプ配置
		this.KeyDown += delegate(Object sender,KeyEventArgs e)
		{
			if(	e.KeyCode == Keys.Up)
			{
				OnOff = "ON";
			}
		};
		
		//車椅
		wheelchair.Image = Image.FromFile(@"Z:\パソコン部\文化祭発表用フォルダ\exes\kurumaisuImages\weelcar.png");
		wheelchair.Parent = this;
		wheelchair.Left = 30;
		wheelchair.Top = this.Height - 100;
		wheelchair.Height = 44;
		wheelchair.Width = 50;
		//爺さん呼び出し
		MoreImages();
		Ura();
		kai3();
		kai4();
		kai5();
        kai6();





		//画面描画処理
		tm.Interval = 1;
		tm.Tick += delegate
		{
            
            NowTime +=1;
			GAMEMAIN();
            encountObject();
			Movewheelchair();
			//最後の画像が1000を超えたとき
			if(Pict[4].Left <= 1200)
			{
				MoveUra();
				speed =10;
			}
			
			//ｳﾗの最後の画像が1100を超えたとき
			if(PictUra[4].Left <= 1100)
			{
				Movekai3();
				speed = 20;
			}
			
			if(Pict3[4].Left <= 1200)
			{
				Movekai4();
				speed = 10;				
			}
			
			if(Pictt[4].Left <= 1200)
			{
				Movekai5();
				speed = 10;				
			}
			
			if (Pictd[4].Left <=0)
			{
                wheelchair.Left = 500;
                emblem.Width = 300;
                emblem.Height = 300;
                
                Movekai6();
                speed = 10;
			}
			
		};
		
		
		//Parent
		point.Parent = this;
		GameStart.Parent = this;
		
		
	}
/*
 * 	PictureBox [] Pict = new PictureBox[5];
	PictureBox [] PictUra = new PictureBox[5];
	PictureBox [] Pict3 = new PictureBox[5];
	PictureBox [] Pictt = new PictureBox[5];
	PictureBox [] Pictd = new PictureBox[5];
	PictureBox wheelchair = new PictureBox();
    */
    void encountObject()
    {
        for(int i = 0;i < Pict.Length ;i++ )
        {
            if (wheelchair.Bottom >=  Pict[i].Top && wheelchair.Left <= Pict[i].Left && Pict[i].Left <= wheelchair.Right)

        {
                if (i == 1 || i == 4)
                {
                    points += 5;
                    point.Text = "血圧 " + points;

                }
                else
                {
                    points += -5;
                    point.Text = "血圧 " + points;
                }
        }
           if(wheelchair.Bottom >= PictUra[i].Top && wheelchair.Left <= PictUra[i].Left && PictUra[i].Left <= wheelchair.Right)

        {
                if (i == 1)
                {
                    points += 5;
                    point.Text = "血圧 " + points;

                }
                else
                {
                    points += -20;
                    point.Text = "血圧 " + points;
                }
            }
           if(wheelchair.Bottom >= Pict3[i].Top && wheelchair.Left <= Pict3[i].Left && Pict3[i].Left <= wheelchair.Right)

        {
                if (i == 1 || i == 3)
                {
                    points += 5;
                    point.Text = "血圧 " + points;

                }
                else
                {
                    points += -20;
                    point.Text = "血圧 " + points;
                }
            }
           if (wheelchair.Bottom >= Pictt[i].Top && wheelchair.Left <= Pictt[i].Left && Pictt[i].Left <= wheelchair.Right)

            {
                if (i == 1 || i == 3)
                {
                    points += 20;
                    point.Text = "血圧 " + points;

                }
                else
                {
                    points += -20;
                    point.Text = "血圧 " + points;
                }
            }
           if(wheelchair.Bottom >= Pictd[i].Top && wheelchair.Left <= Pictd[i].Left && Pictd[i].Left <= wheelchair.Right)

        {
                if (i == 1 || i == 3)
                {
                    points += 5;
                    point.Text = "血圧 " + points;

                }
                else
                {
                    points += -20;
                    point.Text = "血圧 " + points;
                }
            }
            if (wheelchair.Left <= emblem.Left && emblem.Left <= wheelchair.Right)

            {
                emblem.Top = 20;
                speed = 4;
                emblem.Image = Image.FromFile(@"Z:\パソコン部\文化祭発表用フォルダ\exes\kurumaisuImages\sssss.png");
                if (emblem.Left == 0)
                {
                    
                }
            }
            

        }
    }

	void Movewheelchair()
	{
		if(OnOff == "ON")
		{
			tmp +=1;
		}
		
		if(tmp < 17)
		{
			wheelchair.Top += -tmp;
		}
		else if(tmp == 17)
		{
			wheelchair.Left +=1;
		}
		else if(tmp > 17 && tmp < 40)
		{
			wheelchair.Top += (tmp-10)/4;
		}
		else if(tmp == 40)
		{
			tmp =0;
			wheelchair.Top = this.Height - 100;
			OnOff ="OFF";
		}
		
	}
		
	
	void kai3()
	{
		for(int i = 0;i <PictUra.Length;i++)
		{
			Pict3[i] = new PictureBox();
			Pict3[i].Parent = null;			//標準状態だと非表示
			Pict3[i].Width = 50;
			Pict3[i].Height = 82;
			//一番下に表示(あとで書き直し、不正な位置）
			Pict3[i].Top = Height - 100;

			Pict3[i].Left = 1400;
		}
		Pict3[0].Image = Image.FromFile(@"Z:\パソコン部\文化祭発表用フォルダ\exes\kurumaisuImages\ojiisan.png");
		Pict3[1].Image = Image.FromFile(@"Z:\パソコン部\文化祭発表用フォルダ\exes\kurumaisuImages\qqsha.png");
		Pict3[2].Image = Image.FromFile(@"Z:\パソコン部\文化祭発表用フォルダ\exes\kurumaisuImages\ojiisan.png");
		Pict3[3].Image = Image.FromFile(@"Z:\パソコン部\文化祭発表用フォルダ\exes\kurumaisuImages\qqsha.png");
		Pict3[4].Image = Image.FromFile(@"Z:\パソコン部\文化祭発表用フォルダ\exes\kurumaisuImages\ojiisan.png");
		
		kankakuRandam3();
	}
	
	void kankakuRandam3()
	{
		rund[] RDM = new rund[5];
		
		for (int i = 0; i < RDM.Length; i++)
		{
			RDM[i] = new rund(4,15,i*100);	//シード値ごまかし
			Pict3[i].Left += RDM[i].rand * 100;
			this.Text += RDM[i].rand +" ";
		}		
	}
	void Movekai3()
	{
		for (int I = 0;I<Pict3.Length;I++)
		{
			//すべての画像を表示させる
			Pict3[I].Parent= this;
			//すべての画像を移動させる
			Pict3[I].Left += -(speed);
		}		
	}

//
	void kai4()
	{
		for(int i = 0;i <PictUra.Length;i++)
		{
			Pictt[i] = new PictureBox();
			Pictt[i].Parent = null;			//標準状態だと非表示
			Pictt[i].Width = 50;
			Pictt[i].Height = 82;
			//一番下に表示(あとで書き直し、不正な位置）
			Pictt[i].Top = Height - 100;
			Pictt[i].Left = 1400;
		}
		Pictt[0].Image = Image.FromFile(@"Z:\パソコン部\文化祭発表用フォルダ\exes\kurumaisuImages\ojiisan.png");
		Pictt[1].Image = Image.FromFile(@"Z:\パソコン部\文化祭発表用フォルダ\exes\kurumaisuImages\qqsha.png");
		Pictt[2].Image = Image.FromFile(@"Z:\パソコン部\文化祭発表用フォルダ\exes\kurumaisuImages\ojiisan.png");
		Pictt[3].Image = Image.FromFile(@"Z:\パソコン部\文化祭発表用フォルダ\exes\kurumaisuImages\qqsha.png");
		Pictt[4].Image = Image.FromFile(@"Z:\パソコン部\文化祭発表用フォルダ\exes\kurumaisuImages\ojiisan.png");
		
		kankakuRandam3();
	}
	
	void kankakuRandam4()
	{
		rund[] RDM = new rund[5];
		
		for (int i = 0; i < RDM.Length; i++)
		{
			RDM[i] = new rund(4,29,i*100);	//シード値ごまかし
			Pictt[i].Left += RDM[i].rand * 100;
			this.Text += RDM[i].rand +" ";
		}		
	}
	void Movekai4()
	{
		for (int I = 0;I<Pictt.Length;I++)
		{
			//すべての画像を表示させる
			Pictt[I].Parent= this;
			//すべての画像を移動させる
			Pictt[I].Left += -(speed);
		}		
	}
//
	void kai5()
	{
		for(int i = 0;i <PictUra.Length;i++)
		{
			Pictd[i] = new PictureBox();
			Pictd[i].Parent = null;			//標準状態だと非表示
			Pictd[i].Width = 50;
			Pictd[i].Height = 82;
			//一番下に表示(あとで書き直し、不正な位置）
			Pictd[i].Top = Height - 100;
			Pictd[i].Left = 1400;
		}
		Pictd[0].Image = Image.FromFile(@"Z:\パソコン部\文化祭発表用フォルダ\exes\kurumaisuImages\ojiisan.png");
		Pictd[1].Image = Image.FromFile(@"Z:\パソコン部\文化祭発表用フォルダ\exes\kurumaisuImages\qqsha.png");
		Pictd[2].Image = Image.FromFile(@"Z:\パソコン部\文化祭発表用フォルダ\exes\kurumaisuImages\ojiisan.png");
		Pictd[3].Image = Image.FromFile(@"Z:\パソコン部\文化祭発表用フォルダ\exes\kurumaisuImages\qqsha.png");
		Pictd[4].Image = Image.FromFile(@"Z:\パソコン部\文化祭発表用フォルダ\exes\kurumaisuImages\ojiisan.png");
		
		kankakuRandam5();
	}
	
	void kankakuRandam5()
	{
		rund[] RDM = new rund[5];
		
		for (int i = 0; i < RDM.Length; i++)
		{
			RDM[i] = new rund(4,29,i*100);	//シード値ごまかし
			Pictd[i].Left += RDM[i].rand * 100;
			this.Text += RDM[i].rand +" ";
		}		
	}
	void Movekai5()
	{
		for (int I = 0;I<Pictt.Length;I++)
		{
			//すべての画像を表示させる
			Pictd[I].Parent= this;
			//すべての画像を移動させる
			Pictd[I].Left += -(speed);
		}		
	}

    //ji
    void kai6()
    {

            emblem.Parent = null;         //標準状態だと非表示
            emblem.Width =100 ;
            emblem.Height = 100;
            //一番下に表示(あとで書き直し、不正な位置）
            emblem.Top = Height - 150;
            emblem.Left = 1400;

    }


    void Movekai6()
    {
            //すべての画像を表示させる
            emblem.Parent = this;
            //すべての画像を移動させる
            emblem.Left += -(speed);

    }





    //メイン部分
    void GAMEMAIN()
	{
		//ボタン部分を消す
		GameStart.Dispose();
		MoveObject();

		
		//テスト
		this.Text = "" + NowTime +" 速度："+speed;
	}
	
	void Ura()
	{
		for(int i = 0;i <PictUra.Length;i++)
		{
			PictUra[i] = new PictureBox();
			PictUra[i].Parent = null;			//標準状態だと非表示
			PictUra[i].Width = 50;
			PictUra[i].Height = 82;
			//一番下に表示(あとで書き直し、不正な位置）
			PictUra[i].Top = Height - 100;
			PictUra[i].Left = 1400;
		}
		PictUra[0].Image = Image.FromFile(@"Z:\パソコン部\文化祭発表用フォルダ\exes\kurumaisuImages\ojiisan.png");
		PictUra[1].Image = Image.FromFile(@"Z:\パソコン部\文化祭発表用フォルダ\exes\kurumaisuImages\qqsha.png");
		PictUra[2].Image = Image.FromFile(@"Z:\パソコン部\文化祭発表用フォルダ\exes\kurumaisuImages\ojiisan.png");
		PictUra[3].Image = Image.FromFile(@"Z:\パソコン部\文化祭発表用フォルダ\exes\kurumaisuImages\ojiisan.png");
		PictUra[4].Image = Image.FromFile(@"Z:\パソコン部\文化祭発表用フォルダ\exes\kurumaisuImages\ojiisan.png");
		
		kankakuRandamUra();
	}
	
	void MoveUra()
	{
		for (int I = 0;I<PictUra.Length;I++)
		{
			//すべての画像を表示させる
			PictUra[I].Parent= this;
			//すべての画像を移動させる
			PictUra[I].Left += -(speed);
		}		
	}
	void kankakuRandamUra()
	{	
		rund[] RDM = new rund[5];
		
		for (int i = 0; i < RDM.Length; i++)
		{
			RDM[i] = new rund(0,20,i*100);	//シード値ごまかし
			PictUra[i].Left += RDM[i].rand * 100;
			this.Text += RDM[i].rand +" ";
		}
	}	


	
	void MoveObject()
	{
		for (int I = 0;I<Pict.Length;I++)
		{
			//すべての画像を表示させる
			Pict[I].Parent= this;
			//すべての画像を移動させる
			Pict[I].Left += -(speed);
		}
	}
	
	
	void MoreImages()
	{
//		//爺さんを表示、あとでやりなし
//		
//		Jisan.Image = Image.FromFile(@"E:\ojiisan.png");
//		Jisan.Parent = null;								//爺さんは標準状態だと非表示
//		Jisan.Height = 82;
//		//一番下に表示(あとで書き直し、不正な位置になる)
//		Jisan.Top = Height -100;
//		Jisan.Left = this.Width - Jisan.Width;
		
		//画像複数表示
		//配列で表示
		for (int i = 0; i < Pict.Length; i++)
		{
			Pict[i] = new PictureBox();
			Pict[i].Parent = null;			//標準状態だと非表示
			Pict[i].Width = 50;
			Pict[i].Height = 82;
			//一番下に表示(あとで書き直し、不正な位置）
			Pict[i].Top = Height - 100;
			Pict[i].Left = 1400;
		}
		
		Pict[0].Image = Image.FromFile(@"Z:\パソコン部\文化祭発表用フォルダ\exes\kurumaisuImages\ojiisan.png");
		Pict[1].Image = Image.FromFile(@"Z:\パソコン部\文化祭発表用フォルダ\exes\kurumaisuImages\qqsha.png");
		Pict[2].Image = Image.FromFile(@"Z:\パソコン部\文化祭発表用フォルダ\exes\kurumaisuImages\ojiisan.png");
		Pict[3].Image = Image.FromFile(@"Z:\パソコン部\文化祭発表用フォルダ\exes\kurumaisuImages\ojiisan.png");
		Pict[4].Image = Image.FromFile(@"Z:\パソコン部\文化祭発表用フォルダ\exes\kurumaisuImages\ojiisan.png");
		
		kankakuRandam();
	}

	//間隔をランダム設定
	void kankakuRandam()
	{	
		rund[] RDM = new rund[5];
		
		for (int i = 0; i < RDM.Length; i++)
		{
			RDM[i] = new rund(0,10,i*100);	//シード値ごまかし
			Pict[i].Left += RDM[i].rand * 100;
			this.Text += RDM[i].rand +" ";
		}
	}
	
	void Roop()
	{
	}
}

class rund 
{
    int iResult1;
    //乱数を表示
    public rund(int I, int II,int seed)
    {

        // Random クラスの新しいインスタンスを生成する
        Random cRandom = new Random(seed);

        // 0 以上 512 未満の乱数を取得する
        iResult1 = cRandom.Next(I,II);
        cRandom = null;
    }
    public int rand
    {
        set{ iResult1 = value; }
        get{ return iResult1; }
    }
}