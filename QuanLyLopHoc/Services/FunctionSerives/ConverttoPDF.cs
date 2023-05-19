using System.Xml.Xsl;
using System.Xml;
using QuanLyLopHoc.Models.DAO;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using iTextSharp.text;
using QuanLyLopHoc.Models.Entities;

namespace QuanLyLopHoc.Services.FunctionSerives
{
    public class ConverttoPDF
    {
        public static string Template(Summary completeList, User user)
        {
            String htmlStyle = "<!DOCTYPE html>" +
        "<html>" +
            "<head>" +
            "<meta charset='UTF-8'>" +
            "</head>" +
        "<body>" +
                "<style type='text/css'>" +
                    "table {" +
                    "  font-family: arial, sans-serif;" +
                    "  border-collapse: collapse;" +
                    "  width: 100%;" +
                    "}" +
                    "h1 {  text-align: center;}" +
                    "" +
                    "td, th {" +
                    "  border: 1px solid #000000;" +
                    "  text-align: left;" +
                    "  padding: 8px;" +
                    "}" +
                    "" +
                    "tr:nth-child(even) {" +
                    "  background-color: #dddddd;" +
                    "}" +
                "</style>";
            htmlStyle += "<h1>Bảng điểm</h1>";
            htmlStyle += "<h2>Tên sinh viên: " + user.FirstName + " " + user.LastName + "</h2>";
            htmlStyle += "<h2>Email: " + user.Email + "</h2>";
            String tableContent = "";
            foreach (var item in completeList.Transcript)
            {
                tableContent += "  <tr>" +
            "    <td>" + item.SubjectName + "</td>" +
            "    <td>" + item.Credit + "</td>" +
            "    <td>" + item.DiemTB + "</td>" +
            "    <td>" + item.Heso4 + "</td>" +
            "    <td>" + item.XepLoai + "</td>" +
            "  </tr>";
            }

            String table = "<table>" +
            "  <tr>" +
            "    <th>Tên môn học</th>" +
            "    <th>Số tín chỉ</th>" +
            "    <th>Điểm trung bình</th>" +
            "    <th>Điểm hệ số 4</th>" +
            "    <th>Xếp loại</th>" +
            "  </tr>" +
            tableContent +
            "</table>" + "<h3>Tống tín chỉ: " + completeList.TotalCredit + "</h3>" +
            "<h3>Điểm trung bình: " + completeList.Avg + "</h3>" +
            "<h3>Điểm hệ số 4: " + completeList.Heso4 + "</h3>"
            + "</body>" +
            "</html>";

            return htmlStyle + table;
        }
        public static void Transform(string fileHtml)
        {
            StringReader sr = new StringReader(fileHtml.ToString());
            Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
            HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
            using (MemoryStream memoryStream = new MemoryStream())
            {
                PdfWriter writer = PdfWriter.GetInstance(pdfDoc, memoryStream);
                pdfDoc.Open();

                htmlparser.Parse(sr);
                pdfDoc.Close();

                byte[] bytes = memoryStream.ToArray();
                memoryStream.Close();
            }
        }
    }
}
