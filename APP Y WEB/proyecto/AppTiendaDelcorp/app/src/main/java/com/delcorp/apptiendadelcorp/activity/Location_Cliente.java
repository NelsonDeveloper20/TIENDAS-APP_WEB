package com.delcorp.apptiendadelcorp.activity;

import android.Manifest;
import android.content.pm.PackageManager;
import android.location.Location;
import android.os.Build;
import android.support.annotation.NonNull;
import android.support.annotation.Nullable;
import android.support.v4.app.ActivityCompat;
import android.support.v4.content.ContextCompat;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.util.Log;

import com.delcorp.apptiendadelcorp.R;
import com.google.android.gms.common.ConnectionResult;
import com.google.android.gms.common.api.GoogleApiClient;
import com.google.android.gms.location.FusedLocationProviderClient;
import com.google.android.gms.location.LocationListener;
import com.google.android.gms.location.LocationRequest;
import com.google.android.gms.location.LocationServices;
import com.google.android.gms.maps.CameraUpdate;
import com.google.android.gms.maps.CameraUpdateFactory;
import com.google.android.gms.maps.GoogleMap;
import com.google.android.gms.maps.OnMapReadyCallback;
import com.google.android.gms.maps.SupportMapFragment;
import com.google.android.gms.maps.model.BitmapDescriptor;
import com.google.android.gms.maps.model.BitmapDescriptorFactory;
import com.google.android.gms.maps.model.LatLng;
import com.google.android.gms.maps.model.Marker;
import com.google.android.gms.maps.model.MarkerOptions;
import com.google.android.gms.tasks.OnSuccessListener;
import com.google.android.gms.tasks.Task;
import com.google.maps.android.ui.IconGenerator;

import java.text.DateFormat;
import java.util.Date;

public class Location_Cliente extends AppCompatActivity implements GoogleMap.OnInfoWindowClickListener,GoogleMap.OnMarkerDragListener,OnMapReadyCallback, GoogleApiClient.ConnectionCallbacks,
        GoogleApiClient.OnConnectionFailedListener, LocationListener,GoogleMap.OnMarkerClickListener  {

    SupportMapFragment supportMapFragment;
    FusedLocationProviderClient client;
    private Location mCurrentLocation;
    private String mLastUpdateTime;
    private GoogleMap mMap;


    private Marker marcadornelson,markerDraw,infowindow;
    private GoogleApiClient mGoogleApiClient;
    private LocationRequest mLocationRequest;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_location__cliente);

        supportMapFragment=(SupportMapFragment) getSupportFragmentManager()
                .findFragmentById(R.id.map4);

        client= LocationServices.getFusedLocationProviderClient(this);

        if(ActivityCompat.checkSelfPermission(Location_Cliente.this,
                Manifest.permission.ACCESS_FINE_LOCATION)== PackageManager.PERMISSION_GRANTED){

            getCurrentLocation();

        }else{
            //pedir persisos
            ActivityCompat.requestPermissions(Location_Cliente.this,
                    new String[]{Manifest.permission.ACCESS_FINE_LOCATION},44);
        }

        // Obteniendo el SupportMapFragment y se notificará cuando el mapa esté listo para ser utilizado.
        SupportMapFragment mapFragment = (SupportMapFragment) getSupportFragmentManager().findFragmentById(R.id.map4);
        mapFragment.getMapAsync(this);

    }




    private void getCurrentLocation() {
        Task<Location> task=client.getLastLocation();
        task.addOnSuccessListener(new OnSuccessListener<Location>() {
            @Override
            public void onSuccess(final Location location) {
                if(location !=null){
                    supportMapFragment.getMapAsync(new OnMapReadyCallback() {
                        @Override
                        public void onMapReady(GoogleMap googleMap) {
                            LatLng latLng=new LatLng(location.getLatitude(),
                                    location.getLongitude());
                            MarkerOptions options=new MarkerOptions().position(latLng)
                                    .title("Mi UBICACION").icon(BitmapDescriptorFactory.fromResource(R.drawable.ubicacion_vendedor));
                        //zoom map
                            googleMap.animateCamera(CameraUpdateFactory.newLatLngZoom(latLng,13));
                            //add marker on map
                            googleMap.addMarker(options);
                        }
                    });
                }
            }
        });
    }
    protected synchronized void buildGoogleApiClient() {
        mGoogleApiClient = new GoogleApiClient.Builder(this)
                .addConnectionCallbacks(this)
                .addOnConnectionFailedListener(this)
                .addApi(LocationServices.API)
                .build();
        mGoogleApiClient.connect();
    }

    @Override
    public void onRequestPermissionsResult(int requestCode, @NonNull String[] permissions, @NonNull int[] grantResults) {
        super.onRequestPermissionsResult(requestCode, permissions, grantResults);
    if(requestCode==44){
if(grantResults.length>0 && grantResults[0]==PackageManager.PERMISSION_GRANTED){
    //when perimison
    //call
    getCurrentLocation();
}
    }
    }

    @Override
    public void onConnected(@Nullable Bundle bundle) {

    }

    @Override
    public void onConnectionSuspended(int i) {

    }

    @Override
    public void onConnectionFailed(@NonNull ConnectionResult connectionResult) {

    }

    @Override
    public void onLocationChanged(Location location) {
        mCurrentLocation = location;
        mLastUpdateTime = DateFormat.getTimeInstance().format(new Date());
        Double Latitud=12.1137842;
        Double Longitud=12.1137842;
        LatLng latLng = new LatLng(mCurrentLocation.getLatitude(),  mCurrentLocation.getLongitude());
        //agregarMarcador();
    }

    @Override
    public void onInfoWindowClick(Marker marker) {

    }

    @Override
    public boolean onMarkerClick(Marker marker) {
        return false;
    }

    @Override
    public void onMarkerDragStart(Marker marker) {

    }

    @Override
    public void onMarkerDrag(Marker marker) {

    }

    @Override
    public void onMarkerDragEnd(Marker marker) {

    }

    @Override
    public void onMapReady(GoogleMap googleMap) {
        mMap = googleMap;

        //Iniciando Google Play Services
        if (android.os.Build.VERSION.SDK_INT >= Build.VERSION_CODES.M) {
            if (ContextCompat.checkSelfPermission(this, android.Manifest.permission.ACCESS_FINE_LOCATION) == PackageManager.PERMISSION_GRANTED) {
                buildGoogleApiClient();
                mMap.setMyLocationEnabled(true);
                mMap.getUiSettings().setZoomControlsEnabled(true);
            }
        } else {
            buildGoogleApiClient();
            mMap.setMyLocationEnabled(true);
            mMap.getUiSettings().setZoomControlsEnabled(true);


        }

        LatLng markerPerson = new LatLng(-12.053971, -77.040832);
     /*   marcadornelson=googleMap.addMarker(new MarkerOptions().position(markerPerson)
                .title("CLIENTE A NSM DDS")
                .snippet("CASA ROJA ASNANSAASK").icon(BitmapDescriptorFactory.fromResource(R.drawable.marker_client)));
*/
        Marker marker = googleMap.addMarker(new MarkerOptions()
                .position(markerPerson)
                .title("CLIENTE (A) )")
                .snippet("CASITA ROJA ").icon(BitmapDescriptorFactory.fromResource(R.drawable.marker_client)));

        marker.showInfoWindow();

        //clcik en markador
        googleMap.setOnMarkerClickListener(this);
        //end

        //infowindows dialog
        googleMap.setOnInfoWindowClickListener(this);
        //end
    }
}
