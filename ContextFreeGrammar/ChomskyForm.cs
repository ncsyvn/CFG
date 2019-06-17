using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ContextFreeGrammar
{
    public partial class ChomskyForm : Form
    {
        public string s;
        public string s1;
        public List<Road> road = new List<Road>();
        List<string> end = new List<string>();
        List<string> notEnd = new List<string>();

        public ChomskyForm(string s, List<Road> road, List<string> end, List<string> notEnd, string s1)
        {
            InitializeComponent();
            this.s = s;
            this.s1 = s1;
            this.road = new List<Road>();
            this.end = new List<string>();
            this.notEnd = new List<string>();
            this.road = road;
            this.end = end;
            this.notEnd = notEnd;
            this.Show();
            ConvertToChomsky();
        }
        

        #region Convert To Chomsky
        public void ConvertToChomsky()
        {

            // Tạo tập hợp các kí tự chưa kết thúc từ A đến Z
            List<string> Aggregate = new List<string>();
            int i, j;
            for (i = 65; i <= 90; i++) Aggregate.Add(Convert.ToChar(i).ToString());
            for (i = 65; i <= 90; i++) Aggregate.Add(Convert.ToChar(i).ToString() + "1");
            for (i = 0; i < notEnd.Count; i++)
            {
                for (j = 0; j < Aggregate.Count; j++)
                {
                    if (Aggregate[j] == notEnd[i])
                    {
                        Aggregate.RemoveAt(j);
                        break;
                    }
                }
            }


            // Bước 1: Lấy ra các suy dẫn đã thỏa mãn Chomsky (A->AB, A->a)
            List<Road> chomsky = new List<Road>();
            List<Road> newRoad = new List<Road>();
            for (i = 0; i < road.Count; i++) newRoad.Add(road[i]);
            for (i = 0; i < newRoad.Count; i++)
            {
                if (newRoad[i].End.Length == 2 &&
                    (int)newRoad[i].End[0] >= 65 && (int)newRoad[i].End[0] <= 90 &&
                    (int)newRoad[i].End[1] >= 65 && (int)newRoad[i].End[1] <= 90)
                {
                    chomsky.Add(newRoad[i]);
                    newRoad.RemoveAt(i);
                    i--;
                }

                else if (newRoad[i].End.Length == 1 && (int)newRoad[i].End[0] >= 97 && (int)newRoad[i].End[0] <= 122)
                {
                    chomsky.Add(newRoad[i]);
                    newRoad.RemoveAt(i);
                    i--;
                }
            }


            string sNew = "";
            for (i = 0; i < chomsky.Count; i++) sNew = sNew + chomsky[i].Start + "->" + chomsky[i].End + System.Environment.NewLine;
            textBoxStep1ChomskyNew.Text = sNew;
            string sOld = "";
            for (i = 0; i < newRoad.Count; i++) sOld = sOld + newRoad[i].Start + "->" + newRoad[i].End + System.Environment.NewLine;
            textBoxStep1ChomskyOld.Text = sOld;


            // Bước 2: đổi hết kí tự kết thúc bằng kí hiệu chưa kết thúc, tạo các suy dẫn mới đến kí hiệu kết thúc
            Road roadTg = new Road();
            for (i = 0; i < newRoad.Count; i++)
            {
                for (j = 0; j < newRoad[i].End.Length; j++)
                {
                    if (((int)newRoad[i].End[j] >= 97 && (int)newRoad[i].End[j] <= 122) ||
                       ((int)newRoad[i].End[j] >= 48 && (int)newRoad[i].End[j] <= 57) ||
                       (newRoad[i].End[j] == '$'))
                    {
                        roadTg = new Road();
                        roadTg.Start = Aggregate[0];
                        roadTg.End = newRoad[i].End[j].ToString();
                        chomsky.Add(roadTg);

                        newRoad[i].End = newRoad[i].End.Remove(j, 1);
                        newRoad[i].End = newRoad[i].End.Insert(j, Aggregate[0]);

                        Aggregate.RemoveAt(0);

                    }
                }
            }
            sNew = "";
            for (i = 0; i < chomsky.Count; i++) sNew = sNew + chomsky[i].Start + "->" + chomsky[i].End + System.Environment.NewLine;
            textBoxStep2ChomskyNew.Text = sNew;
            sOld = "";
            for (i = 0; i < newRoad.Count; i++) sOld = sOld + newRoad[i].Start + "->" + newRoad[i].End + System.Environment.NewLine;
            textBoxStep2ChomskyOld.Text = sOld;



            // Bước 3: Xử lý rút gọn khi end.length>2
            for (i = 0; i < newRoad.Count; i++)
            {
                while (newRoad[i].End.Length > 2)
                {

                    roadTg = new Road();
                    roadTg.Start = road[i].Start;
                    roadTg.End = road[i].End[0].ToString() + Aggregate[0];
                    chomsky.Add(roadTg);

                    newRoad[i].Start = Aggregate[0];
                    newRoad[i].End = newRoad[i].End.Remove(0, 1);

                    Aggregate.RemoveAt(0);
                }
                chomsky.Add(newRoad[i]);
                //newRoad.RemoveAt(i);
            }
            sNew = "";
            for (i = 0; i < chomsky.Count; i++) sNew = sNew + chomsky[i].Start + "->" + chomsky[i].End + System.Environment.NewLine;
            textBoxStep3ChomskyNew.Text = sNew;
            sOld = "";
            for (i = 0; i < newRoad.Count; i++) sOld = sOld + newRoad[i].Start + "->" + newRoad[i].End + System.Environment.NewLine;
            textBoxStep3ChomskyOld.Text = "";
        }
        #endregion

    }
}
