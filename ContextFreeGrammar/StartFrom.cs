using ContextFreeGrammar.Guide_Form;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ContextFreeGrammar
{
    public partial class StartFrom : Form
    {
        public string s;
        public List<Road> road = new List<Road>();
        List<string> end = new List<string>();
        List<string> notEnd = new List<string>();

        public StartFrom()
        {
            InitializeComponent();           
        }

        #region Input

        // Chuẩn hóa chuỗi
        public void ProgressStandardized()
        {
            int i;
            string str;
            // gán s = dữ liệu trong textBox đã nhập vào
            s = textBoxInput.Text;

            // Xóa trắng đầu và cuối chuỗi
            s = s.Trim();

            // xóa các khoảng trắng
            for (i = 0; i < s.Length - 1; i++)
                if (s[i] == ' ')
                {
                    s=s.Remove(i, 1);
                    i--;
                }

            // bổ sung thêm > nếu chỉ có -
            for (i=0; i<s.Length; i++)
                if (s[i]== '-' && i != s.Length - 1 && s[i+1]!='>')
                {
                    str = s.Substring(i + 1);
                    s=s.Remove(i + 1);
                    s = s + ">" + str;
                }

            // bổ sung thêm - nếu chỉ có >
            for (i = 0; i < s.Length; i++)
                if (s[i] == '>' && i != 0 && s[i - 1] != '-') 
                {
                    str = s.Substring(i);
                    s = s.Remove(i);
                    s = s + "-" + str;
                }

            textBoxStandardized.Text = s;
        }

        // Nhập đến đâu cập nhật dữ liệu và chuẩn hóa đến đó
        private void textBoxInput_TextChanged(object sender, EventArgs e)
        {
            ProgressStandardized();
            
        }


        // Mở file rồi đọc nội dung vào texboxStandardized
        private void buttonOpenFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog()==DialogResult.OK)
            {
                textBoxFilePath.Text = openFileDialog.FileName;
                textBoxStandardized.Text = File.ReadAllText(textBoxFilePath.Text);
                s = textBoxStandardized.Text;
            }


        }

        // Tách dữ liệu đầu vào, lưu vào list road (gồm điểm bắt đầu và điểm kết thúc)
        public void ProgressSplit()
        {
            int i, j;
            int count = 0;
            string str = "";
            string[] array = new string[1000];
            for (i=0; i<s.Length; i++)
            {
                if ( ((int)s[i]>=65 && (int)s[i] <=90) || ((int)s[i] >= 97 && (int)s[i] <= 122) || ((int)s[i] >= 48 && (int)s[i] <= 58) ||
                        (s[i]=='-') || (s[i]=='>') || (s[i]=='$') )
                {
                    str += s[i].ToString();
                }
                else
                {
                    array[count] = str;
                    str = "";
                    count++;
                }
            }
            array[count] = str;
            count++;

            for (i=0; i<count; i++)
            {
                if (array[i] != "" && (array[i].IndexOf('-') < 0))
                {
                    for (j = i; j >= 0; j--)
                    {
                        if (array[j].IndexOf('-')>0)
                        {
                            array[i] = array[j].Substring(0, array[j].IndexOf('-'))+"->" + array[i];
                            break;
                        }
                    }
                }
            }
            
            for (i=0; i<count; i++)
            {
                if (array[i]!="")
                {
                    Road roadTg = new Road();
                    roadTg.Start = array[i].Substring(0, array[i].IndexOf('-'));
                    roadTg.End = array[i].Substring(array[i].IndexOf('-')+2);
                    road.Add(roadTg);
                }
            }

        }

        private void buttonMin_Click(object sender, EventArgs e)
        {
            ProgressSplit();
            FindList_End_NotEnd();
            DeleteInfertility();
            DeleteEpxilon();
        }
        #endregion

        #region Analytic Data
        //Tìm tập hợp các kí tự kết thúc và không kết thúc
        public void FindList_End_NotEnd()
        {
            int i, j;
            
            //Lấy ra các kí tự kết thúc
            for (i = 0; i < road.Count; i++)
            {
                for (j=0; j<road[i].End.Length; j++)
                    if ( ((int)road[i].End[j] >=97 && (int)road[i].End[j] <=122) ||
                         ((int)road[i].End[j] >= 48 && (int)road[i].End[j] <= 58) || road[i].End[j]=='$' )
                    {
                        end.Add(road[i].End[j].ToString());
                    }                
            }
            // xóa các kí tự trùng nhau
            end.Sort();
            for (i = 0; i < end.Count - 1; i++)
            {
                if (end[i] == end[i + 1])
                {
                    end.RemoveAt(i);
                    i--;
                }
            }



            // lấy ra các kí tự chưa kết thúc
            for (i = 0; i < road.Count; i++)
            {
                notEnd.Add(road[i].Start);
                for (j = 0; j < road[i].End.Length; j++)
                    if ((int)road[i].End[j] >= 65 && (int)road[i].End[j] <= 90)
                    {
                        notEnd.Add(road[i].End[j].ToString());
                    }
            }
            notEnd.Sort();
            for (i = 0; i < notEnd.Count - 1; i++)
            {
                if (notEnd[i] == notEnd[i + 1])
                {
                    notEnd.RemoveAt(i);
                    i--;
                }
            }

            //gán textBoxStep1Min.Text = chuỗi kí tự kết thúc.
            string s = "";
            for (i = 0; i < end.Count-1; i++) s = s + end[i] + "; ";
            s = s + end[end.Count-1];
            s = "{" + s + "}";
            textBoxStep1Infertility.Text = s;            
        }


        //Phương thức hỗ trợ tìm sự xuất hiện của các phần tử trong chuỗi trong 1 list
        public int FindElementStringInList(List<string> list, string s)
        {
            int i;
            for (i = 0; i < s.Length; i++)
            {
                if (list.Contains(s[i].ToString()) == false) return 0;
            }
            return 1;
        }
        #endregion

        #region Delete Infertility
        //Xóa bỏ các kí tự vô sinh
        public void DeleteInfertility()
        {
            List<string> tg = new List<string>();
            List<Road> roadTg = new List<Road>();
            
            int i;
            // roadTg=road
            for (i=0; i<road.Count; i++)
            {
                roadTg.Add(road[i]);
            }

            // tg = end
            for (i=0; i<end.Count; i++)
            {
                tg.Add(end[i]);
            }

            int kt = 1;
            int dem = 0;
            while (kt==1)
            {
                for (i = 0; i < roadTg.Count; i++)
                {
                    if (FindElementStringInList(tg, roadTg[i].End) == 1)
                    {
                        tg.Add(roadTg[i].Start);
                        roadTg.RemoveAt(i);
                        i--;
                        dem++;
                    }
                    if ( roadTg.Count == 0 || i == -1 || (i == roadTg.Count - 1 && dem == 0) )
                    {
                        kt = 0;
                        break;
                    }
                }
                dem = 0;
            }

            // Sắp xếp để xóa những kí tự liền nhau giống nhau
            tg.Sort();
            // Xóa các kí tự giống nhau trong tập kí tự hữu sinh
            for (i=0; i<tg.Count-1; i++)
                if (tg[i]==tg[i+1])
                {
                    tg.RemoveAt(i);
                    i--;
                }
            //gán textBoxStep2Min.Text = chuỗi kí tự thỏa mãn.
            string s = "";
            for (i = 0; i < tg.Count - 1; i++) s = s + tg[i] + "; ";
            s = s + tg[tg.Count - 1];
            s = "{" + s + "}";
            textBoxStep2Infertility.Text = s;


            //Xóa các suy dẫn vô ích trong list road (những suy dẫn chứa kí tự vô sinh)
            List<string> a = new List<string>();
            for (i = 0; i < road.Count; i++)
            {
                a.Add(road[i].Start + road[i].End);
            }
            for (i=0; i<road.Count; i++)
                if (FindElementStringInList(tg, a[i])==0)
                {
                    road.RemoveAt(i);
                    a.RemoveAt(i);
                    i--;
                }

            // Đưa dữ liệu vào textBoxStep3Min.TExt
            string sNew = "";
            for (i = 0; i < road.Count; i++) sNew = sNew + road[i].Start + "->" + road[i].End + System.Environment.NewLine;
            textBoxStep3Infertility.Text = sNew;

        }
        #endregion

        #region Delete Epxilon

        List<Road> notEpxilon = new List<Road>();
        string startNotEpxilon = "";
        string endNotEpxilon = "";

        //Xóa bỏ sản xuất epxilon
        public void DeleteEpxilon()
        {
            // Tìm những kí tự chưa kết thúc suy dẫn ra epxilon
            List<string> notEndToEpxilon = new List<string>();
            int i, j;
            for (i = 0; i < road.Count; i++)
                if (road[i].End == "$") notEndToEpxilon.Add(road[i].Start);

            //gán textBoxStep1Epxilon.Text = chuỗi kí tự thỏa mãn.
            string s1 = "";
            for (i = 0; i < notEndToEpxilon.Count - 1; i++) s1 = s1 + notEndToEpxilon[i] + "; ";
            s1 = s1 + notEndToEpxilon[notEndToEpxilon.Count - 1];
            s1 = "{" + s1 + "}";
            textBoxStep1Epxilon.Text = s1;


            // Tìm W
            List<Road> roadTg = new List<Road>();
            // roadTg=road
            for (i = 0; i < road.Count; i++)
            {
                roadTg.Add(road[i]);
            }

            int kt = 1;
            int dem = 0;
            while (kt == 1)
            {
                for (i = 0; i < roadTg.Count; i++)
                {
                    if (FindElementStringInList(notEndToEpxilon, roadTg[i].End) == 1)
                    {
                        notEndToEpxilon.Add(roadTg[i].Start);
                        roadTg.RemoveAt(i);
                        i--;
                        dem++;
                    }
                    if (roadTg.Count == 0 || i == -1 || (i == roadTg.Count - 1 && dem == 0))
                    {
                        kt = 0;
                        break;
                    }
                }
                dem = 0;
            }

            // Sắp xếp để xóa những kí tự liền nhau giống nhau
            notEndToEpxilon.Sort();
            // Xóa các kí tự giống nhau trong tập kí tự 
            for (i = 0; i < notEndToEpxilon.Count - 1; i++)
                if (notEndToEpxilon[i] == notEndToEpxilon[i + 1])
                {
                    notEndToEpxilon.RemoveAt(i);
                    i--;
                }
            s1 = "";
            for (i = 0; i < notEndToEpxilon.Count - 1; i++) s1 = s1 + notEndToEpxilon[i] + "; ";
            s1 = s1 + notEndToEpxilon[notEndToEpxilon.Count - 1];
            s1 = "{" + s1 + "}";
            textBoxStep2Epxilon.Text = s1;


            // Tìm văn phạm tương ứng không chứa epxilon
            List<int> check = new List<int>();
            List<int> s = new List<int>();
            Road add = new Road();
            
            for (i = 0; i < road.Count; i++)
            {
                if (FindElementStringInList(notEndToEpxilon, road[i].Start) == 1)
                {

                    check.RemoveRange(0, check.Count);
                    s.RemoveRange(0, s.Count);
                    for (j = 0; j < road[i].End.Length; j++) s.Add(0);
                    for (j = 0; j < road[i].End.Length; j++)
                    {
                        if (FindElementStringInList(notEndToEpxilon, road[i].End[j].ToString()) == 1) check.Add(1);
                        else
                        {
                            check.Add(2);
                            s[j] = 2;
                        }
                    }
                    startNotEpxilon = road[i].Start;
                    endNotEpxilon = road[i].End;
                    Try(0, s, check);
                }
            }

            // Xóa các kí tự epxilon trong các suy dẫn tìm được
            for (i=0; i<notEpxilon.Count; i++)
            {
                for (j=0; j<notEpxilon[i].End.Length; j++)
                {
                    if (notEpxilon[i].End[j]=='$')
                    {
                        notEpxilon[i].End = notEpxilon[i].End.Remove(j, 1);
                        j--;
                    }
                }
            }

            // Xóa các suy dẫn trùng nhau
            for (i=0; i<notEpxilon.Count-1; i++)
            {
                for (j=i+1; j<notEpxilon.Count; j++)
                {
                    if (notEpxilon[i].Start == notEpxilon[j].Start && notEpxilon[i].End == notEpxilon[j].End)
                    {
                        notEpxilon.RemoveAt(j);
                        j--;
                    }
                }              
            }

            //  Xóa các suy dẫn rỗng
            for (i=0; i<notEpxilon.Count; i++)
            {
                if (notEpxilon[i].End=="")
                {
                    notEpxilon.RemoveAt(i);
                    i--;
                }
            }
            string sNew = "";
            for (i = 0; i < notEpxilon.Count; i++) sNew = sNew + notEpxilon[i].Start + "->" + notEpxilon[i].End + System.Environment.NewLine;
            textBoxStep3Epxilon.Text = sNew;


        }

        // Phương thức tìm notEpxion.End
        public void addToNotEpxilon(List<int>s)
        {
            int i;
            string start=startNotEpxilon;
            string end = endNotEpxilon;
            for (i=0; i<s.Count; i++)
            {
                if (s[i]==0)
                {
                    end=end.Remove(i, 1);
                    end=end.Insert(i, "$");

                }
            }
            Road tg = new Road();
            tg.Start = start;
            tg.End = end;
            notEpxilon.Add(tg);

        }

        // Thủ tục đệ quy tìm tổ hợp
        public void Try(int i, List<int> s, List<int> check)
        {
            string start = startNotEpxilon;
            string end = endNotEpxilon;
            int j;
            for (j=0; j<=1; j++)
            {
                if (check[i]==1)
                {
                    s[i] = j;
                    if (i == s.Count - 1) 
                    {

                        /*for (int k = 0; k < s.Count; k++)
                            if (s[k] == 0)
                            {
                                end=end.Remove(k, 1);
                                end=end.Insert(k, "$");
                            }
                        Road tg = new Road();
                        tg.Start = start;
                        tg.End = end;
                        notEpxilon.Add(tg);*/
                        addToNotEpxilon(s);
                    }
                    else
                    {
                        check[i] = 0;
                        Try(i + 1, s, check);
                        check[i] = 1;
                    }
                }
                if (check[i]==2)
                {
                    if (i == s.Count - 1)
                    {
                        /*for (int k = 0; k < s.Count; k++)
                            if (s[k] == 0)
                            {
                                end = end.Remove(k, 1);
                                end =end.Insert(k, "$");

                            }
                        Road tg = new Road();
                        tg.Start = start;
                        tg.End = end;
                        notEpxilon.Add(tg);
                        */
                        addToNotEpxilon(s);

                    }
                    else Try(i + 1, s, check);
                }

            }
        }

        #endregion

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
            for (i = 0; i < chomsky.Count; i++) sNew = sNew + chomsky[i].Start+"->"+chomsky[i].End+ System.Environment.NewLine;
            textBoxStep1ChomskyNew.Text = sNew;
            string sOld = "";
            for (i = 0; i < newRoad.Count; i++) sOld = sOld + newRoad[i].Start + "->" + newRoad[i].End+ System.Environment.NewLine;
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
                while (newRoad[i].End.Length>2)
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

        private void Chomsky_Click(object sender, EventArgs e)
        {
            if (textBoxStandardized.Text == "")
            {
                MessageBox.Show("Input is null");
                s = "";
            }
            ProgressSplit();
            //FindList_End_NotEnd();
            //DeleteInfertility();
            ConvertToChomsky();
        }
        #endregion

        private void StartFrom_Load(object sender, EventArgs e)
        {

        }

        #region Guide
        private void guideChomsky_Click(object sender, EventArgs e)
        {
            GuideChomsky guideChomsky = new GuideChomsky();
            guideChomsky.Show();
        }

        private void guideInfertility_Click(object sender, EventArgs e)
        {
            GuideInfertility guideInfertility = new GuideInfertility();
            guideInfertility.Show();
        }

        private void guideEpxilon_Click(object sender, EventArgs e)
        {
            GuideEpxilon guideEpxilon = new GuideEpxilon();
            guideEpxilon.Show();
        }
        #endregion
    }
}
