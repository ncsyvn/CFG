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
                        (s[i]=='-') || (s[i]=='>') )
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
                if (array[i] != "" && ((int)array[i][0] < 65 || (int)array[i][0] > 90))
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

            for (i = 0; i < road.Count; i++)
                MessageBox.Show(road[i].Start + "->" + road[i].End);

        }

        private void buttonMin_Click(object sender, EventArgs e)
        {
            ProgressSplit();
        }
    }

    
}
