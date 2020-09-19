package com.delcorp.apptiendadelcorp.service;

import android.annotation.SuppressLint;
import android.app.NotificationChannel;
import android.app.NotificationManager;
import android.app.PendingIntent;
import android.content.Context;
import android.content.Intent;
import android.content.SharedPreferences;
import android.graphics.Color;
import android.media.AudioAttributes;
import android.media.RingtoneManager;
import android.provider.Settings;
import android.support.v4.app.NotificationCompat;
import android.util.Log;
import android.widget.Toast;

import com.delcorp.apptiendadelcorp.R;
import com.delcorp.apptiendadelcorp.activity.FullPromoActivity;
import com.delcorp.apptiendadelcorp.activity.LoginActivity;
import com.delcorp.apptiendadelcorp.activity.ReporteSugeridoMenorActivity;
import com.delcorp.apptiendadelcorp.activity.SplashActivity;
import com.google.firebase.messaging.FirebaseMessagingService;
import com.google.firebase.messaging.RemoteMessage;

import java.util.Map;
import java.util.Random;


/**
 * Created by NgocTri on 8/9/2016.
 */
public class MyFirebaseMessagingService extends FirebaseMessagingService {
    private static final String TAG = "MyFirebaseMsgCliente";
    SharedPreferences pref ;
    boolean iniciado;
    private NotificationManager mNotificationManager;
    private NotificationCompat.Builder mBuilder;

    public static final String NOTIFICATION_CHANNEL_ID = "10001";


    @Override
    public void onNewToken(String s) {
        super.onNewToken(s);

        Log.d("NEW_TOKENCliente",s);
        pref =   getSharedPreferences(getResources().getString(R.string.shared), Context.MODE_PRIVATE) ;
        SharedPreferences.Editor edit = pref.edit();
        edit.putString("token",s);
        edit.commit();

    }

    @Override
    public void onMessageReceived(RemoteMessage remoteMessage) {

        Log.d(TAG, "LLEGO MENSAJE:" + remoteMessage.getFrom());
        Map<String, String> data = remoteMessage.getData();

        String id = data.get("id");
        String titulo = data.get("titulo");
        String mensaje = data.get("msj");
        String rutafoto = data.get("rutafoto");

        if(remoteMessage.getData().size() > 0) {
           // Log.d(TAG, "Message data: " + remoteMessage.getData());
            sendNotification(id,titulo,mensaje,rutafoto   );
        }


        if(remoteMessage.getNotification() != null) {
            Log.d(TAG, "LLEGO MENSAJE:LLEGO MENSAJEEEEEE");
            sendNotification(id,titulo,mensaje ,rutafoto);
        }


    }

    /**
     * Dispay the notification
     * @param id
     */
    private void sendNotification(String id ,String titulo,String mensaje,String rutafoto  ) {

            crearNotification( id,titulo, mensaje ,rutafoto);
    }


