package com.example.appthoitrang;

import androidx.appcompat.app.ActionBar;
import androidx.appcompat.app.AppCompatActivity;
import androidx.appcompat.widget.Toolbar;
import androidx.recyclerview.widget.LinearLayoutManager;
import androidx.recyclerview.widget.RecyclerView;

import android.os.Bundle;
import android.util.Log;

import com.android.volley.RequestQueue;
import com.android.volley.Response;
import com.android.volley.VolleyError;
import com.android.volley.toolbox.StringRequest;
import com.android.volley.toolbox.Volley;
import com.example.appthoitrang.Models.CustomerMangment;
import com.example.appthoitrang.R;
import com.squareup.picasso.Downloader;

import java.util.HashMap;

public class OrderActivity extends AppCompatActivity {
private RecyclerView recyclerView ;
CustomerMangment customerMangment;
private final Response.Listener<String> listener = new Response.Listener<String>() {
    @Override
    public void onResponse(String response) {
        try {
            Log.e("Bkap", "JSON: "+response);
        }catch (Exception e){}
    }
};
    private Response.ErrorListener errorListener= new Response.ErrorListener() {
        @Override
        public void onErrorResponse(VolleyError error) {
            Log.e("BKAP","ERROR: " + error.getMessage());
        }
    };
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_order);
        Toolbar toolbar = findViewById(R.id.itemToolBarCategory);
        toolbar.setTitle("History orders");
        setSupportActionBar(toolbar);
        ActionBar ab = getSupportActionBar();
        ab.setDisplayHomeAsUpEnabled(true);
        customerMangment = new CustomerMangment(this);
//        loadJSONOrder();
        recyclerView=findViewById(R.id.listOrder);
        recyclerView.setHasFixedSize(true);
        recyclerView.setLayoutManager(new LinearLayoutManager(this));
    }
    private void loadJSONOrder() {
        HashMap<String,String> cus= customerMangment.myaccount();
        String mEmail = cus.get(customerMangment.EMAIL);
        Host host = new Host();
        String url = "http://"+host.getHost()+":8183/api/list_order?email=" +mEmail;
        RequestQueue queue = Volley.newRequestQueue(this);
        StringRequest stringRequest = new StringRequest(url, listener, errorListener);

        queue.add(stringRequest);
    }
}