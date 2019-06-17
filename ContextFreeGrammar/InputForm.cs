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
    public partial class InputForm : Form
    {
        public string s;
        public string s1;
        public List<Road> road = new List<Road>();
        List<string> end = new List<string>();
        List<string> notEnd = new List<string>();
        public InputForm()
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
                    s = s.Remove(i, 1);
                    i--;
                }

            // bổ sung thêm > nếu chỉ có -
            for (i = 0; i < s.Length; i++)
                if (s[i] == '-' && i != s.Length - 1 && s[i + 1] != '>')
                {
                    str = s.Substring(i + 1);
                    s = s.Remove(i + 1);
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
            if (openFileDialog.ShowDialog() == DialogResult.OK)
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
            for (i = 0; i < s.Length; i++)
            {
                if (((int)s[i] >= 65 && (int)s[i] <= 90) || ((int)s[i] >= 97 && (int)s[i] <= 122) || ((int)s[i] >= 48 && (int)s[i] <= 58) ||
                        (s[i] == '-') || (s[i] == '>') || (s[i] == '$'))
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

            for (i = 0; i < count; i++)
            {
                if (array[i] != "" && (array[i].IndexOf('-') < 0))
                {
                    for (j = i; j >= 0; j--)
                    {
                        if (array[j].IndexOf('-') > 0)
                        {
                            array[i] = array[j].Substring(0, array[j].IndexOf('-')) + "->" + array[i];
                            break;
                        }
                    }
                }
            }
            for (i = 0; i < count; i++)
            {
                if (array[i] != "")
                {
                    Road roadTg = new Road();
                    roadTg.Start = array[i].Substring(0, array[i].IndexOf('-'));

                    roadTg.End = array[i].Substring(array[i].IndexOf("-") + 2);
                    road.Add(roadTg);
                }
            }

        }

        #region Analytic Data
        //Tìm tập hợp các kí tự kết thúc và không kết thúc
        public void FindList_End_NotEnd()
        {
            int i, j;

            //Lấy ra các kí tự kết thúc
            for (i = 0; i < road.Count; i++)
            {
                for (j = 0; j < road[i].End.Length; j++)
                    if (((int)road[i].End[j] >= 97 && (int)road[i].End[j] <= 122) ||
                         ((int)road[i].End[j] >= 48 && (int)road[i].End[j] <= 58) || road[i].End[j] == '$')
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
            for (i = 0; i < end.Count - 1; i++) s = s + end[i] + "; ";
            s = s + end[end.Count - 1];
            s = "{" + s + "}";
            s1 = s;
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

        #endregion

        private void buttonSimplify_Click(object sender, EventArgs e)
        {
            ProgressSplit();
            FindList_End_NotEnd();
            SimplifyForm simplifyForm = new SimplifyForm(s, road, end, notEnd, s1);
            simplifyForm.Show();
        }
    }
}
