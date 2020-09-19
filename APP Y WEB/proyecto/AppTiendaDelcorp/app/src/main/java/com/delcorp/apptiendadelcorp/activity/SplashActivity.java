package com.delcorp.apptiendadelcorp.activity;


import android.content.Context;
import android.content.Intent;
import android.content.SharedPreferences;
import android.os.Build;
import android.os.Bundle;
import android.support.v4.content.ContextCompat;
import android.support.v7.app.AppCompatActivity;
import android.widget.Toast;

import com.delcorp.apptiendadelcorp.R;
import com.squareup.picasso.Picasso;

import java.util.Calendar;
import java.util.Timer;
import java.util.TimerTask;

public class SplashActivity extends AppCompatActivity {


    private  static final long SPLASH=2000;

    SharedPreferences pref;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_splash);
        pref =   getSharedPreferences(getResources().getString(R.string.shared), Context.MODE_PRIVATE) ;
        SharedPreferences.Editor edit = pref.edit();

        Calendar calendar = Calendar.getInstance();
        int day = calendar.get(Calendar.DAY_OF_WEEK);

        Integer i = 0;

        switch (day) {
            case Calendar.MONDAY:
                i = 1 ;
                break;
            case Calendar.TUESDAY:
                i = 2 ;
                break;
            case Calendar.WEDNESDAY:
                i = 3 ;
                break;
            case Calendar.THURSDAY:
                i = 4 ;
                break;
            case Calendar.FRIDAY:
                i = 5 ;
                break;
            case Calendar.SATURDAY:
                i = 6 ;
                break;
            case Calendar.SUNDAY:
                i = 7 ;
                break;
        }



        if(!pref.getString("dia","9").equals(i+"")){
            edit.putString("pedidoComp","0");
        }


        switch (day) {
            case Calendar.MONDAY:
                // LUNES
                //Toast.makeText(getApplicationContext(),"HOY EL LUNES",Toast.LENGTH_SHORT).show();
                edit.putString("diaSemana","LUNES");
                edit.putString("dia","1");
                break;
            case Calendar.TUESDAY:
                // MARTES
                //Toast.makeText(getApplicationContext(),"HOY EL MARTES",Toast.LENGTH_SHORT).show();
                edit.putString("diaSemana","MARTES");
                edit.putString("dia","2");
                break;
            case Calendar.WEDNESDAY:
                // MIERCOLES
                //Toast.makeText(getApplicationContext(),"HOY EL MIERCOLES",Toast.LENGTH_SHORT).show();
                edit.putString("diaSemana","MIERCOLES");
                edit.putString("dia","3");
                break;
            case Calendar.THURSDAY:
                // JUEVES
                //Toast.makeText(getApplicationContext(),"HOY EL JUEVES",Toast.LENGTH_SHORT).show();
                edit.putString("diaSemana","JUEVES");
                edit.putString("dia","4");
                break;
            case Calendar.FRIDAY:
                // VIERNES
                //Toast.makeText(getApplicationContext(),"HOY EL VIERNES",Toast.LENGTH_SHORT).show();
                edit.putString("diaSemana","VIERNES");
                edit.putString("dia","5");
                break;
            case Calendar.SATURDAY:
                // SABADO
                //Toast.makeText(getApplicationContext(),"HOY EL SABADO",Toast.LENGTH_SHORT).show();
                edit.putString("diaSemana","SABADO");
                edit.putString("dia","6");
                break;
            case Calendar.SUNDAY:
                // DOMINGO
                //Toast.makeText(getApplicationContext(),"HOY EL DOMINGO",Toast.LENGTH_SHORT).show();
                edit.putString("diaSemana","DOMINGO");
                edit.putString("dia","7");
                break;
        }





        edit.commit();
        //getWindow().setFlags(WindowManager.LayoutParams.FLAG_FULLSCREEN, WindowManager.LayoutParams.FLAG_FULLSCREEN);
        if (android.os.Build.VERSION.SDK_INT >= Build.VERSION_CODES.LOLLIPOP) {
            getWindow().setNavigationBarColor(ContextCompat.getColor(this, R.color.colorAccent));

        }else{

        }
        TimerTask timerTask = new TimerTask() {
            @Override
            public void run() {


                if(pref.getString("sesion","").equals("")){
                    Intent mainIntent = new Intent(SplashActivity.this, LoginActivity.class);
                    SplashActivity.this.startActivity(mainIntent);
                    SplashActivity.this.finish();
                }else  if(pref.getString("idTipoAcceso","").equals("1") && pref.getString("idUsuarioCliente","").equals("")) {

                    Intent mainIntent = new Intent(SplashActivity.this, ListaClienteActivity.class);
                    SplashActivity.this.startActivity(mainIntent);
                    SplashActivity.this.finish();
                }else{
                    Intent mainIntent = new Intent(SplashActivity.this, MainActivity.class);
                    SplashActivity.this.startActivity(mainIntent);
                    SplashActivity.this.finish();
                }




            }
        };
        Timer time = new Timer();
        time.schedule(timerTask,SPLASH);
    }

    }

