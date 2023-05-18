using QuanLyLopHoc.Models.Entities;

namespace QuanLyLopHoc.Models.DAO
{
    public class Summary
    {
        public ICollection<MyTranscriptModel> Transcript { get; set; } 
        public decimal Avg { get; set; }
        public int TotalCredit { get; set; }
        public decimal Heso4 { get; set;}
        public Summary()
        {
            
        }
        public Summary(ICollection<MyTranscriptModel> Transcript)
        {
            this.Transcript = Transcript;
            this.TotalCredit = Transcript.Sum(i=>i.Credit);
            this.Avg = this.TotalCredit == 0 ? 0 : Math.Round(Transcript.Sum(i=>i.Credit*i.DiemTB)/this.TotalCredit, 2);
            this.Heso4 = toFour(this.Avg);
        }
        public Summary(ICollection<Subject> subjects)
        {
            ICollection<MyTranscriptModel> Transcript = new List<MyTranscriptModel>();
            foreach (var item in subjects)
            {
                Transcript.Add(new MyTranscriptModel(item));
            }
            this.Transcript = Transcript;
            this.TotalCredit = Transcript.Sum(i => i.Credit);
            this.Avg = this.TotalCredit==0?0: Math.Round(Transcript.Sum(i => i.Credit * i.DiemTB) / this.TotalCredit, 2);
            this.Heso4 = toFour(this.Avg);
        }
        decimal toFour(decimal x)
        {
            return Math.Round(x * 4 / 10, 2);
        }
    }
    public class MyTranscriptModel
    {
        public string SubjectId { get; set; }
        public string SubjectName { get; set; }
        public decimal DiemCC { get; set; }
        public decimal DiemTX { get; set; }
        public decimal DiemCK { get; set; }
        public decimal DiemTB { get; set; }
        public string XepLoai { get; set; }
        public decimal Heso4 { get; set; }
        public int Credit { get; set; }
        public MyTranscriptModel()
        {
            
        }
        public MyTranscriptModel(Subject subject)
        {
            this.Credit = subject.Credit;
            this.SubjectId = subject.Id;
            this.SubjectName = subject.SubjectName;
            this.DiemCC = subject.Transcript.Details.First().DiemCC != null? subject.Transcript.Details.First().DiemCC.Value:0;
            this.DiemTX = subject.Transcript.Details.First().DiemTX != null ? subject.Transcript.Details.First().DiemTX.Value : 0;
            this.DiemCK = subject.Transcript.Details.First().DiemCK != null ? subject.Transcript.Details.First().DiemCK.Value : 0;
            this.DiemTB = subject.Transcript.Details.First().DiemTB != null ? subject.Transcript.Details.First().DiemTB.Value : 0;
            this.XepLoai = toABC(this.DiemTB);
            this.Heso4 = toFour(this.DiemTB);
        }
        decimal toFour(decimal x)
        {
            return Math.Round(x * 4 / 10, 2);
        }
        string toABC(decimal x)
        {
            if (x < 4M)
            {
                return "F";
            }
            else if (x < 5M)
            {
                return "D";
            }
            else if (x < 5.5M)
            {
                return "D+";
            }
            else if (x < 6.5M)
            {
                return "C";
            }
            else if (x < 7)
            {
                return "C+";
            }
            else if (x < 8)
            {
                return "B";
            }
            else if (x < 8.5M)
            {
                return "B+";
            }
            else if (x < 9)
            {
                return "A";
            }
            else if (x < 10)
            {
                return "A+";
            }
            return "";
        }
    }
}
