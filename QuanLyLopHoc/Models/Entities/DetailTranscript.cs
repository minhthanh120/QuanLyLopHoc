﻿using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace QuanLyLopHoc.Models.Entities
{
    [Table("DetailTranscript")]
    public class DetailTranscript
    {
        public string UserId { get; set; }
        public string TranscriptId { get; set; }
        public decimal DiemCC { get; set; }
        public decimal DiemTX { get; set; }
        public decimal DiemCK { get; set; }
        public decimal DiemTB { get; set; }
        public virtual Transcript Transcript { get; set; }
        public virtual User Student { get; set; }
    }
}
