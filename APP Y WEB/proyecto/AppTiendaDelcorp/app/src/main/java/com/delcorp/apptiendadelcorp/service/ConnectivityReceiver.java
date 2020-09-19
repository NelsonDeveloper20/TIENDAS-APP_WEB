package com.delcorp.apptiendadelcorp.service;

import android.content.BroadcastReceiver;
import android.content.Context;
import android.content.Intent;
import android.widget.Toast;

import com.delcorp.apptiendadelcorp.util.AppStatus;

public class ConnectivityReceiver  extends BroadcastReceiver {
    @Override
    public void onReceive(Context context, Intent intent) {

        if (AppStatus.getInstance(context).isOnline()) {

         /*   Intent intent1=new Intent(context,DisplayAct.class);
            intent1.setFlags(Intent.FLAG_ACTIVITY_NEW_TASK);
            context.startActivity(intent1);*/

            Toast.makeText(context, "CONECTADO", Toast.LENGTH_SHORT).show();


        } else {

            Toast.makeText(context, "DESCONECTADO", Toast.LENGTH_SHORT).show();

        }
    }
}
