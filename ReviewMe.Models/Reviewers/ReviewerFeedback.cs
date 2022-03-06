﻿using ReviewMe.Models.Enums;

namespace ReviewMe.Models.Reviewers
{
    public class ReviewerFeedback
    {
        public string Name { get; set; } = string.Empty;
        public string Feedback { get; set; } = string.Empty;
        public string ImageSrc { get; set; } = string.Empty;
        public AssessmentReviewerState AssessmentReviewerState { get; set; }
        public string AreasForImprovements { get; set; } = string.Empty;
    }
}
