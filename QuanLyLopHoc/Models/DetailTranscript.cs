using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace QuanLyLopHoc.Models
{
    [Table("DetailTranscript")]
    public class DetailTranscript
    {
        [Key]
        [Column(TypeName = "CHAR(32)")]
        public string UserId;
        [Key]
        [Column(TypeName = "CHAR(32)")]
        public string TranscriptId;
        public decimal DiemCC;
        public decimal DiemTX;
        public decimal DiemCK;
    }
}
