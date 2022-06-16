﻿namespace EmailService.Configuration;

public class SmtpOptions
{
    public string? From { get; set; }
    public string? FromDisplay { get; set; }
    public string? UserName { get; set; }
    public string? Password { get; set; }
    public string? Host { get; set; }
    public int Port { get; set; }
}