    public void crearNotification(String id ,String title, String message,String rutafoto ) {
        pref =   getSharedPreferences(getResources().getString(R.string.shared), Context.MODE_PRIVATE) ;

        if (id.equals("10")) {
            SharedPreferences.Editor editor = pref.edit();
            editor.putString("sesion", "");
            editor.commit();

            Intent i = new Intent(getBaseContext(), LoginActivity.class);
            i.setFlags(Intent.FLAG_ACTIVITY_NEW_TASK|Intent.FLAG_ACTIVITY_CLEAR_TOP|Intent.FLAG_ACTIVITY_CLEAR_TASK);
            startActivity(i);


        }else if (id.equals("2") && !pref.getString("sesion","").equals("") && pref.getString("idTipoUsuario","0").equals("1")) {

            SharedPreferences.Editor edit = pref.edit();
            edit.putString("pedidoComp",rutafoto);
            edit.commit();

            Intent i  = new Intent(getBaseContext(), ReporteSugeridoMenorActivity.class);

            PendingIntent resultPendingIntent = PendingIntent.getActivity(getBaseContext(),
                    0 /* Request code */, i,
                    PendingIntent.FLAG_UPDATE_CURRENT);

            mBuilder = new NotificationCompat.Builder(getBaseContext());
            mBuilder.setSmallIcon(R.mipmap.ic_xmarket);
            mBuilder.setContentTitle(title)
                    .setContentText(message)
                    .setAutoCancel(true)
                    //.setSubText(message)
                    .setPriority(NotificationManager.IMPORTANCE_HIGH)
                    .setStyle(new NotificationCompat.BigTextStyle().bigText(message))

                    .setSound(Settings.System.DEFAULT_NOTIFICATION_URI)
                    .setContentIntent(resultPendingIntent);

            mNotificationManager = (NotificationManager) getBaseContext().getSystemService(Context.NOTIFICATION_SERVICE);

            if (android.os.Build.VERSION.SDK_INT >= android.os.Build.VERSION_CODES.O) {
                AudioAttributes audioAttributes = new AudioAttributes.Builder()
                        .setContentType(AudioAttributes.CONTENT_TYPE_SONIFICATION)
                        .setUsage(AudioAttributes.USAGE_NOTIFICATION_RINGTONE).build();

                int importance = NotificationManager.IMPORTANCE_HIGH; //NotificationManager.IMPORTANCE_HIGH;
                @SuppressLint("WrongConstant") NotificationChannel notificationChannel = new NotificationChannel(NOTIFICATION_CHANNEL_ID, "NOTIFICATION_CHANNEL_NAME", importance);
                notificationChannel.enableLights(true);
                notificationChannel.setLightColor(Color.RED);
                notificationChannel.setSound(RingtoneManager.getDefaultUri(RingtoneManager.TYPE_NOTIFICATION), audioAttributes);
                notificationChannel.enableVibration(true);
                notificationChannel.setVibrationPattern(new long[]{100, 200, 300, 400, 500, 400, 300, 200, 400});

                assert mNotificationManager != null;
                mBuilder.setChannelId(NOTIFICATION_CHANNEL_ID);
                mNotificationManager.createNotificationChannel(notificationChannel);
            }
            assert mNotificationManager != null;

            int min = 20;
            int max = 80;
            int random = new Random().nextInt((max - min) + 1) + min;
            mNotificationManager.notify(random /* Request Code */, mBuilder.build());

        } else if (id.equals("1") && !pref.getString("sesion","").equals("")) {


            Intent i;
            if (rutafoto.equals("")) {
                i = new Intent(getBaseContext(), SplashActivity.class);
            } else {
                i = new Intent(getBaseContext(), FullPromoActivity.class);
                i.putExtra("rutafoto", rutafoto);
            }

            PendingIntent resultPendingIntent = PendingIntent.getActivity(getBaseContext(),
                    0 /* Request code */, i,
                    PendingIntent.FLAG_UPDATE_CURRENT);

            mBuilder = new NotificationCompat.Builder(getBaseContext());
            mBuilder.setSmallIcon(R.mipmap.ic_xmarket);
            mBuilder.setContentTitle(title)
                    .setContentText(message)
                    .setAutoCancel(false)
                    .setSubText(message)
                    .setStyle(new NotificationCompat.BigTextStyle().bigText(message))
                    /*.setStyle(new NotificationCompat.BigPictureStyle()
                            .setSummaryText(message)
                            .bigPicture(myLogo) )*/
                    .setSound(Settings.System.DEFAULT_NOTIFICATION_URI)
                    .setContentIntent(resultPendingIntent);

            mNotificationManager = (NotificationManager) getBaseContext().getSystemService(Context.NOTIFICATION_SERVICE);

            if (android.os.Build.VERSION.SDK_INT >= android.os.Build.VERSION_CODES.O) {
                AudioAttributes audioAttributes = new AudioAttributes.Builder()
                        .setContentType(AudioAttributes.CONTENT_TYPE_SONIFICATION)
                        .setUsage(AudioAttributes.USAGE_NOTIFICATION_RINGTONE).build();

                int importance = NotificationManager.IMPORTANCE_HIGH; //NotificationManager.IMPORTANCE_HIGH;
                @SuppressLint("WrongConstant") NotificationChannel notificationChannel = new NotificationChannel(NOTIFICATION_CHANNEL_ID, "NOTIFICATION_CHANNEL_NAME", importance);
                notificationChannel.enableLights(true);
                notificationChannel.setLightColor(Color.RED);
                notificationChannel.setSound(RingtoneManager.getDefaultUri(RingtoneManager.TYPE_NOTIFICATION), audioAttributes);
                notificationChannel.enableVibration(true);
                notificationChannel.setVibrationPattern(new long[]{100, 200, 300, 400, 500, 400, 300, 200, 400});

                assert mNotificationManager != null;
                mBuilder.setChannelId(NOTIFICATION_CHANNEL_ID);
                mNotificationManager.createNotificationChannel(notificationChannel);
            }
            assert mNotificationManager != null;

              int min = 20;
              int max = 80;
              int random = new Random().nextInt((max - min) + 1) + min;

            mNotificationManager.notify(random /* Request Code */, mBuilder.build());
        }
    }

}
