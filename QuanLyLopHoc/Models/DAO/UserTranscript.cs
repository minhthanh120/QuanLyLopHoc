using QuanLyLopHoc.Models.Entities;

namespace QuanLyLopHoc.Models.DAO
{
    public class UserTranscript
    {
        public int SumaryScore { get;set; }
        public int SumaryCredit { get;set; }
        public decimal AverareScore { get;set; }
        public ICollection<Subject> Subjects { get; set; }
    }
}
