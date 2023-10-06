﻿using CapitalPlacement.Domain.Common;


namespace CapitalPlacement.Domain.Models
{
    public class VideoInterviewQuestion : BaseEntity
    {
        public Guid VideoId { get; set; } = Guid.NewGuid();
        public string  Question { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int MaxDuration { get; set; }
        public string DurationUnit { get; set; } = string.Empty;
        public int SubmissionDays { get; set; } 
    }
}
