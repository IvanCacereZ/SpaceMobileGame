using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
#if UNITY_ANDROID
using Unity.Notifications.Android;
using UnityEngine.Android;
#endif

[CreateAssetMenu(fileName = "Notification", menuName = "ScriptableObjects/Settings/Notifications", order = 4)]
public class NotificactionSO : ScriptableObject
{
    [Header("Canal")]
    public string Id = "Id del canal";
    public string Name = "Nombre del canal";
    public Importance channel;
    public string message = "Descripcion del canal";

    [Header("Notificacion")]
    public string _Tittle = "Titulo de la notificacion";
    public string _Text = "Descripcion de la notificacion";
    public float _Hours = 0;

    #if UNITY_ANDROID

    //Request authorization to send notifications
    public void RequestAuhtorization()
    {
        if (!Permission.HasUserAuthorizedPermission("android.permission.POST_NOTIFICATIONS"))
        {
            Permission.RequestUserPermission("android.permission.POST_NOTIFICATIONS");
        }
    }

    //Register a Notification Channel
    public void RegisterNotificationChannel()
    {
        AndroidNotificationChannel Notificationchannel = new();
        Notificationchannel.Id = Id;
        Notificationchannel.Name = name;
        Notificationchannel.Importance = channel;
        Notificationchannel.Description = message;
        AndroidNotificationCenter.RegisterNotificationChannel(Notificationchannel);
    }
    public void SendNotification()
    {
        InitialChannel();
        AndroidNotification notification = new AndroidNotification();
        notification.Title = _Tittle;
        notification.Text = _Text;
        notification.FireTime = DateTime.Now.AddHours(_Hours);
        notification.SmallIcon = "icon_0";
        notification.LargeIcon = "icon_1";

        AndroidNotificationCenter.SendNotification(notification, Id);
    }
    //Set Up Notification Template
    private void InitialChannel()
    {
        RequestAuhtorization();
        RegisterNotificationChannel();
    }
    #endif
}
