﻿namespace LH.ManageProduct.Business.Notification
{
    public class AppNotification
    {
        public AppNotification(string message)
        {
            Message = message;
        }

        public string? Message { get; }
    }
}
