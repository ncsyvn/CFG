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

    public partial class SimplifyForm : Form
    {
        public string s;
        public string s1;
        public List<Road> road = new List<Road>();
        List<string> end = new List<string>();
        List<string> notEnd = new List<string>();

        public SimplifyForm(string s, List<Road> road, List<string>end, List<string> notEnd, string s1)
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
            DeleteInfertility();
            DeleteEpxilon();

        }

        public int FindElementStringInList(List<string> list, string s)
        {
            int i;
            for (i = 0; i < s.Length; i++)
            {
                if (list.Contains(s[i].ToString()) == false) return 0;
            }
            return 1;
        }

        #region Delete Infertility
        //Xóa bỏ các kí tự vô sinh
        public void DeleteInfertility()
        {
            textBoxStep1Infertility.Text = s1;
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
            for (i = 0; i < road.Count; i++)
                if (FindElementStringInList(tg, a[i]) == 0)
                {
                    road.RemoveAt(i);
                    a.RemoveAt(i);
                    i--;
                }

            s = "";
            for (i = 0; i < road.Count; i++) s = s + road[i].Start + "->" + road[i].End + System.Environment.NewLine;
            textBoxStep3Infertility.Text = s;
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

            if (notEndToEpxilon.Count == 0)
            {
                textBoxStep3Epxilon.Text = textBoxStep3Infertility.Text;
            }
            else
            {         
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
                for (i = 0; i < notEpxilon.Count; i++)
                {
                    for (j = 0; j < notEpxilon[i].End.Length; j++)
                    {
                        if (notEpxilon[i].End[j] == '$')
                        {
                            notEpxilon[i].End = notEpxilon[i].End.Remove(j, 1);
                            j--;
                        }
                    }
                }

                // Xóa các suy dẫn trùng nhau
                for (i = 0; i < notEpxilon.Count - 1; i++)
                {
                    for (j = i + 1; j < notEpxilon.Count; j++)
                    {
                        if (notEpxilon[i].Start == notEpxilon[j].Start && notEpxilon[i].End == notEpxilon[j].End)
                        {
                            notEpxilon.RemoveAt(j);
                            j--;
                        }
                    }
                }

                //  Xóa các suy dẫn rỗng
                for (i = 0; i < notEpxilon.Count; i++)
                {
                    if (notEpxilon[i].End == "")
                    {
                        notEpxilon.RemoveAt(i);
                        i--;
                    }
                }
                string sNew = "";
                for (i = 0; i < notEpxilon.Count; i++) sNew = sNew + notEpxilon[i].Start + "->" + notEpxilon[i].End + System.Environment.NewLine;
                textBoxStep3Epxilon.Text = sNew;

            }

            // Phần của Nam
            RemoveUnitProduct(road);

            if (road.Count == 0)
            {
                txtResult.Text = textBoxStep3Epxilon.Text;
            }
            else
            {
                for (int k = 0; k < road.Count; k++)
                    road[k].SetValid(false);

                for (int k = 0; k < road.Count; k++)
                {
                    if (road[k].Start.Contains("S") && road[k].isVaLid() == false)
                    {
                        checkIn(road[k]);
                    }
                }

                // Xóa đi các phần tử false trong list:

                List<Road> lst = road.OrderByDescending(n => n.isVaLid().ToString()).ToList();
                int totalRoad = lst.Count;
                int falseRoad = lst.Where(n => n.isVaLid() == false).Count();
                int nDelete = totalRoad - falseRoad;
                lst.RemoveRange(nDelete, falseRoad);

                // hiển thị list mới lên textbox
                for (int k = 0; k < lst.Count; k++)
                {
                    txtResult.Text += lst[k].Start + "->" + lst[k].End + "\r\n";
                }
            }
            

        }

        // Phương thức tìm notEpxion.End
        public void addToNotEpxilon(List<int> s)
        {
            int i;
            string start = startNotEpxilon;
            string end = endNotEpxilon;
            for (i = 0; i < s.Count; i++)
            {
                if (s[i] == 0)
                {
                    end = end.Remove(i, 1);
                    end = end.Insert(i, "$");

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
            for (j = 0; j <= 1; j++)
            {
                if (check[i] == 1)
                {
                    s[i] = j;
                    if (i == s.Count - 1)
                    {
                        addToNotEpxilon(s);
                    }
                    else
                    {
                        check[i] = 0;
                        Try(i + 1, s, check);
                        check[i] = 1;
                    }
                }
                if (check[i] == 2)
                {
                    if (i == s.Count - 1)
                    {
                        addToNotEpxilon(s);

                    }
                    else Try(i + 1, s, check);
                }

            }
        }

        #endregion

        #region CNF Nam
        public List<Road> CNF(List<Road> List)
        {

            List<Road> lst = null;
            return lst;
        }



        //  chuẩn hóa GNF

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
            foreach (var item in List)
            {
                if (item.Start.CompareTo(_start) == 0)
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
                for (int j = i + 1; j < List2.Count; j++)
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
            foreach (var item in List)
            {
                if (item.Start[0] == item.End[0])
                {
                    LayRaTapDanXuat = getEndbyStart(item.Start, List);
                    foreach (var item2 in LayRaTapDanXuat)
                    {
                        if (item2[0] == item.Start[0])
                        {
                            Alpha.Add(item2.Remove(0, 1));
                        }
                        else if (item2[0] >= 97 && item2[0] <= 122)
                        {
                            Beta.Add(item2);
                        }
                    }
                    foreach (var item2 in Beta)
                    {
                        Road r = new Road();
                        r.Start = item.Start;
                        r.End = item2;

                        List2.Add(r);
                    }
                    foreach (var item2 in Beta)
                    {
                        Road r = new Road();
                        r.Start = item.Start;
                        r.End = item2 + item.Start + "'";
                        List2.Add(r);
                    }
                    foreach (var item2 in Alpha)
                    {
                        Road r = new Road();
                        r.Start = item.Start + "'";
                        r.End = item2;
                        List2.Add(r);
                    }
                    foreach (var item2 in Alpha)
                    {
                        Road r = new Road();
                        r.Start = item.Start + "'";
                        r.End = item2 + r.Start;
                        List2.Add(r);
                    }
                    break;
                }

            }
            foreach (var item in LayRaTapDanXuat)
            {
                if (item[0] >= 65 && item[0] <= 90)
                {
                    List.RemoveAll(n => n.End.CompareTo(item) == 0);
                }
            }
            foreach (var item in List2)
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
            for (int i = 0; i < List.Count - 1; i++)
            {
                for (int j = i + 1; j < List.Count; j++)
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
            foreach (var item in GetEndToRemove)
            {
                List.RemoveAll(n => n.End.CompareTo(item) == 0);
            }
            foreach (var item in List2)
            {
                List.Add(item);
            }

            for (int i = 0; i < List.Count - 1; i++)
            {
                for (int j = i + 1; j < List.Count; j++)
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
            string _startReplace;

            foreach (var item in List)
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
                        ls = getEndbyStart(item2.Start, road);
                        for (int i = 0; i < ls.Count; i++)
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
            foreach (var item in List)
            {
                if (item.isVaLid() == false)
                    List2.Add(item);
            }

            List2 = LoaiBoDeQuiTrai(List2);
            List2 = LoaiBoDeQuiTrai(List2);
            List2 = List2.OrderByDescending(n => n.Start).ToList();
            List2 = LoaiBoLuatSinhTrungNhau(List2);
            List2 = ThayTheVeDangGNF(List2);
            List2 = LoaiBoLuatSinhTrungNhau(List2);


            return List2;
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







        // Xóa dẫn xuất đơn
        public void RemoveUnitProduct(List<Road> lst)
        {
            List<Road> List = lst;
            List<Road> List2 = new List<Road>();
            List<string> RemoveList = new List<string>();
            List<string> LayKiTuKhongKetThuc = new List<string>();


            foreach (var item in List)
            {
                LayKiTuKhongKetThuc.Add(item.Start);
            }
            for (int i = 0; i < List.Count - 1; i++)
            {
                for (int j = i + 1; j < List.Count; j++)
                {
                    if (List[i].End.CompareTo(List[j].Start) == 0  /*&& Regex.IsMatch(regex,List[j].End)*/)
                    {
                        RemoveList.Add(List[i].End);
                        Road r = new Road();
                        r.Start = List[i].Start;
                        r.End = List[j].End;
                        List2.Add(r);


                        List<string> LayDanXuatLan2 = new List<string>();
                        LayDanXuatLan2 = getEndbyStart(List[j].End, List);
                        foreach (var it in LayDanXuatLan2)
                        {
                            Road r2 = new Road();
                            r2.Start = List[i].Start;
                            r2.End = it;
                            List2.Add(r2);
                        }
                    }
                }
            }
            foreach (var item in List2)
            {
                List.Add(item);
            }
            foreach (var item in RemoveList)
            {
                List.RemoveAll(n => n.End.CompareTo(item) == 0);

            }
            string s = "";
            for (int i = 0; i < List.Count; i++) s = s + List[i].Start + "->" + List[i].End + System.Environment.NewLine;
            textRun4.Text = s;
            //return List = List.OrderBy(n => n.Start).ToList();
        }






        /*

        private void Run3_Click(object sender, EventArgs e)
        {
            ProgressSplit();
            FindList_End_NotEnd();
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
        }

        private void Greibach_Click(object sender, EventArgs e)
        {
            ProgressSplit();
            FindList_End_NotEnd();
            List<Road> List = GNF();
            List = List.OrderByDescending(n => n.Start).ToList();
            foreach (var i in List)
            {

                txtGNF.Text += i.Start + "->" + i.End + "\r\n";
            }
        }


        private void Run4_Click(object sender, EventArgs e)
        {
            ProgressSplit();
            FindList_End_NotEnd();
            RemoveUnitProduct(road);
        }
        */
        #endregion

        private void buttonConvertToChomsky_Click(object sender, EventArgs e)
        {
            ChomskyForm chomskyForm = new ChomskyForm(s, road, end, notEnd, s1);
            chomskyForm.Show();
        }

        private void buttonConvertToGreibach_Click(object sender, EventArgs e)
        {
            string s = "";
            List<Road> List = GNF();
            List = List.OrderByDescending(n => n.Start).ToList();
            foreach (var i in List)
            {
                s += i.Start + "->" + i.End + "\r\n";
            }
            GreibachForm greibachForm = new GreibachForm(s);
            greibachForm.Show();
        }
    }
}
