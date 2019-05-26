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

            for (i = 0; i < road.Count; i++)
                MessageBox.Show(road[i].Start + "->" + road[i].End + "  i=" + i);

        }

        private void buttonMin_Click(object sender, EventArgs e)
        {
            ProgressSplit();


        }
        public void checkIn(Road r)
        {
            r.SetValid(true);

            for (int j = 0; j < road.Count; j++)
            {
                if (r.End.Contains(road[j].Start) && road[j].isVaLid() == false)
                {

                    checkIn(road[j]);
                }
            }
        }

        public List<Road> RemoveUnitProduct(List<Road> lst)
        {
            List<Road> List = lst;
            List<Road> List2 = new List<Road>();
            List<string> LayKiTuKhongKetThuc = new List<string>();
            for(int i = 0; i < List.Count - 1; i++)
            {
                for(int j = i + 1; j < List.Count; j++)
                {
                    if(List[i].End.CompareTo(List[j].Start) == 0)
                    {
                        Road r = new Road();
                        r.Start = List[i].Start;
                        r.End = List[j].End;
                        List2.Add(r);
                    }
                }
            }

            return List2;
            
        }


        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < road.Count; i++)
                road[i].SetValid(false);

            for (int i = 0; i < road.Count; i++)
            {
                if (road[i].Start.Contains("S") && road[i].isVaLid() == false)
                {
                    checkIn(road[i]);
                }
            }

            // Xóa đi các phần tử false trong list:

            List<Road> lst = road.OrderByDescending(n => n.isVaLid().ToString()).ToList();
            int totalRoad = lst.Count;
            int falseRoad = lst.Where(n => n.isVaLid() == false).Count();
            int nDelete = totalRoad - falseRoad;
            lst.RemoveRange(nDelete, falseRoad);

            // hiển thị list mới lên textbox
            for (int i = 0; i < lst.Count; i++)
            {
                txtResult.Text += lst[i].Start + "->" + lst[i].End + "\r\n";
            }
            FindList_End_NotEnd();
            //DeleteInfertility();

        }
        //Tìm tập hợp các kí tự kết thúc và không kết thúc
        public void FindList_End_NotEnd()
        {
            int i, j;

            //Lấy ra các kí tự kết thúc
            for (i = 0; i < road.Count; i++)
            {
                for (j = 0; j < road[i].End.Length; j++)
                    if (((int)road[i].End[j] >= 97 && (int)road[i].End[j] <= 122) || ((int)road[i].End[j] >= 48 && (int)road[i].End[j] <= 58))
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



            // lấy ra các kí tự kết thúc
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
            for (i = 0; i < road.Count; i++)
            {
                roadTg.Add(road[i]);
            }

            // tg = end
            for (i = 0; i < end.Count; i++)
            {
                tg.Add(end[i]);
            }

            int kt = 1;
            int dem = 0;
            while (kt == 1)
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
                    if (roadTg.Count == 0 || i == -1 || (i == roadTg.Count - 1 && dem == 0))
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
            for (i = 0; i < tg.Count - 1; i++)
                if (tg[i] == tg[i + 1])
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
            for (i = 0; i < road.Count; i++)
                if (FindElementStringInList(tg, a[i]) == 0)
                {
                    road.RemoveAt(i);
                    a.RemoveAt(i);
                    i--;
                }
            for (i = 0; i < road.Count; i++) MessageBox.Show(road[i].Start + "->" + road[i].End);

        }

        //
        public List<Road> CNF(List<Road> List)
        {

            List<Road> lst = null;
            return lst;
        }



        //  chuẩn hóa GNF---------------------------------------
        
        public List<string> getNotEnd()
        {
            List<string> newV = new List<string>();
            for (int i = notEnd.Count - 1; i >= 0; i--)
            {
                newV.Add(notEnd[i]);
            }

            return newV;
        }  

        public List<string> getEndbyStart(string _start, List<Road> l)
        {
            List<Road> List = l;
            List<string> EndList = new List<string>();
            foreach(var item in List)
            {
                if(item.Start.CompareTo(_start) == 0)
                {
                    EndList.Add(item.End);
                }
            }
            return EndList;
        }
        public List<Road> LoaiBoLuatSinhTrungNhau(List<Road> lst)
        {
            List<Road> List2 = lst;
            for (int i = 0; i < List2.Count - 1; i++)
            {
                for(int j=i+1;j<List2.Count;j++)
                if (List2[i].Start.CompareTo(List2[j].Start) == 0 && List2[i].End.CompareTo(List2[j].End) == 0)
                {
                    List2.Remove(List2[i]);
                    i--;
                }
            }
            
            return List2;
        }
        public List<Road> LoaiBoDeQuiTrai(List<Road> List)
        {
            List<Road> List2 = new List<Road>();
            List<string> LayRaTapDanXuat = new List<string>();
            List<string> Beta = new List<string>();
            List<string> Alpha = new List<string>();
            foreach(var item in List)
            {
                if (item.Start[0] == item.End[0])
                {
                    LayRaTapDanXuat = getEndbyStart(item.Start,List);
                    foreach(var item2 in LayRaTapDanXuat)
                    {
                        if(item2[0] == item.Start[0])
                        {
                            Alpha.Add(item2.Remove(0,1));
                        }
                        else if (item2[0] >= 97 && item2[0] <= 122)
                        {
                            Beta.Add(item2);
                        }
                    }
                    foreach(var item2 in Beta)
                    {
                        Road r = new Road();
                        r.Start = item.Start;
                        r.End = item2;

                        List2.Add(r);
                    }
                    foreach(var item2 in Beta){
                        Road r = new Road();
                        r.Start = item.Start;
                        r.End = item2 + item.Start + "'";
                        List2.Add(r);
                    }
                    foreach(var item2 in Alpha)
                    {
                        Road r = new Road();
                        r.Start = item.Start + "'";
                        r.End = item2;
                        List2.Add(r);
                    }
                    foreach(var item2 in Alpha)
                    {
                        Road r = new Road();
                        r.Start = item.Start + "'";
                        r.End = item2 + r.Start;
                        List2.Add(r);
                    }
                    break;
                }
                
            }
            foreach(var item in LayRaTapDanXuat)
            {
                if (item[0] >= 65 && item[0] <= 90)
                {
                    List.RemoveAll(n => n.End.CompareTo(item) == 0);
                }
            }
            foreach(var item in List2)
            {
                List.Add(item);
            }
            
            return List;
        }
        public List<Road> ThayTheVeDangGNF(List<Road> lst)
        {
            List<Road> List = lst;
            List<Road> List2 = new List<Road>();
            List<string> LayRaTapDanXuat = new List<string>();
            List<string> GetEndToRemove = new List<string>();
            for(int i=0;i<List.Count - 1; i++)
            {
                for(int j = i + 1; j < List.Count; j++)
                {
                    if (List[i].End[0] == List[j].Start[0] && List[j].End[0] >= 97 && List[j].End[0] <= 122)
                    {
                        LayRaTapDanXuat = getEndbyStart(List[j].Start, List);
                        GetEndToRemove.Add(List[i].End);
                        foreach (var str in LayRaTapDanXuat)
                        {
                            Road r = new Road();
                            r.Start = List[i].Start;
                            r.End = str + List[i].End.Remove(0, 1);
                            List2.Add(r);
                        }
                    } 
                }
            }
            foreach(var item in GetEndToRemove)
            {
                List.RemoveAll(n => n.End.CompareTo(item) == 0);
            }
            foreach(var item in List2)
            {
                List.Add(item);
            }
            
            for(int i = 0; i < List.Count-1; i++)
            {
                for(int j = i + 1; j < List.Count; j++)
                {
                    if (List[i].End[0] == List[j].Start[0])
                    {
                        List = ThayTheVeDangGNF(List);
                    }
                }
            }

            return List;
        }
        public List<Road> GNF()
        {   
            List<Road> List = road;
            List<Road> List2 = new List<Road>();
            List<string> ls;
            string _startReplace ;
               
            foreach(var item in List)
            {
                item.SetValid(false);
            }
            foreach (var item1 in List)
            {
                foreach (var item2 in List)
                {
                    if (item1.End[0] == item2.Start[0] && item1.Start[0] == item2.End[0])
                    {
                        _startReplace = item1.Start;
                        item1.SetValid(true);
                        ls = getEndbyStart(item2.Start,road);
                        for (int i=0;i<ls.Count;i++)
                        {
                            ls[i] += item1.End[1];
                            Road r = new Road();
                            r.Start = _startReplace;
                            r.End = ls[i];
                            List2.Add(r);  
                        }
                        break;
                    }
                }
            }
            foreach(var item in List)
            {
                if(item.isVaLid() == false)
                List2.Add(item);
            }

            List2 = LoaiBoDeQuiTrai(List2);
            List2 = LoaiBoDeQuiTrai(List2);
            List2 = List2.OrderByDescending(n=>n.Start).ToList();
            List2 = LoaiBoLuatSinhTrungNhau(List2);
            List2 = ThayTheVeDangGNF(List2);
            List2 = ThayTheVeDangGNF(List2);
            List2 = LoaiBoLuatSinhTrungNhau(List2);
           
           
            return List2;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<Road> List = GNF();
            List = List.OrderByDescending(n => n.Start).ToList();
            foreach (var i in List)
            {
                
                txtGNF.Text += i.Start + "->" + i.End + "\r\n";
            }

        }
    }

    
}
