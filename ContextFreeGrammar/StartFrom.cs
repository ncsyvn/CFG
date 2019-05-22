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
           // DeleteEpxilon();
            //DeleteInfertility();

        }
        //Tìm tập hợp các kí tự kết thúc và không kết thúc
        public void FindList_End_NotEnd()
        {
            int i, j;
            
            //Lấy ra các kí tự kết thúc
            for (i = 0; i < road.Count; i++)
            {
                for (j=0; j<road[i].End.Length; j++)
                    if ( ((int)road[i].End[j] >=97 && (int)road[i].End[j] <=122) || ((int)road[i].End[j] >= 48 && (int)road[i].End[j] <= 58) || road[i].End == "$")
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
            for (i = 0; i < road.Count; i++) MessageBox.Show(road[i].Start+"->"+road[i].End);
        }

        //Xóa bỏ sản xuất epxilon
        public void DeleteEpxilon()
        {
            List<string> notEndToEpxilon = new List<string>();
            int i,j;
            for (i = 0; i < road.Count; i++)
                if (road[i].End == "$") notEndToEpxilon.Add(road[i].Start);

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
            // Tìm văn phạm tương ứng không chứa epxilon

            List<Road> a = new List<Road>();
            List<string> check = new List<string>();
            Road add = new Road();
            string s;
            for (i=0; i<road.Count; i++)
            {
                if(FindElementStringInList(notEndToEpxilon, road[i].Start)==1)
                {
                    a.Add(road[i]);
                    add.Start = road[i].Start;

                    for (j = 0; j < road[i].End.Length; j++) 
                    {
                        if (FindElementStringInList(notEndToEpxilon, road[i].End[j].ToString()) == 1) check.Add(road[i].End[j].ToString());
                        else check.Add("");
                    }

                }
            }
           
        }



      
    }  
}
