﻿namespace backend.Dto;

public class ApprovedMessageRequest
{
    public string Keyword { get; set; }
    public string Title { get; set; }
    public bool IsFound { get; set; }
    public int ChatId { get; set; }
    public int MessageId { get; set; }
    public string SessionString { get; set; }
    public string Content { get; set; }
}